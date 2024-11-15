using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;

namespace RestaurantApp.Classes
{
    public class SousChef : StaffBase
    {
        public SousChef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse)
           : base(person, salary, department, storehouse)
        {
            Position = PositionEnum.Sous_Chef;
        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
        public void PrepareMainDish()
        {
            Console.WriteLine($"Mistrz gotowania {Person} przygotowuje danie dnia. ");
        }
    }
}
