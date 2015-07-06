using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace PrimeFactor_csharp
{
    public class PrimeFactorTests
    {
        [TestCase(-1)]
        [TestCase(0)]
        [TestCase(1)]
        public void Should_Return_empty_list_When_number_is_less_or_equal_to_one(int number)
        {
            CollectionAssert.IsEmpty(PrimeFactors.Generate(number));
        }
        
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(5)]
        public void Should_Return_input_number_When_number_is_a_prime_number(int number)
        {
            CollectionAssert.AreEquivalent(new List<int> { number }, PrimeFactors.Generate(number));
        }

        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        public void Should_Return_list_of_lower_primes_When_number_is_not_a_prime_number(int number)
        {
            Assert.IsTrue(PrimeFactors.Generate(number).All(factor => factor < number));
        }


        [Test]
        public void Should_Return_multiplication_of_factors_equals_to_number()
        {
            for (int i = 2; i < 100; i++)
            {
                Assert.AreEqual(i, PrimeFactors.Generate(i).Mult());
            }

        }
    }
    public static class NumberExt
    {
        public static int Mult(this IEnumerable<int> source)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            int num1 = 1;
            foreach (int num2 in source)
                checked { num1 *= num2; }
            return num1;

        }
    }
}
