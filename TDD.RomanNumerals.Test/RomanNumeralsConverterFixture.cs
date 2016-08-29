// 
// RomanNumeralsConverterFixture.cs
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

namespace TDD.RomanNumerals.Test
{
    [TestFixture]
    public class RomanNumeralsConverterFixture
    {
        private void CheckExpectedConversion(int n, string expectedRomanNumerals)
        {
            var actualRomanNumerals = RomanNumeralsConverter.ToString(n);
                
            Assert.AreEqual(expectedRomanNumerals, actualRomanNumerals);
        }

        [Test]
        public void Should_not_return_special_characters_more_than_3_times_in_a_row()
        {
            var specialCharacters = new[] {"I", "X", "C", "M"};

            for (var i = 0; i < 3000; i++)
            {
                var actual = RomanNumeralsConverter.Convert();
            }
        }

        public void Should_not_return()
        {
            
        }
    }

    public static class RomanNumeralsConverter
    {
        public static IReadOnlyList<RomanNumerals> ToNumerals(int n)
        {
            throw new NotImplementedException();
        }

        public static string ToString(int n)
        {
            var romanNumerals = ToNumerals(n);

            var str = string.Join(string.Empty, romanNumerals);

            return str;
        }
    } 
}