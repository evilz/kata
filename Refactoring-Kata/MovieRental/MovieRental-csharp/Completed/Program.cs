using System;

namespace MovieRental_csharp.Completed
{
    class Program
    {
        static void Main(string[] args)
        {
            Movie movie = new Movie("Transformer", Movie.REGULAR);
		
		    Rental rental = new Rental(movie, 3);
		
		    Customer customer = new Customer("jpartogi");
		    customer.AddRental(rental);
		
		    String statement = customer.Statement();
            System.Console.WriteLine(statement);
        }
    }
}
