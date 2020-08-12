using NUnit.Framework;
using BankLibrary;

namespace BankApp_Refactored_Week4.Test
{
    public class RegisterTests
    {
        [Test]
        public void FullNameTest()  // Test for the fullname
        {
            //arrange
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            //act
            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);

            // assert
            Assert.AreEqual("adeyemi", response.Fullname);
        }

        [Test]
        public void EmailTest() // Tests for the email
        {
            //arrange
            Customer customer = new Customer("adeyemi", "ababaseun@gmail.com", "1234");

            //act
            CustomerController controller = new CustomerController();
            var response = controller.RegisterCustomer(customer);
            // assert
            Assert.AreEqual("ababaseun@gmail.com", response.Email);
        }
    }
}