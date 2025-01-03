using RestaurantApp.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Menu : MenuBase
    {
        private string non_alcoholic_beverage;
        private string alcoholic_beverage;
        private string starter;
        private string soup;
        private string salad;
        private string main;
        private string pastry;

        public Menu() { }

        public Menu(string starter, string soup, string main)
        {
            this.starter = starter;
            this.soup = soup;
            this.main = main;
        }

        public Menu(string starter, string soup, string main, string pastry, string non_alcoholic_beverage) : this(starter, soup, main)
        {
        }

        public Menu(string non_alcoholic_beverage, string alcoholic_beverage, string starter, string soup, string salad, string main, string pastry)
        {
            this.non_alcoholic_beverage = non_alcoholic_beverage;
            this.alcoholic_beverage = alcoholic_beverage;
            this.starter = starter;
            this.soup = soup;
            this.salad = salad;
            this.main = main;
            this.pastry = pastry;
            
        }


        public string Non_alcoholic_beverage { get { return non_alcoholic_beverage; } set { non_alcoholic_beverage = value; } }
        public string Alcoholic_beverage { get { return alcoholic_beverage; } set { alcoholic_beverage = value; } }
        public string Starter { get { return starter; } set { starter = value; } }
        public string Soup { get { return soup; } set { soup = value; } }
        public string Salad { get { return salad; } set { salad = value; } }
        public string Main { get { return main; } set { main = value; } }
        public string Pastry { get { return pastry; } set { pastry = value; } }
        public void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"{ToString()}");
        }
    }
}
