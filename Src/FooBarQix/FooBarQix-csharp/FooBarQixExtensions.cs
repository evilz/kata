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
                            .Where(i => number%i == 0)
                            .Aggregate(string.Empty, (current, i) => current + _fooBarQixMap[i]);

            result = number.ToString()
                        .Where(c => _fooBarQixMap.ContainsKey(c-'0'))
                        .Aggregate(result, (current, c) => current + _fooBarQixMap[c - '0']);


            return string.IsNullOrEmpty(result) ? number.ToString() : result;
        }
    }
}
