using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace Minesweeper_csharp
{
    public class MinesweeperTests
    {
        [TestCase("3 5\r\n.....\r\n.....\r\n.....\r\n0 0", 3, 5)]
        [TestCase("2 1\r\n.\r\n.\r\n0 0", 2, 1)]
        public void Should_Parse_firstline_as_fieldsize(string input, int height, int width)
        {

            var minesweeper = Minesweeper.Parse(input.ToReader());

            var firstField = minesweeper.Fields.First();

            Assert.AreEqual(height, firstField.Height);
            Assert.AreEqual(width, firstField.Width);
        }

        [Test]
        public void Should_Parse_star_char_as_mine_cell()
        {
            var input = "1 1\r\n*0 0";

            TextReader reader = new StringReader(input);
            var minesweeper = Minesweeper.Parse(reader);

            var firstField = minesweeper.Fields.First();

            Assert.That(firstField.GetSolution(), Does.Contain("*"));
        }

        [Test]
        public void Should_Parse_dot_char_as_clear_cell()
        {
            var input = "1 1\r\n.0 0";

            TextReader reader = new StringReader(input);
            var minesweeper = Minesweeper.Parse(reader);

            var firstField = minesweeper.Fields.First();

            Assert.That(firstField.GetSolution(), Does.Contain("0"));
        }

        [TestCase("3 3\r\n...\r\n.*.\r\n...0 0", "111\r\n1*1\r\n111")]
        [TestCase("3 3\r\n***\r\n*.*\r\n***0 0", "***\r\n*8*\r\n***")]
        [TestCase("3 3\r\n*..\r\n...\r\n...0 0", "*10\r\n110\r\n000")]
        public void Should_Count_Neighbours_mine_cells(string input, string excpectedInOutput)
        {
            TextReader reader = new StringReader(input);
            var minesweeper = Minesweeper.Parse(reader);

            var firstField = minesweeper.Fields.First();

            Assert.That(firstField.GetSolution(), Does.Contain(excpectedInOutput));
        }

        [Test]
        public void Should_Parse_Expected_number_of_fields()
        {
            var input = @"4 4
*...
....
.*..
....
3 5
**...
.....
.*...
0 0";
            var minesweeper = Minesweeper.Parse(input.ToReader());


            Assert.AreEqual(2, minesweeper.Fields.Count());
        }

        [Test]
        public void Should_Return_fieldNumber_has_header_of_each_solution()
        {
            var input = @"4 4
*...
....
.*..
....
3 5
**...
.....
.*...
0 0";
            var minesweeper = Minesweeper.Parse(input.ToReader());

            Assert.That(minesweeper.GetSolution(), Does.StartWith("Field #1:" + Environment.NewLine));
            Assert.That(minesweeper.GetSolution(), Does.Contain("Field #2:" + Environment.NewLine));

        }

    }

    public static class Helpers
    {
        public static TextReader ToReader(this string input)
        {
            return new StringReader(input);
        }
    }
}
