using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    internal class LoginTests
    {
        [Test]
        public void EmailTest() // Tests the email value to see if its is a match
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
        public void FullNameTest() // The process is the same as the one above
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            CustomerController controller = new CustomerController();
            BankDB.Customers.Add(customer);

            var response = controller.LoginCustomer("ababaseun@gmail.com", "1234");

            Assert.AreEqual("adeyemi", response.Fullname);
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
    }
}