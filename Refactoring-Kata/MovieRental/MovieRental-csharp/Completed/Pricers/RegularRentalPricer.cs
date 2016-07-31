namespace MovieRental_csharp.Completed
{
    public class RegularRentalPricer : IRentalPricer
    {
        protected virtual double DefaultAmount => 2;
        protected virtual int MaxDayRented => 2;
        protected virtual double MalusByDays => 1.5;


        public virtual double GetAmount(int daysRented)
        {
            double thisAmount = DefaultAmount;
            if (daysRented > MaxDayRented)
                thisAmount += (daysRented - MaxDayRented) * MalusByDays;
            return thisAmount;
        }

        public virtual int GetFrequentRenterPoints(int daysRented)
        {
            return 1;
        }
    }
}