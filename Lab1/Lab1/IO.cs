using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public class IO
    {
        public bool IsParsed { get; private set; }
        public int? ParsedMenuItem { get; private set; }
        public int? ParsedXParameter { get; private set; }
        public int? ParsedZParameter { get; private set; }
        public List<DateTime> ParsedFirstDTSegment { get; private set; }
        public List<DateTime> ParsedSecondDTSegment { get; private set; }
        public string ParsedFirstString { get; private set; }
        public string ParsedSecondString { get; private set; }

        public IO(bool bParsed = false, int? iMenuItem = null,
                  int? iX = null, int? iZ = null,
                  List<DateTime> FirstDTSegment = null, List<DateTime> SecondDTSegment = null,
                  string FirstString = null, string SecondString = null)
        {
            IsParsed = bParsed;
            ParsedMenuItem = iMenuItem;
            ParsedXParameter = iX;
            ParsedZParameter = iZ;
            ParsedFirstDTSegment = FirstDTSegment;
            ParsedSecondDTSegment = SecondDTSegment;
            ParsedFirstString = FirstString;
            ParsedSecondString = SecondString;
        }

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
                if (IsSegmentValid(dtFirstDate, dtSecondDate))
                {
                    aBuffer.Add(dtFirstDate);
                    aBuffer.Add(dtSecondDate);
                    return aBuffer;
                }
                WriteString("First date later than second, try again...");
            }
        }

        public static bool IsSegmentValid(DateTime dtFirstDate, DateTime dtSecondDate)
        {
            return ((dtSecondDate - dtFirstDate).TotalDays >= 0);
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
