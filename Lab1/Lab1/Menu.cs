using Lab1.MenuItem;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class Menu
    {
        private static List<MenuItemCore> MenuItems = new List<MenuItemCore>();

        public static void ClearItems()
        {
            Menu.MenuItems.Clear();
        }

        public static void AddItem(MenuItemCore menuItem)
        {
            Menu.MenuItems.Add(menuItem);
        }

        public static void Execute()
        {
            ShowMenu();
            int iMenu = IO.ReadInteger(null);
            if (iMenu >= 0 && iMenu < Menu.MenuItems.Count)
            {
                Menu.MenuItems.ToArray()[iMenu].Execute();
            }
            else
            {
                Console.WriteLine("Menu item not found.{0}", Environment.NewLine);
            }
        }
        private static void ShowMenu()
        {
            Console.WriteLine("{0}======= MENU =======", Environment.NewLine);

            int iMenuItem = 0;
            foreach (MenuItemCore menuItem in Menu.MenuItems)
            {
                Console.WriteLine("{0}: {1}", iMenuItem++, menuItem.Title);
            }
        }
    }
}
