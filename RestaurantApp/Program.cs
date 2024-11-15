
using RestaurantApp.Abstracts;
using RestaurantApp.Classes;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;

namespace RestaurantApp
{

    internal class Program
    {


        static void Main(string[] args)
        {

            //ListStaff(staff);
            List<StaffBase> staffs = new List<StaffBase>();
            Storehouse storehouse = new Storehouse(MeatEnum.Dziczyzna);
            Storehouse storehouse1 = new Storehouse(VegetableEnum.Cebula, FishEnum.Łosoś);
            Storehouse storehouse2 = new Storehouse(VegetableEnum.Ogórek, FishEnum.Szczupak);
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Piękna", "01-460",
                "Marcin", "Ziętek", DateTime.Parse("1983-01-25"), "M",
                PositionEnum.Chef, 3700, DepartmentEnum.Kitchen, storehouse));
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Prosta", "01-466",
                "Agnieszka", "Urocza", DateTime.Parse("1985-10-05"), "F",
                PositionEnum.Sous_Chef, 3500, DepartmentEnum.Kitchen, storehouse2));
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Dzika", "03-366",
                "Marek", "Walczak", DateTime.Parse("1975-11-05"), "F",
                PositionEnum.Pastry_Chef, 3500, DepartmentEnum.Kitchen, storehouse1));

            foreach (var staff in staffs)
            {
                if (staffs != null)
                {
                    staff.DisplayInfo();
                }
            }


            //staffs.RemoveAll(x => x == null);
            //string jsonString = JsonSerializer.Serialize(staffs);
            //File.WriteAllText("Staff.json", jsonString);
            //var jsonfile = File.ReadAllText("Staff.json");
            //var deserializedJson = JsonSerializer.Deserialize<List<Staff>>(jsonfile);
            //foreach (Staff item in deserializedJson) {
            //    item.DisplayInfo();
            //}
        }
        // Metoda umożliwiająca dodanie obiektu do listy
        public static List<StaffBase> ListStaff(StaffBase staff)
        {
            List<StaffBase> staffs = new List<StaffBase>();
           
            //staffs.Add(staff);
            try
            {

                foreach (var item in staffs)
                {

                    item.DisplayInfo();
                }      

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return staffs;
        }
        public static StaffBase CreateStaff(
            string country, string state, string city, string street, string postalCode,
            string firstName, string lastName, DateTime birthDate, string gender,
            PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse)
        {
            try
            {
                // Tworzenie obiektu Address (kompozycja obiektu w obiekcie Staff)
                Address address = new Address(country, state, city, street, postalCode);

                // Tworzenie obiektu Person (składa się z adresu oraz danych osobowych)
                Person person = new Person(firstName, lastName, birthDate, gender, address);

                // Tworzenie obiektu Staff (kompozycja z obiektem Person)
                StaffBase staff; 

                switch (position)
                {
                    case PositionEnum.Chef :
                        staff = new Chef(person, position, 3300, department, storehouse);
                        break;
                    case PositionEnum.Sous_Chef:
                        staff = new SousChef(person, position, 3300, department, storehouse);
                        break;
                    case PositionEnum.Pastry_Chef:
                        staff = new PastryChef(person, position, 3300, department, storehouse);
                        break;
                    default:
                        throw new ArgumentException("Nie wybrano pozycji na jakiej jest zatrudniony pracownik");
                        break;
                }
                return staff; // Zwracanie poprawnie utworzonego pracownika
            }
            catch (ArgumentException ex)
            {
                // Obsługa wyjątków, gdy wprowadzono niepoprawne dane, np. PESEL, wynagrodzenie itp.
                Console.WriteLine($"Błąd przy tworzeniu pracownika {firstName} {lastName}: {ex.Message}");
                return null; // Zwracamy null, jeśli nastąpił błąd
            }
        }

    }
}
