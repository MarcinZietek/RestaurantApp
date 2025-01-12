﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Abstracts;
using RestaurantApp.Enums;
using RestaurantApp.Helper;
using RestaurantApp.Interfaces;

namespace RestaurantApp.Classes
{
    public class PastryChef : StaffBase, IEmplyeeActions
    {
        private readonly TaskManager<CustomTask> _taskManager = new TaskManager<CustomTask>();
        public PastryChef(Person person, PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours) 
            :base (person, salary, department, storehouse, hours)
        {
            Position = PositionEnum.Pastry_Chef;
        }
        public override decimal BonusSalary()
        {
            return Salary * 0.2M;
        }
       
        public override double TakenHours(double hours)
        {
            return Hours - 180;
        }
        [Obsolete]
        public void PrepareDesert()
        {
            Console.WriteLine($"Mistrz cukiernictwa {Person.LastName} {Person.FirstName} przygotowuje deser dnia. \n");
        }
        public override void DisplayInfo()
        {
            base.DisplayInfo();
            //Console.WriteLine($"Bonus pracownika: {BonusSalary():C}");
            //Console.WriteLine($"Podatek do zapłacenia: {GeneralHelper.CalculateTax(Salary)} ");
            Console.WriteLine($"Brakujące godziny w miesiącu: {TakenHours(Hours)}");
        }

        public override string FullName()
        {
            { return $"{Person.FirstName} {Person.LastName}\n"; }
        }


        public void AssignTask(CustomTask task) => _taskManager.ScheduleTask(task);
        public void ComplitedTask() => _taskManager.CompleteTask();

        public void ReportTask() { Console.WriteLine(_taskManager.ReportTask()); }
        public void PerformDuties()
        {
            Console.WriteLine($"Mistrz cukiernictwa {Person.LastName} {Person.FirstName} rozdysponowuje zadania. \n");
            Console.WriteLine($"Mistrz cukiernictwa {Person.LastName} {Person.FirstName} przygotowuje deser dnia. \n");
        }

        public void ReportWork()
        {
            Console.WriteLine($"Mistrz cukiernictwa {Person.LastName} {Person.FirstName} raportuje swój zespół Szefowi kuchni. \n");
        }

    }
}
