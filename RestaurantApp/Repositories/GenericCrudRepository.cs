using RestaurantApp.Abstracts;
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
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Menu nie może być puste");
            }
            obj.RefreshIds();
            if (items.Exists(m => m.MenuId == obj.MenuId))
            {
                Console.WriteLine($"Menu o Id {obj.MenuId} już istnieje. Dodawanie anulowane.");
                return;
            }
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

        public void DispalyAllId()
        {         
            if (items.Count == 0)
            {
                Console.WriteLine("Brak Menu do wyświetlenia.");
            }
            else
            {
                foreach (var item in items)
                {
                    item.DisplayIdMenu();
                }
            }            
           
        }

    }
}
