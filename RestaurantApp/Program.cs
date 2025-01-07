
using RestaurantApp.Abstracts;
using RestaurantApp.Classes;
using RestaurantApp.Enums;

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

            AutumnMenu grandeMeal = new AutumnMenu();
            AutumnMenu happyMeal = new AutumnMenu();
            SpringMenu grandeMeal1 = new SpringMenu();
            SpringMenu happyMeal1 = new SpringMenu();
            grandeMeal = grandeMeal.GrandeMenu("Grzanki z pasta z suszonych pomidorów oraz serem", "Krem z dyni", "Gęsina Św. Marcina", "Tiramisu truflowe", "Kompot jerzynowy");
            grandeMeal1 = grandeMeal1.GrandeMenu("Sałatka z nowalijek", "Krem z młodych ziemniaków i chrzanu", "Młoda perliczka", "Sernik cytrynowy", "Mus z jarmużu");
            happyMeal = happyMeal.HappyMeal("Chrupiące bataty", "Krem z pora", "Placek po zbójnicku");
            happyMeal1 = happyMeal1.HappyMeal("Seler naciowy z sosem serowym", "Pikantny krem z pomidorów", "Skrzydełka buffalo");

           

            var menuRepo = new GenericRepository<Menu>();
            var menu1 = new Menu("Sałatka", "Pomidorowa", "Stek", "Sernik", "Herbata");
            var menu2 = new Menu("Grzanki z serem", "Minestrone", "Carbonara", "Tiramisu", "Wino Czerwone");
            var springMenuRepo = new GenericRepository<SpringMenu>();
            var autumnMenuRepo = new GenericRepository<AutumnMenu>();
            var springMenu = new SpringMenu("Sałatka owocowa", "Zupa marchewkowa", "Łosoś", "Sernik", "Lemoniada");
            var autumnMenu = new AutumnMenu("Chleb z masłem", "Rosół", "Schabowy", "Szarlotka", "Kompot");


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
                                        menuRepo.DisplayAllMenus(); grandeMeal.DisplayMenu(); grandeMeal1.DisplayMenu(); happyMeal.DisplayMenu(); happyMeal1.DisplayMenu(); autumnMenuRepo.DisplayAllMenus(); springMenuRepo.DisplayAllMenus(); 
                                        break;
                                    case 2:
                                        Console.WriteLine("Dodawanie menu...");
                                        menuRepo.Add(menu1); menuRepo.Add(menu2); springMenuRepo.Add(springMenu); autumnMenuRepo.Add(autumnMenu); 
                                        break;
                                    case 3:
                                        Console.WriteLine("Modyfikowanie menu...");
                                        menu1.Starter = "Bruschetta"; menuRepo.Update(menu1); springMenu.Soup = "Krem z dyni"; springMenuRepo.Update(springMenu); 
                                        menuRepo.Update(menu1);
                                        break;
                                    case 4:
                                        Console.WriteLine("Usuwanie menu...");
                                        menuRepo.Delete(menu2); autumnMenuRepo.Delete(autumnMenu);
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
                        case 2: message = "Pracownicy"; break;
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


