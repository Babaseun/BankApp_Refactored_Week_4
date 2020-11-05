using System.Text.RegularExpressions;

namespace BankApp_Refactored_Week4
{
    public class Util
    {
        public bool isEmailValid(string email)
        {
            return Regex.IsMatch(email, "/\\S+@\\S+\\.\\S+/");
        }

    }
}