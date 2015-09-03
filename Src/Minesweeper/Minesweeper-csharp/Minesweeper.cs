using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Minesweeper_csharp
{
    public class Minesweeper
    {
        private readonly List<Field> _fields = new List<Field>();

        private Minesweeper() { }

        private void ParseField(TextReader reader)
        {
            var field = Field.ParseField(reader);
            if (field.IsValid) { _fields.Add(field); }
        }

        public IEnumerable<Field> Fields => _fields;

        public static Minesweeper Parse(TextReader reader)
        {
            var minesweeper = new Minesweeper();
            while (reader.Peek() != -1)
            {
                minesweeper.ParseField(reader);
            }

            return minesweeper;
        }

        public string GetSolution()
        {
            var allSolutions = Fields.Select(
                 (field, i) => $"Field #{i + 1}:{Environment.NewLine}{field.GetSolution()}");

            return string.Join(Environment.NewLine, allSolutions);
        }
    }
}