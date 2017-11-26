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
using ISE_CourseWork_2.Views;
using ISE_CourseWork_2.Models;

namespace ISE_CourseWork_2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public RuntimeDb RuntimeDb { get; }

        public MainWindow()
        {
            InitializeComponent();
            RuntimeDb = new RuntimeDb();
            Main.Content = new AboutView();
        }

        private void BtnAbout_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AboutView();
        }

        private void BtnLogout_Click(object sender, RoutedEventArgs e)
        {
            ShowDefaultMenuBar();
            RuntimeDb.SignOut();
            Main.Content = new AboutView();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LoginView();
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new SignUpView();
        }

        private void Main_ContentRendered(object sender, EventArgs e)
        {
            if (RuntimeDb.SignedIn)
            {
                ShowLoggedInMenuBar();
            }
            else
            {
                ShowDefaultMenuBar();
            }
        }

        private void ShowLoggedInMenuBar()
        {
            BtnLogin.Visibility = Visibility.Collapsed;
            BtnSignUp.Visibility = Visibility.Collapsed;

            BtnLogout.Visibility = Visibility.Visible;
            BtnMyHomePage.Visibility = Visibility.Visible;
        }

        private void ShowDefaultMenuBar()
        {
            BtnLogin.Visibility = Visibility.Visible;
            BtnSignUp.Visibility = Visibility.Visible;

            BtnLogout.Visibility = Visibility.Collapsed;
            BtnMyHomePage.Visibility = Visibility.Collapsed;

        }

        private void BtnMyHomePage_Click(object sender, RoutedEventArgs e)
        {
            Account ActiveAccount = RuntimeDb.SignedInAccount;
            switch (ActiveAccount.Type)
            {
                case AccountType.Eater:
                    Eater Eater = RuntimeDb.FindEater(ActiveAccount.PersonId);
                    Main.Content = new EaterHomeView(Eater);
                    break;
                case AccountType.Cook:
                    Cook Cook = RuntimeDb.FindCook(ActiveAccount.PersonId);
                    Main.Content = new CookHomeView(Cook);
                    break;
                case AccountType.Administrator:
                    Main.Content = new AdminHomeView();
                    break;
            }
        }

        private void BtnFeedback_Click(object sender, RoutedEventArgs e)
        {
            FeedbackWindow FeedbackWindow = new FeedbackWindow();
            FeedbackWindow.Show();
        }
    }
}
