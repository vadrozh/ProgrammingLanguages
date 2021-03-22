using System;
using System.Collections.Generic;
using System.Text;
using Lab1.Validation;
using Lab1.MenuItem;

namespace Lab1
{
    public static class Parser
    {
        public static IO ParseArgs(string[] args)
        {
            int? iMenu = null, iX = null, iZ = null;
            DateTime FirstDate = DateTime.MinValue, SecondDate = DateTime.MinValue, ThirdDate = DateTime.MinValue, FourthDate = DateTime.MinValue;
            String FirstString = null, SecondString = null;

            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-mi")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read menu parameter: no data.");
                    }
                    if (!Int32.TryParse(args[i + 1], out int tmp))
                    {
                        throw new ValidationException("Can't read menu parameter.");
                    }
                    iMenu = tmp;
                }

                if (args[i] == "-x")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read X parameter: no data.");
                    }
                    if (!Int32.TryParse(args[i + 1], out int tmp))
                    {
                        throw new ValidationException("Can't read X parameter.");
                    }
                    iX = tmp;
                }

                if (args[i] == "-z")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read Z parameter: no data.");
                    }
                    if (!Int32.TryParse(args[i + 1], out int tmp))
                    {
                        throw new ValidationException("Can't read Z parameter.");
                    }
                    iZ = tmp;
                }

                if (args[i] == "-d1st")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read first segment first date parameter: no data.");
                    }
                    if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out FirstDate))
                    {
                        throw new ValidationException("Can't read first segment first date parameter.");
                    }
                }

                if (args[i] == "-d1end")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read first segment second date parameter: no data.");
                    }
                    if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out SecondDate))
                    {
                        throw new ValidationException("Can't read first segment second date parameter.");
                    }
                }

                if (args[i] == "-d2st")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read second segment first date parameter: no data.");
                    }
                    if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out ThirdDate))
                    {
                        throw new ValidationException("Can't read second segment first date parameter.");
                    }
                }

                if (args[i] == "-d2end")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read second segment second date parameter: no data.");
                    }
                    if (!DateTime.TryParseExact(args[i + 1], "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out FourthDate))
                    {
                        throw new ValidationException("Can't read second segment second date parameter.");
                    }
                }

                if (args[i] == "-s1")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read first string parameter: no data.");
                    }
                    FirstString = args[i + 1];
                }

                if (args[i] == "-s2")
                {
                    if (i + 1 >= args.Length)
                    {
                        throw new ValidationException("Can't read second string parameter: no data.");
                    }
                    SecondString = args[i + 1];
                }
            }

            if (iMenu == null)
            {
                return new IO();
            }
            else
            {
                List<DateTime> aFirstBuffer = null;
                List<DateTime> aSecondBuffer = null;
                if ((FirstDate != DateTime.MinValue) && (SecondDate != DateTime.MinValue) && (ThirdDate != DateTime.MinValue) && (FourthDate != DateTime.MinValue))
                {
                    if (IO.IsSegmentValid(FirstDate, SecondDate) && IO.IsSegmentValid(ThirdDate, FourthDate))
                    {
                        aFirstBuffer = new List<DateTime>();
                        aSecondBuffer = new List<DateTime>();
                        aFirstBuffer.Add(FirstDate);
                        aFirstBuffer.Add(SecondDate);
                        aSecondBuffer.Add(ThirdDate);
                        aSecondBuffer.Add(FourthDate);
                    }
                }
                return new IO(true, iMenu, iX, iZ, aFirstBuffer, aSecondBuffer, FirstString, SecondString);
            }
        }
    }
}
