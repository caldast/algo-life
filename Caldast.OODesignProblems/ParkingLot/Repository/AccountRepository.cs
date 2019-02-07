using System;
using System.Collections.Generic;
using Caldast.OODesignProblems.ParkingLot.Users;
namespace Caldast.OODesignProblems.ParkingLot.Repository
{
    public interface IAccountRepository
    {
        Account Register(Account account);
        Account Login(string username, string password);
        bool Logout(string username);
        Account View(string username);
        bool Update(Account account);
    }

    public class AccountRepository: IAccountRepository
    {
        private readonly Dictionary<string, Account> _users = new Dictionary<string, Account>();

        public Account Login(string username, string password)
        {
            if (View(username) != null)
            {
                Account account = _users[username];
                if (account.Password.Equals(password))
                    return account;
            }

            return null;
        }

        public Account Register(Account account)
        {
            if (View(account.UserName) == null)
            {
               _users.Add(account.UserName,account);
            }

            return null;
        }

        public bool Logout(string username)
        {
            if (View(username) != null)
            {
                return true;
            }

            return false;
        }


        public Account View(string username)
        {
            if (_users.ContainsKey(username))
            {
                return _users[username];
            }

            return null;
        }

        public bool Update(Account account)
        {
            if (View(account.UserName) != null)
            {
                _users[account.UserName] = account;
            }

            return false;
        }
    }
}
