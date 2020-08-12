using System;
using System.Collections.Generic;
using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class TransactionTests
    {
        [Test]
        public void TransactionFullame()
        {
            //Arrange 
            Transaction transaction = new Transaction();
            transaction.FullName = "adeyemi onibokun";
            transaction.AccountNumber = "1234567890";
            transaction.AccountType = "savings";
            transaction.Amount = 100M;
            transaction.Note = "dollar";
            transaction.OwnerID = Guid.NewGuid();
            transaction.Date = DateTime.Now;

            //Act
            BankDB.Transactions.Add(transaction);

            TransactionController controller = new TransactionController();
            var response = controller.GetTransaction(transaction.OwnerID); // Gets the transaction ID of the user

            //Assert
            Assert.IsNotEmpty(response.AccountNumber);
        }
        [Test]
        public void TransactionBalanceIsPositive()
        {
            //Arrange 
            Transaction transaction = new Transaction();
            transaction.FullName = "adeyemi onibokun";
            transaction.AccountNumber = "1234567890";
            transaction.AccountType = "savings";
            transaction.Amount = 100M;                         // Creating an object of the transaction class
            transaction.Note = "dollar";
            transaction.OwnerID = Guid.NewGuid();
            transaction.Date = DateTime.Now;


            //Act
            BankDB.Transactions.Add(transaction); // Adds the instance of the transaction class


            TransactionController controller = new TransactionController();
            var response = controller.GetTransaction(BankDB.Transactions[0].OwnerID);

            //Assert
            Assert.Positive(response.Amount);
        }


    }
}