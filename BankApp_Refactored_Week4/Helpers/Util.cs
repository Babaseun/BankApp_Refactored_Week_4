
using System;


namespace BankApp_Refactored_Week4
{
    public class Util
    {
        public bool isEmailValid(string email)
        {
            return email.Contains("@") ? true : false;
        }

        // validate email input
        public string ValidateEmailFormat(string email)
        {
            bool isEmValid = false;
            isEmValid = isEmailValid(email);
            string em = "";

            while (isEmValid == false)
            {
                System.Console.WriteLine("\nInvalid email format");
                Console.WriteLine("Enter email again");
                em = Console.ReadLine();
                isEmValid = isEmailValid(em);
            }

            return em;
        }




    }
}