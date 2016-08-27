// 
// DiamondFixture.cs
// 
// Author:
//       Ehouarn Perret <ehouarn.perret@outlook.com>
// 
// Copyright (c) 2016 Ehouarn Perret
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using TDD.Diamond.Core;

namespace TDD.Diamond.Test
{
    [TestFixture]
    public class DiamondFixture
    {
        private void CheckExpectedActualDiamonds(IReadOnlyList<string> expectedLines, IReadOnlyList<string> actualLines)
        {
            CollectionAssert.AreEqual(expectedLines, actualLines);
        }

        [Test]
        public void Should_return_diamond_with_one_A_only()
        {
            var letter = 'A';

            var actualLines = DiamondPrinter.Print(letter);
            var expectedLines = new[] {"A"};

            CheckExpectedActualDiamonds(expectedLines, actualLines);
        }

        [TestCase('c')]
        [TestCase('3')]
        [TestCase('+')]
        public void Should_throw_exception_if_invalid_character_is_given(char letter)
        {
            Assert.Throws<ArgumentException>(() => DiamondPrinter.Print(letter));
        }

        [TestCase('A', new [] { "A" })]
        [TestCase('B', new [] { " A ", "B B", " A " })]
        [TestCase('C', new [] { "  A  ", " B B ", "C   C", " B B ", "  A  " })]
        public void Should_return_relevant_diamond_letters_pattern(char letter, IReadOnlyList<string> expectedLines)
        {
            var actualLines = DiamondPrinter.Print(letter);

            CheckExpectedActualDiamonds(actualLines, expectedLines);
        }

        [TestCase('A', 1)]
        [TestCase('B', 3)]
        [TestCase('C', 5)]
        public void Should_return_proper_width_diamond(char letter, int expectedWidth)
        {
            var actualLines = DiamondPrinter.Print(letter);

            Assert.IsTrue(actualLines.All(item => item.Length == expectedWidth));
        }
    }
}