﻿using System.Collections.Generic;
using TripServiceKata.Exception;

namespace TripServiceKata.Trip
{
	public class TripDAO : ITripDao
	{
        public List<Trip> FindTripsByUser(User.User user)
        {
            throw new DependendClassCallDuringUnitTestException(
                        "TripDAO should not be invoked on an unit test.");
        }
    }
}
