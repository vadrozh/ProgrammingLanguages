using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lab1;
using Lab1.MenuItem;

namespace Test.Lab1
{
    [TestFixture]
    public class MenuTests
    {

        [Test]
        public void Menu_ManageItems()
        {
            Menu.ClearItems();

            Menu.AddItem(new MenuItemExit());
            Assert.AreEqual(1, Menu.ItemsCount);

            Menu.ClearItems();
            Assert.AreEqual(0, Menu.ItemsCount);
        }
    }
}