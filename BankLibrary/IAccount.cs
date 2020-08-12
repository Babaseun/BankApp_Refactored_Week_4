using System;

namespace BankLibrary
{

    public interface IAccount
    {
        void CreateAccount(Guid ID);
        Account SaveAccount(Account account);
        Account GetAccount(string accountNumber);
    }

}