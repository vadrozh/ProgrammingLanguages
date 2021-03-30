using System;
using System.Collections.Generic;
using System.Text;
using Lab1.Validation;

namespace Lab1
{
    public class IO
    {
        public bool IsParsed { get; private set; }
        public Dictionary<string, int?> IOIntData = null;
        public Dictionary<string, DateTime?> IODateTimeData = null;
        public Dictionary<string, string> IOStringData = null;

        public IO(bool bParsed = false, int? iMenuItem = null,
                  int? iX = null, int? iZ = null,
                  DateTime? FirstDate = null, DateTime? SecondDate = null, DateTime? ThirdDate = null, DateTime? FourthDate = null,
                  string FirstString = null, string SecondString = null)
        {
            IsParsed = bParsed;
            IOIntData = new Dictionary<string, int?>(3);
            IODateTimeData = new Dictionary<string, DateTime?>(4);
            IOStringData = new Dictionary<string, string>(2);

            IOIntData.Add("Menu Item", iMenuItem);
            IOIntData.Add("X", iX);
            IOIntData.Add("Z", iZ);

            IODateTimeData.Add("First segment first date", FirstDate);
            IODateTimeData.Add("First segment second date", SecondDate);
            IODateTimeData.Add("Second segment first date", ThirdDate);
            IODateTimeData.Add("Second segment second date", FourthDate);

            IOStringData.Add("First string", FirstString);
            IOStringData.Add("Second string", SecondString);
        }

        public int ReadInteger(string sVarName = null, string sMessage = null, bool bZeroAcceptable = true, bool bIsNotNegative = false, string sTryReadValue = null)
        {
            if (!string.IsNullOrEmpty(sMessage) && !IsParsed)
            {
                WriteString(sMessage);
            }

            if (sTryReadValue != null)
            {
                if (Int32.TryParse(sTryReadValue, out int iTryRead) && (bZeroAcceptable || iTryRead != 0) && (!bIsNotNegative || (iTryRead >= 0)))
                {
                    return iTryRead;
                }
                else
                {
                    throw new ValidationException(string.Format("Value {0} is incorrect.", sTryReadValue));
                }
            }

            if (IsParsed && (sVarName != null))
            {
                if (IOIntData.TryGetValue(sVarName, out int? iValue) && (iValue != null) && (bZeroAcceptable || iValue != 0) && (!bIsNotNegative || (iValue >= 0)))
                {
                    return (int)iValue;
                }
                else
                {
                    throw new ValidationException(string.Format("Value of {0} is incorrect.", sVarName));
                }
            }

            while (true)
            {
                string sValue = Console.ReadLine();
                if (Int32.TryParse(sValue, out int iRead) && (bZeroAcceptable || iRead != 0) && (!bIsNotNegative || (iRead >= 0)))
                {
                    return iRead;
                }

                WriteString("ERROR: Incorrect value. Enter integer value...");
            }
        }

        public DateTime ReadDateTime(string sVarName = null, string sMessage = null, string sTryReadValue = null)
        {
            if (!string.IsNullOrEmpty(sMessage) && !IsParsed)
            {
                WriteString(sMessage);
            }

            if (sTryReadValue != null)
            {
                if (DateTime.TryParseExact(sTryReadValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime dtTryRead))
                {
                    return dtTryRead;
                }
                else
                {
                    throw new ValidationException(string.Format("Value {0} is incorrect.", dtTryRead));
                }
            }

            if (IsParsed && (sVarName != null))
            {
                if (IODateTimeData.TryGetValue(sVarName, out DateTime? iValue) && (iValue != null))
                {
                    return (DateTime)iValue;
                }
                else
                {
                    throw new ValidationException(string.Format("Value of {0} is incorrect.", sVarName));
                }
            }

            while (true)
            {
                string sValue = Console.ReadLine();
                if (DateTime.TryParseExact(sValue, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime date))
                {
                    return date;
                }

                WriteString("ERROR: Incorrect format. Enter correct date...");
            }
        }

        public List<DateTime> ReadDTSegment(string sSegmentName = null)
        {
            List<DateTime> aBuffer = new List<DateTime>();
            if (!IsParsed)
            {
                WriteString(string.Format("{0} segment", sSegmentName));
            }

            while (true)
            {
                DateTime dtFirstDate = ReadDateTime(string.Format("{0} segment first date", sSegmentName), "Enter first date");
                DateTime dtSecondDate = ReadDateTime(string.Format("{0} segment second date", sSegmentName), "Enter second date");

                if (IsSegmentValid(dtFirstDate, dtSecondDate))
                {
                    aBuffer.Add(dtFirstDate);
                    aBuffer.Add(dtSecondDate);
                    return aBuffer;
                }

                if (IsParsed)
                {
                    throw new ValidationException(string.Format("First date later than second on segment {0}", sSegmentName));
                }
                else
                {
                    WriteString("First date later than second, try again...");
                }
            }
        }

        public static bool IsSegmentValid(DateTime dtFirstDate, DateTime dtSecondDate)
        {
            return ((dtSecondDate - dtFirstDate).TotalDays > 0);
        }

        public static void WriteString(string sMessage)
        {
            Console.WriteLine(sMessage);
        }

        public string ReadString(string sVarName = null, string sMessage = null)
        {
            if (!string.IsNullOrEmpty(sMessage) && !IsParsed)
            {
                WriteString(sMessage);
            }

            if (IsParsed && (sVarName != null))
            {
                if (IOStringData.TryGetValue(sVarName, out string iValue) && (iValue != null))
                {
                    return iValue;
                }
                else
                {
                    throw new ValidationException(string.Format("Value of {0} is incorrect.", sVarName));
                }
            }

            return Console.ReadLine();
        }
    }
}
