using System.Collections.Generic;
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
	            if (user.IsFriendOf(loggedUser))
                {	                
	                tripList = _tripDao.FindTripsByUser(user);
                }
	            return tripList;
            }
		    throw new UserNotLoggedInException();
        }
    }
}
