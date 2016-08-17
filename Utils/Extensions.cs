using System;
using System.Collections.Generic;

namespace Utils
{
    public static class Extensions
    {
        public static IEnumerable<TSource> WalkAround<TSource>(this TSource[,] source, Int32 centerX, Int32 centerY)
        {
            var rowLimit = source.GetLength(0) - 1;
            var columnLimit = source.GetLength(1) - 1;

            for (var x = Math.Max(0, centerX - 1); x <= Math.Min(centerX + 1, rowLimit); x++)
            {
                for (var y = Math.Max(0, centerY - 1); y <= Math.Min(centerY + 1, columnLimit); y++)
                {
                    if ((x != centerX) || (y != centerY))
                    {
                        yield return source[x, y];
                    }
                }
            }
        }

        public static Boolean IsBetween<TSource>(this TSource source, TSource lowerBound, TSource upperBound)
            where TSource : IComparable<TSource>
        {
            if (lowerBound.CompareTo(upperBound) > 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lowerBound));
            }
            else
            {
                return
                    (lowerBound.CompareTo(source) <= 0) &&
                    (source.CompareTo(upperBound) <= 0);
            }
        }
    }
}
