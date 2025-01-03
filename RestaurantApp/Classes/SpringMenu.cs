using RestaurantApp.Abstracts;
using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
        public class SpringMenu : MenuBase, IMenu
        {
            private string non_alcoholic_beverage;
            private string alcoholic_beverage;
            private string starter;
            private string soup;
            private string salad;
            private string main;
            private string pastry;
            private double cost;

            public SpringMenu() { }
            public SpringMenu(string starter, string soup, string main)
            {
                Starter = starter;
                Soup = soup;
                Main = main;
            }
            public SpringMenu(string starter, string soup, string main, string pastry, string non_alcoholic_beverage)
            {
                Starter = starter;
                Soup = soup;
                Main = main;
                Pastry = pastry;
                Non_alcoholic_beverage = non_alcoholic_beverage;
            }
            public SpringMenu(string non_alcoholic_beverage, string alcoholic_beverage, string starter, string soup, string salad, string main, string pastry, double cost)
            {
                Non_alcoholic_beverage = non_alcoholic_beverage;
                Alcoholic_beverage = alcoholic_beverage;
                Starter = starter;
                Soup = soup;
                Salad = salad;
                Main = main;
                Pastry = pastry;
                Cost = cost;
            }
            public string Non_alcoholic_beverage { get { return non_alcoholic_beverage; } set { non_alcoholic_beverage = value; } }
            public string Alcoholic_beverage { get { return alcoholic_beverage; } set { alcoholic_beverage = value; } }
            public string Starter { get { return starter; } set { starter = value; } }
            public string Soup { get { return soup; } set { soup = value; } }
            public string Salad { get { return salad; } set { salad = value; } }
            public string Main { get { return main; } set { main = value; } }
            public string Pastry { get { return pastry; } set { pastry = value; } }
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
        public void Menu()
        {
            base.DisplayInfo();
            Console.WriteLine($"{ToString()}");
        }

    }
}



