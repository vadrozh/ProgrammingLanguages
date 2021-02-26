using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    public static class IO
    {
        public static int ReadInteger(string message, bool ZeroAcceptable = true, bool IsNotNegative = false)
        {
            if (!string.IsNullOrEmpty(message))
            {
                Console.WriteLine(message);
            }
            while (true)
            {
                string sValue = Console.ReadLine();
                if (Int32.TryParse(sValue, out int iValue) && (ZeroAcceptable || iValue != 0) && (!IsNotNegative || (iValue >= 0)))
                {
                    return iValue;
                }

                Console.WriteLine("ERROR: Incorrect format. Enter integer value...");
            }
        }
    }
}
