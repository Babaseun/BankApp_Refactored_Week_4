using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class TransferTests
    {
        [Test]
        public void TransfarFromAccountTest()
        {
            Account newAccount1 = new Account("savings", "1234567890", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            Account newAccount2 = new Account("savings", "1234567891", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount1);
            BankDB.Accounts.Add(newAccount2);

            TransactionController transaction = new TransactionController();

            var accounts = transaction.Transfer(newAccount1.AccountNumber, newAccount2.AccountNumber, 100);

            Assert.GreaterOrEqual(accounts[1].Balance, 100);
        }

        [Test]
        public void TransferToAccountTest()
        {
            Account newAccount1 = new Account("savings", "1234567895", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            Account newAccount2 = new Account("savings", "1234567899", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount1);
            BankDB.Accounts.Add(newAccount2);

            TransactionController transaction = new TransactionController();

            var accounts = transaction.Transfer(newAccount1.AccountNumber, newAccount2.AccountNumber, 100);

            Assert.AreEqual(accounts[0].Balance, 999900);
        }
    }
}