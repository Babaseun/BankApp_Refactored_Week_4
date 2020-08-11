using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class DepositTests
    {
        [Test]
        public void DepositValueTest()
        {
            Account newAccount = new Account("savings", "1234567893", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            TransactionController storeDeposit = new TransactionController();
            var response = storeDeposit.SaveDeposit(100, newAccount.AccountNumber);

            Assert.Greater(response.Balance, 0);
        }
    }
}