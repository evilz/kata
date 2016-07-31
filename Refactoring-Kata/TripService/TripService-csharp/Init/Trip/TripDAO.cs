using System.Collections.Generic;
using TripService_csharp.Init.Exception;

namespace TripService_csharp.Init.Trip
{
    public class TripDAO
    {
        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
