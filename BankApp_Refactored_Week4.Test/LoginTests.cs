using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    internal class LoginTests
    {
        [Test]
        public void EmailTest()
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");
            BankDB.Customers.Add(customer);

            CustomerController controller = new CustomerController();
            var response = controller.LoginCustomer("ababaseun@gmail.com", "1234");

            Assert.AreEqual("ababaseun@gmail.com", response.Email);
        }

        [Test]
        public void FullNameTest()
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