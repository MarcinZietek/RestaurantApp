using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;
using RestaurantApp.Enums;
using RestaurantApp.Helper;
using RestaurantApp.Interfaces;

namespace RestaurantApp.Classes
{
    public class Chef : StaffBase, IEmplyeeActions
    {
        private readonly TaskManager<string> _taskManager = new TaskManager<string>();
        public Chef() { }
        public Chef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours)
        : base(person, salary, department, storehouse, hours)
        {
            Position = PositionEnum.Chef;
            Salary = salary;
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
            //Console.WriteLine($"Bonus pracownika: {BonusSalary():C}");
            //Console.WriteLine($"Podatek do zapłacenia: {GeneralHelper.CalculateTax(Salary)} ");
            Console.WriteLine($"Brakujące godziny w miesiącu: {TakenHours(Hours)}");
        }
        [Obsolete]
        public void ChefDuties()
        {
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} sprawdza menu... \n");
            ReportTask();
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} sprawdza jakość produktów... \n");
            ReportTask();
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} prezentuje danie dnia... \n");
        }

        public override string FullName()
        {
            { return $"{Person.FirstName} {Person.LastName}\n"; }
        }
        public void AssignTask(string task) => _taskManager.ScheduleTask(task);
        public void ComplitedTask() =>_taskManager.CompleteTask();

        public void ReportTask() { Console.WriteLine( _taskManager.ReportTask()); }

        public void PerformDuties()
        {
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} sprawdza menu... \n");
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} sprawdza jakość produktów... \n");
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} prezentuje danie dnia... \n");
        }

        public void ReportWork()
        {
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} przyjmuje raport zespołu kucharskiego... \n");
            Console.WriteLine($"Szef {Person.LastName} {Person.FirstName} przyjmuje raport zespołu cukierniczego... \n");
        }
    }   

}
