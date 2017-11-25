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
    /// Interaction logic for AdminAllMealSharesView.xaml
    /// </summary>
    public partial class AdminAllMealSharesView : Page
    {
        private List<MealShare> MealShares { get; set; }
        private List<AdminMealShareRow> TableData { get; set; }

        public AdminAllMealSharesView()
        {
            InitializeComponent();

            TableData = new List<AdminMealShareRow>();

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
                AdminMealShareRow MealShareRow = new AdminMealShareRow(MealShare.Id);
                MealShareRow.EaterName = Eater.FirstName + " " + Eater.Surname;
                MealShareRow.CookName = Cook.FirstName + " " + Cook.Surname;
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

    class AdminMealShareRow
    {
        public string CookName { get; set; }

        public string EaterName { get; set; }

        public string Meal { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

        public string Time { get; set; }

        public string Id { get; set; }

        public AdminMealShareRow(string Id)
        {
            this.Id = Id;
        }
    }

}
