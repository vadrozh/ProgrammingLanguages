using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public class MenuItemExit : MenuItemCore
    {
        public override string Title { get { return "Exit"; } }

        public override void Execute(IO IOClass)
        {
            IO.WriteString("Exiting...");
            Environment.Exit(0);
        }
    }
}
