using System.Collections.Generic;
using TripService_csharp.Completed.Exception;

namespace TripService_csharp.Completed.Trip
{
    public class TripDAO : ITripRepository
    {
        IList<Trip> ITripRepository.FindTripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }

        public static List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
