// 
// DateTimeExtensionsFixture.cs
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
using NUnit.Framework;

namespace TDD.LeapYears.Test
{
    [TestFixture]
    public class DateTimeExtensionsFixture
    {
        [TestCase(42)]
        [TestCase(1850)]
        public void Should_not_throw_exception_if_year_is_positive(Int32 year)
        {
            Assert.DoesNotThrow(() => DateTime.IsLeapYear(year));
        }

        [TestCase(-42)]
        [TestCase(-1750)]
        public void Should_throw_out_of_range_exception_if_year_is_negative(Int32 year)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DateTime.IsLeapYear(year));
        }

        [TestCase(2001)]
        public void Should_return_false_if_year_not_divisible_by_4(Int32 year)
        {
            var actual = DateTime.IsLeapYear(year);
            Assert.IsFalse(actual);
        }

        [TestCase(1996)]
        public void Should_return_true_if_year_divisible_by_4_and_not_divisible_by_100(Int32 year)
        {
            var actual = DateTime.IsLeapYear(year);
            Assert.IsTrue(actual);
        }

        [TestCase(1900)]
        public void Should_return_false_if_year_divisible_by_4_and_not_divisible_by_400(Int32 year)
        {
            var actual = DateTime.IsLeapYear(year);
            Assert.IsFalse(actual);
        }

        [TestCase(2000)]
        public void Should_return_true_if_year_not_divisible_by_400_and_not_divisible_by_4_and_not_divisible_by_100(Int32 year)
        {
            var actual = DateTime.IsLeapYear(year);
            Assert.IsTrue(actual);
        }
    }
}