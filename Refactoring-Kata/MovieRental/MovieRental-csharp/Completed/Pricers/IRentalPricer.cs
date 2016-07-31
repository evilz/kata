namespace MovieRental_csharp.Completed
{
    public interface IRentalPricer
    {
        double GetAmount(int daysRented);
        int GetFrequentRenterPoints(int daysRented);
    }
}