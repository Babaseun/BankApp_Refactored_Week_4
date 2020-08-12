using System;
using System.Collections.Generic;
namespace BankLibrary
{

    public interface ITransaction
    {
        void GetTransactionData(string option);
        Account SaveDeposit(decimal amount, string accountNo);
        Account Withdraw(decimal amount, string accountNo);
        List<Account> Transfer(string firstAccount, string beneficiary, decimal amount);
        void TransferBetweenAccounts();
        Transaction GetTransaction(Guid ID);
        void GetTransactionHistory(Guid ID);

    }

}