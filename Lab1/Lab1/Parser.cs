using System;
using System.Collections.Generic;
using System.Text;
using Lab1.Validation;
using Lab1.MenuItem;

namespace Lab1
{
    public static class Parser
    {
        public static void ParseArgs(string[] args)
        {
            int iMenu, iX, iY, iZ = -1;
            DateTime FirstDate, SecondDate, ThirdDate, FourthDate;
            String FirstString, SecondString;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-mi")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read menu parameter: no data.");
                    } else if (!Int32.TryParse(args[i + 1], out iMenu))
                    {
                        throw new ValidationException("Can't read menu parameter.");
                    }
                }

                if (args[i] == "-x")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read X parameter: no data.");
                    }
                    else if (!Int32.TryParse(args[i + 1], out iX))
                    {
                        throw new ValidationException("Can't read X parameter.");
                    }
                }

                if (args[i] == "-y")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read Y parameter: no data.");
                    }
                    else if (!Int32.TryParse(args[i + 1], out iY))
                    {
                        throw new ValidationException("Can't read Y parameter.");
                    }
                }

                if (args[i] == "-z")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read Z parameter: no data.");
                    }
                    else if (!Int32.TryParse(args[i + 1], out iZ))
                    {
                        throw new ValidationException("Can't read Z parameter.");
                    }
                }

                if (args[i] == "-d1st")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read first segment first date parameter: no data.");
                    }
                    else if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out FirstDate))
                    {
                        throw new ValidationException("Can't read first segment first date parameter.");
                    }
                }

                if (args[i] == "-d1end")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read first segment second date parameter: no data.");
                    }
                    else if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out SecondDate))
                    {
                        throw new ValidationException("Can't read first segment second date parameter.");
                    }
                }

                if (args[i] == "-d2st")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read second segment first date parameter: no data.");
                    }
                    else if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ThirdDate))
                    {
                        throw new ValidationException("Can't read second segment first date parameter.");
                    }
                }

                if (args[i] == "-d2end")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read second segment second date parameter: no data.");
                    }
                    else if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out FourthDate))
                    {
                        throw new ValidationException("Can't read second segment second date parameter.");
                    }
                }

                if (args[i] == "-s1")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read first string parameter: no data.");
                    }
                    else
                    {
                        FirstString = args[i + 1];
                    }
                }

                if (args[i] == "-s2")
                {
                    if (!(i + 1 >= args.Length))
                    {
                        throw new ValidationException("Can't read second string parameter: no data.");
                    }
                    else
                    {
                        SecondString = args[i + 1];
                    }
                }
            }
        }
    }
}
