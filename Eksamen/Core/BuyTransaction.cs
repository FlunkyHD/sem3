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
            _productBought = productBought;
            _amountAtPurchase = amount;
        }

        private Product _productBought;
        public Product ProductBought
        {
            get { return _productBought; }
        }

        private decimal _amountAtPurchase;
        public decimal AmountAtPurchase
        {
            get { return _amountAtPurchase; }
        }

        public override string ToString()
        {
            return $"{User} bought {ProductBought.Name} for {AmountAtPurchase} at {TransactionTime} with ID:{ID}";
        }

        public override void Execute()
        {
            if ((User.Balance - AmountAtPurchase) < 0 && !ProductBought.CanBeBoughtOnCredit)
            {
                throw new InsufficientCreditsException($"User: {User} does not have enough balance to buy: {ProductBought}");
            }

            if (!ProductBought.Active)
            {
                throw new NotActiveProductException($"This product is not available!");
            }

            User.Balance -= AmountAtPurchase;
        }
    }
}
