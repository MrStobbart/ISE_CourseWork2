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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpView : Page
    {
        
        private string Email;
        private string Password;
        private string PasswordRepeat;

        private string Street;
        private string HouseNumber;
        private string City;
        private string ZipCode;

        private string FirstName;
        private string Surname;
        private string PhoneNumber;



        public SignUpView()
        {
            InitializeComponent();
        }

        private void BtnSignUpEater_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {

                Address Address = new Address(Street, HouseNumber, City, ZipCode);
                IPerson NewPerson = new IPerson(FirstName, Surname, PhoneNumber, Address);
                Account NewAccount = new Account(Email, Password, AccountType.Eater, NewPerson.Id);

                ((MainWindow)App.Current.MainWindow).Main.Content = new SignUpEaterView(NewPerson, NewAccount);
            }
        }

        private void BtnSignUpCook_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                Address Address = new Address(Street, HouseNumber, City, ZipCode);
                IPerson NewPerson = new IPerson(FirstName, Surname, PhoneNumber, Address);
                Account NewAccount = new Account(Email, Password, AccountType.Cook , NewPerson.Id);

                ((MainWindow)App.Current.MainWindow).Main.Content = new SignUpCookView(NewPerson, NewAccount);
            }
        }

        private bool InputIsValid()
        {
            Email = TxtEmail.Text;
            Password = TxtPassword.Password.ToString();
            PasswordRepeat = TxtPasswordRepeat.Password.ToString();

            Street = TxtStreet.Text;
            HouseNumber = TxtHouseNumber.Text;
            City = TxtCity.Text;
            ZipCode = TxtZipCode.Text;
            FirstName = TxtFirstName.Text;
            Surname = TxtSurname.Text;
            PhoneNumber = TxtPhoneNumber.Text != "" ? TxtPhoneNumber.Text : "None supplied";


            if (TxtEmail.Text == "")
            {
                TxtWarning.Text = "Please insert an email";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (Password == "")
            {
                TxtWarning.Text = "Please insert a secure password";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (PasswordRepeat == "")
            {
                TxtWarning.Text = "Please repeat the password";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if(Password != PasswordRepeat)
            {
                TxtWarning.Text = "The passwords do not match";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }


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
