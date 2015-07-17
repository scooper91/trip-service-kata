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
            List<Trip> tripList = new List<Trip>();
            var loggedUser = _users.GetLoggedUser();
            bool isFriend = false;
            if (loggedUser != null)
            {
                foreach(User.User friend in user.GetFriends())
                {
                    if (friend.Equals(loggedUser))
                    {
                        isFriend = true;
                        break;
                    }
                }
                if (isFriend)
                {	                
	                tripList = _tripDao.FindTripsByUser(user);
                }
	            return tripList;
            }
            else
            {
                throw new UserNotLoggedInException();
            }
        }
    }
}
