using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Classes;
using RestaurantApp.Enums;
using RestaurantApp.Interfaces;

namespace RestaurantApp.Abstracts
{
    public abstract class StaffBase 
    {
        

        private Person person;
        private PositionEnum position;
        private decimal salary;
        private DepartmentEnum department;
        private Storehouse storehouse;
        private double hours;
        public Guid StaffId { get; private set; }
        public StaffBase() { }
        public StaffBase(Person person, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours, PositionEnum position = PositionEnum.General)
        {
            StaffId = Guid.NewGuid();
            Person = person;
            Position = position;
            Salary = salary;
            Department = department;
            Storehouse = storehouse;
            Hours = hours;
        }
        public Person Person { get { return person; } set { person = value; } }
        public PositionEnum Position { get { return position; } set { position = value; } }
        public decimal Salary { get { return salary; } set { salary = value; } }
        public DepartmentEnum Department { get { return department; } set { department = value; } }
        public Storehouse Storehouse { get { return storehouse; } set { storehouse = value; } }
        public double Hours { get { return hours; } set { hours = value; } } 
        public string FullName
        {
            get { return $"{Person.FirstName} {Person.LastName}"; } // Zwraca imię i nazwisko osoby
        }
        //public override string ToString()
        //{
        //    return $"ID: {StaffId}\nStanowisko: {Position}\nPensja: {Salary}\nDepartament: {Department}\nDane personalne {Person}";
        //}

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"ID: {StaffId}\nStanowisko: {Position}\nDepartament: {Department}\nOdpowiedzialność: {Storehouse}");
        }

        

        public abstract decimal BonusSalary();
        public abstract double TakenHours(double hours); //Metoda obliczająca bilans godzin pracy w miesiącu

       
    }   


}
