
using RestaurantApp.Classes;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace RestaurantApp
{
   
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Staff> staffs = new List<Staff>();
           
           
            Address address = new Address("Polska", "Mazowieckie", "Warszawa", "Piękna", "01-460");
            Person person = new Person("Marcin", "Ziętek", DateTime.Parse("1983-01-25"), "M", address);
            Storehouse storehouse = new Storehouse(MeatEnum.Dziczyzna);
            Storehouse storehouse1 = new Storehouse(VegetableEnum.Cebula, FishEnum.Łosoś);
            Storehouse storehouse2 = new Storehouse(VegetableEnum.Ogórek, FishEnum.Szczupak);
            Staff staff = new Staff(person, PositionEnum.Chef, 3700, DepartmentEnum.Kitchen, storehouse);

            Address address1 = new Address("Polska", "Mazowieckie", "Warszawa", "Prosta", "01-466");
            Person person1 = new Person("Agnieszka", "Urocza", DateTime.Parse("1985-10-05"), "F", address);
            Staff staff1 = new Staff(person1, PositionEnum.Sous_Chef, 3500, DepartmentEnum.Kitchen, storehouse2);
            Staff staff2 = new Staff(person, PositionEnum.Cook, 3300, DepartmentEnum.Kitchen, storehouse1);


            staffs.Add(staff);
            staffs.Add(staff1);
            staffs.Add(staff2);

            staffs.RemoveAll(x => x == null);
            string jsonString = JsonSerializer.Serialize(staffs);
            File.WriteAllText("Staff.json", jsonString);
            var jsonfile = File.ReadAllText("Staff.json");
            var deserializedJson = JsonSerializer.Deserialize<List<Staff>>(jsonfile);
            foreach (Staff item in deserializedJson) {
                item.DisplayInfo();
            }

            foreach (Staff item in staffs)
            {
                item.DisplayInfo();
               
            }

            foreach (Staff item in staffs)
            {
                Console.WriteLine(item);

            }




        }
       
    }
}
