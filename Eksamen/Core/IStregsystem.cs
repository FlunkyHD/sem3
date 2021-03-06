﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eksamen.Core
{
    public interface IStregsystem
    {
        IEnumerable<Product> ActiveProducts { get; }
        InsertCashTransaction AddCreditsToAccount(User user, int amount);
        BuyTransaction BuyProduct(User user, Product product);
        Product GetProductByID(int id);
        IEnumerable<Transaction> GetTransactions(User user, int count);
        IEnumerable<User> GetUsers(Func<User, bool> predicate);
        User GetUserByUsername(string username);
        event UserBalanceNotification UserBalanceWarning;
        event FileReadWarning FileReadError;
        void ReadFiles(); 
    }
}
