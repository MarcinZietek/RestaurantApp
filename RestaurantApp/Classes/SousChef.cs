using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;
using RestaurantApp.Helper;

namespace RestaurantApp.Classes
{
    public class SousChef : StaffBase
    {
        public SousChef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours)
           : base(person, salary, department, storehouse, hours)
        {
            Position = PositionEnum.Sous_Chef;
        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
       
        public override double TakenHours(double Hours)
        {
            return Hours - 180;
        }
        public void PrepareMainDish()
        {
            Console.WriteLine($"Mistrz gotowania {Person} przygotowuje danie dnia. ");
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bonus pracownika: {BonusSalary():C}");
            Console.WriteLine($"Podatek do zapłacenia: {GeneralHelper.CalculateTax(Salary)} ");
            Console.WriteLine($"Brakujące godziny w miesiącu: {TakenHours(Hours)}");
        }
    }
}
