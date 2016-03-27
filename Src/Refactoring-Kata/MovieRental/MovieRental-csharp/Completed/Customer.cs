using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieRental_csharp.Completed
{
    public class Customer
    {
        private readonly List<Rental> Rentals = new List<Rental>();
        
        public string Name { get; }
        
        public Customer(string name)
        {
            Name = name;
        }

        public void AddRental(Rental rental)
        {
            Rentals.Add(rental);
        }

        private int TotalFrequentRenterPoints => Rentals.Sum(r => r.FrequentRenterPoints());
        private double TotalAmount => Rentals.Sum(r => r.Amount);

        public string Statement()
        {
            var result = new StringBuilder();
            result.Append($"Rental Record for {Name}\n");
            result.Append(string.Join(string.Empty,Rentals));
            result.Append($"Amount owed is {TotalAmount}\n");
            result.Append($"You earned {TotalFrequentRenterPoints} frequent renter points");

            return result.ToString();
        }
    }
}
