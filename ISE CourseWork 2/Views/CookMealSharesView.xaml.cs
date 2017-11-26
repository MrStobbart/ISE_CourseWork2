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
using System.Collections.ObjectModel;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for CookMealSharesView.xaml
    /// </summary>
    public partial class CookMealSharesView : Page
    {
        private List<MealShare> MealShares { get; set; }
        private ObservableCollection<CookMealShareRow> TableData { get; set; }

        public CookMealSharesView()
        {
            InitializeComponent();

            TableData = new ObservableCollection<CookMealShareRow>();

            CreateTableMealShares();
        }

        public void CreateTableMealShares()
        {
            // Sort meal shares according to date
            MealShares = ((MainWindow)App.Current.MainWindow).RuntimeDb.MealShares.OrderBy(MealShare => MealShare.DateTime).ToList();

            foreach (MealShare MealShare in MealShares)
            {
                if(((MainWindow)App.Current.MainWindow).RuntimeDb.SignedInAccount.PersonId == MealShare.CookId)
                {
                    Eater Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(MealShare.EaterId);
                    Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId);
                    CookMealShareRow MealShareRow = new CookMealShareRow(MealShare.Id);
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
            }

            CollectionViewSource itemCollectionViewSource;
            itemCollectionViewSource = (CollectionViewSource)(TryFindResource("ItemCollectionViewSource"));
            itemCollectionViewSource.Source = TableData;
        }

        private void BtnUploadPicture_Click(object sender, RoutedEventArgs e)
        {
            CookMealShareRow ClickedRow = ((FrameworkElement)sender).DataContext as CookMealShareRow;
            MealShare ClickedMealShare = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindMealShare(ClickedRow.Id);
            if (DateTime.Compare(ClickedMealShare.DateTime, DateTime.Now) < 0)
            {
                Microsoft.Win32.OpenFileDialog OpenFileDialog = new Microsoft.Win32.OpenFileDialog();
                OpenFileDialog.FileName = "Meal share picture"; // Default file name
                OpenFileDialog.DefaultExt = ".jpg"; // Default file extension
                OpenFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*"; // Filter files by extension

                // Show open file dialog box
                bool? result = OpenFileDialog.ShowDialog();

                // Process open file dialog box results
                if (result == true)
                {
                    ((MainWindow)App.Current.MainWindow).RuntimeDb.UploadPicture(ClickedMealShare.Id, OpenFileDialog.FileName);
                    ((MainWindow)App.Current.MainWindow).RuntimeDb.UpdateMealShareStatus(ClickedMealShare.Id, MealShareStatus.Done);
                    ((MainWindow)App.Current.MainWindow).Main.Content = new CookMealSharesView();
                }
            }
            else
            {
                MessageBox.Show("You can only upload pictures to meal shares that already took place.", "Upload not possible!", MessageBoxButton.OK, MessageBoxImage.None);
            }

            
        }
    }

    class CookMealShareRow
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

        public CookMealShareRow(string Id)
        {
            this.Id = Id;
        }
    }

}
