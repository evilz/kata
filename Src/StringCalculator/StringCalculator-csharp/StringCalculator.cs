using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace StringCalculator_csharp
{
    public class StringCalculator
    {
        private List<char> _delimiters = new List<char> { ',', '\n' };
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
                return 0;

            numbers = ExtractDelimiter(numbers, _delimiters);
            
            var ints = numbers
                .Trim()
                .Split(_delimiters.ToArray())
                .Select(int.Parse)
                .Where(i => i <= 1000)
                .ToArray();

            CheckNegativeNumber(ints);

            return ints.Length == 1 ? ints.First() * 2 : ints.Sum();
        }

        internal static void CheckNegativeNumber(int[] ints)
        {
            var neg = ints.Where(i => i < 0).ToArray();
            if (neg.Any())
            {
                throw new InvalidExpressionException("Negatives not allowed: " + string.Join(",", neg));
            }
        }

        internal string ExtractDelimiter(string numbers, ICollection<char> delimiters)
        {
            var splited = numbers.Split('\n');
            var separator = splited.First();
            if (separator.StartsWith("//") && separator.Length >= 3)
            {
                delimiters.Add(separator[2]);
                numbers = string.Join(string.Empty, splited.Skip(1));
            }
            return numbers;
        }
    }
}