
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
            List<StaffBase> staffs = new List<StaffBase>();
            Storehouse storehouse = new Storehouse(MeatEnum.Dziczyzna);
            Storehouse storehouse1 = new Storehouse(VegetableEnum.Cebula, FishEnum.Łosoś);
            Storehouse storehouse2 = new Storehouse(VegetableEnum.Ogórek, FishEnum.Szczupak);
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Piękna", "01-460",
                "Marcin", "Ziętek", DateTime.Parse("1983-01-25"), "M",
                PositionEnum.Chef, 3700, DepartmentEnum.Kitchen, storehouse, 120));
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Prosta", "01-466",
                "Agnieszka", "Urocza", DateTime.Parse("1985-10-05"), "F",
                PositionEnum.Sous_Chef, 3500, DepartmentEnum.Kitchen, storehouse2, 145));
            staffs.Add(CreateStaff(
                "Polska", "Mazowieckie", "Warszawa", "Dzika", "03-366",
                "Marek", "Walczak", DateTime.Parse("1975-11-05"), "F",
                PositionEnum.Pastry_Chef, 3500, DepartmentEnum.Kitchen, storehouse1, 195));

            bool quit = false;

            //Wyświetlanie menu z możliwością ciągłego wyboru opcji. Użytkownik sam decyduje o zakończeniu programu
            Options();         
             

            while (!quit)
            {
                try
                {
                    Console.WriteLine("Wybierz opcję.");
                    int choice = int.Parse(Console.ReadLine());
                    string message = null;
                    switch (choice)
                    {
                        case 1: message = "Pokazuje wszystkich pracowników"; 

                         
                            break;
                        case 2: message = "Dodawanie pacowników"; break;
                        case 3: message = "Modyfikacja pracownika"; break;
                        case 4: message = "Usuwa pracownika"; break;
                        case 5: message = "Wyświetla wybranego pracownika"; break;
                        case 6: Options(); break;
                        case 7: message = "Koniec programu"; quit = true; break;
                        case 8: message = "Czyszczenie konsoli"; Console.Clear(); Options(); break;
                        case 9: message = "Zapisywanie danych do pliku - format JSON"; break;
                        default: message = "Brak wyboru"; break;
                    }
                    Console.WriteLine(message);
                }
                catch (FormatException fe)
                {
                    // Obsługa wyjątków, gdy nie wprowadzono wskazanego numeru w menu
                    Console.WriteLine($"Błąd rzutowania stringu na integer: {fe.Message}");
                }
            }
            //Wyświetlanie opcji 
            void Options()
            {
                Console.WriteLine("\n\t1 - Pokaż wszystkich pracowników");
                Console.WriteLine("\n\t2 - Dodaj pracownika");
                Console.WriteLine("\n\t3 - Zmodyfikuj pracownika");
                Console.WriteLine("\n\t4 - Usuń pracownika");
                Console.WriteLine("\n\t5 - Wyświetl wybranego pracownika");
                Console.WriteLine("\n\t6 - Wybor opcji");
                Console.WriteLine("\n\t7 - Zakoncz");
                Console.WriteLine("\n\t8 - Wyczyść konsolę");
                Console.WriteLine("\n\t9 - Zapisz do pliku - JSON\n");
            }

            //ManageCRUD<Person> manageCRUD = new ManageCRUD<Person>();
            //manageCRUD.Create(new Person { FirstName = "test1" });
            //manageCRUD.Create(new Person { FirstName = "test2" });
            //manageCRUD.Create(new Person { FirstName = "test3" });
            //manageCRUD.Create(new Person { FirstName = "test4" });
            
            
            //ManageCRUD<PastryChef> pastryCheef = new ManageCRUD<PastryChef>();
            //manageCRUD.Create(new Person { FirstName = "test1" });
            //manageCRUD.Create(new Person { FirstName = "test2" });
            //manageCRUD.Create(new Person { FirstName = "test3" });
            //manageCRUD.Create(new Person { FirstName = "test4" });

            //var lista2 = .GetAll();

        }


        public static StaffBase CreateStaff(
            string country, string state, string city, string street, string postalCode,
            string firstName, string lastName, DateTime birthDate, string gender,
            PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours)
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
                        staff = new Chef(person, position, 3300, department, storehouse, hours);
                        break;
                    case PositionEnum.Sous_Chef:
                        staff = new SousChef(person, position, 3300, department, storehouse, hours);
                        break;
                    case PositionEnum.Pastry_Chef:
                        staff = new PastryChef(person, position, 3300, department, storehouse, hours);
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

        
        
        //foreach (var staff in staffs)
        //{
        //    if (staffs != null)
        //    {
        //        staff.DisplayInfo();
        //        if (staff is Chef chef)
        //        {
        //            chef.CheckMenu();
        //            chef.TakenHours(150);
        //        }
        //        else if (staff is PastryChef pastry) 
        //        {
        //            pastry.PrepareDesert();
        //        } 
        //        else if (staff is SousChef sous)
        //        {
        //            sous.PrepareMainDish();
        //        }
        //    }
    }




    //staffs.RemoveAll(x => x == null);
    //string jsonString = JsonSerializer.Serialize(staffs);
    //File.WriteAllText("Staff.json", jsonString);
    //var jsonfile = File.ReadAllText("Staff.json");
    //var deserializedJson = JsonSerializer.Deserialize<List<Staff>>(jsonfile);
    //foreach (Staff item in deserializedJson) {
    //    item.DisplayInfo();
    //}
    //}

  

}


