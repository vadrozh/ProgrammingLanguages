using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Lab1.Validation
{
    public class Validations
    {
        public static void IsEqual(string FirstString, string SecondString)
        {
            if (FirstString.Equals(SecondString))
            {
                throw new ValidationException("Strings equal.");
            }
            else
            {
                throw new ValidationException("Strings not equal.");
            }
        }

        public static void IsPalindrome(string FirstString, string SecondString)
        {
            char[] aReverse = FirstString.ToCharArray();
            Array.Reverse(aReverse);

            if (SecondString.Equals(new string(aReverse)))
            {
                throw new ValidationException("Strings are palindromes.");
            }
            else
            {
                throw new ValidationException("Strings aren't palindromes.");
            }
        }

        public static void IsEmail(string sData)
        {
            if (Regex.IsMatch(sData, "[^@ \t\r\n]+@[^@ \t\r\n]+\\.[^@ \t\r\n]+"))
            {
                throw new ValidationException(string.Format("String {0} contains E-mail", sData));
            }
            else
            {
                throw new ValidationException(string.Format("String {0} doesn't contains E-mail", sData));
            }
        }

        public static void IsPhoneNumber(string sData)
        {
            if (Regex.IsMatch(sData, "[\\+]?[(]?[0-9]{3}[)]?[-\\s\\.]?[0-9]{3}[-\\s\\.]?[0-9]{4,6}"))
            {
                throw new ValidationException(string.Format("String {0} contains phone number", sData));
            }
            else
            {
                throw new ValidationException(string.Format("String {0} doesn't contains phone number", sData));
            }
        }

        public static void IsIP(string sData)
        {
            if (Regex.IsMatch(sData, "(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)(\\.(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)){3}"))
            {
                throw new ValidationException(string.Format("String {0} contains IP", sData));
            }
            else
            {
                throw new ValidationException(string.Format("String {0} doesn't contains IP", sData));
            }
        }
    }
}
