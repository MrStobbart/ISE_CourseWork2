using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ISE_CourseWork_2.Models;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for AdminAllFeedbacksView.xaml
    /// </summary>
    public partial class AdminAllFeedbacksView : Page
    {
        private List<Feedback> Feedbacks { get; set; }
        private List<AdminFeedbackRow> TableData { get; set; }

        public AdminAllFeedbacksView()
        {
            InitializeComponent();

            TableData = new List<AdminFeedbackRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            // Sort meal shares according to date
            Feedbacks = ((MainWindow)App.Current.MainWindow).RuntimeDb.Feedbacks.OrderBy(Feedback => Feedback.Type).ToList();

            foreach (Feedback Feedback in Feedbacks)
            {
                string UserName = "";
                string RegardingName = "";

                if(Feedback.AccountId != "")
                {
                    Account Account = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindAccount(Feedback.AccountId);
                    switch (Account.Type)
                    {
                        case AccountType.Eater:
                            UserName = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(Account.PersonId).GetFullName();
                            break;
                        case AccountType.Cook:
                            UserName = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(Account.PersonId).GetFullName();
                            break;
                    }
                }

                if(Feedback.Type == FeedbackType.MealShare)
                {
                    MealShare MealShare = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindMealShare(Feedback.MealShareId);
                    RegardingName = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId).GetFullName();

                }
                AdminFeedbackRow AdminFeedbackRow = new AdminFeedbackRow(Feedback.Id);
                AdminFeedbackRow.CreatorName = UserName;
                AdminFeedbackRow.RegardingName = RegardingName;
                AdminFeedbackRow.Type = Feedback.Type.ToString(); ;
                AdminFeedbackRow.Rating = Feedback.Rating;
                AdminFeedbackRow.Comment = Feedback.Comment;
                AdminFeedbackRow.Date = Feedback.DateTime.ToString("dd.MM.yyyy");

                TableData.Add(AdminFeedbackRow);
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableData;
        }

    }

    class AdminFeedbackRow
    {
        public string CreatorName { get; set; }

        public string RegardingName { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; }

        public string Date { get; set; }

        public string Id { get; set; }

        public AdminFeedbackRow(string Id)
        {
            this.Id = Id;
        }
    }

}
