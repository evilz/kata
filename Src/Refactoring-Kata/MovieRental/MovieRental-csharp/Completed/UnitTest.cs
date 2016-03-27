using System;
using ApprovalTests.Reporters;
using NUnit.Framework;

namespace MovieRental_csharp.Completed
{
    public class UnitTest
    {
        [Test]
        [UseReporter(typeof(DiffReporter))]
        public void TestStatement()
        {
            Customer customer = new Customer("jpartogi");

            customer.AddNewRental("REGULAR3", Movie.REGULAR, 3);
            customer.AddNewRental("REGULAR1", Movie.REGULAR, 1);
            customer.AddNewRental("NEW_RELEASE3", Movie.NEW_RELEASE, 3);
            customer.AddNewRental("NEW_RELEASE1", Movie.NEW_RELEASE, 1);
            customer.AddNewRental("CHILDRENS1", Movie.CHILDRENS, 1);
            customer.AddNewRental("CHILDRENS5", Movie.CHILDRENS, 5);
            
            var statement = customer.Statement();
            ApprovalTests.Approvals.Verify(statement);
        }


    }

    public static class TestHelpers
    {
        public static void AddNewRental(this Customer customer, string title, int priceCode, int daysRented)
        {
            var movie = new Movie(title, priceCode);
            var rental = new Rental(movie, daysRented);
            customer.AddRental(rental);
        }
    }
}
