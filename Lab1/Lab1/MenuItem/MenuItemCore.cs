using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public abstract class MenuItemCore
    {
        public abstract string Title { get; }
        public abstract void Execute();
        /*public abstract void Execute(int iValue);
        public abstract void Execute(int x, int y, int z);
        public abstract void Execute(DateTime FirstDate, DateTime SecondDate, DateTime ThirdDate, DateTime FourthDate);
        public abstract void Execute(string FirstString, string SecondString);*/
    }
}
