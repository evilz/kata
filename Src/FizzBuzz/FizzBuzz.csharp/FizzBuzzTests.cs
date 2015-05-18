using Xunit;

namespace FizzBuzz.csharp
{
   
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void Number_Should_Be_ReturnAsString(int value)
        {
            var result = value.FizzBuzz();
            Assert.Equal<string>(value.ToString(), result);
        }

        [Theory]
        [InlineData(3)]
        [InlineData(6)]
        [InlineData(9)]
        public void ModOf3_Should_Be_ReplaceByFizz(int value)
        {
            var result = value.FizzBuzz();
            Assert.Equal<string>("Fizz",result);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(10)]
        [InlineData(20)]
        public void ModOf5_Should_Be_ReplaceByBuzz(int value)
        {
            var result = value.FizzBuzz();
            Assert.Equal<string>("Buzz", result);
        }

        [Theory]
        [InlineData(15)]
        [InlineData(30)]
        [InlineData(45)]
        public void ModOf3And5_Should_Be_ReplaceByFizzBuzz(int value)
        {
            var result = value.FizzBuzz();
            Assert.Equal<string>("FizzBuzz", result);
        }


    }
}
