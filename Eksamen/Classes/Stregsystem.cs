using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Eksamen;

namespace Eksamen
{
    public class Stregsystem : IStregsystem
    {
        private List<Product> allProducts;
        private List<User> allUsers;
        private List<Transaction> allTransactions = new List<Transaction>();

        public Stregsystem()
        {
            allProducts = readProductFile();
            allUsers = readUserFile();
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
            if (transaction.User.Balance <= 50)
            {
                UserBalanceWarning?.Invoke(transaction.User, transaction.User.Balance);
            }
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
            //TODO transactions.RemoveRange(count, transactions.Count - count);

            return transactions;
        }

        public User GetUsers(Func<User, bool> predicate) //TODO
        {
            //return allUsers.FindAll();
            throw new NotImplementedException();
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

            throw new NonExistingUserException();
        }

        //TODO GØR PATHS RELATIVE, ELLER PÅ ANDEN MÅDE MINDRE KOKS
        private List<Product> readProductFile()
        {
            return File.ReadLines("C:\\Users\\Win10\\Desktop\\3. Semester\\OOP\\sem3\\Eksamen\\Data\\products.csv").Skip(1).Select(line => new Product(line)).ToList();
        }

        private List<User> readUserFile()
        {
            return File.ReadLines("C:\\Users\\Win10\\Desktop\\3. Semester\\OOP\\sem3\\Eksamen\\Data\\users.csv").Skip(1).Select(line => new User(line)).ToList();
        }

        //TODO TILFØJ LOGFIL

        public void PrintAll()
        {
            foreach (var user in allUsers)
            {
                Console.WriteLine(user);
            }

            foreach (var product in allProducts)
            {
                Console.WriteLine(product);
            }
        }
    }

}
