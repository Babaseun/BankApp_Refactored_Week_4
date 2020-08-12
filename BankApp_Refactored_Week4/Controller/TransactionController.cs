using System;
using System.Collections.Generic;
using BankLibrary;

namespace BankApp_Refactored_Week4
{
    public class TransactionController : ITransaction
    {
        public void GetTransactionData(string option) // Gets the transaction data from user and options for either deposit or withdrawal
        {
            Console.WriteLine("--------Enter account number--------");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("--------Enter amount--------");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountController account = new AccountController();
            var getAccount = account.GetAccount(accountNumber); // Fetches the account 

            if (getAccount == null) // Checks if account for these user exists
            {
                Console.WriteLine("-----No Account for these user-------");
            }
            else
            {
                if (option == "2")
                {
                    TransactionController transaction = new TransactionController();
                    var response = transaction.SaveDeposit(amount, accountNumber); // Saves deposit value of the user





                    Console.WriteLine("--------------Account Information----------");
                    Console.WriteLine();
                    Console.WriteLine("AccountID: " + response.ID);
                    Console.WriteLine("AccountType: " + response.AccountType);  /// Displays Account of the user after deposit 
                    Console.WriteLine("AccountNumber: " + response.AccountNumber);
                    Console.WriteLine("Balance: " + response.Balance);
                    Console.WriteLine("CreatedAT: " + response.DateCreated);
                    Console.WriteLine("Currency: " + response.Note);
                    Console.WriteLine("OwnerID: " + response.OwnerID);
                }
                if (option == "3") // when the option is to withdraw
                {
                    TransactionController transaction = new TransactionController();
                    var response = transaction.Withdraw(amount, accountNumber);

                    Console.WriteLine("--------------Account Information----------");
                    Console.WriteLine();
                    Console.WriteLine("AccountID: " + response.ID);
                    Console.WriteLine("AccountType: " + response.AccountType);
                    Console.WriteLine("AccountNumber: " + response.AccountNumber);
                    Console.WriteLine("Balance: " + response.Balance);
                    Console.WriteLine("CreatedAT: " + response.DateCreated);
                    Console.WriteLine("Currency: " + response.Note);
                    Console.WriteLine("OwnerID: " + response.OwnerID);
                }
            }
        }

        public Account SaveDeposit(decimal amount, string accountNo)
        {
            var account = BankDB.Accounts.Find(acc => acc.AccountNumber == accountNo); // Updates the deposit balance of the user 

            var user = BankDB.Customers.Find(customer => customer.ID == account.OwnerID);


            if (user != null)
            {
                Transaction transaction = new Transaction();

                transaction.FullName = user.Fullname;
                transaction.Balance = account.Balance;
                transaction.AccountType = account.AccountType;
                transaction.Amount = amount;   // Saves the transaction of the user
                transaction.Date = DateTime.Now;
                transaction.Note = account.Note;
                transaction.OwnerID = user.ID;

                BankDB.Transactions.Add(transaction);

            }




            account.Balance += amount; // deposit value is added 

            Console.WriteLine("Deposit Successful");




            return account;
        }

        public Account Withdraw(decimal amount, string accountNo)
        {
            var account = BankDB.Accounts.Find(acc => acc.AccountNumber == accountNo);

            var user = BankDB.Customers.Find(customer => customer.ID == account.OwnerID);

            if (user != null)
            {
                Transaction transaction = new Transaction();

                transaction.FullName = user.Fullname;
                transaction.Balance = account.Balance;
                transaction.AccountType = account.AccountType;
                transaction.Amount = amount;
                transaction.Date = DateTime.Now;
                transaction.Note = account.Note;
                transaction.OwnerID = user.ID;

                BankDB.Transactions.Add(transaction);

            }



            if (account.AccountType == "savings")
            {
                if (account.Balance <= 1000 || amount == account.Balance)
                {
                    Console.WriteLine("Insufficient Funds");
                }
                else
                {
                    account.Balance = account.Balance - amount;
                }
            }
            else
            {
                if (account.Balance <= 100 || amount == account.Balance)
                {
                    Console.WriteLine("Insufficient Funds");
                }
                else
                {
                    account.Balance = account.Balance - amount;
                }
            }

            return account;
        }

        public List<Account> Transfer(string firstAccount, string beneficiary, decimal amount) // When a user transfers between accounts
        {
            var account1 = BankDB.Accounts.Find(acc => acc.AccountNumber == firstAccount);
            var account2 = BankDB.Accounts.Find(acc => acc.AccountNumber == beneficiary);
            var user = BankDB.Customers.Find(customer => customer.ID == account1.OwnerID);

            if (user != null)
            {
                Transaction transaction = new Transaction();

                transaction.FullName = user.Fullname;
                transaction.Balance = account1.Balance;
                transaction.AccountType = account1.AccountType; // Stores the transaction
                transaction.Amount = amount;
                transaction.Date = DateTime.Now;
                transaction.Note = account1.Note;
                transaction.OwnerID = user.ID;

                BankDB.Transactions.Add(transaction);
            }

            if (account1.AccountType == "savings")
            {
                if (account1.Balance <= 1000 || amount == account1.Balance)
                {
                    Console.WriteLine("Insufficient Funds");
                }
                else
                {
                    account1.Balance = account1.Balance - amount;
                    account2.Balance = account2.Balance + amount;
                }
            }
            else
            {
                if (account1.Balance <= 100 || amount == account1.Balance)
                {
                    Console.WriteLine("Insufficient Funds");
                }
                else
                {
                    account1.Balance = account1.Balance - amount;
                    account2.Balance = account2.Balance + amount;
                }
            }
            return new List<Account>() { account1, account2 };
        }

        public void TransferBetweenAccounts() // Gets the transfer data from the user
        {
            Console.WriteLine("--------Enter account number--------");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("--------Enter beneficiary account number--------");
            string accountNumber2 = Console.ReadLine();

            Console.WriteLine("--------Enter amount--------");
            decimal amount = decimal.Parse(Console.ReadLine());

            AccountController account = new AccountController();
            var getAccount1 = account.GetAccount(accountNumber);
            var getAccount2 = account.GetAccount(accountNumber2);

            TransactionController transaction = new TransactionController();
            var updatedAccounts = transaction.Transfer(getAccount1.AccountNumber, getAccount2.AccountNumber, amount);

            Console.WriteLine("--------------Account Information----------");
            Console.WriteLine();
            Console.WriteLine("AccountID: " + updatedAccounts[0].ID);
            Console.WriteLine("AccountType: " + updatedAccounts[0].AccountType);
            Console.WriteLine("AccountNumber: " + updatedAccounts[0].AccountNumber);
            Console.WriteLine("Balance: " + updatedAccounts[0].Balance);
            Console.WriteLine("CreatedAT: " + updatedAccounts[0].DateCreated);
            Console.WriteLine("Currency: " + updatedAccounts[0].Note);
            Console.WriteLine("OwnerID: " + updatedAccounts[0].OwnerID);

            Console.WriteLine("--------------Account Information----------");
            Console.WriteLine();
            Console.WriteLine("AccountID: " + updatedAccounts[1].ID);
            Console.WriteLine("AccountType: " + updatedAccounts[1].AccountType);
            Console.WriteLine("AccountNumber: " + updatedAccounts[1].AccountNumber);
            Console.WriteLine("Balance: " + updatedAccounts[1].Balance);
            Console.WriteLine("CreatedAT: " + updatedAccounts[1].DateCreated);
            Console.WriteLine("Currency: " + updatedAccounts[1].Note);
            Console.WriteLine("OwnerID: " + updatedAccounts[1].OwnerID);
        }

        public Transaction GetTransaction(Guid ID)
        {
            var transaction = BankDB.Transactions.Find(transaction => transaction.OwnerID == ID);
            return transaction;
        }
        public void GetTransactionHistory(Guid ID)
        {
            TransactionController controller = new TransactionController();
            var transaction = controller.GetTransaction(ID);

            Console.WriteLine("--------------Transaction History----------");
            Console.WriteLine();
            Console.WriteLine("Fullname: " + transaction.FullName);
            Console.WriteLine("AccountType: " + transaction.AccountType);
            Console.WriteLine("AccountNumber: " + transaction.AccountNumber);
            Console.WriteLine("Balance: " + transaction.Balance);
            Console.WriteLine("CreatedAT: " + transaction.Date);
            Console.WriteLine("Currency: " + transaction.Note);
            Console.WriteLine("OwnerID: " + transaction.OwnerID);
            Console.WriteLine("Amount: " + transaction.Amount);
        }
    }
}