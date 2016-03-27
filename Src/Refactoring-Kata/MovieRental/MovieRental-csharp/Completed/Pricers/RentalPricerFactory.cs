using System.Collections.Generic;

namespace MovieRental_csharp.Completed
{
    public static class RentalPricerFactory
    {
        private static readonly IDictionary<int, IRentalPricer> RentalPricers = new Dictionary<int, IRentalPricer>
        {
            {Movie.REGULAR, new RegularRentalPricer() },
            {Movie.CHILDRENS, new ChildrenRentalPricer() },
            {Movie.NEW_RELEASE, new NewReleaseRentalPricer() },

        };

        public static IRentalPricer GetPricer(int priceCode)
        {
            if(RentalPricers.ContainsKey(priceCode))
                return RentalPricers[priceCode];

            return RentalPricers[Movie.REGULAR];
        }
    }
}
