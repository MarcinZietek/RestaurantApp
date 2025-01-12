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
        protected static int idCounter = 1;
        public string menuName;

        public int MenuId { get; private set; }

        public MenuBase() { RefreshIds(); }
   
        public MenuBase(string menuName)
        {          
            MenuName = menuName;
        }

        public string MenuName { get; set; }    

        public void RefreshIds()
        {
            MenuId = idCounter++;
            UniversalMenuId = Guid.NewGuid();
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MenuId: {MenuId} - Rodzaj Menu: {MenuName}\n");
        }

        public virtual void DisplayGuid()
        {
            Console.WriteLine($"MenuId: {UniversalMenuId}");
        }
    }
}
