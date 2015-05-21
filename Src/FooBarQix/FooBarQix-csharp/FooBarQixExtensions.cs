using System;

namespace FooBarQix_csharp
{
    public static class FooBarQixExtensions
    {
        public static string FooBarQix(this int number)
        {
            string result = String.Empty;

            string s = number.ToString();
            Func<int, int, bool> isMod = (n, d) => n%d == 0;

            if (isMod(number, 3))
            {
                result += "foo";
            }
            if (isMod(number, 5))
            {
                result += "bar";
            }
            if (isMod(number, 7))
            {
                result += "qix";
            }

            foreach (var c in s)
            {
                if (c == '3')
                {
                    result += "foo";
                }

                if (c == '5')
                {
                    result += "bar";
                }

                if (c == '7')
                {
                    result += "qix";
                }
            }
            

            return string.IsNullOrEmpty(result) ? number.ToString() : result;
        }
    }
}
