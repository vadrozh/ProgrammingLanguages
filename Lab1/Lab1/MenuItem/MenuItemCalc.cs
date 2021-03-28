using System;
using Lab1.Validation;

namespace Lab1.MenuItem
{
    public class MenuItemCalc : MenuItemCore
    {
        public override string Title { get { return "Calc: sqrt(X)-6/Z"; } }

        public override void Execute(IO IOClass)
        {
            int x, z;
            x = IOClass.ReadInteger("X", "Enter X:", false, true);
            z = IOClass.ReadInteger("Z", "Enter Z:", false);

            IO.WriteString(string.Format("Result: {0:F3}{1}", Calculate(x, z), Environment.NewLine));
        }

        public static double Calculate(int x, int z)
        {
            return Math.Sqrt(x) - (6 / z);
        }
    }
}
