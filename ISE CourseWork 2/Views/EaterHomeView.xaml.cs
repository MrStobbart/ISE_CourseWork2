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
    /// Interaction logic for EaterHomeView.xaml
    /// </summary>
    public partial class EaterHomeView : Page
    {
        public EaterHomeView()
        {
            InitializeComponent();
        }

        private void BtnClick_PastMealShares(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new PastMealSharesView();
        }

        private void BtnClick_UpcomingMealShares(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new UpcomingMealSharesView();
        }

        private void BtnClick_SelectFriends(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new SelectFriendsView();
        }
    }
}
