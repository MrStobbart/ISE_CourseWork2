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

        public RuntimeDb()
        {
            Cooks = new List<Cook>();
            Eaters = new List<Eater>();
            Accounts = new List<Account>();
        }

        public void AddCook(Cook Cook)
        {
            Cooks.Add(Cook);
        }

        public Person FindCook(String Id)
        {
            return Cooks.Find(Cook => Cook.Id == Id);
        }

        public void AddEater(Eater Eater)
        {
            Eaters.Add(Eater);
        }

        public Eater FindEater(String Id)
        {
            return Eaters.Find(Eater => Eater.Id == Id);
        }

        public void AddAccount(Account Account)
        {
            Accounts.Add(Account);
        }

        public Account FindAccount(String Id)
        {
            return Accounts.Find(Account => Account.Id == Id);
        }
    }
}
