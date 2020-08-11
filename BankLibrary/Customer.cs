using System;
using System.Collections.Generic;
using System.Text;

namespace BankLibrary
{
    public class Customer
    {
        public Guid ID { get; private set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; private set; }

        public Customer(string fullname, string email, string password)
        {
            this.ID = Guid.NewGuid();
            this.Email = email;
            this.Fullname = fullname;
            this.Password = password;
        }
    }
}