using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Classes
{
    public class GenericCrudRepository<T> : ICrudRepository<T> where T : Menu
    {
        private readonly List<T> items;

        public GenericCrudRepository()
        {
            items = new List<T>();
        }

        public void Add(T obj)
        {
            items.Add(obj);
            Console.WriteLine($"{typeof(T).Name} dodano pomyślnie.");
        }

        public void Update(T obj)
        {
            T existingItem = null;
            foreach (var item in items)
            {
                if (item.MenuId == obj.MenuId)
                {
                    existingItem = item;
                    break;
                }
            }

            if (existingItem != null)
            {
                items.Remove(existingItem);
                items.Add(obj);
                Console.WriteLine($"{typeof(T).Name} zmodyfikowano pomyślnie.");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} nie znaleziono.");
            }
        }

        public void Delete(T obj)
        {
            if (items.Remove(obj))
            {
                Console.WriteLine($"{typeof(T).Name} usunięto pomyślnie.");
            }
            else
            {
                Console.WriteLine($"{typeof(T).Name} nie znaleziono.");
            }
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }

        public void DisplayAllMenus()
        {
            foreach (var item in items)
            {
                item.DisplayMenu();
            }
        }
    }
}
