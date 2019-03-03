using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper
{
    public interface IUser
    {
        #region properties
        string Nick { get; } 
        string Password { get; }
        List<ITransaction> Transactions { get; } //to many
        #endregion
        #region methods
        string CountTendency(); // Bilans -12.34
        string CountIncomes(); // 12 przychodów wartości 1234zl
        string CountOutcomes();
        string ListTransactions();
        string ShowTransaction(int i);
        bool DeleteTransaction(int i);
        void DeleteAllTransactions();
        #endregion
    }
    public class User : IUser
    {
        #region properties
        public string Nick { get; private set; }
        public string Password { get; private set; }
        public List<ITransaction> Transactions { get; private set; }
        #endregion
        #region methods
        public User(string nick, string password)
        {
            Nick = nick;
            Password = password;
            Transactions = new List<ITransaction>();
        }
        #region counting
        public string CountTendency()
        {
            int total = Transactions.Count;
            if (total == 0)
                return string.Empty;
            else
            {
                double totalTendency = 0;
                for (int i = 0; i < total; i++)
                {
                    totalTendency += Transactions[i].ValueInPLN;
                }
                return "Total tendency: " + totalTendency + " zł.";
            }
        }

        public string CountIncomes()
        {
            int total = Transactions.Count;
            if (total == 0)
                return string.Empty;
            else
            {
                double totalIncome = 0;
                for (int i = 0; i < total; i++)
                {
                    if (Transactions[i].ValueInPLN > 0)
                    {
                        totalIncome += Transactions[i].ValueInPLN;
                    }
                }
                return "Total income: " + totalIncome + " zł.";
            }
        }

        public string CountOutcomes()
        {
            int total = Transactions.Count;
            if (total == 0)
                return string.Empty;
            else
            {
                double totalOutcome = 0;
                for (int i = 0; i < total; i++)
                {
                    if (Transactions[i].ValueInPLN < 0)
                    {
                        totalOutcome += Transactions[i].ValueInPLN;
                    }
                }
                return "Total outcome: " + totalOutcome + " zł.";
            }
        }
        #endregion
        public string ListTransactions()
        {
            throw new NotImplementedException();
        }

        public string ShowTransaction(int i)
        {
            throw new NotImplementedException();
        }

        public bool DeleteTransaction(int i)
        {
            throw new NotImplementedException();
        }

        public void DeleteAllTransactions()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
