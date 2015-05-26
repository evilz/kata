using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator_csharp
{
    public class StringCalculatorTests
    {
        StringCalculator _calc = new StringCalculator();

        [Test]
        public void Add_Should_Return0_When_InputIsNullOrEmpty()
        {
            var result = _calc.Add(string.Empty);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Add_Should_ReturnSum_When_InputIsOneNumber()
        {
            var result = _calc.Add("3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_Should_ReturnSum_When_InputIs2Numbers()
        {
            var result = _calc.Add("3,8");
            Assert.AreEqual(11, result);
        }

        [Test]
        public void Add_Should_HandleManyNumbers()
        {
            var result = _calc.Add("3,8,2,7");
            Assert.AreEqual(20, result);
        }

        [Test]
        public void Add_Should_Handle_CommasAndNewLine()
        {
            var result = _calc.Add("1\n2,3");
            Assert.AreEqual(6, result);
        }

        [Test]
        public void Add_Should_Handle_SpecifiedSeparator()
        {
            var result = _calc.Add("//;\n1;2");
            Assert.AreEqual(3, result);
        }

        [Test]
        public void ExtractDelimiter_Should_AddDelimiterToList()
        {
            var emptyList = new List<char>();
            var numberOnly = _calc.ExtractDelimiter("//;\n1;2", emptyList);
            Assert.AreEqual(1, emptyList.Count);
            Assert.AreEqual(';', emptyList[0]);
            Assert.AreEqual("1;2", numberOnly);
        }
        
        [TestCase("-1,2", "Negatives not allowed: -1")]
        [TestCase("2,-4,3,-5", "Negatives not allowed: -4,-5")]
        public void Add_Should_Throw_NegativesNotAllowed_when_AnyNegativeNumver(string numbers, string errorMessage)
        {
            var ex = Assert.Throws<InvalidExpressionException>(() => _calc.Add(numbers));
            Assert.AreEqual(errorMessage,ex.Message);
        }

        [TestCase("1001,2")]
        public void Add_Should_IgnoreNumber_When_GreaterThan1000(string numbers)
        {
            var result = _calc.Add(numbers);
            Assert.AreEqual(4, result);
        }
       
    }
}
