using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceHelper
{
    class Manage
    {
        public List<ITransaction> Transactions { get; private set; }
        public List<IUser> Users { get; private set; }



        Manage()
        {
            Transactions = new List<ITransaction>();
            Users = new List<IUser>();
        }
        public IUser GetUser(string nick)
        {
            return Users.Find(u => u.Nick == nick);
        }

        public bool UserExists(string nick)
        {
            if (GetUser(nick) != null)
                return true;
            return false;
        }

        public bool UserExists(IUser user)
        {
            if (Users.Contains(user))
                return true;
            return false;
        }

        public bool SignUp(string nick, string password)
        {
            if (String.IsNullOrEmpty(nick) || String.IsNullOrEmpty(password))
                throw new ArgumentNullException();
            if (!UserExists(nick))
            {
                Users.Add(new User(nick, password));
                return true;
            }
            else
                return false;
        }

        public bool SignUp(IUser user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (!UserExists(user.Nick))
            {
                Users.Add(user);
                return true;
            }
            else
                return false;
        }

        public IUser LogIn(string nick, string password)
        {
            return Users.Find(u => u.Nick == nick && u.Password == password);
        }

        public bool RemoveUser(string nickname)
        {
            if (String.IsNullOrEmpty(nickname))
                throw new ArgumentNullException();
            if (UserExists(nickname))
            {
                Users.Remove(GetUser(nickname));
                return true;
            }
            else
                return false;
        }

        public bool RemoveUser(IUser user)
        {
            if (user == null)
                throw new ArgumentNullException();
            if (UserExists(user))
            {
                Users.Remove(user);
                return true;
            }
            else
                return false;
        }

        public void CreateTransaction()
        {

        }
        /*
         * manage()
         * logowanie
         * rejestracja
         * 
         */
    }
}
