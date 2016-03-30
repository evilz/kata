using System.Collections.Generic;
using TripService_csharp.Init.Exception;
using TripService_csharp.Init.User;

namespace TripService_csharp.Init.Trip
{
    public class TripService
    {
        public List<TripService_csharp.Init.Trip.Trip> GetTripsByUser(User.User user)
        {
            List<TripService_csharp.Init.Trip.Trip> tripList = new List<TripService_csharp.Init.Trip.Trip>();
            User.User loggedUser = UserSession.GetInstance().GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach(User.User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {
                    tripList = TripDAO.FindTripsByUser(user);
                }
                return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
