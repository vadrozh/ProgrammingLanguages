using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lab1;
using Lab1.MenuItem;

namespace Tests.Lab1.MenuItemTests
{
    public class MenuItemRecursionDateTest
    {
        [TestCase("01.03.2020", "20.03.2020", "10.03.2020", "15.03.2020", ExpectedResult = 6)]
        [TestCase("01.04.2021", "16.04.2020", "20.02.2020", "30.02.2020", ExpectedResult = 0)]
        [TestCase("08.06.2019", "25.08.2019", "20.08.2019", "30.08.2020", ExpectedResult = 6)]
        [TestCase("15.01.2010", "02.02.2010", "10.01.2010", "15.01.2021", ExpectedResult = 19)]
        public int MenuItemRecursionDate_IntervalDaysInSegmentsTest(string First, string Second, string Third, string Fourth)
        {
            List<DateTime> FirstSegment = new List<DateTime>();
            List<DateTime> SecondSegment = new List<DateTime>();
            DateTime.TryParseExact(First, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp1);
            DateTime.TryParseExact(Second, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp2);
            DateTime.TryParseExact(Third, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp3);
            DateTime.TryParseExact(Fourth, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp4);

            FirstSegment.Add(tmp1);
            FirstSegment.Add(tmp2);
            SecondSegment.Add(tmp3);
            SecondSegment.Add(tmp4);

            return MenuItemRecursionDate.IntervalDaysInSegments(FirstSegment, SecondSegment);
        }
    }
}
