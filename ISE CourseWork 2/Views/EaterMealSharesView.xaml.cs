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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for EaterMealSharesView.xaml
    /// </summary>
    public partial class EaterMealSharesView : Page
    {

        private List<MealShare> MealShares { get; set; }
        private List<EaterMealShareRow> TableData { get; set; }

        public EaterMealSharesView()
        {
            InitializeComponent();

            TableData = new List<EaterMealShareRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            // Sort meal shares according to date
            MealShares = ((MainWindow)App.Current.MainWindow).RuntimeDb.MealShares.OrderBy(MealShare => MealShare.DateTime).ToList();

            foreach (MealShare MealShare in MealShares)
            {
                Eater Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(MealShare.EaterId);
                Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId);
                EaterMealShareRow MealShareRow = new EaterMealShareRow(MealShare.Id);
                MealShareRow.CookName = Cook.FirstName + " " + Cook.Surname;
                MealShareRow.PhoneNumber = Eater.PhoneNumber;
                MealShareRow.Meal = MealShare.Meal;
                MealShareRow.Status = MealShare.Status.ToString().ToLower();
                MealShareRow.Date = MealShare.DateTime.ToString("dd.MM.yyyy");
                MealShareRow.Time = MealShare.DateTime.ToString("hh:mm tt");

                TableData.Add(MealShareRow);
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableData;
        }

        private void RowButton_Click(object sender, RoutedEventArgs e)
        {
            EaterMealShareRow ClickedRow = ((FrameworkElement)sender).DataContext as EaterMealShareRow;
            ((MainWindow)App.Current.MainWindow).RuntimeDb.UpdateMealShareStatus(ClickedRow.Id, MealShareStatus.Accepted);

            // Reload the site to update the status
            ((MainWindow)App.Current.MainWindow).Main.Content = new EaterMealSharesView();
        }
    }

    class EaterMealShareRow

    {

        public string Meal { get; set; }

        public string CookName { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Id { get; set; }

        public EaterMealShareRow(string Id)
        {
            this.Id = Id;
        }

    }

}
