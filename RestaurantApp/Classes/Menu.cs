using RestaurantApp.Abstracts;
using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Menu : MenuBase, IMenu
    {
        
        private string non_alcoholic_beverage;
        private string alcoholic_beverage;
        private string starter;
        private string soup;
        private string salad;
        private string main;
        private string pastry;

        public Menu() :base() { }

        public Menu(string menuName, string starter, string soup, string main) : base(menuName)
        {         
            Starter = starter;
            Soup = soup;
            Main = main;
        }

        public Menu(string menuName, string starter, string soup, string main, string pastry, string non_alcoholic_beverage) : base(menuName)
        {
            Starter = starter;
            Soup = soup;
            Main = main;
            Pastry = pastry;
            Non_alcoholic_beverage = non_alcoholic_beverage;
        }

        public Menu(string non_alcoholic_beverage, string alcoholic_beverage, string starter, string soup, string salad, string main, string pastry)
        {
            Non_alcoholic_beverage = non_alcoholic_beverage;
            Alcoholic_beverage = alcoholic_beverage;
            Starter = starter;
            Soup = soup;
            Salad = salad;
            Main = main;
            Pastry = pastry;
            
        }

       
        public string Non_alcoholic_beverage { get { return non_alcoholic_beverage; } set { non_alcoholic_beverage = value; } }
        public string Alcoholic_beverage { get { return alcoholic_beverage; } set { alcoholic_beverage = value; } }
        public string Starter { get { return starter; } set { starter = value; } }
        public string Soup { get { return soup; } set { soup = value; } }
        public string Salad { get { return salad; } set { salad = value; } }
        public string Main { get { return main; } set { main = value; } }
        public string Pastry { get { return pastry; } set { pastry = value; } }    

        public override string ToString()
        {
            return $"Id: {MenuId}, Nazwa Menu: {MenuName}, Przystawka: {Starter}, Zupa: {Soup}, Danie główne: {Main}, Deser: {Pastry}, " +
                   $"Napój bezalkoholowy: {Non_alcoholic_beverage}, Napój alkoholowy: {Alcoholic_beverage}\n";
        }

        public void DisplayMenu()
        {
            Console.WriteLine($"{ToString()}");
        }

        public void DisplayIdMenu()
        {
            base.DisplayInfo();
        }
      
    }
}
