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
    public partial class CookRestrictedHomeView : Page
    {
        private Cook Cook;

        public CookRestrictedHomeView(Cook Cook)
        {
            InitializeComponent();
            this.Cook = Cook;
        }

        private void BtnUploadPvg_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog SaveFileDialog = new Microsoft.Win32.SaveFileDialog();
            SaveFileDialog.FileName = "PVG certificate"; // Default file name
            SaveFileDialog.DefaultExt = ".pdf"; // Default file extension
            SaveFileDialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show save file dialog box
            bool? result = SaveFileDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = SaveFileDialog.FileName;
            }
        }

        private void BtnUploadFoodHygiene_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog SaveFileDialog = new Microsoft.Win32.SaveFileDialog();
            SaveFileDialog.FileName = "Foodhygiene certificate"; // Default file name
            SaveFileDialog.DefaultExt = ".pdf"; // Default file extension
            SaveFileDialog.Filter = "Text documents (.pdf)|*.pdf"; // Filter files by extension

            // Show save file dialog box
            bool? result = SaveFileDialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                string filename = SaveFileDialog.FileName;
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
