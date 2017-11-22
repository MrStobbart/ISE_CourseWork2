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
    /// Interaction logic for SignUpEaterView.xaml
    /// </summary>
    public partial class SignUpEaterView : Page
    {
        private Address Adress;
        private Eater Eater;
        private Account Account;

        private string Email;
        private string Password;

        private string Street;
        private string HouseNumber;
        private string City;
        private string ZipCode;

        private string FirstName;
        private string Surname;
        private string PhoneNumber;

        private string FoodPreferences;

        public SignUpEaterView(string Email, string Password)
        {
            InitializeComponent();
            this.Email = Email;
            this.Password = Password;
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                // TODO add data to data object in MainWindow
                ((MainWindow)App.Current.MainWindow).Main.Content = new EaterHomeView();
            }
        }

        private Boolean InputIsValid()
        {
            Street = TxtStreet.Text;
            HouseNumber = TxtHouseNumber.Text;
            City = TxtCity.Text;
            ZipCode = TxtZipCode.Text;
            FirstName = TxtFirstName.Text;
            Surname = TxtSurname.Text;
            PhoneNumber = TxtPhoneNumber.Text;

            if (FirstName == "")
            {
                TxtWarning.Text = "Please insert your first name";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }
            if (Surname == "")
            {
                TxtWarning.Text = "Please insert your surname";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }
            if (Street == "")
            {
                TxtWarning.Text = "Please insert a street";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }
            if (HouseNumber == "")
            {
                TxtWarning.Text = "Please insert a house number";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }
            if (City == "")
            {
                TxtWarning.Text = "Please insert a city";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }
            if (ZipCode == "")
            {
                TxtWarning.Text = "Please insert a ZIP code";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }
    }
}
