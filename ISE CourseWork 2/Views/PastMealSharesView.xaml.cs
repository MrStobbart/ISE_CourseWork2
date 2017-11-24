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

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for PastMealSharesView.xaml
    /// </summary>
    public partial class PastMealSharesView : Page
    {
        public PastMealSharesView()
        {
            InitializeComponent();
            //create business data
            var itemList = new List<StockItem>();
 
            //link business data to CollectionViewSource
            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = itemList;
            itemList.Add(new StockItem { Name = "Many items", Quantity = 100 });
            itemList.Add(new StockItem { Name = "Enough items", Quantity = 10 });
        }
    }

    class StockItem
    {
        public string Name { get; set; }
        public int Quantity { get; set; }

    }
}
