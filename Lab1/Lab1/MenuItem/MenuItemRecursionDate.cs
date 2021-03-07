using System;
using System.Collections.Generic;
using System.Text;

namespace Lab1.MenuItem
{
    public class MenuItemRecursionDate : MenuItemCore
    {
        public override string Title { get { return "Recursion date"; } }

        public override void Execute()
        {
            Console.WriteLine("Enter two time Segments.");
            Console.WriteLine("First Segment: ");
            List<DateTime> aFirstSegment = ReadSegment();
            Console.WriteLine("Second Segment: ");
            List<DateTime> aSecondSegment = ReadSegment();

            int iDays = IntervalDaysInSegments(aFirstSegment, aSecondSegment);
            if (iDays > 4000)
            {
                Console.WriteLine("Ooof, try with another interval, it's too big (>4000)");
            }

            Console.WriteLine("All simple dividers of {0}:", iDays);
            ShowAllSimpleDividers(iDays);
        }

        private static List<DateTime> ReadSegment()
        {
            List<DateTime> aBuffer = new List<DateTime>();
            while (true)
            {
                Console.WriteLine("Enter first date");
                DateTime dtFirstDate = IO.ReadDateTime();
                Console.WriteLine("Enter second date");
                DateTime dtSecondDate = IO.ReadDateTime();
                if ((dtSecondDate - dtFirstDate).TotalDays >= 0)
                {
                    aBuffer.Add(dtFirstDate);
                    aBuffer.Add(dtSecondDate);
                    return aBuffer;
                }
                Console.WriteLine("First date later than second, try again...");
            }
        }

        private static int IntervalDaysInSegments(List<DateTime> FirstSegment, List<DateTime> SecondSegment)
        {
            int iDays = 0;

            if (FirstSegment[0] <= SecondSegment[0] &&
                SecondSegment[0] <= FirstSegment[1] &&
                FirstSegment[1] <= SecondSegment[1])
            {
                iDays = Convert.ToInt32((FirstSegment[1] - SecondSegment[0]).TotalDays) + 1;
            }
            else if (SecondSegment[0] <= FirstSegment[0] &&
                     FirstSegment[0] <= SecondSegment[1] &&
                     SecondSegment[1] <= FirstSegment[1])
            {
                iDays = Convert.ToInt32((SecondSegment[1] - FirstSegment[0]).TotalDays) + 1;
            }
            else if (FirstSegment[0] <= SecondSegment[0] && 
                     SecondSegment[0] <= SecondSegment[1] &&
                     SecondSegment[1] <= FirstSegment[1])
            {
                iDays = Convert.ToInt32((SecondSegment[1] - SecondSegment[0]).TotalDays) + 1;
            }
            else if (SecondSegment[0] <= FirstSegment[0] &&
                     FirstSegment[0] <= FirstSegment[1] &&
                     FirstSegment[1] <= SecondSegment[1])
            {
                iDays = Convert.ToInt32((FirstSegment[1] - FirstSegment[0]).TotalDays) + 1;
            }

            return iDays;
        }

        private static List<int> aSimpleNums = new List<int>();
        private static void ShowAllSimpleDividers(int iNumber)
        {
            bool f = false;
            for (int i = 2; i < 1000; i++)
            {
                foreach (int SimpleNum in aSimpleNums)
                {
                    f = i % SimpleNum == 0;
                    if (f) break;
                }
                if (!f)
                {
                    aSimpleNums.Add(i);
                }
                f = false;
            }
            RecursiveCheck(iNumber);
        }

        static void RecursiveCheck(int iNumber)
        {
            if (aSimpleNums.Contains(iNumber))
            {
                Console.Write("{0}\t", iNumber);
            } else
            {
                foreach (int SimpleNum in aSimpleNums)
                {
                    if (iNumber % SimpleNum == 0)
                    {
                        Console.Write("{0}\t", SimpleNum);
                        RecursiveCheck(iNumber / SimpleNum);
                        break;
                    }
                }
            }
        }
    }
}
