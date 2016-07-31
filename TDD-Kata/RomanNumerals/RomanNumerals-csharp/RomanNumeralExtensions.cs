using System.Linq;
using System.Text;

namespace RomanNumerals_csharp
{
    public static class RomanNumeralExtensions
    {
        private class RomanLetter
        {
            public RomanLetter(int value, string letter)
            {
                Value = value;
                Letter = letter;
            }

            public int Value { get; }
            public string Letter { get; }
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
            var romanLetter = _map.SingleOrDefault(x => x.Value == val);
           return romanLetter == null ? string.Empty : romanLetter.Letter;
        }

        private static int GetValueFromLetter(char letter) => GetValueFromLetter(letter.ToString());

        private static int GetValueFromLetter(string letter) => _map.Single(x => x.Letter == letter).Value;

        public static string ToRomanNumeral(this int number)
        {
            var sb = new StringBuilder();
            var maxRomanDigit = _map.Max(x => x.Value);

            for (var powOfTen = maxRomanDigit; powOfTen > 0; powOfTen = powOfTen / 10)
            {
                var currentDigit = number / powOfTen;
                if (currentDigit == 0) continue;

                var unitLetter = GetLetterFromValue(powOfTen)[0];
                var halfLetter = GetLetterFromValue(powOfTen*5);
                var decimalLetter = GetLetterFromValue(powOfTen*10);

                var currentRoman = string.Empty;

                if (currentDigit.IsBetween(1,3)) currentRoman = new string(unitLetter, currentDigit);
                else if (currentDigit == 4) currentRoman = (unitLetter + halfLetter);
                else if (currentDigit.IsBetween(5,8)) currentRoman = (halfLetter + new string(unitLetter, currentDigit-5));
                else if (currentDigit == 9) currentRoman = (unitLetter + decimalLetter);

                sb.Append(currentRoman);

                number -= currentDigit * powOfTen;
            }
            return sb.ToString();
        }

        public static bool IsBetween(this int number,int left, int right)
        {
            return number >= left && number <= right;
        }

        public static int FromRomanNumeral(this string romanNumber)
        {
            var result = 0;

            for (var i = 0; i < romanNumber.Length; i++)
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
