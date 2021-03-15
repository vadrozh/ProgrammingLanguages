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
            IO.WriteString("Enter two time Segments.");
            IO.WriteString("First Segment: ");
            List<DateTime> aFirstSegment = IO.ReadSegment();
            IO.WriteString("Second Segment: ");
            List<DateTime> aSecondSegment = IO.ReadSegment();

            int iDays = IntervalDaysInSegments(aFirstSegment, aSecondSegment);
            if (iDays > 4000)
            {
                IO.WriteString("Ooof, try with another interval, it's too big (>4000)");
            }

            IO.WriteString(string.Format("All simple dividers of {0}:", iDays));
            ShowAllSimpleDividers(iDays);
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
                foreach (int iSimpleNum in aSimpleNums)
                {
                    f = i % iSimpleNum == 0;
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
                IO.WriteString(string.Format("{0}", iNumber));
            } else
            {
                foreach (int iSimpleNum in aSimpleNums)
                {
                    if (iNumber % iSimpleNum == 0)
                    {
                        IO.WriteString(string.Format("{0}\t", iSimpleNum));
                        RecursiveCheck(iNumber / iSimpleNum);
                        break;
                    }
                }
            }
        }
    }
}
