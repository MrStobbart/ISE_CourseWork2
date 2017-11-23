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
    /// Interaction logic for SignUpCookView.xaml
    /// </summary>
    public partial class SignUpCookView : Page
    {

        private Person Person;
        private Account Account;

        private string FoodPreferences;
        private List<string> TravelCapabilities;

        public SignUpCookView(Person Person, Account Account)
        {
            InitializeComponent();
            TravelCapabilities = new List<string>();
            this.Person = Person;
            this.Account = Account;
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                Cook NewCook = new Cook(Person, FoodPreferences, TravelCapabilities);

                // Add data to runtime db
                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddCook(NewCook);
                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddAccount(Account);

                // Sign in new account
                ((MainWindow)App.Current.MainWindow).RuntimeDb.SignIn(Account);

                ((MainWindow)App.Current.MainWindow).Main.Content = new CookRestrictedHomeView();
            }
        }

        private bool InputIsValid()
        {
            FoodPreferences = TxtFoodPreferences.Text;
            bool ByFoot = CheckBoxByFoot.IsChecked.Value;
            bool Bike = CheckBoxBike.IsChecked.Value;
            bool Car = CheckBoxCar.IsChecked.Value;
            bool PublicTransport = CheckBoxPublicTransport.IsChecked.Value;

            if(!ByFoot && !Bike && !Car && !PublicTransport)
            {
                TxtWarning.Text = "Please select at least one traval capability";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (ByFoot)
            {
                TravelCapabilities.Add("byFoot");
            }

            if (Bike)
            {
                TravelCapabilities.Add("bike");
            }

            if (Car)
            {
                TravelCapabilities.Add("car");
            }

            if (PublicTransport)
            {
                TravelCapabilities.Add("publicTransport");
            }

            return true;
        }
    }
}
