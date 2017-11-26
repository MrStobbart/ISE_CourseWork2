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
    /// Interaction logic for AdminView.xaml
    /// </summary>
    public partial class AdminHomeView : Page
    {
        public AdminHomeView()
        {
            InitializeComponent();
            CalculateValues();
        }

        private void CalculateValues()
        {
            int CooksCount = ((MainWindow)App.Current.MainWindow).RuntimeDb.Cooks.Count();
            TxtCooksCount.Text = CooksCount.ToString();

            int EatersCount = ((MainWindow)App.Current.MainWindow).RuntimeDb.Eaters.Count();
            TxtEatersCount.Text = EatersCount.ToString();

            // Count all meal shares this month
            int MealSharesCount = ((MainWindow)App.Current.MainWindow).RuntimeDb.MealShares.Count(MealShare => MealShare.DateTime.Month == DateTime.Now.Month && MealShare.DateTime.Year == DateTime.Now.Year);
            TxtMealSharesCount.Text = MealSharesCount.ToString();

            int FeedbacksCount = ((MainWindow)App.Current.MainWindow).RuntimeDb.Feedbacks.Count();
            TxtFeedbacksCount.Text = FeedbacksCount.ToString();

            // Simplified version of meal shares per week per eater count (this month)
            double MealSharesPerEaterPerWeek = Math.Round((double)MealSharesCount / (double)EatersCount / 4.3, 2);
            TxtEatersMealsPerWeek.Text = MealSharesPerEaterPerWeek.ToString();
        }

        private void BtnShowCooks_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminAllCooksView();
        }

        private void BtnShowEaters_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminAllEatersView();
        }

        private void BtnShowMealShares_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminAllMealSharesView();
        }

        private void BtnShowFeedbacks_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminAllFeedbacksView();
        }
    }
}
