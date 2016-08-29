// 
// FooBarQixFixture.cs
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

using System.Collections.Generic;
using NUnit.Framework;
using TDD.FooBarQix.Core;

namespace TDD.FooBarQix.Test
{
    [TestFixture]
    public class FooBarQixFixture
    {
        private IReadOnlyList<string> _output;

        [SetUp]
        public void SetUp()
        {
            _output = Program.FooBarQix();
        }

        private void CheckExpectedNumberStringConsistency(byte number, string expectedNumberString)
        {
            var expected = expectedNumberString;
            var actual = Program.GetNumberString(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(9)]
        [TestCase(24)]
        public void Should_return_Foo_if_number_only_divisible_by_3(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Foo);
        }

        [TestCase(13)]
        [TestCase(23)]
        public void Should_return_Foo_if_number_only_contains_3(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Foo);
        }

        [TestCase(3)]
        public void Should_return_FooFoo_if_number_only_divisible_by_3_and_contains_3(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Foo + Program.Foo);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void Should_return_Bar_if_number_only_divisible_by_5(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Bar);
        }

        [TestCase(59)]
        [TestCase(58)]
        public void Should_return_Bar_if_number_only_contains_5(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Bar);
        }

        [TestCase(5)]
        public void Should_return_BarBar_if_number_only_divisible_by_5_and_contains_5(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Bar + Program.Bar);
        }

        [TestCase(14)]
        [TestCase(28)]
        public void Should_return_Bar_if_number_only_divisible_by_7(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Qix);
        }

        [TestCase(71)]
        [TestCase(74)]
        public void Should_return_Foo_if_number_only_contains_7(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Qix);
        }

        [TestCase(7)]
        public void Should_return_QixQix_if_number_only_divisible_by_7_and_contains_7(byte number)
        {
            CheckExpectedNumberStringConsistency(number, Program.Qix + Program.Qix);
        }
    }
}