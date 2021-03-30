using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lab1;
using Lab1.MenuItem;

namespace Tests.Lab1.MenuItemTests
{
    public class MenuItemCalcTests
    {
        [TestCase(4, 2, ExpectedResult = -1)]
        [TestCase(16, 6, ExpectedResult = 3)]
        public int MenuItemCalc_Test(int value1, int value2)
        {
            return (int)MenuItemCalc.Calculate(value1, value2);
        }
    }
}
