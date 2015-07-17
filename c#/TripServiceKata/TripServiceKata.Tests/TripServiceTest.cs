using NUnit.Framework;
using TripServiceKata.Trip;

namespace TripServiceKata.Tests
{
    [TestFixture]
	public class TripServiceTest : IUsers
    {
		[Test]
		public void ShouldGetTripsForUser()
		{
			var tripService = new TripService(this);
			var trips = tripService.GetTripsByUser(new User.User());
			Assert.That(trips,Is.Not.Null);
		}

	    public User.User GetLoggedUser()
	    {
		    return new User.User();
	    }
    }
}
