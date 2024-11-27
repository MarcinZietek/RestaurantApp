using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;
using RestaurantApp.Helper;
using RestaurantApp.Interfaces;

namespace RestaurantApp.Classes
{
    public class Chef : StaffBase, IListObject<Chef>
    {
        private readonly List<Chef> list = new List<Chef>();
        public Chef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours)
        : base(person, salary, department, storehouse, hours)
        {
           Position = PositionEnum.Chef;
        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
      
        public override double TakenHours(double Hours) 
        {
            return Hours - 160;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bonus pracownika: {BonusSalary():C}");
            Console.WriteLine($"Podatek do zapłacenia: {GeneralHelper.CalculateTax(Salary)} ");
            Console.WriteLine($"Brakujące godziny w miesiącu: {TakenHours(Hours)}");
        }
        public void CheckMenu()
        {
            Console.WriteLine($"Szef {Person} sprawdza menu... ");
        }

        List<Chef> IListObject<Chef>.GetAll()
        {
            return list;
        }
    }
}
