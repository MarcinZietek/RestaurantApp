using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;

namespace RestaurantApp.Classes
{
    public class Chef : StaffBase
    {
        public Chef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse)
        : base(person, position, salary, department, storehouse)
        {
           
        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Bonus praconika: {BonusSalary():C}");
        }
        public void CheckMenu()
        {
            Console.WriteLine($"Szef {Person} sprawdza menu... ");
        }

    }
}
