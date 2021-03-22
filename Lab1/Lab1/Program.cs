using Lab1.MenuItem;
using Lab1.Validation;
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

            IO IOClass = null;

            try
            {
                IOClass = Parser.ParseArgs(args);
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }

            if (IOClass.IsParsed)
            {
                Menu.Execute(IOClass);
            }
            else
            {
                while (true)
                {
                    Menu.Execute(IOClass);
                }
            }
        }
    }
}
