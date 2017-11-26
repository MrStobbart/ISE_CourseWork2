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
    /// Interaction logic for AdminAllCooksView.xaml
    /// </summary>
    public partial class AdminAllCooksView : Page
    {
        private List<Cook> Cooks { get; set; }
        private List<AdminCookRow> TableData { get; set; }

        public AdminAllCooksView()
        {
            InitializeComponent();

            TableData = new List<AdminCookRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            // Sort meal shares according to date
            Cooks = ((MainWindow)App.Current.MainWindow).RuntimeDb.Cooks.OrderBy(Cook => Cook.Id).ToList();

            foreach (Cook Cook in Cooks)
            {
                AdminCookRow AdminCookRow = new AdminCookRow(Cook.Id);
                AdminCookRow.Name = Cook.FirstName + " " + Cook.Surname;
                AdminCookRow.StreetAndNumber = Cook.Address.Street + " " + Cook.Address.HouseNumber;
                AdminCookRow.ZipCode = Cook.Address.ZipCode;
                AdminCookRow.City = Cook.Address.City;
                AdminCookRow.PhoneNumber = Cook.PhoneNumber;
                AdminCookRow.PvgStatus = Cook.Pvg.ToString();
                AdminCookRow.FoodHygieneStatus = Cook.FoodHygiene.ToString();

                // Calculate average rating
                List<Feedback> Feedbacks = ((MainWindow)App.Current.MainWindow).RuntimeDb.Feedbacks;
                int SumRating = 0;
                int RatingCount = 0;
                foreach(Feedback Feedback in Feedbacks)
                {
                    if(Feedback.RegardingPersonId == Cook.Id)
                    {
                        SumRating += Feedback.Rating;
                        RatingCount++;
                    }
                }
                if (RatingCount == 0)
                {
                    AdminCookRow.AverageRating = "-";
                }
                else
                {
                    AdminCookRow.AverageRating = Math.Round(((double)SumRating / (double)RatingCount), 1).ToString();
                }

                TableData.Add(AdminCookRow);
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableData;
        }

        private void BtnManageCook_Click(object sender, RoutedEventArgs e)
        {
            AdminCookRow ClickedRow = ((FrameworkElement)sender).DataContext as AdminCookRow;
            Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(ClickedRow.Id);
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminManageCookView(Cook);
        }

    }

    class AdminCookRow
    {
        public string Name { get; set; }

        public string StreetAndNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string PvgStatus { get; set; }

        public string FoodHygieneStatus { get; set; }

        public string AverageRating { get; set; }

        public string Id { get; set; }

        public AdminCookRow(string Id)
        {
            this.Id = Id;
        }
    }

}
