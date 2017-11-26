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
using System.Diagnostics;
using System.Windows.Shapes;
using ISE_CourseWork_2.Models;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for CookRestrictedHomeView.xaml
    /// </summary>
    public partial class CookUploadView : Page
    {
        private Cook Cook;

        public CookUploadView(Cook Cook)
        {
            InitializeComponent();
            this.Cook = Cook;
        }

        private void BtnUploadPvg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OpenFileDialog = new Microsoft.Win32.OpenFileDialog();
            OpenFileDialog.FileName = "PVG certificate"; // Default file name
            OpenFileDialog.DefaultExt = ".pdf"; // Default file extension
            OpenFileDialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show open file dialog box
            bool? result = OpenFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                ((MainWindow)App.Current.MainWindow).RuntimeDb.UploadPvgCertificate(Cook.Id, OpenFileDialog.FileName);
                ((MainWindow)App.Current.MainWindow).RuntimeDb.UpdateCookPvg(Cook.Id, PvgStatus.AwaitingCheck);
            }
        }

        private void BtnUploadFoodHygiene_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog OpenFileDialog = new Microsoft.Win32.OpenFileDialog();
            OpenFileDialog.FileName = "Foodhygiene certificate"; // Default file name
            OpenFileDialog.DefaultExt = ".pdf"; // Default file extension
            OpenFileDialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show open file dialog box
            bool? result = OpenFileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                ((MainWindow)App.Current.MainWindow).RuntimeDb.UploadFoodHygieneCertificate(Cook.Id, OpenFileDialog.FileName);
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void BtnContinueToHomePage_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)App.Current.MainWindow).Main.Content = new CookHomeView(Cook);
        }
    }
}
