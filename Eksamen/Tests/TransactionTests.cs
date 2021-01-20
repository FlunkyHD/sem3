using System;
using System.Collections.Generic;
using System.Text;
using Eksamen.Core;
using NUnit.Framework;

namespace Eksamen.Tests
{
    public class TransactionTests
    {

        [Test]
        [TestCase(-50)]
        [TestCase(0)]
        [TestCase(50)]
        public void CreateValidInsertCashTransaction_Succes(decimal amount)
        {
            User user = new User("first name", "last name", "username", "email@domain.com", 500);
            InsertCashTransaction ict = new InsertCashTransaction(user, amount);

            Assert.IsTrue(ict.User == user && ict.Amount == amount);
        }

        [Test]
        [TestCase(-50.5)]
        [TestCase(0.96)]
        [TestCase(50.2)]
        [TestCase(-505)]
        public void InsertCashIntoUserAcountExecute_Succes(decimal amount)
        {
            User user = new User("first name", "last name", "username", "email@domain.com", 500);
            InsertCashTransaction ict = new InsertCashTransaction(user, amount);

            ict.Execute();

            Assert.IsTrue(user.Balance == (500 + amount));
        }

        //BuyTransaction

        [Test]
        public void CreateValidBuyTransaction_Succes()
        {
            User user = new User("first name", "last name", "username", "email@domain.com", 500);
            Product product = new Product(69, "TestProduct", 25, true, false);

            BuyTransaction bt = new BuyTransaction(user, product.Price, product);

            Assert.IsTrue(bt.User == user && bt.ProductBought == product && bt.AmountAtPurchase == product.Price);
        }

        [Test]
        [TestCase(-25)]
        [TestCase(0)]
        [TestCase(25)]
        [TestCase(50)]
        public void ExecuteValidBuyTransaction_Succes(decimal amount)
        {
            User user = new User("first name", "last name", "username", "email@domain.com", amount);
            Product product = new Product(69, "TestProduct", 25, true, true);
            BuyTransaction bt = new BuyTransaction(user, product.Price, product);

            bt.Execute();

            Assert.IsTrue((amount - product.Price) == user.Balance);
        }

        [Test]
        public void ExecuteInvalidBuyTransaction_WithInactiveProduct_ThrowError()
        {
            User user = new User("first name", "last name", "username", "email@domain.com", 500);
            Product product = new Product(69, "TestProduct", 25, false, true);
            BuyTransaction bt = new BuyTransaction(user, product.Price, product);


            Assert.Throws<NotActiveProductException>(() => bt.Execute());
        }

        [Test]
        public void ExecuteInvalidBuyTransaction_WithCreditOff_ThrowError()
        {
            User user = new User("first name", "last name", "username", "email@domain.com", 0);
            Product product = new Product(69, "TestProduct", 25, true, false);
            BuyTransaction bt = new BuyTransaction(user, product.Price, product);


            Assert.Throws<InsufficientCreditsException>(() => bt.Execute());
        }

    }
}
