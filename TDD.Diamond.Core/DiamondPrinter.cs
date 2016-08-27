using System;
using System.Text;

namespace TDD.Diamond.Core
{
    public static class DiamondPrinter
    {
        public static string[] Print(char letter)
        {
            if (!char.IsLetter(letter) || char.IsLower(letter))
            {
                throw new ArgumentException(nameof(letter));
            }
            else
            {
                var difference = letter - 'A';
                var currentLetter = 'A';

                var width = difference * 2 + 1;
                var stringBuilder = new StringBuilder(width);
                stringBuilder.Append(' ', width);

                var lines = new string[width];

                for (var i = 0; i <= difference; i++)
                {
                    var borderPadding = difference - i;
                    var centerPadding = width - 2 * borderPadding - 1;

                    stringBuilder[borderPadding] = currentLetter;
                    stringBuilder[borderPadding + centerPadding] = currentLetter;

                    lines[i] = lines[lines.Length - 1 - i] = stringBuilder.ToString();
                    stringBuilder.Reset(' ');
                    currentLetter++;
                }

                return lines;
            }
        }
    }

    public static class StringBuilderExtensions
    {
        public static void Reset(this StringBuilder stringBuilder, char character)
        {
            var length = stringBuilder.Length;
            stringBuilder.Clear();
            stringBuilder.Append(character, length);
        }
    }
}