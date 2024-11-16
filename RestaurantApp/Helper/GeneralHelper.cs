using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Helper
{
    public static class GeneralHelper
    {
        public static decimal CalculateTax(decimal salary, decimal taxRate = 0.2M)
        {
            return salary * taxRate;
        }
        
    }
}
