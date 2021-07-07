using System;
using System.Text;

namespace RandomPasswordGenerator
{
    class Program
    {
        private const string CapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string SmallLetters = "abcdefghijklmnopqrstuvwxyz";
        private const string Digits = "0123456789";
        private const string SpecialChars = "~!@#$%^&*()_+='{}[]\\|:;/?<>";
        private const string AllChars = CapitalLetters + SmallLetters + Digits + SpecialChars;

        private static Random random = new Random();

        static void Main(string[] args)
        {
            StringBuilder password = new StringBuilder();

            //Generate two random capital letters
            for(int i = 0; i < 2; i++)
            {
                char capitalLetter = GenerateChar(CapitalLetters);
                InsertAtRandomPosition(password, capitalLetter);
            }

            //Generate two random small letters
            for (int i = 0; i < 2; i++)
            {
                char smallLetter = GenerateChar(SmallLetters);
                InsertAtRandomPosition(password, smallLetter);
            }

            //Generate one random digit
            char digit = GenerateChar(Digits);
            InsertAtRandomPosition(password, digit);

            //Generate three random special characters
            for(int i = 0; i < 3; i++)
            {
                char specialChar = GenerateChar(SpecialChars);
                InsertAtRandomPosition(password, specialChar);
            }

            //Generate few random characters
            for(int i = 0; i < 7; i++)
            {
                char randomChar = GenerateChar(AllChars);
                InsertAtRandomPosition(password, randomChar);
            }

            Console.WriteLine("Your password is: " + password);
        }

        private static void InsertAtRandomPosition(StringBuilder password,char character)
        {
            int randomPosition = random.Next(password.Length + 1);
            password.Insert(randomPosition, character);
        }

        private static char GenerateChar(string availableChars)
        {
            int randomIndex = random.Next(availableChars.Length);
            char randomChar = availableChars[randomIndex];
            return randomChar;
        }
    }
}
