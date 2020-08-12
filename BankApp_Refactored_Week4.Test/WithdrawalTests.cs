using System;

using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class WithdrawalTests
    {
        [Test]
        public void WithdrawalForSavingsTest()
        {
            // arrange
            Account newAccount = new Account("savings", "1234567844", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            // act
            TransactionController transaction = new TransactionController();  //Ensuring users don"t have a negative balance
                                                                              // When they try to do a withdrawal on a new account
            var response = transaction.Withdraw(1000, newAccount.AccountNumber);

            //assert
            Assert.AreEqual(response.Balance, 0M);
        }

        [Test]
        public void WithdrawalForCurrentTest()
        {
            //arrange
            Account newAccount = new Account("current", "1234517899", 1000000M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);  // Creates an object of the account class and adds it 

            //act
            TransactionController transaction = new TransactionController();
            var response = transaction.Withdraw(1000, newAccount.AccountNumber);
            //assert
            Assert.AreEqual(response.Balance, 999000); // Checking if balance on withdraw is the same
        }
    }
}