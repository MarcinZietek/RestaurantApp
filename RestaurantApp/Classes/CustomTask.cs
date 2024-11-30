using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class CustomTask
    {
        public string Title { get; set; }
        public DateTime Deadline { get; set; }

        public override string ToString()
        {
            return $"Zadanie: {Title} (Wykonać do: {Deadline.ToShortDateString()})";
        }

    }
}
