using TripService_csharp.Completed.Exception;

namespace TripService_csharp.Completed.User
{
    public interface IUserSession
    {
        User GetLoggedUser();
    }

    public class UserSession : IUserSession
    {
        private static readonly UserSession userSession = new UserSession();

        private UserSession() { }

        public static UserSession GetInstance()
        {
            return userSession;
        }

        public bool IsUserLoggedIn(User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.IsUserLoggedIn() should not be called in an unit test");
        }

        public User GetLoggedUser()
        {
            throw new DependendClassCallDuringUnitTestException(
                "UserSession.GetLoggedUser() should not be called in an unit test");
        }
    }
}
