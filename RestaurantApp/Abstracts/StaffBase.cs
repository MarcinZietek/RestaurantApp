using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Classes;

namespace RestaurantApp.Abstracts
{
    public abstract class StaffBase
    {
        private Person person;
        private PositionEnum position;
        private decimal salary;
        private DepartmentEnum department;
        private Storehouse storehouse;
        public Guid StaffId { get; private set; }
        public StaffBase() { }
        public StaffBase(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse)
        {
            StaffId = Guid.NewGuid();
            Person = person;
            Position = position;
            Salary = salary;
            Department = department;
            Storehouse = storehouse;
        }
        public Person Person { get { return person; } set { person = value; } }
        public PositionEnum Position { get { return position; } set { position = value; } }
        public decimal Salary { get { return salary; } set { salary = value; } }
        public DepartmentEnum Department { get { return department; } set { department = value; } }
        public Storehouse Storehouse { get { return storehouse; } set { storehouse = value; } }
        public override string ToString()
        {
            return $"ID: {StaffId}\nStanowisko: {Position}\nPensja: {Salary}\nDepartament: {Department}\nDane personalne {Person}";
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {StaffId}\nStanowisko: {Position}\nDepartament: {Department}\nOdpowiedzialność: {Storehouse}");
        }

        public abstract decimal BonusSalary();

    }

    public enum PositionEnum
    {
        Chef, Sous_Chef, Pastry_Chef, Cook, Kitchen_Assistant, Kitchen_Porter, Dish_Washer, Manager, Junior_Manager, Waiter
    }

    public enum DepartmentEnum
    {
        Kitchen, Office, Dining_Room, Reception
    }


}
