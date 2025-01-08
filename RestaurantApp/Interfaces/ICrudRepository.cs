using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Interfaces
{
    public interface ICrudRepository<T>
    {
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
    }
}
