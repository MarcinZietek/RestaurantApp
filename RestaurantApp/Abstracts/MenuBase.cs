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
        
        public MenuBase() {
            UniversalMenuId = Guid.NewGuid();           
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MenuId: {UniversalMenuId}");
        }
    }
}
