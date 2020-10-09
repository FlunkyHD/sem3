using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion_4
{
    class BankAccount
    {
        private decimal _balance;

        public BankAccount(decimal balance)
        {
            if (balance < 0)
            {
                throw new InsufficientFundsException("Nice try dude!");
            }
            else
            {
                _balance = balance;
            }
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                _balance += amount;
            }

        }

        public void Withdraw(decimal amount)
        {
            if (_balance - amount < 0)
            {
                throw new InsufficientFundsException("DIN FATTIGRØV HAHAHAHAHAHA!!!");
            }
            else
            {
                _balance -= amount;
            }
        }

    }
}
