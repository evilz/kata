using NUnit.Framework;

namespace RomanNumerals_csharp
{
    public class RomanNumeralsTests
    {
        [TestCase(1, "I")]
        [TestCase(5, "V")]
        [TestCase(10, "X")]
        [TestCase(50, "L")]
        [TestCase(100, "C")]
        [TestCase(500, "D")]
        [TestCase(1000, "M")]

        public void ToRomanNumeral_Should_Return_SimpleLetter(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected, result);
        }

        [TestCase(2, "II")]
        [TestCase(3, "III")]
        [TestCase(20, "XX")]
        [TestCase(30, "XXX")]
        [TestCase(200, "CC")]
        [TestCase(300, "CCC")]
        [TestCase(2000, "MM")]
        [TestCase(3000, "MMM")]

        public void ToRomanNumeral_Should_RepeatUnitLetter(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected, result);
        }

        [TestCase(6, "VI")]
        [TestCase(7, "VII")]
        [TestCase(8, "VIII")]
        [TestCase(60, "LX")]
        [TestCase(700, "DCC")]
        public void ToRomanNumeral_Should_AddAndRepeatUnitLetterAfterMidVal(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected, result);
        }

        [TestCase(9, "IX")]
        [TestCase(90, "XC")]
        [TestCase(900, "CM")]
        public void ToRomanNumeral_Should_SubstractOneSmallValueFromLager(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected, result);
        }



        [TestCase(1903, "MCMIII")]
        public void ToRomanNumeral_Should_BreakNumberInDigit(int number, string expected)
        {
            var result = number.ToRomanNumeral();
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void ToRomanNumeralAndFromRomanNumeral_Should_RevertToInitialValue()
        {
            for (int i = 1; i < 3001; i++)
            {
                var roman = i.ToRomanNumeral();
                var revert = roman.FromRomanNumeral();
                Assert.AreEqual(i, revert);
            }
        }
    }
}
