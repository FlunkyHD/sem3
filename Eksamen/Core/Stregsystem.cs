using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using Eksamen;

namespace Eksamen.Core
{
    public class Stregsystem : IStregsystem
    {
        private List<Product> allProducts;
        private List<User> allUsers;
        private List<Transaction> allTransactions = new List<Transaction>();
        public event UserBalanceNotification UserBalanceWarning;
        public event FileReadWarning FileReadError;

        public IEnumerable<Product> ActiveProducts
        {
            get
            {
                List<Product> active = new List<Product>();
                foreach (Product item in allProducts)
                {
                    if (item.Active)
                    {
                        active.Add(item);
                    }
                }

                return active;
            }
        }
        public InsertCashTransaction AddCreditsToAccount(User user, int amount)
        {
            InsertCashTransaction transaction = new InsertCashTransaction(user, amount);
            ExecuteTransaction(transaction);
            return transaction;
        }

        public BuyTransaction BuyProduct(User user, Product product)
        {
            BuyTransaction transaction = new BuyTransaction(user, product.Price, product);
            ExecuteTransaction(transaction);
            return transaction;
        }

        //Helper function for executing both kinds of transactions, while adding them to the log file
        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            if (transaction.User.Balance <= 50)
            {
                UserBalanceWarning?.Invoke(transaction.User, transaction.User.Balance);
            }
            writeToLogFile(transaction);
            allTransactions.Add(transaction);
        }

        public Product GetProductByID(int id)
        {
            Product product = allProducts.Find(x => x.ID == id);

            if (product == null)
            {
                throw new NonExistingProductException($"ID: {id}");
            }

            return product;

        }

        //Get the last 10 transaction for a user, or less if they do not have 10
        public IEnumerable<Transaction> GetTransactions(User user, int count)
        {
            List<Transaction> transactions = allTransactions.FindAll(x => x.User == user);
            transactions.Reverse();
            if (transactions.Count > 10)
            {
                transactions.RemoveRange(count, transactions.Count - count);
            }
            return transactions;
        }


        public IEnumerable<User> GetUsers(Func<User, bool> predicate)
        {
            List<User> list = new List<User>();
            foreach (User user in allUsers)
            {
                if (predicate(user))
                {
                    list.Add(user);
                }
            }

            if (list.Count < 1)
            {
                throw new NonExistingUserException($"A user that matches this predicate: {predicate} could not be found");
            }

            return list;
        }

        public User GetUserByUsername(string username)
        {
            foreach (User user in allUsers)
            {
                if (user.Username == username)
                {
                    return user;
                }
            }

            throw new NonExistingUserException($"{username}");
        }


        public void ReadFiles()
        {
            allProducts = readFile("..\\..\\..\\Data\\products.csv", (s => new Product(s)));
            allUsers = readFile("..\\..\\..\\Data\\users.csv", (s => new User(s)));
        }


        //Try to read the file, while creating users/products and returning a list containing them all
        private List<T> readFile<T>(string path, Func<string,T> func)
        {
            List<T> liste = new List<T>();
            try
            {
                liste = File.ReadLines(path).Skip(1).Select(line => func(line)).ToList();
            }
            catch (Exception e)
            {
                FileReadError?.Invoke(e.Message);
            }

            return liste;
        }

        //Writes to log.txt inside where the program is executed
        private void writeToLogFile(Transaction transaction)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(transaction.ToString());
            File.AppendAllText("..\\..\\..\\Data\\log.txt", sb.ToString());
        }

    }

}
