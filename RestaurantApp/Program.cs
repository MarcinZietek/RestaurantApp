
using RestaurantApp.Abstracts;
using RestaurantApp.Classes;
using RestaurantApp.Enums;
using RestaurantApp.Helper;
using System;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;

namespace RestaurantApp
{

    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var fromNumberEmoji = new StringBuilder();
            var toNumberEmoji = new StringBuilder();
            
            int fromNumber = 8883;
            int toNumber = 8882;
            string emojiFromNumber = char.ConvertFromUtf32(fromNumber);
            string emojiToNumber = char.ConvertFromUtf32(toNumber);
            fromNumberEmoji.Append(emojiFromNumber);
            toNumberEmoji.Append(emojiToNumber);        
            var menuRepo = new GenericMenuRepository<Menu>();
            bool quit = false;
            
            //Wyświetlanie menu z możliwością ciągłego wyboru opcji. Użytkownik sam decyduje o zakończeniu programu
            Options();

            // Pętla wywołująca menu do momentu decyzji użytkownika o zakończniu programu
            while (!quit)
            {
                Console.Clear();
                try
                {
                    Console.ForegroundColor = ConsoleColor.DarkBlue;
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.WriteLine("|                                      Restaurant University Application                                             |");
                    Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                    Console.ResetColor();
                    Console.ForegroundColor= ConsoleColor.Blue;
                    Console.WriteLine("Wybierz opcję.");
                    Console.ResetColor();
                    Console.Write("Wybierz cyfrę");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 8 ");                  
                    Console.ResetColor();
                    Options();
                    int choice = int.Parse(Console.ReadLine());
                    string message = null;
                    switch (choice)
                    {                      
                        case 1: 
                            bool inSubMenu = true;
                            while (inSubMenu)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("|                                               Menu Options                                                         |");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                Console.ResetColor();
                                Console.WriteLine("\t1 - Wyświetl menu");
                                Console.WriteLine("\t2 - Dodaj menu");
                                Console.WriteLine("\t3 - Zmodyfikuj menu");
                                Console.WriteLine("\t4 - Usuń menu");
                                Console.WriteLine("\t0 - Powrót do menu głównego");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("\nWybierz opcję: ");
                                Console.ResetColor();
                                Console.Write("Wybierz cyfrę");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 4");
                                Console.ResetColor();

                                int subMenuChoice = int.Parse(Console.ReadLine());
                                switch (subMenuChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Wyświetlanie menu...");
                                     //   menuRepo.DisplayAllMenus(); autumnMenuRepo.DisplayAllMenus(); springMenuRepo.DisplayAllMenus(); //grandeMeal.DisplayMenu(); grandeMeal1.DisplayMenu(); happyMeal.DisplayMenu(); happyMeal1.DisplayMenu();  
                                        bool inListMenu = true;
                                        while (inListMenu)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine("|                                               List Menu                                                          |");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.ResetColor();
                                            Console.WriteLine("\t1 - Wyświetl wszystkie Menu");
                                            Console.WriteLine("\t2 - Wyświetl Menu Kart");
                                            Console.WriteLine("\t3 - Wyświetl Menu Wiosenne");
                                            Console.WriteLine("\t4 - Wyświetl Menu Letnie");
                                            Console.WriteLine("\t5 - Wyświetl Menu Jesienne");
                                            Console.WriteLine("\t6 - Wyświetl Menu Zimowe");
                                            Console.WriteLine("\t0 - Powrót do menu głównego");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write("\nWybierz opcję: ");
                                            Console.ResetColor();
                                            Console.Write("Wybierz cyfrę");
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 5");
                                            Console.ResetColor();

                                            int listMenuChoice = int.Parse(Console.ReadLine());
                                            switch (listMenuChoice)
                                            {
                                                case 1:
                                                    Console.WriteLine("Wyświetl wszystkie Menu");
                                                    menuRepo.DisplayAllMenus();
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Menu z Karty:");
                                                    var menus = menuRepo.FindMenusByName("Zwykłe");
                                                    menuRepo.DisplayAllMenus(menus);
                                                    break;
                                                case 3:
                                                    Console.WriteLine("Wiosenne Menu:");
                                                    var springMenus = menuRepo.FindMenusByName("Wiosenne");
                                                    menuRepo.DisplayAllMenus(springMenus);
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Wyświetl Menu Letnie");
                                                    var summerMenus = menuRepo.FindMenusByName("Letnie");
                                                    menuRepo.DisplayAllMenus(summerMenus);
                                                    break;
                                                case 5:
                                                    Console.WriteLine("Jesienne Menu:");
                                                    var autumnMenus = menuRepo.FindMenusByName("Jesienne");
                                                    menuRepo.DisplayAllMenus(autumnMenus);
                                                    break;
                                                case 6:
                                                    Console.WriteLine("Wyświetl Menu Zimowe");
                                                    var winterMenu = menuRepo.FindMenusByName("Zimowe");
                                                    menuRepo.DisplayAllMenus(winterMenu);
                                                    break;
                                                case 0:
                                                    inListMenu = false;
                                                    Console.WriteLine("Powrót do menu głównego...");
                                                    break;
                                                default:
                                                    Console.WriteLine("Niepoprawny wybór.");
                                                    break;
                                            }

                                            if (inListMenu)
                                            {
                                                Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować...");
                                                Console.ReadKey();
                                            }
                                        }
                                        break;
                                    case 2:
                                        Console.WriteLine("Dodawanie menu...");
                                          
                                        bool inAddMenu = true;
                                        while (inAddMenu)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine("|                                               Create Menu                                                          |");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.ResetColor();
                                            Console.WriteLine("\t1 - Dodaj Menu Karty");
                                            Console.WriteLine("\t2 - Dodaj Menu Wiosenne");
                                            Console.WriteLine("\t3 - Dodaj Menu Letnie");
                                            Console.WriteLine("\t4 - Dodaj Menu Jesienne");
                                            Console.WriteLine("\t5 - Dodaj Menu Zimowe");
                                            Console.WriteLine("\t9 - Wczytaj dane testowe");
                                            Console.WriteLine("\t0 - Powrót do menu głównego");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write("\nWybierz opcję: ");
                                            Console.ResetColor();
                                            Console.Write("Wybierz cyfrę");
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 5");
                                            Console.ResetColor();

                                            int addMenuChoice = int.Parse(Console.ReadLine());
                                            switch (addMenuChoice)
                                            {
                                                case 1: Console.WriteLine("Dodaj Menu Karty");                                                   
                                                    Menu newMenu = GeneralHelper.CreateMenuFromInput();
                                                    menuRepo.Add(newMenu);
                                                    Console.WriteLine("Nowe menu zostało dodane.");
                                                    break;
                                                case 2: Console.WriteLine("Dodaj Menu Wiosenne");                                                    
                                                    Menu newSpringMenu = GeneralHelper.CreateSpringMenuFromInput();
                                                    menuRepo.Add(newSpringMenu);
                                                    Console.WriteLine("Nowe wiosenne menu zostało dodane.");
                                                    break;
                                                case 3: Console.WriteLine("Dodaj Menu Letnie");
                                                    Console.WriteLine("Tworzenie menu letniego...");
                                                    break;
                                                case 4: Console.WriteLine("Dodaj Menu Jesienne");                                                   
                                                    Menu newAutumnMenu = GeneralHelper.CreateAutumnMenuFromInput();
                                                    menuRepo.Add(newAutumnMenu);
                                                    Console.WriteLine("Nowe jesienne menu zostało dodane.");
                                                    break;
                                                case 5: Console.WriteLine("Dodaj Menu Zimowe");
                                                    Console.WriteLine("Tworzenie menu zimowego...");
                                                    break;
                                                case 9: Console.WriteLine("Wczytaj dane testowe");
                                                    menuRepo.Add(menu1); menuRepo.Add(menu2); menuRepo.Add(menu3); menuRepo.Add(menu4);// menuRepo.Add(springMenu); menuRepo.Add(autumnMenu);
                                                    break;
                                                case 0:
                                                    inAddMenu = false;
                                                    Console.WriteLine("Powrót do menu głównego...");
                                                    break;
                                                default:
                                                    Console.WriteLine("Niepoprawny wybór.");
                                                    break;
                                            }

                                            if (inAddMenu)
                                            {
                                                Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować...");
                                                Console.ReadKey();
                                            }
                                        }
                                        break;
                                    case 3:
                                        Console.WriteLine("Modyfikowanie menu...");
                                        Console.WriteLine("Dostępne Menu - wybierz do modyfikacji.");
                                        menuRepo.DisplayAllId();
                                        string menuIdToEdit = GeneralHelper.GetUserInput("Podaj Id Menu do modyfikacji: ");
                                        Menu menuToUpdate = menuRepo.GetAll().FirstOrDefault(m => m.MenuId.ToString() == menuIdToEdit);

                                        if (menuToUpdate != null)
                                        {
                                            menuToUpdate.MenuName = GeneralHelper.GetUserInput("Nazwa Menu: ");
                                            menuToUpdate.Starter = GeneralHelper.GetUserInput("Nowa przystawka: ");
                                            menuToUpdate.Soup = GeneralHelper.GetUserInput("Nowa zupa: ");
                                            menuToUpdate.Main = GeneralHelper.GetUserInput("Nowe danie główne: ");
                                            menuToUpdate.Pastry = GeneralHelper.GetUserInput("Nowy deser: ");
                                            menuToUpdate.Non_alcoholic_beverage = GeneralHelper.GetUserInput("Nowy napój bezalkoholowy: ");
                                            menuRepo.Update(menuToUpdate);
                                            Console.WriteLine("Menu zostało zaktualizowane.");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Menu o podanym ID nie znaleziono.");
                                        }
                                                                               
                                        break;
                                    case 4:
                                        Console.WriteLine("Usuwanie menu...");
                                        menuRepo.Delete(menu2);// autumnMenuRepo.Delete(autumnMenu);
                                        break;
                                    case 0:
                                        inSubMenu = false;
                                        Console.WriteLine("Powrót do menu głównego...");
                                        break;
                                    default:
                                        Console.WriteLine("Niepoprawny wybór.");
                                        break;
                                }

                                if (inSubMenu)
                                {
                                    Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować...");
                                    Console.ReadKey();
                                }
                            }                     
                            break;
                        case 2:
                            bool inSubEmployee = true;
                            while (inSubEmployee)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                Console.WriteLine("|                                               Employee Options                                                     |");
                                Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                Console.ResetColor();
                                Console.WriteLine("\t1 - Wyświetlanie pracowników...");
                                Console.WriteLine("\t2 - Dodawanie pracowników...");
                                Console.WriteLine("\t3 - Modyfikowanie pracowników...");
                                Console.WriteLine("\t4 - Usuwanie pracowników...");
                                Console.WriteLine("\t5 - Zestawienia pracowników...");
                                Console.WriteLine("\t0 - Powrót do menu głównego");
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.Write("\nWybierz opcję: ");
                                Console.ResetColor();
                                Console.Write("Wybierz cyfrę");
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 4");
                                Console.ResetColor();

                                int subMenuChoice = int.Parse(Console.ReadLine());
                                switch (subMenuChoice)
                                {
                                    case 1:
                                        Console.WriteLine("Wyświetlanie pracowników...");
                                        
                                        break;
                                    case 2:
                                        Console.WriteLine("Dodawanie pracowników...");
                                        
                                        break;
                                    case 3:
                                        Console.WriteLine("Modyfikowanie pracowników...");
                                        
                                        break;
                                    case 4:
                                        Console.WriteLine("Usuwanie pracowników...");
                                    
                                        break;
                                    case 5:
                                        Console.WriteLine("Zestawienia pracowników...");
                                        bool inSubEmployeeList = true;
                                        while (inSubEmployeeList)
                                        {
                                            Console.Clear();
                                            Console.ForegroundColor = ConsoleColor.DarkBlue;
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.WriteLine("|                                               Employee Lists                                                       |");
                                            Console.WriteLine("----------------------------------------------------------------------------------------------------------------------");
                                            Console.ResetColor();
                                            Console.WriteLine("\t1 - Wyświetlanie pracowników w departamencie kuchni");
                                            Console.WriteLine("\t2 - Wyświetlanie pracowników w departamencie sali");
                                            Console.WriteLine("\t3 - Wyświetlanie pracowników w zależności od stanowiska");
                                            Console.WriteLine("\t4 - Wyświetl pracowników w zależności od płacy");
                                            Console.WriteLine("\t5 - Wyświetl pracowników w zależności od stażu");
                                            Console.WriteLine("\t0 - Powrót do menu głównego");
                                            Console.ForegroundColor = ConsoleColor.Blue;
                                            Console.Write("\nWybierz opcję: ");
                                            Console.ResetColor();
                                            Console.Write("Wybierz cyfrę");
                                            Console.ForegroundColor = ConsoleColor.Magenta;
                                            Console.WriteLine($" 1 {toNumberEmoji} {fromNumberEmoji} 4");
                                            Console.ResetColor();

                                            int subEmployeeChoice = int.Parse(Console.ReadLine());
                                            switch (subEmployeeChoice)
                                            {
                                                case 1:
                                                    Console.WriteLine("Wyświetlanie pracowników w departamencie kuchni");

                                                    break;
                                                case 2:
                                                    Console.WriteLine("Wyświetlanie pracowników w departamencie sali");

                                                    break;
                                                case 3:
                                                    Console.WriteLine("Wyświetlanie pracowników w zależności od stanowiska");

                                                    break;
                                                case 4:
                                                    Console.WriteLine("Wyświetl pracowników w zależności od płacy");

                                                    break;
                                                case 5:
                                                    Console.WriteLine("Wyświetl pracowników w zależności od stażu");

                                                    break;
                                                case 0:
                                                    inSubEmployeeList = false;
                                                    Console.WriteLine("Powrót do menu głównego...");
                                                    break;
                                                default:
                                                    Console.WriteLine("Niepoprawny wybór.");
                                                    break;
                                            }

                                            if (inSubEmployeeList)
                                            {
                                                Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować...");
                                                Console.ReadKey();
                                            }

                                        }
                                     
                                        break;
                                    case 0:
                                        inSubMenu = false;
                                        Console.WriteLine("Powrót do menu głównego...");
                                        break;
                                    default:
                                        Console.WriteLine("Niepoprawny wybór.");
                                        break;
                                }

                                if (inSubEmployee)
                                {
                                    Console.WriteLine("\nWciśnij dowolny klawisz, aby kontynuować...");
                                    Console.ReadKey();
                                }

                            }
                            break;
                        case 3: message = "Produkty"; break;
                        case 4: message = "Pliki";  break;
                        case 5: message = "Zestawienia"; break;
                        case 6: Options(); break;        
                        case 0: message = "Koniec programu"; quit = true; break;                     
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
                Console.WriteLine("\n\t1 - Menu");
                Console.WriteLine("\n\t2 - Pracownicy");
                Console.WriteLine("\n\t3 - Produkty");
                Console.WriteLine("\n\t4 - Zestawienia");
                Console.WriteLine("\n\t5 - Wyświetl wybranego pracownika");
                Console.WriteLine("\n\t0 - Koniec programu");                             
            }
           
        }

    }
}


