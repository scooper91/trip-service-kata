using System.Collections.Generic;

namespace TripServiceKata.Trip
{
	public interface ITripDao
	{
		List<Trip> FindTripsByUser(User.User user);
	}
}