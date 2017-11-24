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
    public partial class PastMealSharesView : Page
    {
        private List<MealShare> MealShares { get; set; }
        private List<TableMealShare> TableMealShares { get; set; }

        public PastMealSharesView()
        {
            InitializeComponent();

            TableMealShares = new List<TableMealShare>();
            MealShares = ((MainWindow)App.Current.MainWindow).RuntimeDb.MealShares;

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            foreach(MealShare MealShare in MealShares)
            {
                Eater Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(MealShare.EaterId);
                Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId);
                TableMealShares.Add(new TableMealShare { CookName = Cook.FirstName + " " + Cook.Surname, EaterName = Eater.FirstName + " " + Eater.Surname, DateTime = MealShare.ProposedDateTime.ToString()  });
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableMealShares;
        }

    }

    class TableMealShare
    {
        public string CookName { get; set; }

        public string EaterName { get; set; }

        public string DateTime { get; set; }
    }

    class StockItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
