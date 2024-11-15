using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;

namespace RestaurantApp.Classes
{
    public class PastryChef : StaffBase { 
        public PastryChef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse) 
            :base (person, position, salary, department, storehouse)
        {

        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
        public void PrepareDesert()
        {
            Console.WriteLine($"Mistrz cukiernictwa {Person} przygotowuje deser dnia. ");
        }

    }
}
