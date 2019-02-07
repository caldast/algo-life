using Caldast.OODesignProblems.ParkingLot.Repository;
using Caldast.OODesignProblems.ParkingLot.Users;

namespace Caldast.OODesignProblems.ParkingLot.Service
{
    public interface IAccountService
    {
        Account Login(string username, string password);
        Account Register(Account account);
        bool Logout(string username);
        Account View(string username);
        bool Update(Account account);
    }

    public class AccountService: IAccountService
    {
        private readonly  IAccountRepository _accountRepository;
        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public Account Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            return _accountRepository.Login(username, password);
        }

        public Account Register(Account account)
        {
            if (account == null)
                return null;
            return _accountRepository.Register(account);
        }

        public bool Logout(string username)
        {
            if (string.IsNullOrEmpty(username))
                return false;

            return _accountRepository.Logout(username);
        }


        public Account View(string username)
        {
            return _accountRepository.View(username);
        }

        public bool Update(Account account)
        {
            return _accountRepository.Update(account);
        }
    }
}
