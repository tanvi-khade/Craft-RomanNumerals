using System;
using System.Collections.Generic;
using System.Text;

namespace Craft
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();

            Console.WriteLine("Enter space seprated numbers (ex: 4 5 6): ");

            var input = Console.ReadLine().Split(' ');

            foreach (var numStr in input)
            {
                _ = int.TryParse(numStr, out int num);
                if (num > 0)
                {
                    numbers.Add(num);
                }
            }

            Console.Clear();

            RomanNumerals(numbers);
        }

        public static void RomanNumerals(List<int> numbers)
        {
            var romanEquivalent = "";

            foreach (int number in numbers)
            {
                int digit = number % 10;
                int newNum = number / 10;
                if (digit > 0)
                {
                    UnitsPlace(ref romanEquivalent, digit);
                }
                digit = newNum % 10;

                if (digit > 0)
                {
                    string tensPlace = "";
                    if (digit < 4)
                    {
                        tensPlace = MultiplyChar(digit, tensPlace, 'X');
                    }
                    else if (digit == 4)
                        tensPlace = "XL";

                    else
                    {
                        tensPlace = "L";
                        digit -= 5;

                        if (digit == 4)
                            tensPlace = "XC";
                        else
                            tensPlace = MultiplyChar(digit, tensPlace, 'X');
                    }
                    romanEquivalent = tensPlace + romanEquivalent;
                }

                newNum /= 10;
                digit = newNum % 10;

                if (digit > 0)
                {
                    string hundredsPlace = "";

                    if (digit < 4)
                    {
                        hundredsPlace = MultiplyChar(digit, hundredsPlace, 'C');
                    }
                    else if (digit == 4)
                    {
                        hundredsPlace = "CD";
                    }
                    else
                    {
                        hundredsPlace = "D";
                        digit -= 5;
                        if (digit == 4) // digit == 9
                            hundredsPlace = "CM";
                        else
                            hundredsPlace = MultiplyChar(digit, hundredsPlace, 'C');
                    }

                    romanEquivalent = hundredsPlace + romanEquivalent;
                }

                newNum /= 10;
                digit = newNum % 10;

                if (digit > 0 && digit <= 3)
                {
                    string thousandsPlace = "";
                    thousandsPlace = MultiplyChar(digit, thousandsPlace, 'M');

                    romanEquivalent = thousandsPlace + romanEquivalent;
                }

                Console.WriteLine($"{number} = \"{romanEquivalent}\"");
                romanEquivalent = "";
            }
        }

        private static string MultiplyChar(int digit, string result, char charToMultiply)
        {
            for (int i = 1; i <= digit; i++)
            {
                result += charToMultiply;
            }

            return result;
        }

        private static void UnitsPlace(ref string romanEquivalent, int digit)
        {
            switch (digit)
            {
                case 1:
                    romanEquivalent = "I" + romanEquivalent;
                    break;
                case 2:
                    romanEquivalent = "II" + romanEquivalent;
                    break;
                case 3:
                    romanEquivalent = "III" + romanEquivalent;
                    break;
                case 4:
                    romanEquivalent = "IV" + romanEquivalent;
                    break;
                case 5:
                    romanEquivalent = "V" + romanEquivalent;
                    break;
                case 6:
                    romanEquivalent = "VI" + romanEquivalent;
                    break;
                case 7:
                    romanEquivalent = "VII" + romanEquivalent;
                    break;
                case 8:
                    romanEquivalent = "VIII" + romanEquivalent;
                    break;
                case 9:
                    romanEquivalent = "IX" + romanEquivalent;
                    break;
            }

        }
    }
}
