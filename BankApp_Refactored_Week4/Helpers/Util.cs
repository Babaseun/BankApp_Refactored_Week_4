using System;


namespace BankApp_Refactored_Week4
{
    public class Util
    {
        public bool isEmailValid(string email)
        {
            return email.Contains("@") ? true : false;
        }





    }
}