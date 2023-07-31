using System;
using System.Security.Cryptography;
using System.Text;

namespace Randomnumber_RandomString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        static void GenerateRandomNumber(int MinValue, int MaxValue)
        {
            Random random = new Random();
            Console.WriteLine($"Random Number: {random.Next(MinValue, MaxValue)}");
        }

        static void GenerateRandomString(int Length)
        {
            string bufferCapitalLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string bufferSmallLetters = "abcdefghijklmnopqrstuvwxyz";
            string bufferNumbers = "0123456789";
            string bufferSymbols = "/*-+!@#$&*()<>%^";

            Random random = new Random();
            StringBuilder stringBuilder = new StringBuilder();

            Console.WriteLine("[1]Include capital Letters (y/n):");
            string IncludeCapitalLetters = Console.ReadLine();
            Console.WriteLine("[2]Include Small Letters (y/n):");
            string IncludeSmallLetters = Console.ReadLine();
            Console.WriteLine("[3]Include Numbers (y/n):");
            string IncludeNumbers = Console.ReadLine();
            Console.WriteLine("[4]Include Symbols (y/n):");
            string IncludeSymbols = Console.ReadLine();

            while (stringBuilder.Length < Length)
            {
                if (IncludeCapitalLetters == "Y" || IncludeCapitalLetters == "y")
                {
                    stringBuilder.Append(bufferCapitalLetters[random.Next(0, bufferCapitalLetters.Length)]);
                }
                if (IncludeSmallLetters == "Y" || IncludeSmallLetters == "y")
                {
                    stringBuilder.Append(bufferSmallLetters[random.Next(0, bufferSmallLetters.Length)]);
                }
                if (IncludeNumbers == "Y" || IncludeNumbers == "y")
                {
                    stringBuilder.Append(bufferNumbers[random.Next(0, bufferNumbers.Length)]);
                }
                if (IncludeSymbols == "Y" || IncludeSymbols == "y")
                {
                    stringBuilder.Append(bufferSymbols[random.Next(0, bufferSymbols.Length)]);
                }
            }

            Console.WriteLine($"Random string: {stringBuilder}");
        }
        static void MainMenu() 
        {
            while (true)
            {
                Console.WriteLine("Please select options:\n[1]-Random number\n[2]-Random string");
                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    Console.Write("Please Enter MinValue: ");
                    int minValue = int.Parse(Console.ReadLine());
                    Console.Write("Please Enter MaxValue: ");
                    int maxValue = int.Parse(Console.ReadLine());
                    GenerateRandomNumber(minValue, maxValue);
                }
                else if (select == 2)
                {
                    try
                    {
                        Console.WriteLine("Enter The Length:");
                        int length = int.Parse(Console.ReadLine());
                        if (length <= 0)
                            throw new Exception("Please enter a length greater than 0.");
                        GenerateRandomString(length);
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(ex.Message);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }

                Console.WriteLine("____________________________");
            }
        }
    }
}
