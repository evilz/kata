using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    public static class Extensions
    {
        public static IEnumerable<T> WalkAround<T>(this T[, ] source, Int32 centerX, Int32 centerY)
        {
            var rowCount = source.GetLength(0);
            var columnCount = source.GetLength(1);

            for (var x = Math.Max(0, centerX - 1); x <= Math.Min(centerX + 1, rowCount); x++)
            {
                for (var y = Math.Max(0, centerY - 1); y <= Math.Min(centerY + 1, columnCount); y++)
                {
                    if ((x != centerX) || (y != centerY))
                    {
                        yield return source[x, y];
                    }
                }
            }
        } 
    }
}
