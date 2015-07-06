using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Diamond_csharp
{
    public class Diamond
    {
        public static string Create(char c)
        {
            // only A
            c = c.ToString().ToUpperInvariant()[0];
            if (c == 'A') return c.ToString();

            int width = c - '@';
            
            var sb = new StringBuilder();


            // first
            sb.Append("A".PadLeft(width) + Environment.NewLine);
            
            for (int i = 1; i < width; i++)
            {
                sb.Append(WriteLine(width, i));
            }
            for (int i = width - 2; i > 0; i--)
            {
                sb.Append(WriteLine(width, i));
            }

            // last
            sb.Append("A".PadLeft(width));

            return sb.ToString();
        }

        private static string WriteLine(int width, int i)
        {
            var currentChar = ((char)('A' + i)).ToString();
            var padding = width - i;
            var line = currentChar.PadLeft(padding) + currentChar.PadLeft(2 * (width - padding)) + Environment.NewLine;
            Debug.Write(line);
            return line;
        }
    }
}