using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helper
{
    public static class GeneralHelper
    {
        public static decimal CalculateTax(decimal salary, decimal taxRate = 0.2M)
        {
            return salary * taxRate;
        }

        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        public static bool IsValidInput(string input)
        {
            return !string.IsNullOrEmpty(input);
        }

        public static Menu CreateMenuFromInput()
        {
            string starter = GetUserInput("Podaj przystawkę: ");
            string soup = GetUserInput("Podaj zupę: ");
            string main = GetUserInput("Podaj danie główne: ");
            string pastry = GetUserInput("Podaj deser: ");
            string nonAlcoholicBeverage = GetUserInput("Podaj napój bezalkoholowy: ");

            return new Menu(starter, soup, main, pastry, nonAlcoholicBeverage);
        }

        public static SpringMenu CreateSpringMenuFromInput()
        {
            string starter = GetUserInput("Podaj przystawkę: ");
            string soup = GetUserInput("Podaj zupę: ");
            string main = GetUserInput("Podaj danie główne: ");
            string pastry = GetUserInput("Podaj deser: ");
            string nonAlcoholicBeverage = GetUserInput("Podaj napój bezalkoholowy: ");
            return new SpringMenu(starter, soup, main, pastry, nonAlcoholicBeverage);
        }

        public static AutumnMenu CreateAutumnMenuFromInput()
        {
            string starter = GetUserInput("Podaj przystawkę: ");
            string soup = GetUserInput("Podaj zupę: ");
            string main = GetUserInput("Podaj danie główne: ");
            string pastry = GetUserInput("Podaj deser: ");
            string nonAlcoholicBeverage = GetUserInput("Podaj napój bezalkoholowy: ");
            return new AutumnMenu(starter, soup, main, pastry, nonAlcoholicBeverage);
        }


    }
}
