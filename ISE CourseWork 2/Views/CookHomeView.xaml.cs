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
    /// Interaction logic for CookHomeView.xaml
    /// </summary>
    public partial class CookHomeView : Page
    {
        private Cook Cook;

        public CookHomeView(Cook Cook)
        {
            this.Cook = Cook;
            InitializeComponent();
            CheckForCertificates();
        }

        private void CheckForCertificates()
        {
            if(Cook.FoodHygiene == FoodHygieneStatus.RenewalWithinThreeMonths)
            {
                TxtInformation.Text = "Your food hygiene certificate is running out within the next three months. Please renew it and upload the new certificate.";
                BtnMissingCertificates.Visibility = Visibility.Visible;
                BtnNewMealShare.Visibility = Visibility.Visible;
                BtnMealShares.Visibility = Visibility.Visible;
                // Show Renewal within 3 months
                // Your food hygiene certificate is running out within the next three months. Please renew it and upload the new certificate.
            }

            if(Cook.Pvg == PvgStatus.Ok && Cook.FoodHygiene == FoodHygieneStatus.Ok)
            {
                TxtInformation.Text = "We are happy that you are a part of the meal-sharers initiative. Below you can either plan the next meal you want to share or view past meals you shared.";
                BtnMissingCertificates.Visibility = Visibility.Collapsed;
                BtnNewMealShare.Visibility = Visibility.Visible;
                BtnMealShares.Visibility = Visibility.Visible;
            }

            if (Cook.Pvg == PvgStatus.AwaitingCheck || Cook.FoodHygiene == FoodHygieneStatus.AwaitingCheck)
            {
                TxtInformation.Text = "Your uploaded certificates will be checked by one of our clerks. We will inform you via email once this is done and you can use meal-sharers.";
                BtnMissingCertificates.Visibility = Visibility.Visible;
                BtnNewMealShare.Visibility = Visibility.Collapsed;
                BtnMealShares.Visibility = Visibility.Collapsed;
            }

            if (Cook.Pvg == PvgStatus.None || Cook.FoodHygiene == FoodHygieneStatus.None)
            {
                TxtInformation.Text = "Some certificates are still missing to user meal-sharers! Click the button below for more information.";
                BtnMissingCertificates.Visibility = Visibility.Visible;
                BtnNewMealShare.Visibility = Visibility.Collapsed;
                BtnMealShares.Visibility = Visibility.Collapsed;
            }

            if(Cook.Pvg == PvgStatus.AwaitingResult)
            {
                TxtInformation.Text = "Unfortunately, we are still waiting for the result of the criminal background check. We will inform you via email once it is through.";
                BtnMissingCertificates.Visibility = Visibility.Collapsed;
                BtnNewMealShare.Visibility = Visibility.Collapsed;
                BtnMealShares.Visibility = Visibility.Collapsed;
            }

            if (Cook.Pvg == PvgStatus.Rejected)
            {
                TxtInformation.Text = "Unfortunately, your criminal background check outcome does not allow you to take part in the meal-sharers service. For further information you can contact us under 0131 12345678.";
                BtnMissingCertificates.Visibility = Visibility.Collapsed;
                BtnNewMealShare.Visibility = Visibility.Collapsed;
                BtnMealShares.Visibility = Visibility.Collapsed;
            }

        }

        private void BtnNewMealShare_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new NewMealShareView(Cook);
        }


        private void BtnMealShares_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new CookMealSharesView();
        }

        private void BtnMissingCertificates_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new CookUploadView(Cook);
        }
    }
}
