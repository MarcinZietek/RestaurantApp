using RestaurantApp.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.Interfaces
{
    public interface IPersonCRUD<T>
    {
        Person Create(T obj);
        T Read(string key);
        void Update(T obj);
        void Delete(string key);
        //IEnumerable<T> GetAll();
    }
}
