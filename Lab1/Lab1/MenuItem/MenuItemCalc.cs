using System;

namespace Lab1.MenuItem
{
    public class MenuItemCalc : MenuItemCore
    {
        public override string Title { get { return "Calc: sqrt(X)-6/Z"; } }

        public override void Execute()
        {
            IO.WriteString("Enter X:");
            int x = IO.ReadInteger(null, false, true);

            IO.WriteString("Enter Z:");
            int z = IO.ReadInteger(null, false);

            IO.WriteString(string.Format("Result: {0:F3}{1}", Math.Sqrt(x) - (6 / z), Environment.NewLine));
        }
    }
}
