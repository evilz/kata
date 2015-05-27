using System.Collections.Generic;
using System.Text;

namespace RomanNumerals_csharp
{

    public static class RomanNumeralExtensions
    {
        private static Dictionary<int, string> _map = new Dictionary<int, string>
        {
            {1, "I"},
            {5, "V"},
            {10, "X"},
            {50, "L"},
            {100, "C"},
            {500, "D"},
            {1000, "M"}
        };

        public static string ToRomanNumeral(this int number)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1000; i > 0; i = i / 10)
            {
                int part = number / i;
                if(part == 0) continue;
                else if (part == 1) sb.Append(_map[i]);
                else if(part == 2) sb.Append(_map[i] + _map[i]);
                else if(part == 3) sb.Append(_map[i] + _map[i] + _map[i]);
                else if(part == 4) sb.Append(_map[i] + _map[i * 5]);
                else if(part == 5) sb.Append(_map[i * 5]);
                else if(part == 6) sb.Append(_map[i * 5] + _map[i]);
                else if(part == 7) sb.Append(_map[i * 5] + _map[i] + _map[i]);
                else if(part == 8) sb.Append(_map[i * 5] + _map[i] + _map[i] + _map[i]);
                else if(part == 9) sb.Append(_map[i] + _map[i * 10]);

                number -= part * i;
            }
            return sb.ToString();
        }
    }
}
