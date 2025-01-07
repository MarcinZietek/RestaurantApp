
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
                    Console.Write($" od {toNumberEmoji} {fromNumberEmoji} i \u001b[32mwciśnij ENTER\u001b[0m");                  
                    Console.ResetColor();
                    Console.WriteLine(" \u001b[32mLub wybierz liczbę\u001b[0m");
                    int choice = int.Parse(Console.ReadLine());
                    string message = null;
                    switch (choice)
                    {
                        case 1: message = "Menu"; menuRepo.DisplayAllMenus(); grandeMeal.DisplayMenu(); grandeMeal1.DisplayMenu(); happyMeal.DisplayMenu(); happyMeal1.DisplayMenu(); autumnMenuRepo.DisplayAllMenus(); springMenuRepo.DisplayAllMenus(); break;
                        case 2: message = "Dodawanie menu"; menuRepo.Add(menu1); menuRepo.Add(menu2); springMenuRepo.Add(springMenu); autumnMenuRepo.Add(autumnMenu); break;
                        case 3: message = "Modyfikacja menu"; menu1.Starter = "Bruschetta"; menuRepo.Update(menu1); springMenu.Soup = "Krem z dyni"; springMenuRepo.Update(springMenu); break;
                        case 4: message = "Usuwa menu"; menuRepo.Delete(menu2); autumnMenuRepo.Delete(autumnMenu); break;
                        case 5: message = "Wyświetla pracowników z pensją powyżej 3500"; break;
                        case 6: Options(); break;
                        case 7: message = "Czyszczenie konsoli"; Console.Clear(); Options(); break;
                        case 8: message = "Koniec programu"; quit = true; break;
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
                Console.WriteLine("\n\t1 - Menu");
                Console.WriteLine("\n\t2 - Dodaj menu");
                Console.WriteLine("\n\t3 - Zmodyfikuj menu");
                Console.WriteLine("\n\t4 - Usuń menu");
                Console.WriteLine("\n\t5 - Wyświetl wybranego pracownika");
                Console.WriteLine("\n\t6 - Wybor opcji");
                Console.WriteLine("\n\t7 - Wyczyść konsolę");
                Console.WriteLine("\n\t8 - Koniec programu");
                Console.WriteLine("\n\t9 - Zapisz do pliku - JSON");
                
            }
           
        }

    }
}


