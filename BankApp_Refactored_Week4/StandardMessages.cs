using System;
using System.Collections.Generic;
using System.Text;

namespace BankApp_Refactored_Week4
{
    public class StandardMessages
    {
        public static void WelcomeMessage()
        {
            Console.WriteLine("                         Welcome to Console Bank Application                   ");
            Console.WriteLine("                                                                                ");
            Console.WriteLine("                         Please press 1 to REGISTER or 2 to LOGIN                ");
        }

        public static void Options()
        {
            Console.WriteLine("                                                                               ");
            Console.WriteLine("                                                                                ");
            Console.WriteLine("                         Please press 1 to Create an Account                    ");
            Console.WriteLine("                         Please press 2 to Deposit into an Account                ");
            Console.WriteLine("                         Please press 3 to Withdraw from an Account                ");
            Console.WriteLine("                         Please press 4 to Transfer to an Account                  ");
            Console.WriteLine("                         Please press 5 to see your transaction History                  ");

            Console.WriteLine("                         Please press 6 to LOGOUT                 ");
        }
    }
}