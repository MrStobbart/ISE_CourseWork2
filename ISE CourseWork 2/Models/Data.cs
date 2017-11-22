using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    class Data
    {
        public List<Cook> Cooks;
        public List<Eater> Eaters;
        public List<Account> Accounts;

        public void AddPerson(Cook Cook)
        {
            Cooks.Add(Cook);
        }

        public Person FindPerson(String Id)
        {
            return Cooks.Find(Cook => Cook.Id == Id);
        }
    }
}
