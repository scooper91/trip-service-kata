using NUnit.Framework;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestFixture]
	public class TripServiceTest : IUsers
    {
		[Test]
		public void ShouldHaveNoTripsWhenThereAreNoFriends()
		{
			var tripService = new TripService(this);
			var trips = tripService.GetTripsByUser(new User.User());
			Assert.That(trips.Count,Is.EqualTo(0));
		}

	    public User.User GetLoggedUser()
	    {
		    return new User.User();
	    }
    }
}
