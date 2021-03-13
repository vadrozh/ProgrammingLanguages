using Lab1.MenuItem;
using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu.ClearItems();
            Menu.AddItem(new MenuItemExit());
            Menu.AddItem(new MenuItemHelloWorld());
            Menu.AddItem(new MenuItemCalc());
            Menu.AddItem(new MenuItemRecursionDate());
            Menu.AddItem(new MenuItemStringsValidation());

            while (true)
            {
                Menu.Execute();
            }
        }
    }
}
