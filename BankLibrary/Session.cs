using System;

namespace BankLibrary
{
    public class Session
    {
        public Guid Token { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}