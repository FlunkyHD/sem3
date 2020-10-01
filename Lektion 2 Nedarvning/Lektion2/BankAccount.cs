using System;
using System.Collections.Generic;
using System.Text;

namespace Lektion2
{
    class BankAccount
    {
        private double _balance;

        public double Balance
        {
            get { return _balance;}
            set {
                if (Balance > 250000 || Balance < -100000)
                {
                    throw new ArgumentException("Taber: ");
                }

                _balance = value;
            }
        }

        private double _borrowRate;
        public double BorrowRate
        {
            get { return _borrowRate; }
            set
            {
                if (BorrowRate <= 1.06)
                {
                    throw new ArgumentException("For lille borrow rate");
                }

                _borrowRate = value;
            }
        }

        private double _savingsRate;
        public double SavingsRate
        {
            get { return _savingsRate; }
            set
            {
                if (SavingsRate > 1.02)
                {
                    throw new ArgumentException("Får høj savingsrate");
                }

                _savingsRate = value;
            }
        }

        public BankAccount(double balance, double borrowRate, double savingsRate)
        {
            Balance = balance;
            _borrowRate = borrowRate;
            _savingsRate = savingsRate;
        }


        public void DepositCash(double cash)
        {
            if (Balance > 250000)
            {
                throw new ArgumentException("For rig");
            }
            Balance += cash;
        }

        public void WithdrawCash(double cash)
        {
            if (Balance < 0)
            {
                throw new ArgumentException("Fattig røv");
            }
            Balance -= cash;
        }

        public void ChargeInterest()
        {
            Balance *= _savingsRate;
        }



    }
}
