using System;
using BankLibrary;

namespace BankApp_Refactored_Week4
{
    public class CustomerController
    {
        public Customer GetCustomerDetails()
        {
            Console.WriteLine("--------------Enter your fullname---------");
            string fullname = Console.ReadLine();

            Console.WriteLine("--------------Enter your email-------------");
            string email = Console.ReadLine();

            Console.WriteLine("--------------Enter your password---------");
            string password = Console.ReadLine();

            CustomerController controller = new CustomerController();

            var checkIfUserExist = BankDB.Customers.Find(customer => customer.Email == email);

            if (checkIfUserExist == null)
            {
                Customer customer = new Customer(fullname, email, password);

                var customerData = controller.RegisterCustomer(customer);

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
            BankDB.Customers.Add(customer);

            return customer;
        }

        public Customer LoginCustomer(string email, string password)
        {
            var customer = BankDB.Customers.Find(customer => customer.Email == email && customer.Password == password);
            return customer;
        }

        public Customer GetCustomerLoginCredentials()
        {
            Console.WriteLine("--------------Enter your email-------------");
            string email = Console.ReadLine();

            Console.WriteLine("--------------Enter your password---------");
            string password = Console.ReadLine();

            CustomerController controller = new CustomerController();

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