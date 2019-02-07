using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Users
{
    public class Admin: Account
    {

        public Admin(string username, string password,
            string firstName, string lastname ,string email) 
            : base(username, password,firstName, lastname ,email, UserType.Admin)
        {
        }
    }
}
