using BankLibrary;
using System;

namespace BankApp_Refactored_Week4
{
    public class AccountController : IAccount
    {
        public static int accountNumberGenerator = 1234567890;
        public string accountNumber { get; set; }

        public AccountController()
        {
            this.accountNumber = accountNumberGenerator.ToString();
            accountNumberGenerator++;
        }

        public void CreateAccount(Guid ID) // Collects Data from user and creates an account
        {
            Console.WriteLine("--------------PRESS 1 FOR A SAVINGS ACCOUNT OR 2 FOR A CURRENT ACCOUNT---------");
            string option = Console.ReadLine();

            Console.WriteLine("--------------PRESS 1 FOR A DOLLAR ACCOUNT OR 2 FOR A NARIA ACCOUNT--------------");
            string option2 = Console.ReadLine();

            string accountType = option == "1" ? "savings" : "current";
            string accountNote = option2 == "1" ? "dollar" : "naria";

            Account newAccount = new Account(accountType, accountNumber, 0M, ID, accountNote, DateTime.Now);

            var account = new AccountController();
            var addedAccount = account.SaveAccount(newAccount); // Saves the newly created account by calling the save method or function

            Console.WriteLine("------------------Account Created----------");
            Console.WriteLine();
            Console.WriteLine("AccountID: " + addedAccount.ID);
            Console.WriteLine("AccountType: " + addedAccount.AccountType);
            Console.WriteLine("AccountNumber: " + addedAccount.AccountNumber);   // Displays the account information for user
            Console.WriteLine("Balance: " + addedAccount.Balance);
            Console.WriteLine("CreatedAT: " + addedAccount.DateCreated);
            Console.WriteLine("Currency: " + addedAccount.Note);
            Console.WriteLine("OwnerID: " + addedAccount.OwnerID);
        }

        public Account SaveAccount(Account account) // Saves new account to the List and returns the saved account
        {
            BankDB.Accounts.Add(account);
            return account;
        }

        public Account GetAccount(string accountNumber) // Gets an account  based on the account number
        {
            var account = BankDB.Accounts.Find(account => account.AccountNumber == accountNumber);
            return account;
        }
    }
}