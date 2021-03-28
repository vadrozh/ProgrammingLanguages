using Lab1.MenuItem;
using Lab1.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class Menu
    {
        private static List<MenuItemCore> MenuItems = new List<MenuItemCore>();

        public static int ItemsCount
        {
            get
            {
                return MenuItems.Count;
            }
        }

        public static void ClearItems()
        {
            Menu.MenuItems.Clear();
        }

        public static void AddItem(MenuItemCore menuItem)
        {
            Menu.MenuItems.Add(menuItem);
        }

        public static void Execute(IO IOClass)
        {
            if (!IOClass.IsParsed)
            {
                ShowMenu();
            }
            int iMenu = IOClass.ReadInteger("Menu Item", null, true, true);
            if (iMenu < Menu.MenuItems.Count)
            {
                Menu.MenuItems.ToArray()[iMenu].Execute(IOClass);
            }
            else
            {
                if (IOClass.IsParsed)
                {
                    throw new ValidationException("Menu item not found.");
                }
                IO.WriteString(string.Format("Menu item not found.{0}", Environment.NewLine));
            }
        }
        private static void ShowMenu()
        {
            IO.WriteString(string.Format("{0}======= MENU =======", Environment.NewLine));

            int iMenuItem = 0;
            foreach (MenuItemCore menuItem in Menu.MenuItems)
            {
                IO.WriteString(string.Format("{0}: {1}", iMenuItem++, menuItem.Title));
            }
        }
    }
}
