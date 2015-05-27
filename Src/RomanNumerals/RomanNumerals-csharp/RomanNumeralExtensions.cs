using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace RomanNumerals_csharp
{

    public static class RomanNumeralExtensions
    {
        private struct RomanLetter
        {
            public RomanLetter(int value, string letter)
            {
                Value = value;
                Letter = letter;
            }

            public int Value { get; set; }
            public string Letter { get; set; }
        }

        private static readonly RomanLetter[] _map = {
            new RomanLetter(1, "I"),
            new RomanLetter(5, "V"),
            new RomanLetter(10, "X"),
            new RomanLetter(50, "L"),
            new RomanLetter(100, "C"),
            new RomanLetter(500, "D"),
            new RomanLetter(1000, "M")
        };

        private static string GetLetterFromValue(int val)
        {
            return _map.Single(x => x.Value == val).Letter;
        }

        private static int GetValueFromLetter(char letter)
        {
            return GetValueFromLetter(letter.ToString());
        }

        private static int GetValueFromLetter(string letter)
        {
            return _map.Single(x => x.Letter == letter).Value;
        }

        public static string ToRomanNumeral(this int number)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1000; i > 0; i = i / 10)
            {
                int part = number / i;
                if (part == 0) continue;
                else if (part == 1) sb.Append(GetLetterFromValue(i));
                else if (part == 2) sb.Append(GetLetterFromValue(i) + GetLetterFromValue(i));
                else if (part == 3) sb.Append(GetLetterFromValue(i) + GetLetterFromValue(i) + GetLetterFromValue(i));
                else if (part == 4) sb.Append(GetLetterFromValue(i) + GetLetterFromValue(i * 5));
                else if (part == 5) sb.Append(GetLetterFromValue(i * 5));
                else if (part == 6) sb.Append(GetLetterFromValue(i * 5) + GetLetterFromValue(i));
                else if (part == 7) sb.Append(GetLetterFromValue(i * 5) + GetLetterFromValue(i) + GetLetterFromValue(i));
                else if (part == 8) sb.Append(GetLetterFromValue(i * 5) + GetLetterFromValue(i) + GetLetterFromValue(i) + GetLetterFromValue(i));
                else if (part == 9) sb.Append(GetLetterFromValue(i) + GetLetterFromValue(i * 10));

                number -= part * i;
            }
            return sb.ToString();
        }

        public static int FromRomanNumeral(this string romanNumber)
        {
            var result = 0;

            for (int i = 0; i < romanNumber.Length; i++)
            {
                var currentLetter = romanNumber[i];
                var currentValue = GetValueFromLetter(currentLetter);
                var tail = romanNumber.Substring(i + 1);

                if (tail.Any(c => GetValueFromLetter(c) > currentValue))
                {
                    result -= currentValue;
                }
               
                else
                {
                    result += currentValue;
                }
            }
            
            return result;
        }
    }
}
