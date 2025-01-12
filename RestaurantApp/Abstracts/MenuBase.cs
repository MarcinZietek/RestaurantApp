using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Abstracts
{
    public abstract class MenuBase
    {       
        public Guid UniversalMenuId { get; private set; }
        private static int idCounter = 1;
        public string menuName;

        public MenuBase() {
            UniversalMenuId = Guid.NewGuid();
            MenuId = idCounter++;
        }

        public MenuBase(string menuName)
        {
            MenuName = menuName;
        }

        public int MenuId { get; private set; }

        public string MenuName { get; set; }    

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MenuId: {MenuId} - Rodzaj Menu: {menuName}\n");
        }

        public virtual void DisplayGuid()
        {
            Console.WriteLine($"MenuId: {UniversalMenuId}");
        }
    }
}
