using System;
using System.Collections.Generic;
using System.Text;
using Utils;

namespace TDD.Diamond.Core
{
    public static class DiamondPrinter
    {
        public static IReadOnlyList<string> Print(char letter)
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

                var readOnlyLines = lines.AsReadOnly();

                return readOnlyLines;
            }
        }
    }
}