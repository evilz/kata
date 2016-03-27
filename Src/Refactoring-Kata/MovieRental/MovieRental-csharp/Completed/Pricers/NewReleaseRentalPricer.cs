namespace MovieRental_csharp.Completed
{
    public class NewReleaseRentalPricer : RegularRentalPricer
    {
        protected override double DefaultAmount => 3;
        protected override int MaxDayRented => 1;
        protected override double MalusByDays => 3;
        
        public override int GetFrequentRenterPoints(int daysRented)
        {
            return daysRented > 1 
                ? 2 
                : 1;
        }
    }
}