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
            Transaction transaction = new Transaction();
            transaction.FullName = "adeyemi onibokun";
            transaction.AccountNumber = "1234567890";
            transaction.AccountType = "savings";
            transaction.Amount = 100M;
            transaction.Note = "dollar";
            transaction.OwnerID = Guid.NewGuid();
            transaction.Date = DateTime.Now;

            BankDB.Transactions.Add(transaction);

            TransactionController controller = new TransactionController();
            var response = controller.GetTransaction(transaction.OwnerID);

            Assert.IsNotEmpty(response.AccountNumber);
        }
    }
}