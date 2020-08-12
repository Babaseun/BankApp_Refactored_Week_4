using System;

namespace BankLibrary
{

    public interface ICustomer
    {
        Customer GetCustomerDetails();
        Customer RegisterCustomer(Customer customer);
        Customer LoginCustomer(string email, string password);
        Customer GetCustomerLoginCredentials();

    }

}