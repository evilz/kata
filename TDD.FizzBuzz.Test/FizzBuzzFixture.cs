// 
// FizzBuzzFixture.cs
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
using System.Collections.ObjectModel;
using NUnit.Framework;
using TDD.FizzBuzz.Core;

namespace TDD.FizzBuzz.Test
{
    [TestFixture]
    public class FizzBuzzFixture
    {
        [SetUp]
        public void SetUp()
        {
            this._output = Program.FizzBuzz();
        }

        private ReadOnlyCollection<String> _output;

        [TestCase]
        public void Should_output_100_items()
        {
            var expected = 100;
            var actual = this._output.Count;

            Assert.AreEqual(expected, actual);
        }

        [TestCase(3)]
        [TestCase(9)]
        public static void Should_print_Fizz_if_number_multiple_of_3_only(Int32 number)
        {
            var expected = Program.Fizz;
            var actual = Program.GetNumberString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(5)]
        [TestCase(10)]
        public static void Should_print_Buzz_if_number_multiple_of_5_only(Int32 number)
        {
            var expected = Program.Buzz;
            var actual = Program.GetNumberString(number);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(15)]
        [TestCase(45)]
        public static void Should_print_FizzBuzz_if_number_multiple_of_3_and_5(Int32 number)
        {
            const String expected = Program.Fizz + Program.Buzz;
            var actual = Program.GetNumberString(number);

            Assert.AreEqual(expected, actual);
        }
    }
}