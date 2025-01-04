using RestaurantApp.Classes;
using RestaurantApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantApp.Repositories
{
    public class MenuRepository : IRepositoryCRUD<Menu>
    {
        private readonly List<Menu> menus;

        public MenuRepository()
        {
            menus = new List<Menu>();
        }

        public void Add(Menu obj)
        {
            menus.Add(obj);
            Console.WriteLine("Menu dodane.");
        }

        public void Update(Menu obj)
        {
            Menu existingMenu = null;
            foreach (var menu in menus)
            {
                if (menu.MenuId == obj.MenuId)
                {
                    existingMenu = menu;
                    break;
                }
            }

            if (existingMenu != null)
            {
                menus.Remove(existingMenu);
                menus.Add(obj);
                Console.WriteLine("Menu zmodyfikowane.");
            }
            else
            {
                Console.WriteLine("Menu nie znaleziono.");
            }
        }

        public void Delete(Menu obj)
        {
            if (menus.Remove(obj))
            {
                Console.WriteLine("Menu usunięte.");
            }
            else
            {
                Console.WriteLine("Menu nie znaleziono.");
            }
        }

        public IEnumerable<Menu> GetAll()
        {
            return menus;
        }

        public void DisplayAllMenus()
        {
            foreach (var menu in menus)
            {
                menu.DisplayMenu();
            }
        }
    }
}

