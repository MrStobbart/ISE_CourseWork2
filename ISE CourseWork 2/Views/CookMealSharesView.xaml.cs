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
    /// Interaction logic for PastMealSharesView.xaml
    /// </summary>
    public partial class CookMealSharesView : Page
    {
        private List<MealShare> MealShares { get; set; }
        private List<MealShareRow> TableData { get; set; }

        public CookMealSharesView()
        {
            InitializeComponent();

            TableData = new List<MealShareRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            MealShares = ((MainWindow)App.Current.MainWindow).RuntimeDb.MealShares.OrderBy(MealShare => MealShare.DateTime).ToList();

            foreach (MealShare MealShare in MealShares)
            {
                Eater Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(MealShare.EaterId);
                Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId);
                MealShareRow MealShareRow = new MealShareRow(MealShare.Id);
                MealShareRow.EaterName = Eater.FirstName + " " + Eater.Surname;
                MealShareRow.StreetAndNumber = Eater.Address.Street + " " + Eater.Address.HouseNumber;
                MealShareRow.ZipCode = Eater.Address.ZipCode;
                MealShareRow.City = Eater.Address.City;
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

    }

    class MealShareRow
    {
        public string EaterName { get; set; }

        public string StreetAndNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Meal { get; set; }

        public string Id { get; set; }

        public MealShareRow(string Id)
        {
            this.Id = Id;
        }
    }

}
