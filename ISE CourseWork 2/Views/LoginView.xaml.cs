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
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginView : Page
    {

        private string Email;
        private string Password;
        private Account Account;

        public LoginView()
        {
            InitializeComponent();
        }


        private void BtnSignIn_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                Account = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindAccount(Email, Password);

                if(Account == null)
                {
                    TxtWarning.Text = "Wrong credentials";
                    TxtWarning.Visibility = Visibility.Visible;

                } else
                {
                    ((MainWindow)App.Current.MainWindow).RuntimeDb.SignIn(Account);
                    switch (Account.Type)
                    {
                        case AccountType.Eater:
                            Eater Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(Account.PersonId);
                            ((MainWindow)App.Current.MainWindow).Main.Content = new EaterHomeView(Eater);
                            break;
                        case AccountType.Cook:
                            // If Document missing navigate to upload page 
                            Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(Account.PersonId);
                            
                            if(Cook.Pvg != PvgStatus.Ok || Cook.FoodHygiene != FoodHygieneStatus.Ok)
                            {
                                ((MainWindow)App.Current.MainWindow).Main.Content = new CookRestrictedHomeView(Cook);
                                break;
                            }

                            ((MainWindow)App.Current.MainWindow).Main.Content = new CookHomeView(Cook);
                            break;
                        case AccountType.Administrator:
                            ((MainWindow)App.Current.MainWindow).Main.Content = new AdminView();
                            break;
                        default:
                            ((MainWindow)App.Current.MainWindow).Main.Content = new HomeView();
                            break;
                    }       
                }


                
            }

        }

        private bool InputIsValid()
        {
            Email = TxtEmail.Text;
            Password = TxtPassword.Password.ToString();

            if(Email == "")
            {
                TxtWarning.Text = "Please insert an email address";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if(Password == "")
            {
                TxtWarning.Text = "Please insert a password";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            return true;

        }

    }
}
