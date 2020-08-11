using System;

namespace BankLibrary
{
    public class Account
    {
        public Guid ID { get; private set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public Guid OwnerID { get; set; }
        public decimal Balance { get; set; }
        public string Note { get; set; }
        public DateTime DateCreated { get; set; }

        public Account(string accountType, string accountNumber, decimal balance, Guid ownerID, string note, DateTime date)
        {
            this.ID = Guid.NewGuid();
            this.AccountType = accountType;
            this.AccountNumber = accountNumber;
            this.OwnerID = ownerID;
            this.Note = note;
            this.DateCreated = date;
            this.Balance = balance;
        }
    }
}