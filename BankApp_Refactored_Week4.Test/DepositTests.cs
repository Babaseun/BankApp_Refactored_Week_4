using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class DepositTests
    {
        [Test]
        public void InitialDepositTest()
        {
            Account newAccount = new Account("savings", "1234567893", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);  // An object of the account class was created and added to the list

            TransactionController storeDeposit = new TransactionController();
            var account = storeDeposit.SaveDeposit(100, newAccount.AccountNumber); // When a new user saves 100 

            Assert.Greater(account.Balance, 0); // For a new account balance should be greater than 0
        }
        [Test]
        public void DepositValueTest() // Checks for a positive balance
        {
            Account newAccount = new Account("savings", "1234567896", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            TransactionController storeDeposit = new TransactionController();
            var account = storeDeposit.SaveDeposit(100, newAccount.AccountNumber);

            Assert.Positive(account.Balance);
        }
    }
}