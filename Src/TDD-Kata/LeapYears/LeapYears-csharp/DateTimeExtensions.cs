using System;

namespace LeapYears_csharp
{
    public static class DateTimeExtensions
    {
        public static bool IsLeapYear(this int year)
        {
            Func<int, int, bool> isMod = (number, divisor) => number % divisor == 0;
            return isMod(year, 400) || isMod(year, 4) && !isMod(year, 100);
        }
    }
}
