using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class Staff
    {
        private Person person;
        private PositionEnum position;
        private decimal salary;
        private DepartmentEnum department;
        private Storehouse storehouse;
        public Guid StaffId { get; private set; }
        public Staff() { }
        public Staff(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse)
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

        public void DisplayInfo()
        {
           Console.WriteLine($"ID: {StaffId}\nStanowisko: {Position}\nDepartament: {Department}\nOdpowiedzialność: {Storehouse}");
        }

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
