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
        string ValueInPLN { get; }
        double ExchangePrice { get; }
        #endregion

        string CalculateValueInPLN(double amount, double exchangeprice);



    }
    class Transaction : ITransaction
    {
        #region properties
        public IUser Client { get; private set; }

        public DateTime TransactionDate { get; private set; }

        public double Amount { get; private set; }

        public string Currency { get; private set; }

        public string Name { get; private set; }

        public string ValueInPLN { get; private set; }

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

        public string CalculateValueInPLN(double amount, double exchangeprice)
        {
            double returned;
            if (!(exchangeprice > 0))
            {
                throw new ArgumentException("Exchange price must be greater than 0!");
            }
            returned = amount * exchangeprice;
            return String.Format("Wartość w PLN: {0}zł", returned);
        }
    }
}
