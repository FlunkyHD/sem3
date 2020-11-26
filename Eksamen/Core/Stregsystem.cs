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

        public Stregsystem()
        {
            
        }

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

        public event UserBalanceNotification UserBalanceWarning; //TODO RYK

        private void ExecuteTransaction(Transaction transaction)
        {
            transaction.Execute();
            if (transaction.User.Balance <= 5)
            {
                UserBalanceWarning?.Invoke(transaction.User, transaction.User.Balance);
            }
            writeToLogFile(transaction);
            allTransactions.Add(transaction);
        }

        public Product GetProductByID(int id)
        {
            return allProducts.Find(x => x.ID == id);

        }

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


        public User GetUsers(Func<User, bool> predicate) //TODO, tror det virker
        {
            foreach (User user in allUsers)
            {
                if (predicate(user))
                {
                    return user;
                }
            }

            throw new NonExistingUserException($"A user that matches this predicate: {predicate} could not be found");
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

            throw new NonExistingUserException($"A user with this username: {username} could not be found");
        }


        public event FileReadWarning FileReadError;
        public void ReadFiles()
        {
            allProducts = readFile("..\\..\\..\\Data\\products.csv", (s => new Product(s)));
            allUsers = readFile("..\\..\\..\\Data\\users.csv", (s => new User(s)));
        }


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

        //TODO NOK FJERN DET HER
        //private List<Product> readProductFile()
        //{
        //    return File.ReadLines("..\\..\\..\\Data\\products.csv").Skip(1).Select(line => new Product(line)).ToList();
        //}

        //private List<User> readUserFile()
        //{
        //    return File.ReadLines("..\\..\\..\\Data\\users.csv").Skip(1).Select(line => new User(line)).ToList();
        //}

        private void writeToLogFile(Transaction transaction)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(transaction.ToString());
            File.AppendAllText("log.txt", sb.ToString());
        }

    }

}
