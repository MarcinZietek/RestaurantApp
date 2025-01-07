
//using RestaurantApp.Abstracts;
//using RestaurantApp.Classes;
//using RestaurantApp.Enums;

//using System;
//using System.Reflection;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Text.Json;

//namespace RestaurantApp
//{

//    internal class Program
//    {

//        static void Main(string[] args)
//        {
//            Console.OutputEncoding = System.Text.Encoding.UTF8;
//            var fromNumberEmoji = new StringBuilder();
//            var toNumberEmoji = new StringBuilder();

//            int fromNumber = 8883;
//            int toNumber = 8882;
//            string emojiFromNumber = char.ConvertFromUtf32(fromNumber);
//            string emojiToNumber = char.ConvertFromUtf32(toNumber);
//            fromNumberEmoji.Append(emojiFromNumber);
//            toNumberEmoji.Append(emojiToNumber);

//            AutumnMenu grandeMeal = new AutumnMenu();
//            AutumnMenu happyMeal = new AutumnMenu();
//            SpringMenu grandeMeal1 = new SpringMenu();
//            SpringMenu happyMeal1 = new SpringMenu();
//            grandeMeal = grandeMeal.GrandeMenu("Grzanki z pasta z suszonych pomidorów oraz serem", "Krem z dyni", "Gęsina Św. Marcina", "Tiramisu truflowe", "Kompot jerzynowy");
//            grandeMeal1 = grandeMeal1.GrandeMenu("Sałatka z nowalijek", "Krem z młodych ziemniaków i chrzanu", "Młoda perliczka", "Sernik cytrynowy", "Mus z jarmużu");
//            happyMeal = happyMeal.HappyMeal("Chrupiące bataty", "Krem z pora", "Placek po zbójnicku");
//            happyMeal1 = happyMeal1.HappyMeal("Seler naciowy z sosem serowym", "Pikantny krem z pomidorów", "Skrzydełka buffalo");

//            List<StaffBase> staffs = new List<StaffBase>();
//            Storehouse storehouse = new Storehouse(MeatEnum.Dziczyzna);
//            Storehouse storehouse1 = new Storehouse(VegetableEnum.Cebula, FishEnum.Łosoś);
//            Storehouse storehouse2 = new Storehouse(VegetableEnum.Ogórek, FishEnum.Szczupak);
//            staffs.Add(CreateStaff(
//                "Polska", "Mazowieckie", "Warszawa", "Piękna", "01-460",
//                "Marcin", "Ziętek", DateTime.Parse("1983-01-25"), "M",
//                PositionEnum.Chef, 3700, DepartmentEnum.Kitchen, storehouse, 120));
//            staffs.Add(CreateStaff(
//                "Polska", "Mazowieckie", "Warszawa", "Prosta", "01-466",
//                "Agnieszka", "Urocza", DateTime.Parse("1985-10-05"), "F",
//                PositionEnum.Sous_Chef, 3500, DepartmentEnum.Kitchen, storehouse2, 145));
//            staffs.Add(CreateStaff(
//                "Polska", "Mazowieckie", "Warszawa", "Dzika", "03-366",
//                "Marek", "Walczak", DateTime.Parse("1975-11-05"), "M",
//                PositionEnum.Pastry_Chef, 3500, DepartmentEnum.Kitchen, storehouse1, 195));

//            var menuRepo = new GenericRepository<Menu>();
//            var menu1 = new Menu("Sałatka", "Pomidorowa", "Stek", "Sernik", "Herbata");
//            var menu2 = new Menu("Grzanki z serem", "Minestrone", "Carbonara", "Tiramisu", "Wino Czerwone");
//            var springMenuRepo = new GenericRepository<SpringMenu>();
//            var autumnMenuRepo = new GenericRepository<AutumnMenu>();
//            var springMenu = new SpringMenu("Sałatka owocowa", "Zupa marchewkowa", "Łosoś", "Sernik", "Lemoniada");
//            var autumnMenu = new AutumnMenu("Chleb z masłem", "Rosół", "Schabowy", "Szarlotka", "Kompot");


//            bool quit = false;

//            //Wyświetlanie menu z możliwością ciągłego wyboru opcji. Użytkownik sam decyduje o zakończeniu programu
//            Options();

//            // Pętla wywołująca menu do momentu decyzji użytkownika o zakończniu programu
//            while (!quit)
//            {
//                try
//                {
//                    Console.ForegroundColor = ConsoleColor.DarkBlue;
//                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
//                    Console.WriteLine("|                                      Restaurant University Application                                             |");
//                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
//                    Console.ResetColor();
//                    Console.ForegroundColor = ConsoleColor.Blue;
//                    Console.WriteLine("Wybierz opcję.");
//                    Console.ResetColor();
//                    Console.Write("Wybierz cyfrę");
//                    Console.ForegroundColor = ConsoleColor.Magenta;
//                    Console.Write($" od {toNumberEmoji} {fromNumberEmoji} i \u001b[32mwciśnij ENTER\u001b[0m");
//                    Console.ResetColor();
//                    Console.WriteLine(" \u001b[32mLub wybierz liczbę\u001b[0m");
//                    int choice = int.Parse(Console.ReadLine());
//                    string message = null;
//                    switch (choice)
//                    {
//                        case 1: message = "Menu"; menuRepo.DisplayAllMenus(); grandeMeal.DisplayMenu(); grandeMeal1.DisplayMenu(); happyMeal.DisplayMenu(); happyMeal1.DisplayMenu(); autumnMenuRepo.DisplayAllMenus(); springMenuRepo.DisplayAllMenus(); break;
//                        case 2: message = "Dodawanie menu"; menuRepo.Add(menu1); menuRepo.Add(menu2); springMenuRepo.Add(springMenu); autumnMenuRepo.Add(autumnMenu); break;
//                        case 3: message = "Modyfikacja menu"; menu1.Starter = "Bruschetta"; menuRepo.Update(menu1); springMenu.Soup = "Krem z dyni"; springMenuRepo.Update(springMenu); break;
//                        case 4: message = "Usuwa menu"; menuRepo.Delete(menu2); autumnMenuRepo.Delete(autumnMenu); break;
//                        case 5: message = "Wyświetla pracowników z pensją powyżej 3500"; break;
//                        case 6: Options(); break;
//                        case 7: message = "Czyszczenie konsoli"; Console.Clear(); Options(); break;
//                        case 8: message = "Koniec programu"; quit = true; break;
//                        case 9: message = "Zapisywanie danych do pliku - format JSON"; break;
//                        case 10: message = "Wyświetla wszystkie stanowiska: "; foreach (var staff in staffs) { staff.DisplayInfo(); }; break;
//                        case 11: message = "Obowiązki pracowników: "; ShowEmployee(staffs); break;
//                        case 12: message = "Wyświetla zadania pracowników: "; ShowTask(staffs); break;
//                        default: message = "Brak wyboru"; break;
//                    }
//                    Console.WriteLine(message);
//                }
//                catch (FormatException fe)
//                {
//                    // Obsługa wyjątków, gdy nie wprowadzono wskazanego numeru w menu
//                    Console.WriteLine($"Błąd rzutowania stringu na integer: {fe.Message}");
//                }
//            }
//            //Wyświetlanie opcji 
//            void Options()
//            {
//                Console.WriteLine("\n\t1 - Menu");
//                Console.WriteLine("\n\t2 - Dodaj menu");
//                Console.WriteLine("\n\t3 - Zmodyfikuj menu");
//                Console.WriteLine("\n\t4 - Usuń menu");
//                Console.WriteLine("\n\t5 - Wyświetl wybranego pracownika");
//                Console.WriteLine("\n\t6 - Wybor opcji");
//                Console.WriteLine("\n\t7 - Zakoncz");
//                Console.WriteLine("\n\t8 - Wyczyść konsolę");
//                Console.WriteLine("\n\t9 - Zapisz do pliku - JSON");
//                Console.WriteLine("\n\t10 - Wyświetl wszystkie stanowiska");
//                Console.WriteLine("\n\t11 - Wyświetl obowiązki pracowników");
//                Console.WriteLine("\n\t12 - Wyświetl zadania zlecone pracownikom\n");

//            }



//        }

//        public static StaffBase CreateStaff(
//            string country, string state, string city, string street, string postalCode,
//            string firstName, string lastName, DateTime birthDate, string gender,
//            PositionEnum position, decimal salary, DepartmentEnum department, Storehouse storehouse, double hours)
//        {
//            try
//            {
//                // Tworzenie obiektu Address (kompozycja obiektu w obiekcie Staff)
//                Address address = new Address(country, state, city, street, postalCode);

//                // Tworzenie obiektu Person (składa się z adresu oraz danych osobowych)
//                Person person = new Person(firstName, lastName, birthDate, gender, address);



//                // Tworzenie obiektu Staff (kompozycja z obiektem Person)
//                StaffBase staff;

//                switch (position)
//                {
//                    case PositionEnum.Chef:
//                        staff = new Chef(person, position, 4000, department, storehouse, hours);
//                        break;
//                    case PositionEnum.Sous_Chef:
//                        staff = new SousChef(person, position, 3600, department, storehouse, hours);
//                        break;
//                    case PositionEnum.Pastry_Chef:
//                        staff = new PastryChef(person, position, 3600, department, storehouse, hours);
//                        break;
//                    default:
//                        throw new ArgumentException("Nie wybrano pozycji na jakiej jest zatrudniony pracownik");
//                        break;
//                }
//                return staff; // Zwracanie poprawnie utworzonego pracownika
//            }
//            catch (ArgumentException ex)
//            {
//                // Obsługa wyjątków, gdy wprowadzono niepoprawne dane, np. PESEL, wynagrodzenie itp.
//                Console.WriteLine($"Błąd przy tworzeniu pracownika {firstName} {lastName}: {ex.Message}");
//                return null; // Zwracamy null, jeśli nastąpił błąd
//            }
//        }

//        //Metoda wyświetlająca obowiązki pracowników.
//        public static List<StaffBase> ShowEmployee(List<StaffBase> staffs)
//        {
//            foreach (var employee in staffs)
//            {
//                if (employee != null)
//                {
//                    employee.FullName();
//                    if (employee is Chef chef) { chef.PerformDuties(); chef.ReportWork(); }
//                    else if (employee is SousChef sousChef) { sousChef.PerformDuties(); sousChef.ReportWork(); }
//                    else if (employee is PastryChef pastryChef) { pastryChef.PerformDuties(); pastryChef.ReportWork(); }
//                    else { Console.WriteLine("Nie ma pracownika"); }
//                }
//            }
//            return staffs; //Zwracanie listy pracowników
//        }

//        public static List<StaffBase> ShowTask(List<StaffBase> tasks)
//        {
//            foreach (var task in tasks)
//            {
//                if (task != null)
//                {
//                    if (task is Chef chef)
//                    {
//                        chef.AssignTask($"Szef kuchni prezentuje danie dnia... \n");
//                        chef.AssignTask($"Szef kuchni sprawdza jakość produktów... \n");
//                        chef.AssignTask($"Szef kuchni sprawdza menu... \n");
//                        chef.ReportTask();
//                        chef.ComplitedTask();
//                        chef.ReportTask();
//                    }
//                    else if (task is SousChef sousChef)
//                    {
//                        sousChef.AssignTask(new CustomTask { Title = "Mistrz kuchni sprawdza daty przydatności produktów", Deadline = DateTime.Now.AddDays(1) });
//                    }
//                    else if (task is PastryChef pastryChef)
//                    {
//                        pastryChef.AssignTask(new CustomTask { Title = "Mistrz cukiernictwa przygotowuje torty", Deadline = DateTime.Now.AddDays(2) });
//                    }
//                }
//            }
//            return tasks;
//        }




//        //staffs.RemoveAll(x => x == null);
//        //string jsonString = JsonSerializer.Serialize(staffs);
//        //File.WriteAllText("Staff.json", jsonString);
//        //var jsonfile = File.ReadAllText("Staff.json");
//        //var deserializedJson = JsonSerializer.Deserialize<List<Staff>>(jsonfile);
//        //foreach (Staff item in deserializedJson) {
//        //    item.DisplayInfo();
//        //}
//        //}


//    }
//}


