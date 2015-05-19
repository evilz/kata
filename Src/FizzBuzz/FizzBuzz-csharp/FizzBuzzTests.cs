using NUnit.Framework;

namespace FizzBuzz_csharp.Tests
{
    [TestFixture]
    public class FizzBuzzTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void FizzBuzz_Should_Return_NumberAsString(int input)
        {
            var result = input.FizzBuzz();
            Assert.AreEqual(input.ToString(),result);
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        public void FizzBuzz_Should_Return_Fizz_When_NumberIsDivisibleBy3(int input)
        {
            var result = input.FizzBuzz();
            Assert.AreEqual("Fizz", result);
        }
    }
}
