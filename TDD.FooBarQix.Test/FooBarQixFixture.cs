﻿// 
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

using System;
using System.Collections.Generic;
using NUnit.Framework;
using TDD.FooBarQix.Core;

namespace TDD.FooBarQix.Test
{
    [TestFixture]
    public class FooBarQixFixture
    {
        private IReadOnlyList<String> _output;

        [SetUp]
        public void SetUp()
        {
            _output = Program.FooBarQix();
        }

        private void CheckExpectedNumberStringConsistency(Byte number, String expectedNumberString)
        {
            var expected = expectedNumberString;
            var actual = Program.GetNumberString(number);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(9)]
        [TestCase(24)]
        public void Should_return_Foo_if_number_only_divisible_by_3(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Foo);
        }

        [TestCase(13)]
        [TestCase(23)]
        public void Should_return_Foo_if_number_only_contains_3(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Foo);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void Should_return_Bar_if_number_only_divisible_by_5(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Bar);
        }

        [TestCase(51)]
        [TestCase(57)]
        public void Should_return_Foo_if_number_only_contains_5(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Bar);
        }

        [TestCase(14)]
        [TestCase(28)]
        public void Should_return_Bar_if_number_only_divisible_by_7(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Qix);
        }

        [TestCase(71)]
        [TestCase(74)]
        public void Should_return_Foo_if_number_only_contains_7(Byte number)
        {
            this.CheckExpectedNumberStringConsistency(number, Program.Qix);
        }
    }
}