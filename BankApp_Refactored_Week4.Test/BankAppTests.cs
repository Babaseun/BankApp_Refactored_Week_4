using System;

using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class BankAppTests
    {

        //Transfer between Accounts Tests
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
            Assert.AreEqual(accounts[1].Balance, 100); // The balance of the second account should be greater
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

        // Withdrawal Tests
        [Test]
        public void WithdrawalForSavingsTest() // Ensuring users dont have a negative withdrawal
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

        // Register Test

        [Test]
        public void FullNameTest()  // Test for the fullname
        {
            //arrange
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            //act
            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);

            // assert
            Assert.IsNotNull(response.Fullname);
        }

        [Test]
        public void EmailTest() // Tests for the email
        {
            //arrange
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            //act
            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);
            // assert
            Assert.AreEqual("ababaseun@gmail.com", response.Email);
        }

        // Login Tests

        [Test]
        public void EmailTestForLogin() // Tests the email value to see if its is a match
        {
            // arrange
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234"); // An object of the customer class which must been stored before user logs in
            BankDB.Customers.Add(customer); // object is added to the list

            //act
            CustomerController controller = new CustomerController();
            var response = controller.LoginCustomer("ababaseun@gmail.com", "1234"); // Logs in the customer

            // assert
            Assert.AreEqual("ababaseun@gmail.com", response.Email); // Checks if return value are the same
        }

        [Test]
        public void NameTest() // The process is the same as the one above
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            CustomerController controller = new CustomerController();
            BankDB.Customers.Add(customer);

            var response = controller.LoginCustomer("ababaseun@gmail.com", "1234");

            Assert.IsNotNull(response.Fullname);
        }

        [Test]
        public void PasswordTest()
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            CustomerController controller = new CustomerController();
            BankDB.Customers.Add(customer);

            var response = controller.LoginCustomer("ababaseun@gmail.com", "1234");

            Assert.AreEqual("1234", response.Password);
        }
        // Deposit Test

        [Test]
        public void InitialDepositTest()
        {
            // arrange
            Account newAccount = new Account("savings", "1234567893", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);  // An object of the account class was created and added to the list

            // act
            TransactionController storeDeposit = new TransactionController();
            var account = storeDeposit.SaveDeposit(100, newAccount.AccountNumber); // When a new user saves 100 
                                                                                   // assert
            Assert.Greater(account.Balance, 0); // For a new account balance should be greater than 0
        }
        [Test]
        public void DepositValueTest() // Checks for a positive balance
        {
            // arrange
            Account newAccount = new Account("savings", "1234567896", 0M, Guid.NewGuid(), "dollar", DateTime.Now);
            BankDB.Accounts.Add(newAccount);

            // act
            TransactionController storeDeposit = new TransactionController();
            var account = storeDeposit.SaveDeposit(100, newAccount.AccountNumber);
            // assert
            Assert.Positive(account.Balance);
        }
        // Transaction Tests

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