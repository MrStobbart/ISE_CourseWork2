using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class RuntimeDb
    {
        public List<Cook> Cooks { get; set; }
        public List<Eater> Eaters { get; set; }
        public List<Account> Accounts { get; set; }
        public List<MealShare> MealShares { get; private set; }
        public List<Feedback> Feedbacks { get; set; }
        public bool SignedIn { get; private set; }
        public Account SignedInAccount { get; set; }

        public RuntimeDb()
        {
            Cooks = new List<Cook>();
            Eaters = new List<Eater>();
            Accounts = new List<Account>();
            MealShares = new List<MealShare>();
            Feedbacks = new List<Feedback>();
            SignedIn = false;

            CreateDefaultData();
        }

        private void CreateDefaultData()
        {
            Address CookAddress = new Address("Slateford Road", "1E", "Edinburgh", "EH11 1FE");
            IPerson CookPerson = new IPerson("Marek", "Meyer", "1234567890", CookAddress);

            List<TravelCapability> TravelCapabilities = new List<TravelCapability>();
            TravelCapabilities.Add(TravelCapability.ByFoot);
            TravelCapabilities.Add(TravelCapability.Bike);

            Cook Cook = new Cook(CookPerson, "Pasta", TravelCapabilities);
            AddCook(Cook);
            Account CookAccount = new Account("cookmail@outlook.com", "cookpass", AccountType.Cook, Cook.Id);
            Account CookAccountFast = new Account("c", "c", AccountType.Cook, Cook.Id);
            AddAccount(CookAccount);
            AddAccount(CookAccountFast);


            Address EaterAddress = new Address("Street", "15", "Edinburgh", "EH11 1FE");
            IPerson EaterPerson = new IPerson("John", "Smith", "0987654321", EaterAddress);
            Eater Eater = new Eater(EaterPerson, "Fish");
            AddEater(Eater);
            Account EaterAccount = new Account("eatermail@outlook.com", "eaterpass", AccountType.Eater, Eater.Id);
            Account EaterAccountFast = new Account("e", "e", AccountType.Eater, Eater.Id);
            AddAccount(EaterAccount);
            AddAccount(EaterAccountFast);


            Account AdminAccount = new Account("adminmail@outlook.com", "adminpass", AccountType.Administrator, "admin");
            Account AdminAccountFast = new Account("a", "a", AccountType.Administrator, "admin");
            AddAccount(AdminAccount);
            AddAccount(AdminAccountFast);


            MealShare MealShare = new MealShare(Cook.Id, Eater.Id, DateTime.Now.AddDays(1), "Pasta");
            AddMealShare(MealShare);

            MealShare MealShare2 = new MealShare(Cook.Id, Eater.Id, DateTime.Now.AddMonths(-1), "Fish");
            AddMealShare(MealShare2);

            Feedback Feedback = new Feedback(FeedbackType.MealShare, 5, Cook.Id);
            Feedback.UserId = EaterAccount.Id;
            Feedback.Comment = "Great meal share!";
            AddFeedback(Feedback);
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

        public MealShare FindMealShare(string Id)
        {
            return MealShares.Find(MealShare => MealShare.Id == Id);
        }

        public void AddMealShare(MealShare MealShare)
        {
            MealShares.Add(MealShare);
        }

        public void UpdateMealShareStatus(string MealShareId, MealShareStatus NewStatus)
        {
            int index = MealShares.FindIndex(MealShare => MealShare.Id == MealShareId);
            if (index == -1)
            {
                throw new Exception("An mealshare with the id " + MealShareId  + " does not exist!");
            }
            MealShare NewMealShare = MealShares[index];
            NewMealShare.Status = NewStatus;
            MealShares[index] = NewMealShare;
        }

        public void AddFeedback(Feedback Feedback)
        {
            Feedbacks.Add(Feedback);
        }

    }
}
