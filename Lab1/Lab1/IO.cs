using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class IO
    {
        public static int ReadInteger(string sMessage = null, bool bZeroAcceptable = true, bool bIsNotNegative = false)
        {
            if (!string.IsNullOrEmpty(sMessage))
            {
                WriteString(sMessage);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                if (Int32.TryParse(sValue, out int iValue) && (bZeroAcceptable || iValue != 0) && (!bIsNotNegative || (iValue >= 0)))
                {
                    return iValue;
                }

                WriteString("ERROR: Incorrect value. Enter integer value...");
            }
        }

        private static DateTime ReadDateTime(string sMessage = null)
        {
            if (!string.IsNullOrEmpty(sMessage))
            {
                WriteString(sMessage);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                DateTime date;
                if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out date))
                {
                    return date;
                }

                WriteString("ERROR: Incorrect format. Enter correct date...");
            }
        }

        public static List<DateTime> ReadDTSegment()
        {
            List<DateTime> aBuffer = new List<DateTime>();
            while (true)
            {
                WriteString("Enter first date");
                DateTime dtFirstDate = IO.ReadDateTime();
                WriteString("Enter second date");
                DateTime dtSecondDate = IO.ReadDateTime();
                if ((dtSecondDate - dtFirstDate).TotalDays >= 0)
                {
                    aBuffer.Add(dtFirstDate);
                    aBuffer.Add(dtSecondDate);
                    return aBuffer;
                }
                WriteString("First date later than second, try again...");
            }
        }

        public static void WriteString(string sMessage)
        {
            Console.WriteLine(sMessage);
        }

        public static string ReadString()
        {
            return Console.ReadLine();
        }
    }
}
