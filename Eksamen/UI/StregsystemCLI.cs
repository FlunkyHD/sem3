using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Text;
using System.Xml.Schema;
using Eksamen;
using Eksamen.Core;

namespace Eksamen.UI
{
    public class StregsystemCLI : IStregsystemUI
    {
        private readonly IStregsystem IS;
        private bool _running = true;
        public event StregsystemEvent CommandEntered;
        public StregsystemCLI(IStregsystem s)
        {
            IS = s;
            IS.FileReadError += DisplayFileReadError;
            IS.UserBalanceWarning += UserBalanceWarning;
            IS.ReadFiles();
        }

        private void DisplayFileReadError(string message)
        {
            _running = false;
            Console.WriteLine($"Files could not be read because of this invalid data: ({message})");
            Console.WriteLine($"Closing application...");
        }

        public void DisplayUserNotFound(string username)
        {
            Console.WriteLine($"User with: ({username}) as a username could not be found");
        }

        public void DisplayProductNotFound(string product)
        {
            Console.WriteLine($"Product with: ({product}) could not be found");
        }

        public void DisplayUserInfo(User user)
        {
            List<Transaction> transactions = (List<Transaction>)IS.GetTransactions(user, 10);
            Console.WriteLine($"{user}: Balance: {user.Balance}");
            DisplayUserTransactions(transactions);
        }

        public void DisplayTooManyArgumentsError(string command)
        {
            Console.WriteLine($"Too many arguments were entered: ({command})");
        }

        public void DisplayAdminCommandNotFoundMessage(string adminCommand)
        {
            Console.WriteLine($"This admin command: ({adminCommand}) was not found");
        }

        public void DisplayUserBuysProduct(BuyTransaction transaction)
        {
            Console.WriteLine(transaction);
        }

        public void DisplayUserBuysProduct(int count, BuyTransaction transaction)
        {
            Console.WriteLine($"{count}x {transaction}");
        }

        public void Close()
        {
            Console.WriteLine($"Closing program, bye!");
            _running = false;
        }

        public void DisplayInsufficientCash(User user, Product product, int count)
        {
            Console.WriteLine($"User: {user.Username} (balance: {user.Balance}) did not have sufficient funds to purchase: {count}x {product.Name} ({count * product.Price} DKK)");
        }

        public void DisplayGeneralError(string errorString)
        {
            Console.WriteLine($"Error: {errorString}");
        }

        public void DisplayUserTransactions(List<Transaction> transactions)
        {
            Console.WriteLine($"Last {transactions.Count} transations:");
            foreach (Transaction itemTransaction in transactions)
            {
                Console.WriteLine(itemTransaction);
            }

            Console.WriteLine("");
        }

        private void UserBalanceWarning(User user, decimal balance)
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine($"WARNING! User: {user.Username}'s balance is only: {balance} DKK");
        }

        public void Start()
        {
           
            while (_running)
            {
                WriteMenu();
                HandleInput();
            }
        }

        private void HandleInput()
        {
            string command = Console.ReadLine();
            Console.Clear();
            CommandEntered?.Invoke(command);
        }

        private void WriteMenu()
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~ F-Klub Stregssytem ~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("{0,-7} {1,-35} {2,10}  |", "ID:", "Product:", "Price:");
            foreach (Product isActiveProduct in IS.ActiveProducts)
            {
                Console.WriteLine($"{isActiveProduct} DKK |");
            }
            Console.WriteLine("");
            Console.Write("Enter command: ");

        }

        public void DisplayInserCashTransation(InsertCashTransaction transaction)
        {
            Console.WriteLine(transaction);
        }
    }
}
