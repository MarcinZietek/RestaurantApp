using RestaurantApp.Abstracts;
using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
        public class SpringMenu : Menu, IMenu, IRepositoryCRUD<SpringMenu>
        {
        private double cost;
        public SpringMenu() { }
        public SpringMenu(string starter, string soup, string main) : base(starter, soup, main)
        {

        }
        public SpringMenu(string starter, string soup, string main, string pastry, string non_alcoholic_beverage) : base(starter, soup, main, pastry, non_alcoholic_beverage)
        {
          
        }

        public double Cost { get { return cost; } set { cost = value; } }

        public SpringMenu HappyMeal(string Starter, string Soup, string Main)
        {
            SpringMenu menu = new SpringMenu(Starter, Soup, Main);
            if (string.IsNullOrEmpty(Starter) || string.IsNullOrEmpty(Soup) || string.IsNullOrEmpty(Main))
            {
                throw new ArgumentNullException("Nie można utworzyć zestawu, brak któregoś ze dań.");
            }
            else
            {
                return menu;
            }
        }

        public SpringMenu GrandeMenu(string Starter, string Soup, string Main, string Pastry, string Non_alcoholic_beverage)
        {
            SpringMenu menu = new SpringMenu(Starter, Soup, Main, Pastry, Non_alcoholic_beverage);
            if (string.IsNullOrEmpty(Starter) || string.IsNullOrEmpty(Soup) || string.IsNullOrEmpty(Main) || string.IsNullOrEmpty(Pastry) || string.IsNullOrEmpty(Non_alcoholic_beverage))
            {
                throw new ArgumentNullException("Nie można utworzyć zestawu, brak któregoś ze dań.");
            }
            else
            {
                return menu;
            }
        }

        public override string ToString()
        {
            if (Starter != null && Soup != null && Main != null && Pastry != null && Non_alcoholic_beverage != null)
            {
                return $"Duży zestaw wiosenny: \nStarter: {Starter}\nZupa: {Soup}\nDanie główne: {Main}\nDeser: {Pastry}\nNapój: {Non_alcoholic_beverage}\n";
            }
            else if (Starter != null && Soup != null && Main != null && Pastry == null && Non_alcoholic_beverage == null)
            {
                return $"HappyMeal wiosenny: \nStarter: {Starter}\nZupa: {Soup}\ndanie główne: {Main}\n";
            }
            else return $"Menu w trakcie komponowania";

        }
        public void DisplayMenu()
        {
            base.DisplayInfo();
            Console.WriteLine($"{ToString()}");
        }

        public void Add(SpringMenu obj)
        {
            throw new NotImplementedException();
        }

        public void Update(SpringMenu obj)
        {
            throw new NotImplementedException();
        }

        public void Delete(SpringMenu obj)
        {
            throw new NotImplementedException();
        }
    }
}



