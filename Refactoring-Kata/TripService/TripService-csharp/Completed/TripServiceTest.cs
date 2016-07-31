using System;
using NSubstitute;
using NUnit.Framework;
using TripService_csharp.Completed.Exception;
using TripService_csharp.Completed.Trip;
using TripService_csharp.Completed.User;

namespace TripService_csharp.Completed
{
    public class TripServiceTest
    {
         User.User currentUser;
        User.User friend;
        User.User loggedUser;

        private TripService _tripService = null;

        [SetUp]
        public void Setup()
        {
            currentUser = new User.User();
            friend = new User.User();
            loggedUser = new User.User();

            friend.AddTrip(new Trip.Trip());
            friend.AddTrip(new Trip.Trip());
            currentUser.AddFriend(friend);
            
            var userSession = Substitute.For<IUserSession>();
            userSession.GetLoggedUser().Returns(info => loggedUser);

            var tripRepository = Substitute.For<ITripRepository>();
            tripRepository.FindTripsByUser(Arg.Any<User.User>()).Returns(info =>  info.Arg<User.User>().Trips());

            _tripService = new TripService(userSession,tripRepository);
        }

        [Test]
        public void Should_throw_UserNotLoggedInException_when_user_session_does_not_return_any_logged_used()
        {
            loggedUser = null;
            Assert.That(() => _tripService.GetTripsByUser(new User.User()), Throws.TypeOf<UserNotLoggedInException>());
        }

        [Test]
        public void Should_throw_NullReferenceException_when_user_is_null()
        {
            Assert.That(() => _tripService.GetTripsByUser(null), Throws.TypeOf<NullReferenceException>());
        }

        [Test]
        public void Should_return_empty_list_when_logged_user_is_not_a_friend()
        {
            loggedUser = new User.User();

            var result = _tripService.GetTripsByUser(currentUser);

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void Should_return_user_trips_when_logged_user_is_friend()
        {
            loggedUser = friend;

            var result = _tripService.GetTripsByUser(currentUser);

            Assert.That(result, Is.EqualTo(currentUser.Trips()));
        }
    }
}
