using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Trip;

namespace TripServiceKata.User
{
    public class User
    {
        private List<Trip.Trip> trips = new List<Trip.Trip>();
        private List<User> friends = new List<User>();

        public List<User> GetFriends()
        {
            return friends;
        } 

        public void AddFriend(User user)
        {
            friends.Add(user);
        }

        public void AddTrip(Trip.Trip trip)
        {
            trips.Add(trip);
        }

        public List<Trip.Trip> Trips()
        {
            return trips;
        }

	    public bool IsFriendOf(User loggedUser)
	    {
		    return Enumerable.Contains(GetFriends(), loggedUser);
	    }

	    public List<Trip.Trip> GetFriendsTrips(User user, ITripDao tripDao)
	    {
		    var tripList = new List<Trip.Trip>();
		    if (IsFriendOf(user))
		    {
			    tripList = tripDao.FindTripsByUser(this);
		    }
		    return tripList;
	    }
    }
}
