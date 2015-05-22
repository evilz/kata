using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace StringCalculator_csharp
{
    public class StringCalculatorTests
    {
        [Test]
        public void Add_Should_Return0_When_InputIsNullOrEmpty()
        {
            var calc = new StringCalculator();
            calc.Add(string.Empty);
        }
       
    //- The method can take 0, 1, or 2 numbers and will return their sum.
    //- An empty string will return 0. 
    //- Example inputs: "", "1", or "1,2" 
    //- Start with the simplest test case of an empty string. Then 1 number.Then 2 numbers.
    //- Remember to solve things as simply as possible, forcing yourself to write tests for things you didn't think about. 
    //- Remember to refactor after each passing test
    }
}
