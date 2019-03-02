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
        #endregion
        #region methods
        public User(string nick, string password)
        {
            Nick = nick;
            Password = password;
        }

        public string CountTendency()
        {
            throw new NotImplementedException();
        }

        public string CountIncomes()
        {
            throw new NotImplementedException();
        }

        public string CountOutcomes()
        {
            throw new NotImplementedException();
        }

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
