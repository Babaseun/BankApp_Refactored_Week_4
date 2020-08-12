using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class TransferTests
    {
        [Test]
        public void TransferFromAccountTest() // Test for when transfer is done between accounts
        {
            // arrange
            Account newAccount1 = new Account("savings", "1234567890", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            Account newAccount2 = new Account("savings", "1234567891", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount1);  // Created two new accounts
            BankDB.Accounts.Add(newAccount2);

            // act
            TransactionController transaction = new TransactionController();
            var accounts = transaction.Transfer(newAccount1.AccountNumber, newAccount2.AccountNumber, 100); // initiated the transfer
                                                                                                            // assert
            Assert.GreaterOrEqual(accounts[1].Balance, 100); // The balance of the second account should be greater
        }

        [Test]
        public void TransferToAccountTest() // Same for the second account
        {
            Account newAccount1 = new Account("savings", "1234567895", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            Account newAccount2 = new Account("savings", "1234567899", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount1);
            BankDB.Accounts.Add(newAccount2);

            TransactionController transaction = new TransactionController();

            var accounts = transaction.Transfer(newAccount1.AccountNumber, newAccount2.AccountNumber, 100);

            Assert.AreEqual(accounts[0].Balance, 999900); // The first account balance should be lesser on transfer
        }

    }
}