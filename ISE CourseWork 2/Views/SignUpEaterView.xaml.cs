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

        private IPerson Person;
        private Account Account;

        private string FoodPreferences;

        public SignUpEaterView(IPerson Person, Account Account)
        {
            InitializeComponent();
            this.Person = Person;
            this.Account = Account;
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                Eater NewEater = new Eater(Person, FoodPreferences);

                // Add data to runtime db
                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddEater(NewEater);
                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddAccount(Account);

                // Sign in new account
                ((MainWindow)App.Current.MainWindow).RuntimeDb.SignIn(Account);

                ((MainWindow)App.Current.MainWindow).Main.Content = new EaterHomeView(NewEater);
            }
        }

        private bool InputIsValid()
        {

            return true;
        }
    }
}
