using System;
using System.Collections.Generic;
using System.Text;
using Eksamen;

namespace Eksamen.Core
{
    public class BuyTransaction : Transaction
    {
        public BuyTransaction(User user, decimal amount, Product productBought) : base(user, amount)
        {
            ProductBought = productBought;
            AmountAtPurchase = amount;
        }

        public Product ProductBought { get; }

        public decimal AmountAtPurchase { get; }

        public override string ToString()
        {
            return $"{User} bought {ProductBought.Name} for {AmountAtPurchase} DKK at {TransactionTime} with ID:{ID}";
        }

        public override void Execute()
        {
            if (!ProductBought.Active)
            {
                throw new NotActiveProductException($"This product is not available!");
            }

            if ((User.Balance - AmountAtPurchase) < 0 && !ProductBought.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException($"User: {User.Username} does not have enough balance to buy: {ProductBought.Name}");
            }

            User.Balance -= AmountAtPurchase;
        }
    }
}
