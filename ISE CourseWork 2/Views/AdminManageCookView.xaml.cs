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
using System.Diagnostics;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for AdminManageCookView.xaml
    /// </summary>
    public partial class AdminManageCookView : Page
    {

        private Cook Cook { get; set; }

        public AdminManageCookView(Cook Cook)
        {
            InitializeComponent();
            this.Cook = Cook;
            TxtPvgStatus.Text = Cook.Pvg.ToString();

            if (Cook.FoodHygieneCertificateNeedsCheck())
            {
                TxtFoodHygieneStatus.Text = "Awaiting check";
            }
            else
            {
                TxtFoodHygieneStatus.Text = Cook.FoodHygiene.ToString();
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminAllCooksView();
        }

        private void BtnPvgApprove_Click(object sender, RoutedEventArgs e)
        {
            if(Cook.Pvg == PvgStatus.AwaitingCheck)
            {
                ((MainWindow)App.Current.MainWindow).RuntimeDb.UpdateCookPvg(Cook.Id, PvgStatus.Ok);
                TxtPvgStatus.Text = PvgStatus.Ok.ToString(); ;
            }
        }

        private void BtnFoodHygieneApprove_Click(object sender, RoutedEventArgs e)
        {
            if (Cook.FoodHygieneCertificateNeedsCheck())
            {
                ((MainWindow)App.Current.MainWindow).RuntimeDb.UpdateCookFoodHygiene(Cook.Id, FoodHygieneStatus.Ok);
                TxtFoodHygieneStatus.Text = FoodHygieneStatus.Ok.ToString();
            }
        }

        private void BtnPvgCertificate_Click(object sender, RoutedEventArgs e)
        {
            if (Cook.PvgCertificatePath != null && Cook.Pvg == PvgStatus.AwaitingCheck)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Cook.PvgCertificatePath;
                    process.Start();
                    process.WaitForExit();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        private void BtnFoodHygieneCertificate_Click(object sender, RoutedEventArgs e)
        {
            if (Cook.FoodHygieneCertificatePath != null)
            {
                try
                {
                    Process process = new Process();
                    process.StartInfo.FileName = Cook.FoodHygieneCertificatePath;
                    process.Start();
                    process.WaitForExit();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Could not open the file.", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
