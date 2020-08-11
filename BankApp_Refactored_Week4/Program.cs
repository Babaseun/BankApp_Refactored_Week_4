using System;
using BankLibrary;

namespace BankApp_Refactored_Week4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Session session = new Session();
            HomePage:
                StandardMessages.WelcomeMessage();
                string option = Console.ReadLine();

                if (option == "1")
                {
                    try
                    {
                        CustomerController customer = new CustomerController();
                        var response = customer.GetCustomerDetails();

                        session.Token = response.ID;
                        session.Email = response.Email;
                        session.FullName = response.Fullname;
                    }
                    catch (System.NullReferenceException)
                    {
                        goto HomePage;
                    }
                }

                if (option == "2")
                {
                    try
                    {
                        CustomerController customer = new CustomerController();
                        var response = customer.GetCustomerLoginCredentials();
                        session.Token = response.ID;
                        session.Email = response.Email;
                        session.FullName = response.Fullname;
                    }
                    catch (System.NullReferenceException)
                    {
                        goto HomePage;
                    }
                }
                while (session.Token != null && session.FullName != null && session.Email != null)
                {
                    StandardMessages.Options();
                    string opt = Console.ReadLine();
                    if (opt == "1")
                    {
                        AccountController account = new AccountController();
                        account.CreateAccount(session.Token);
                    }
                    if (opt == "2")
                    {
                        TransactionController transaction = new TransactionController();
                        transaction.GetTransactionData(opt);
                    }
                    if (opt == "3")
                    {
                        TransactionController transaction = new TransactionController();
                        transaction.GetTransactionData(opt);
                    }
                    if (opt == "4")
                    {
                        TransactionController controller = new TransactionController();
                        controller.TransferBetweenAccounts();
                    }
                }
            }
        }
    }
}