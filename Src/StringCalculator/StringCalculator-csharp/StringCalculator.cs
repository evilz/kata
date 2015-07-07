using System;
using System.Data;
using System.Linq;

namespace StringCalculator_csharp
{
    public static class StringCalculator
    {
        private static readonly char[] _defaultDelimiters = { ',', '\n' };
        public static int Add(string input)
        {
            input = input.Trim();

            if (string.IsNullOrEmpty(input))
                return 0;

            var inputAndDelimiters = ExtractDelimiter(input);
            input = inputAndDelimiters.Item1;
            var delimiter = inputAndDelimiters.Item2;
            
            var ints = input
                .Split(delimiter)
                .Select(int.Parse)
                .Where(i => i <= 1000)
                .ToArray();

            CheckNegativeNumber(ints);

            return ints.Sum();
        }

        private static void CheckNegativeNumber(int[] ints)
        {
            var neg = ints.Where(i => i < 0).ToArray();
            if (neg.Any())
            {
                throw new InvalidExpressionException("Negatives not allowed: " + string.Join(",", neg));
            }
        }

        private static Tuple<string,char[]> ExtractDelimiter(string input)
        {
            if (input.Length < 4 || !input.StartsWith("//") || input[3] != '\n')
                return new Tuple<string, char[]>(input, _defaultDelimiters.ToArray());

            var allDelimitors = _defaultDelimiters.ToList();
            allDelimitors.Add(input[2]);
            return new Tuple<string, char[]>(input.Substring(4),allDelimitors.ToArray());
        }
    }
}