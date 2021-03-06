using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class IO
    {
        public static int ReadInteger(string sMessage, bool bZeroAcceptable = true, bool bIsNotNegative = false)
        {
            if (!string.IsNullOrEmpty(sMessage))
            {
                Console.WriteLine(sMessage);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                if (Int32.TryParse(sValue, out int iValue) && (bZeroAcceptable || iValue != 0) && (!bIsNotNegative || (iValue >= 0)))
                {
                    return iValue;
                }

                Console.WriteLine("ERROR: Incorrect format. Enter integer value...");
            }
        }
    }
}
