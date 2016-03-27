namespace MovieRental_csharp.Completed
{
    public class ChildrenRentalPricer : RegularRentalPricer
    {
        protected override double DefaultAmount => 1.5;
        protected override int MaxDayRented => 3;
        protected override double MalusByDays => 1.5;
    }
}