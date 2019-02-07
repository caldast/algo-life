using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Users
{
    public class ParkingAttendant: Account
    {
        public ParkingAttendant(string username, string password, string firstName, string lastname, string email) 
            : base(username, password, firstName, lastname, email, UserType.ParkingAttendant)
        {
        }
    }
}
