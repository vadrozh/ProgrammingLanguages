using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public abstract class MenuItemCore
    {
        public abstract string Title { get; }
        public abstract void Execute();
    }
}
