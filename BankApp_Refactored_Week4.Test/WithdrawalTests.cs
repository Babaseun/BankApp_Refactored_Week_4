using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class WithdrawalTests
    {
        [Test]
        public void WithdrawalForSavingsTest()
        {
            Account newAccount = new Account("savings", "1234567890", 0.01M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            TransactionController transaction = new TransactionController();
            var response = transaction.Withdraw(1000, newAccount.AccountNumber);
            Console.WriteLine(response.Balance);

            Assert.GreaterOrEqual(response.Balance, 0);
        }

        [Test]
        public void WithdrawalForCurrentTest()
        {
            Account newAccount = new Account("savings", "1234567891", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            TransactionController transaction = new TransactionController();
            var response = transaction.Withdraw(1000, newAccount.AccountNumber);

            Assert.GreaterOrEqual(response.Balance, 0);
        }
    }
}