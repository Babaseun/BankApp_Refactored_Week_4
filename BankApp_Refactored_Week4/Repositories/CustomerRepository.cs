using BankLibrary;
using System;


namespace BankApp_Refactored_Week4
{
    public class CustomerRepository : ICustomer
    {
        public Customer GetCustomerDetails() // Gets data from the user and returns it
        {
            Console.WriteLine("--------------Enter your fullname---------");
            string fullname = Console.ReadLine();
        BACK:
            Console.WriteLine("--------------Enter your email-------------");
            string email = Console.ReadLine();


            Console.WriteLine("--------------Enter your password---------");
            string password = Console.ReadLine();

            Util utils = new Util();
            var validateEmail = utils.isEmailValid(email);

            if (validateEmail == false)
            {
                Console.WriteLine("------Please enter a valid email to continue ");

                goto BACK;
            }
            CustomerRepository controller = new CustomerRepository();

            var checkIfUserExist = BankDB.Customers.Find(customer => customer.Email == email);

            if (checkIfUserExist == null)
            {
                Customer customer = new Customer(fullname, email, password);

                var customerData = controller.RegisterCustomer(customer); // Registers the customer and stores it in a list

                Console.WriteLine("User " + customerData.Fullname + " was added successfully ");

                return customerData;
            }
            else
            {
                Console.WriteLine("User with these " + email + " has already registered ");
                return null;
            }
        }

        public Customer RegisterCustomer(Customer customer)
        {
            BankDB.Customers.Add(customer); // Saves customer

            return customer;
        }

        public Customer LoginCustomer(string email, string password) // Checks if customer exists
        {
            var customer = BankDB.Customers.Find(customer => customer.Email == email && customer.Password == password);
            return customer;
        }

        public Customer GetCustomerLoginCredentials() // Gets the login data from customer
        {
            Console.WriteLine("--------------Enter your email-------------");
            string email = Console.ReadLine();

            Console.WriteLine("--------------Enter your password---------");
            string password = Console.ReadLine();

            CustomerRepository controller = new CustomerRepository();

            var customerData = controller.LoginCustomer(email, password);

            if (customerData == null)
            {
                Console.WriteLine("User with these " + email + " is not registered");
            }
            else
            {
                Console.WriteLine("-------Login Successful---------");
            }

            return customerData;
        }
    }
}