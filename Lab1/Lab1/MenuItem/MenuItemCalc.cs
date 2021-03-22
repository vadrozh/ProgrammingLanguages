using System;

namespace Lab1.MenuItem
{
    public class MenuItemCalc : MenuItemCore
    {
        public override string Title { get { return "Calc: sqrt(X)-6/Z"; } }

        public override void Execute(IO IOClass)
        {
            int x = 1, z = 1;
            if (IOClass.IsParsed)
            {
                if ((IOClass.ParsedXParameter > 0) && (IOClass.ParsedZParameter > 0))
                {
                    x = (int)IOClass.ParsedXParameter;
                    z = (int)IOClass.ParsedZParameter;
                }
                else
                {
                    IO.WriteString("X or Z is invalid");
                    return;
                }
            }
            else
            {
                IO.WriteString("Enter X:");
                x = IO.ReadInteger(null, false, true);

                IO.WriteString("Enter Z:");
                z = IO.ReadInteger(null, false);
            }
            IO.WriteString(string.Format("Result: {0:F3}{1}", Math.Sqrt(x) - (6 / z), Environment.NewLine));
        }
    }
}
