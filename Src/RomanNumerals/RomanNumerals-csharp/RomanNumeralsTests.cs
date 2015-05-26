using NUnit.Framework;

namespace RomanNumerals_csharp
{

    public class RomanNumeralsTests
    {
        [TestCase(1,"I")]

        public void ToRomanNumeral_Should_Return_SimpleLetter(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected,result);
        }
    }
}
