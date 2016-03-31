using System.Collections.Generic;
using System.Linq;
using TripService_csharp.Completed.Exception;
using TripService_csharp.Completed.User;

namespace TripService_csharp.Completed.Trip
{
    public class TripService
    {
        private readonly IUserSession _userSession;
        private readonly ITripRepository _tripRepository;

        public TripService() :this(UserSession.GetInstance(), new TripDAO())
        {
            
        }

        public TripService(IUserSession userSession, ITripRepository tripRepository)
        {
            _userSession = userSession;
            _tripRepository = tripRepository;
        }


        public IList<Trip> GetTripsByUser(User.User user)
        {
            return user.GetFriends().Contains(LoggedUser) 
                ? _tripRepository.FindTripsByUser(user) 
                : new List<Trip>();
        }

        private User.User LoggedUser
        {
            get
            {
                var loggedUser = _userSession.GetLoggedUser();
                if (loggedUser == null) throw new UserNotLoggedInException();
                return loggedUser;
            }
        }
    }
}
