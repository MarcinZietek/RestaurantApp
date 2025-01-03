using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Abstracts
{
    public abstract class MenuBase
    {
        
        public Guid MenuId { get; private set; }

        public MenuBase() {
            MenuId = Guid.NewGuid();
        }

        public virtual void DisplayInfo()
        {
            Console.WriteLine($"MenuId: {MenuId}");
        }
    }
}
