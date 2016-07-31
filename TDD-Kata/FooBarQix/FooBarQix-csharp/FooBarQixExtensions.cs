using System;
using System.Collections.Generic;
using System.Linq;

namespace FooBarQix_csharp
{
    public static class FooBarQixExtensions
    {

        private static readonly Dictionary<int, string> _fooBarQixMap = new Dictionary<int, string>
            {
                {3,"foo" },
                {5,"bar" },
                {7,"qix" }
            };

        public static string FooBarQix(this int number)
        {
            var result = _fooBarQixMap.Keys
                            .Where(i => IsDivisible(number, i))
                            .Aggregate(string.Empty, (current, i) => current + _fooBarQixMap[i]);

            result = number.ToString()
                        .Where(HasFooBarQixReplacer())
                        .Aggregate(result, (current, c) => current + GetReplacerFromChar(c));


            return string.IsNullOrEmpty(result) ? number.ToString() : result;
        }

        private static bool IsDivisible(int number, int i)
        {
            return number%i == 0;
        }

        private static Func<char, bool> HasFooBarQixReplacer()
        {
            return c => _fooBarQixMap.ContainsKey(IntFromChar(c));
        }

        private static string GetReplacerFromChar(char c)
        {
            return _fooBarQixMap[IntFromChar(c)];
        }

        private static int IntFromChar(char c)
        {
            return c-'0';
        }
    }
}
