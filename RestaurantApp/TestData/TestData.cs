using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.TestData
{
    internal class TestData
    {

        public static List<Menu> GetMenus()
        {
            Menu autumnMenu; Menu autumnMenu1; Menu summerMenu; Menu springMenu; Menu springMenu1; Menu winterMenu; 
            List<Menu> menuList = new List<Menu>();
            var menu1 = new Menu("Zwykłe", "Sałatka", "Pomidorowa", "Stek", "Sernik", "Herbata");
            var menu2 = new Menu("Zwykłe", "Grzanki z serem", "Minestrone", "Carbonara", "Tiramisu", "Wino Czerwone");
            var menu3 = new Menu("Wiosenne", "Sałatka owocowa", "Zupa marchewkowa", "Łosoś", "Sernik", "Lemoniada");
            var menu4 = new Menu("Jesienne", "Chleb z masłem", "Rosół", "Schabowy", "Szarlotka", "Kompot");
            autumnMenu = new AutumnMenu("Jesienne", "Grzanki z pasta z suszonych pomidorów oraz serem", "Krem z dyni", "Gęsina Św. Marcina", "Tiramisu truflowe", "Kompot jerzynowy");
            springMenu = new SpringMenu("Wiosenne", "Sałatka z nowalijek", "Krem z młodych ziemniaków i chrzanu", "Młoda perliczka", "Sernik cytrynowy", "Mus z jarmużu");
            autumnMenu1 = new AutumnMenu("Jesienne", "Chrupiące bataty", "Krem z pora", "Placek po zbójnicku");
            springMenu1 = new SpringMenu("Wiosenne", "Seler naciowy z sosem serowym", "Pikantny krem z pomidorów", "Skrzydełka buffalo");
            menuList.Add(menu1); menuList.Add(menu2); menuList.Add(menu3); menuList.Add(menu4); menuList.Add(autumnMenu); menuList.Add(autumnMenu1); menuList.Add(springMenu); menuList.Add(springMenu1);
            return menuList;
        }
    }
}
