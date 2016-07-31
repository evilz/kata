using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FooBarQix_csharp
{
    public class FooBarQixTests
    {
        [TestCase(1)]
        [TestCase(2)]
        public void FooBarQix_Should_Return_NumberAsString(int number)
        {
           var result = number.FooBarQix();
            Assert.AreEqual(number.ToString(),result);
        }

        [TestCase(6)]
        [TestCase(9)]
        public void FooBarQix_Should_WriteFoo_WhenNumberIsDivisibleBy3(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("foo", result);
        }

        [TestCase(10)]
        [TestCase(20)]
        public void FooBarQix_Should_WriteBar_WhenNumberIsDivisibleBy5(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("bar", result);
        }

        [TestCase(14)]
        public void FooBarQix_Should_WriteQix_WhenNumberIsDivisibleBy7(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("qix", result);
        }

        [TestCase(13)]
        [TestCase(23)]
        public void FooBarQix_Should_WriteFoo_WhenNumberContains3(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("foo", result);
        }

        [TestCase(52)]
        public void FooBarQix_Should_WriteBar_WhenNumberContains5(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("bar", result);
        }

        [TestCase(17)]
        [TestCase(47)]
        public void FooBarQix_Should_WriteQix_WhenNumberContains7(int number)
        {
            var result = number.FooBarQix();
            Assert.AreEqual("qix", result);
        }

        [TestCase(51,"foobar")]
        public void FooBarQix_Should_WatchDividerBeforeContent(int number,string expected)
        {
            var result = number.FooBarQix();
            Assert.AreEqual(expected, result);
        }

        [TestCase(53, "barfoo")]
        public void FooBarQix_Should_WatchContentInOrder(int number, string expected)
        {
            var result = number.FooBarQix();
            Assert.AreEqual(expected, result);
        }

        [TestCase(21, "fooqix")]
        public void FooBarQix_Should_DivideInOrder3_5_7(int number, string expected)
        {
            var result = number.FooBarQix();
            Assert.AreEqual(expected, result);
        }
        

        [TestCase(15, "foobarbar")]
        [TestCase(33, "foofoofoo")]
        
        public void FooBarQix_Should_DivideInOrder3_5_7_And_Then_WatchInOrder(int number, string expected)
        {
            var result = number.FooBarQix();
            Assert.AreEqual(expected, result);
        }
    }
}
