using System.Diagnostics.Eventing.Reader;
using System.Security.Policy;
using Caldast.OODesignProblems.ParkingLot.Enums;

namespace Caldast.OODesignProblems.ParkingLot.Users
{
    public abstract class Account
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public AccountStatus AccountStatus { get; }
    protected Account(string username, string password,
            string firstName, string lastname, string email, UserType userType)
        {
            UserName = username;
            Password = password;
            FirstName = firstName;
            LastName = lastname;
            Email = email;
            UserType = userType;
        }

        public string UserName { get; }
        public string Password { get;  }
        public UserType UserType { get; }
    }
}
