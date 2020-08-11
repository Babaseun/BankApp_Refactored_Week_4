using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class RegisterTests
    {
        [Test]
        public void FullNameTest()
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);

            Assert.AreEqual("adeyemi", response.Fullname);
        }

        [Test]
        public void EmailTest()
        {
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);

            Assert.AreEqual("ababaseun@gmail.com", response.Email);
        }
    }
}