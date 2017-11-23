using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class RuntimeDb
    {
        public List<Cook> Cooks;
        public List<Eater> Eaters;
        public List<Account> Accounts;
        public bool SignedIn;
        public Account SignedInAccount;

        public RuntimeDb()
        {
            Cooks = new List<Cook>();
            Eaters = new List<Eater>();
            Accounts = new List<Account>();
            SignedIn = false;
        }

        public void SignIn(Account Account)
        {
            SignedIn = true;
            SignedInAccount = Account;
        }

        public void SignOut()
        {
            SignedIn = false;
            SignedInAccount = null;
        }

        public void AddCook(Cook Cook)
        {
            Cooks.Add(Cook);
        }

        public Cook FindCook(string Id)
        {
            return Cooks.Find(Cook => Cook.Id == Id);
        }

        public void UpdateCook(Cook NewCook)
        {
            int index = Cooks.FindIndex(Cook => Cook.Id == NewCook.Id);
            if (index == -1)
            {
                throw new Exception("An cook with the id " + NewCook.Id + " does not exist!");
            }
            Cooks[index] = NewCook;
        }

        public void AddEater(Eater Eater)
        {
            Eaters.Add(Eater);
        }

        public Eater FindEater(string Id)
        {
            return Eaters.Find(Eater => Eater.Id == Id);
        }

        public void UpdateEater(Eater NewEater)
        {
            int index = Eaters.FindIndex(Eater => Eater.Id == NewEater.Id);
            if (index == -1)
            {
                throw new Exception("An eater with the id " + NewEater.Id + " does not exist!");
            }
            Eaters[index] = NewEater;
        }

        public void AddAccount(Account Account)
        {
            Accounts.Add(Account);
        }

        public Account FindAccount(string Id)
        {
            return Accounts.Find(Account => Account.Id == Id);
        }

        public Account FindAccount(string Email, string Password)
        {
            return Accounts.Find(Account => (Account.Email == Email && Account.Password == Password));
        }

        public void UpdateAccount(Account NewAccount)
        {
            int index = Accounts.FindIndex(Account => Account.Id == NewAccount.Id);
            if(index == -1)
            {
                throw new Exception("An account with the id " + NewAccount.Id + " does not exist!");
            }
            Accounts[index] = NewAccount;

        }
    }
}
