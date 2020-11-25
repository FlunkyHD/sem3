using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount) : base(user, amount)
        {

        }

        public override string ToString()
        {
            return $"Inserting {Amount} into {User} at {TransactionTime} with ID:{ID}";
        }


        public override void Execute()
        {
            User.Balance += Amount;
        }
    }
}
