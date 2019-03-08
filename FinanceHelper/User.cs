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
        string CountTransactions();
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
        public string CountTransactions()
        {
            return String.Format("You made {0} transactions.", Transactions.Count);
        }

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
            int total = Transactions.Count;
            if (total == 0)
                return string.Empty;
            else
            {
                string echo= "";
                for (int i = 0; i < total; i++)
                { 
                    echo += String.Format("==========={0}===========/n Date{1} /n Currency:{2} /n Amount: {3} /n Value: {4}/n",i,
                        Transactions[i].TransactionDate.ToString("yyyy-MM-dd"), Transactions[i].Currency,
                        Transactions[i].Amount.ToString("#.##"),Transactions[i].ValueInPLN.ToString());
                }
                return echo;
            }
        }

        public string ShowTransaction(int i)
        {
            int total = Transactions.Count;
            if (total < i)
                return "Transaction with this id doesn't exist.";
            else
            {

                return String.Format("==========={0}===========/n Date{1} /n Currency:{2} /n Amount: {3} /n Value: {4}/n", i,
                     Transactions[i].TransactionDate.ToString("yyyy-MM-dd"), Transactions[i].Currency,
                     Transactions[i].Amount.ToString("#.##"), Transactions[i].ValueInPLN.ToString());

            }
        }

        public bool DeleteTransaction(int i)
        {
            int total = Transactions.Count;
            if (total > i)
                {
                    Transactions.RemoveAt(i);
                    return true;
                }
                else return false;
        
        }

        public void DeleteAllTransactions()
        {
            Transactions = new List<ITransaction>();
        }
        #endregion
    }
}
