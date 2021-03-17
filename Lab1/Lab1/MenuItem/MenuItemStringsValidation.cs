using System;
using System.Collections.Generic;
using System.Text;
using Lab1.Validation;

namespace Lab1.MenuItem
{
    public class MenuItemStringsValidation : MenuItemCore
    {
        public override string Title { get { return "Strings"; } }

        public override void Execute()
        {
            IO.WriteString("Enter first string:");
            string FirstString = IO.ReadString();
            IO.WriteString("Enter second string:");
            string SecondString = IO.ReadString();

            CatchIsEqual(FirstString, SecondString);
            CatchIsEqualNormalized(FirstString, SecondString);
            CatchIsPalindrome(FirstString, SecondString);
            CatchIsEmail(FirstString);
            CatchIsEmail(SecondString);
            CatchIsPhoneNumber(FirstString);
            CatchIsPhoneNumber(SecondString);
            CatchIsIP(FirstString);
            CatchIsIP(SecondString);
        }

        public void CatchIsEqual(string FirstString, string SecondString)
        {
            try
            {
                Validations.IsEqual(FirstString, SecondString);
                IO.WriteString("Strings are equal.");
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }

        public void CatchIsEqualNormalized(string FirstString, string SecondString)
        {
            try
            {
                Validations.IsEqualNormalized(FirstString, SecondString);
                IO.WriteString("Normalized strings are equal.");
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }

        public void CatchIsPalindrome(string FirstString, string SecondString)
        {
            try
            {
                Validations.IsPalindrome(FirstString, SecondString);
                IO.WriteString("Strings are palindromes.");
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }

        public void CatchIsEmail(string FirstString)
        {
            try
            {
                Validations.IsEmail(FirstString);
                IO.WriteString(string.Format("String {0} contains E-mail", FirstString));
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }

        public void CatchIsPhoneNumber(string FirstString)
        {
            try
            {
                Validations.IsPhoneNumber(FirstString);
                IO.WriteString(string.Format("String {0} contains phone number", FirstString));
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }

        public void CatchIsIP(string FirstString)
        {
            try
            {
                Validations.IsIP(FirstString);
                IO.WriteString(string.Format("String {0} contains IP", FirstString));
            }
            catch (ValidationException ex)
            {
                IO.WriteString(ex.Message);
            }
        }
    }
}
