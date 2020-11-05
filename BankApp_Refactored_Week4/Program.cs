using BankLibrary;
using System;

namespace BankApp_Refactored_Week4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Session session = new Session();// An Identifier for each user
            HomePage:
                StandardMessages.WelcomeMessage(); // A welcome message from a static method of the standardMessages class
                string option = Console.ReadLine();

                if (option == "1") // IF a user chooses to register an account
                {
                    try
                    {
                        CustomerRepository customer = new CustomerRepository();
                        var response = customer.GetCustomerDetails();
                        // Getting the details from the customer
                        session.Token = response.ID;
                        session.Email = response.Email; // An Identifier for new user
                        session.FullName = response.Fullname;
                    }
                    catch (System.NullReferenceException) // An Exception if the session is not setSSSSS
                    {
                        goto HomePage;
                    }
                }

                if (option == "2")   // Option 2 to Login the User
                {
                    try
                    {
                        CustomerRepository customer = new CustomerRepository();
                        var response = customer.GetCustomerLoginCredentials(); // Gets the login data of the user
                        session.Token = response.ID;
                        session.Email = response.Email;
                        session.FullName = response.Fullname;
                    }
                    catch (System.NullReferenceException) // When session is not set it gives a null reference exception
                    {
                        goto HomePage;
                    }
                }
                while (session.Token != null && session.FullName != null && session.Email != null)
                {
                    StandardMessages.Options(); // Returns a menu of OPTIONS FOR THE USER TO PICK FROM
                    string opt = Console.ReadLine();
                    if (opt == "1")
                    {
                        AccountRepository account = new AccountRepository();
                        account.CreateAccount(session.Token); //creates a new account for user
                    }
                    if (opt == "2")
                    {
                        TransactionRepository transaction = new TransactionRepository();
                        transaction.GetTransactionData(opt); // Gets the transaction Data from user
                    }
                    if (opt == "3")
                    {
                        TransactionRepository transaction = new TransactionRepository();
                        transaction.GetTransactionData(opt);
                    }
                    if (opt == "4")
                    {
                        TransactionRepository controller = new TransactionRepository();
                        controller.TransferBetweenAccounts(); // When user wants to transfer between accounts
                    }
                    if (opt == "5")
                    {
                        TransactionRepository controller = new TransactionRepository();
                        controller.GetTransactionHistory(session.Token); // Gets the history of transactions of a particular user
                    }
                    if (opt == "6")
                    {
                        // When a user decides to Logout it return to the home page
                        goto HomePage;

                    }
                }
            }
        }
    }
}