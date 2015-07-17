using System.Collections.Generic;
using System.Linq;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
    public class TripService
    {
	    private readonly IUsers _users;
	    private readonly ITripDao _tripDao;

	    public TripService(IUsers users, ITripDao tripDao)
	    {
		    _users = users;
			_tripDao = tripDao;
	    }

	    public List<Trip> GetTripsByUser(User.User user)
        {
            var tripList = new List<Trip>();
            var loggedUser = _users.GetLoggedUser();
		    if (loggedUser != null)
            {
	            if (UserIsFriendOfLoggedUser(user, loggedUser))
                {	                
	                tripList = _tripDao.FindTripsByUser(user);
                }
	            return tripList;
            }
		    throw new UserNotLoggedInException();
        }

	    private static bool UserIsFriendOfLoggedUser(User.User user, User.User loggedUser)
	    {
		    return Enumerable.Contains(user.GetFriends(), loggedUser);
	    }
    }
}
