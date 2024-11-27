using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Classes
{
    public class ListItems<T> : IListObject<T>
    {
        private readonly List<T> list = new List<T>();

        public List<T> GetAll()
        {
            return list;
        }
    }
}
