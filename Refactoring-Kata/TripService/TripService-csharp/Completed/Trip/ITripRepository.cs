using System.Collections.Generic;

namespace TripService_csharp.Completed.Trip
{
    public interface ITripRepository
    {
        IList<Trip> FindTripsByUser(User.User user);
    }
}