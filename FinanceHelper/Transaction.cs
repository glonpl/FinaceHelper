using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper
{
    public interface ITransaction
    {
        #region properties
        IUser Client { get; }
        DateTime TransactionDate { get; }
        double Amount { get; }
        string Currency { get; }
        string Name { get; }
        double ValueInPLN { get; }
        double ExchangePrice { get; }
        #endregion

        double CalculateValueInPLN(double amount, double exchangeprice);



    }
    class Transaction : ITransaction
    {
        #region properties
        public IUser Client { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public double Amount { get; private set; }

        public string Currency { get; private set; }

        public string Name { get; private set; }

        public double ValueInPLN { get; private set; }

        public double ExchangePrice { get; private set; }
        #endregion

        public Transaction(IUser client, DateTime transactionDate, double moneyAmount, string currency, string name, double exchange)
        {
            Client = client;
            TransactionDate = transactionDate;
            Amount = moneyAmount;
            Currency = currency;
            Name = name;
            ExchangePrice = exchange;
            ValueInPLN = CalculateValueInPLN(moneyAmount, exchange);
        }

        public double CalculateValueInPLN(double amount, double exchangeprice)
        {
            if (!(exchangeprice > 0))
            {
                throw new ArgumentException("Exchange price must be greater than 0!");
            }
            return amount * exchangeprice;
            
        }
    }
}
