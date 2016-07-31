namespace MovieRental_csharp.Completed
{
    public class Rental
    {
        public Movie Movie { get; }
        public int DaysRented { get; }

        public Rental(Movie movie, int daysRented)
        {
            Movie = movie;
            DaysRented = daysRented;
        }

        public override string ToString()
        {
            return $"\t{Movie.Title}\t{Amount}\n";
        }
        
        public double Amount => RentalPricerFactory.GetPricer(Movie.PriceCode).GetAmount(DaysRented);

        public int FrequentRenterPoints() => RentalPricerFactory.GetPricer(Movie.PriceCode).GetFrequentRenterPoints(DaysRented);
    }
}