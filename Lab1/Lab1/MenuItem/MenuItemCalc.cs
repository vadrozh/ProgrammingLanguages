using System;

namespace Lab1.MenuItem
{
    public class MenuItemCalc : MenuItemCore
    {
        public override string Title { get { return "Calc: sqrt(X)-6/Z"; } }

        public override void Execute()
        {
            Console.WriteLine("Enter X:");
            int x = IO.ReadInteger(null, false);

            Console.WriteLine("Enter Z:");
            int z = IO.ReadInteger(null, false);

            Console.WriteLine("Result: {0:F5}{1}", Math.Sqrt(x) - (6 / z), Environment.NewLine);
        }
    }
}
