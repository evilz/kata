using System;
using NUnit.Framework;

namespace MovieRental_csharp.Init
{
    public class UnitTest
    {
        [Test]
        public void TestStatement()
        {
            Movie movie = new Movie("Transformer", Movie.REGULAR);

            Rental rental = new Rental(movie, 3);

            Customer customer = new Customer("jpartogi");
            customer.AddRental(rental);

            String statement = customer.Statement();
            StringAssert.Contains("Transformer", statement);
        }
    }
}
