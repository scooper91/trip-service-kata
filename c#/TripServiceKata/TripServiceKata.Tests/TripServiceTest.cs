using System.Collections.Generic;
using NUnit.Framework;
using TripServiceKata.Exception;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestFixture]
	public class TripServiceTest : IUsers, ITripDao
    {
	    private User.User _loggedInUser = new User.User();

	    [Test]
		public void ShouldHaveNoTripsWhenThereAreNoFriends()
		{
			var tripService = new TripService(this, this);
			var trips = tripService.GetTripsByUser(_loggedInUser);
			Assert.That(trips.Count,Is.EqualTo(0));
		}

		[Test]
		public void ShouldReturnFriendsTrips()
		{
			var userWithLoggedUserAsFriend = new User.User();
			userWithLoggedUserAsFriend.AddFriend(_loggedInUser);
			var tripService = new TripService(this, this);
			var trips = tripService.GetTripsByUser(userWithLoggedUserAsFriend);

			Assert.That(trips.Count, Is.EqualTo(1));
		}

	    public User.User GetLoggedUser()
	    {
		    return _loggedInUser;
	    }

	    public List<Trip.Trip> FindTripsByUser(User.User user)
	    {
		    return new List<Trip.Trip>
			    {
				    new Trip.Trip()
			    };
	    }
    }

	[TestFixture]
	public class TripServiceTestsWithNoLoggedUser : IUsers
	{
		[Test]
		public void ShouldThrowExceptionWhenNoLoggedInUser()
		{
			var tripService = new TripService(this, null);

			Assert.Throws<UserNotLoggedInException>(() => tripService.GetTripsByUser(new User.User()));
		}

		public User.User GetLoggedUser()
		{
			return null;
		}
	}
}
