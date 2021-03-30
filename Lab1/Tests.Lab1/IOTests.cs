using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lab1;
using Lab1.MenuItem;
using Lab1.Validation;

namespace Tests.Lab1
{
    [TestFixture]
    public class IOTests
    {
        [Test]
        public void IOTests_ParsedNullTest()
        {
            IO IOTest = new IO(true);

            Assert.That(() => IOTest.ReadInteger("X"),
                Throws.TypeOf<ValidationException>());

            Assert.That(() => IOTest.ReadDateTime("First string first segment"),
                Throws.TypeOf<ValidationException>());

            Assert.That(() => IOTest.ReadString("Second string"),
                Throws.TypeOf<ValidationException>());
        }

        [TestCase("06.10.2009", "05.10.2009", ExpectedResult = false)]
        [TestCase("05.06.2021", "29.09.2020", ExpectedResult = false)]
        public bool IOTests_SegmentValidTest_failed(string value1, string value2)
        {
            DateTime.TryParseExact(value1, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp1);
            DateTime.TryParseExact(value2, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp2);
            return IO.IsSegmentValid(tmp1, tmp2);
        }

        [TestCase("01.03.2020", "20.03.2020", ExpectedResult = true)]
        [TestCase("28.02.2015", "21.08.2025", ExpectedResult = true)]
        public bool IOTests_SegmentValidTest_success(string value1, string value2)
        {
            DateTime.TryParseExact(value1, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp1);
            DateTime.TryParseExact(value2, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out DateTime tmp2);
            return IO.IsSegmentValid(tmp1, tmp2);
        }
    }
}
