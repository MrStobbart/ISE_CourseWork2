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
    /// Interaction logic for SignUpPage.xaml
    /// </summary>
    public partial class SignUpView : Page
    {
        
        private string Email;
        private string Password;
        private string PasswordRepeat;


        public SignUpView()
        {
            InitializeComponent();
        }

        private void BtnSignUpEater_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                ((MainWindow)App.Current.MainWindow).Main.Content = new SignUpEaterView(Email, Password);
            }
        }

        private void BtnSignUpCook_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                ((MainWindow)App.Current.MainWindow).Main.Content = new SignUpCookView(Email, Password);
            }
        }

        private Boolean InputIsValid()
        {
            Email = TxtEmail.Text;
            Password = TxtPassword.Password.ToString();
            PasswordRepeat = TxtPasswordRepeat.Password.ToString();

            if(TxtEmail.Text == "")
            {
                TxtWarning.Text = "Please insert an email";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (Password == "")
            {
                TxtWarning.Text = "The passwords do not match";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (PasswordRepeat == "")
            {
                TxtWarning.Text = "Please insert a secure password";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if(Password != PasswordRepeat)
            {
                TxtWarning.Text = "Please repeat the password";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

    }
}
