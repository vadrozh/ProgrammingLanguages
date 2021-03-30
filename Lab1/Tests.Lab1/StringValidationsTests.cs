using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Lab1;
using Lab1.Validation;

namespace Tests.Lab1
{
    public class StringValidationsTests
    {
        [TestCase("testttt", "testttt", true)]
        [TestCase("465488448 99844884984989", "465488448 99844884984989", true)]
        [TestCase("tes      tttt", "testtawdfawwaeftt", false)]
        [TestCase("46548wfaawffwa9844884984989", "4654  wfwfafwwfaafw989", false)]
        public void StringValidationsTests_IsEqual(string value1, string value2, bool expected)
        {
            if (expected)
            {
                Validations.IsEqual(value1, value2);
            }
            else
            {
                Assert.That(() => Validations.IsEqual(value1, value2),
                    Throws.TypeOf<ValidationException>());
            }
        }

        [TestCase("   Testttt     ", "testTTt  ", true)]
        [TestCase("465488448 99844884984989", "465488448 99844884984989", true)]
        [TestCase("tesasdtttt", "testtawdfawwaeftt", false)]
        [TestCase("     testT", "    TEST     ", false)]
        public void StringValidationsTests_IsEqualNormalized(string value1, string value2, bool expected)
        {
            if (expected)
            {
                Validations.IsEqualNormalized(value1, value2);
            }
            else
            {
                Assert.That(() => Validations.IsEqualNormalized(value1, value2),
                    Throws.TypeOf<ValidationException>());
            }
        }

        [TestCase("qwe", "ewq", true)]
        [TestCase("kayak", "kayak", true)]
        [TestCase("test", "test", false)]
        [TestCase("     testT", "    TEqwST   ", false)]
        public void StringValidationsTests_IsPalindrome(string value1, string value2, bool expected)
        {
            if (expected)
            {
                Validations.IsPalindrome(value1, value2);
            }
            else
            {
                Assert.That(() => Validations.IsPalindrome(value1, value2),
                    Throws.TypeOf<ValidationException>());
            }
        }

        [TestCase("123@mail.ru", true)]
        [TestCase("tes_t@ya.net", true)]
        [TestCase("testmail", false)]
        [TestCase("qwert@qw", false)]
        public void StringValidationsTests_IsEmail(string value1, bool expected)
        {
            if (expected)
            {
                Validations.IsEmail(value1);
            }
            else
            {
                Assert.That(() => Validations.IsEmail(value1),
                    Throws.TypeOf<ValidationException>());
            }
        }

        [TestCase("+79001006245", true)]
        [TestCase("89005001064", true)]
        [TestCase("test", false)]
        [TestCase("+1954587q458325484", false)]
        public void StringValidationsTests_IsPhoneNumber(string value1, bool expected)
        {
            if (expected)
            {
                Validations.IsPhoneNumber(value1);
            }
            else
            {
                Assert.That(() => Validations.IsPhoneNumber(value1),
                    Throws.TypeOf<ValidationException>());
            }
        }

        [TestCase("192.168.1.1", true)]
        [TestCase("187.254.100.5", true)]
        [TestCase("250.120.0.q", false)]
        [TestCase("102.106.5", false)]
        public void StringValidationsTests_IsIP(string value1, bool expected)
        {
            if (expected)
            {
                Validations.IsIP(value1);
            }
            else
            {
                Assert.That(() => Validations.IsIP(value1),
                    Throws.TypeOf<ValidationException>());
            }
        }
    }
}
