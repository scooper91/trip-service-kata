using TripServiceKata.User;

namespace TripServiceKata.Trip
{
	public class Users : IUsers
	{
		public User.User GetLoggedUser()
		{
			User.User loggedUser = UserSession.GetInstance().GetLoggedUser();
			return loggedUser;
		}
	}
}