using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public class MenuItemHelloWorld : MenuItemCore
    {
        public override string Title { get { return "Hello world!"; } }

        public override void Execute()
        {
            Console.WriteLine("Hello world! {0}", Environment.NewLine);
        }
    }
}
