﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen
{
    public class Stregsystem : IStregsystem
    {
        public IEnumerable<Product> ActiveProducts { get; }
        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            throw new NotImplementedException();
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            throw new NotImplementedException();
        }

        public Product GetProductByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            throw new NotImplementedException();
        }

        public User GetUsers(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public event UserBalanceNotification UserBalanceWarning;
    }
}
