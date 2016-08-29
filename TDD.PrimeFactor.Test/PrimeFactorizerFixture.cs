// 
// PrimeFactorizerFixture.cs
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
using TDD.PrimeFactors.Core;

namespace TDD.PrimeFactors.Test
{
    [TestFixture]
    public class PrimeFactorizerFixture
    {
        private void CheckExpectedActualPrimeFactors(int n, IReadOnlyList<int> expectedPrimeFactors)
        {
            var actualPrimeFactors = PrimeFactorizer.Factorize(n);

            CollectionAssert.AreEqual(expectedPrimeFactors, actualPrimeFactors);
        }

        [Test]
        public void Should_return_no_primer_numbers()
        {
            var n = 1;
            var expectedPrimeFactors = new int[0];
            CheckExpectedActualPrimeFactors(n, expectedPrimeFactors);
        }

        [TestCase(2)]
        [TestCase(41)]
        [TestCase(67)]
        [TestCase(19)]
        public void Should_return_given_number_if_prime_number(int n)
        {
            var expectedPrimeFactors = new[] {n};
            CheckExpectedActualPrimeFactors(n, expectedPrimeFactors);   
        }

        [TestCase(14, 2, 7)]
        [TestCase(6, 2, 3)]
        [TestCase(32, 2, 2, 2, 2, 2)]
        [TestCase(258, 2, 3, 43)]
        public void Should_return_prime_number_factors_accordingly(int n, params int[] expectedPrimeFactors)
        {
            CheckExpectedActualPrimeFactors(n, expectedPrimeFactors);
        }
    }
}