using NUnit.Framework;

namespace LeapYears_csharp
{
    [TestFixture]
    class LeapYearsTests
    {
        //A leap year is defined as one that is divisible by 4, but is not otherwise divisible by 100 unless it is also divisible by 400.

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void IsLeapYear_Should_Return_FalseByDefault(int year)
        {
            var result = year.IsLeapYear();
            Assert.IsFalse(result);
        }

        [TestCase(12)]
        [TestCase(16)]
        public void IsLeapYear_Should_Return_True_WhenYearIsDivisibleBy4(int year)
        {
            var result = year.IsLeapYear();
            Assert.IsTrue(result);
        }

        [TestCase(100)]
        [TestCase(200)]
        public void IsLeapYear_Should_Return_False_WhenYearIsDivisibleBy100(int year)
        {
            var result = year.IsLeapYear();
            Assert.IsFalse(result);
        }

        [TestCase(400)]
        [TestCase(800)]
        public void IsLeapYear_Should_Return_True_WhenYearIsDivisibleBy400(int year)
        {
            var result = year.IsLeapYear();
            Assert.IsTrue(result);
        }
    }
}
