using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Utils
{
    public static class Extensions
    {
        public static IEnumerable<TSource> WalkAround<TSource>(this TSource[,] source, int centerX, int centerY)
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

        public static IReadOnlyList<T> AsReadOnly<T>(this IList<T> source)
        {
            var readOnlyList = new ReadOnlyCollection<T>(source);

            return readOnlyList;
        }

        public static void Reset(this StringBuilder stringBuilder, char character)
        {
            var length = stringBuilder.Length;
            stringBuilder.Clear();
            stringBuilder.Append(character, length);
        }

        public static int MaxCountRepetitions(this string source, char character)
        {
            var isPreviousChar = source[0] == character;

            var currentCount = isPreviousChar ? 1 : 0;
            var maxCount = currentCount;

            for (var i = 1; i < source.Length; i++)
            {
                var currentChar = source[i];

                isPreviousChar = source[0] == character;

                if (!isPreviousChar)
                {
                    currentCount = 1;
                }

                if (currentChar == character)
                {
                    currentCount++;

                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                    }
                }
            }

            return maxCount;
        }
    }
}
