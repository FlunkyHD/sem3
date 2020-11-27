using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Eksamen.Core
{
    public abstract class Transaction
    {
        public Transaction(User user, decimal amount)
        {
            User = user;
            Amount = amount;
            TransactionTime = DateTime.Now;
        }

        //Static to make sure each transaction gets a unique id
        private static int idCounter = 0;
        private readonly int _id = ++idCounter;
        public int ID
        {
            get { return _id; }
        }

        private User _user;

        public User User
        {
            get { return _user; }
            set
            {
                if (value != null)
                {
                    _user = value;
                }
                else
                {
                    throw new InvalidDataException("Not a valid user for transaction");
                }
            }
        }

        public DateTime TransactionTime { get; }

        public decimal Amount { get; set; }

        public override string ToString()
        {
            return $"{ID} by {User} for {Amount} at {TransactionTime}";
        }

        //Abstract to make sure "children" implement it
        public abstract void Execute();
    }
}
