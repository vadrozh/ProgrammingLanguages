using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public class MenuItemHelloWorld : MenuItemCore
    {
        public override string Title { get { return "Hello world!"; } }

        public override void Execute(IO IOClass)
        {
            IO.WriteString(string.Format("Hello world! {0}", Environment.NewLine));
        }
    }
}
