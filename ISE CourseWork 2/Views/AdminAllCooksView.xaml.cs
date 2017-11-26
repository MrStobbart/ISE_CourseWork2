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
                AdminCookRow MealShareRow = new AdminCookRow(Cook.Id);
                MealShareRow.Name = Cook.FirstName + " " + Cook.Surname;
                MealShareRow.StreetAndNumber = Cook.Address.Street + " " + Cook.Address.HouseNumber;
                MealShareRow.ZipCode = Cook.Address.ZipCode;
                MealShareRow.City = Cook.Address.City;
                MealShareRow.PhoneNumber = Cook.PhoneNumber;
                MealShareRow.PvgStatus = Cook.Pvg.ToString();
                MealShareRow.FoodHygieneStatus = Cook.FoodHygiene.ToString();

                TableData.Add(MealShareRow);
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

        public string Id { get; set; }

        public AdminCookRow(string Id)
        {
            this.Id = Id;
        }
    }

}
