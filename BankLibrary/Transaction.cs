using System;

namespace BankLibrary
{
    public class Transaction
    {
        public string FullName { get; set; }
        public string AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }
        public Guid OwnerID { get; set; }
    }
}