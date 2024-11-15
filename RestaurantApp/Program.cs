﻿
using RestaurantApp.Abstracts;
using RestaurantApp.Classes;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace RestaurantApp
{

    internal class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address("Polska", "Mazowieckie", "Warszawa", "Piękna", "01-460");
            Person person = new Person("Marcin", "Ziętek", DateTime.Parse("1983-01-25"), "M", address);
            Address address1 = new Address("Polska", "Mazowieckie", "Warszawa", "Prosta", "01-466");
            Person person1 = new Person("Agnieszka", "Urocza", DateTime.Parse("1985-10-05"), "F", address);
            Storehouse storehouse = new Storehouse(MeatEnum.Dziczyzna);
            Storehouse storehouse1 = new Storehouse(VegetableEnum.Cebula, FishEnum.Łosoś);
            Storehouse storehouse2 = new Storehouse(VegetableEnum.Ogórek, FishEnum.Szczupak);

            StaffBase staff = new StaffBase(person, PositionEnum.Chef, 3700, DepartmentEnum.Kitchen, storehouse);     
            StaffBase staff1 = new StaffBase(person1, PositionEnum.Sous_Chef, 3500, DepartmentEnum.Kitchen, storehouse2);
            StaffBase staff2 = new StaffBase(person, PositionEnum.Cook, 3300, DepartmentEnum.Kitchen, storehouse1);

            ListStaff(staff);
            ListStaff(staff1);
            ListStaff(staff2);


            //staffs.RemoveAll(x => x == null);
            //string jsonString = JsonSerializer.Serialize(staffs);
            //File.WriteAllText("Staff.json", jsonString);
            //var jsonfile = File.ReadAllText("Staff.json");
            //var deserializedJson = JsonSerializer.Deserialize<List<Staff>>(jsonfile);
            //foreach (Staff item in deserializedJson) {
            //    item.DisplayInfo();
            //}
        }
        public static List<StaffBase> ListStaff(StaffBase staff) 
        {
            List<StaffBase> staffs = new List<StaffBase>();
            staffs.Add(staff);
            try
            {
                
                foreach (StaffBase item in staffs)
                    {
                        
                        item.DisplayInfo();
                    }

            //staffs.Add(staff1);
            //staffs.Add(staff2);         

        }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return staffs;
        }
    }
}
