using RestaurantApp.Abstracts;
using RestaurantApp.Interfaces;
using RestaurantApp.TestData;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Classes
{
    public class GenericMenuRepository<T> : ICrudRepository<T> where T : MenuBase
    {      
        private readonly List<T> items;

        public GenericMenuRepository()
        {
            items = new List<T>();
        }

        public void LoadTestData()
        {
            var testData = Data.GetMenus().Where(menu => menu is T).Select(menu => menu as T).Cast<T>();
            foreach (var menu in testData)            
            {
                try
                {
                    Add(menu);
                }
                catch (InvalidCastException e)
                {
                   Console.WriteLine($"Błąd rzutowania obiektu { e.Message}");
                }               
            }
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
        
        [Obsolete]
        public void DisplayAllId()
        {         
            if (items.Count == 0)
            {
                Console.WriteLine("Brak Menu do wyświetlenia.");
            }
            else
            {
                foreach (var item in items)
                {
                    //item.DisplayIdMenu();
                }
            }            
           
        }

        public IEnumerable<T> FindMenusByName(string menuName)
        {
            if (string.IsNullOrEmpty(menuName))
            {
                throw new ArgumentException("Nazwa menu nie może być pusta.", nameof(menuName));
            }
            IEnumerable<T> listMenusByName = from item in items where item.MenuName == menuName select item;
            return listMenusByName; 
        }

        public void DisplayAllMenus(IEnumerable<T> menus)
        {
            foreach (var menu in menus)
            {
                menu.DisplayInfo();
            }
        }

        public void DisplayAllMenus()
        {
            foreach (var menu in items)
            {
                menu.DisplayInfo();
            }
        }
    }
}
