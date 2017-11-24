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
using Xceed.Wpf.Toolkit;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for NewMealShareView.xaml
    /// </summary>
    public partial class NewMealShareView : Page
    {
        private DateTime SelectedDateTime { get; set; }
        private Eater Eater { get; set; }
        private Cook Cook { get; set; }

        private string Meal { get; set; }

        public NewMealShareView(Cook Cook)
        {
            InitializeComponent();
            this.Cook = Cook;
            SelectEaterBox.ItemsSource = ((MainWindow)App.Current.MainWindow).RuntimeDb.Eaters;

            var DateTimeDefault = DateTime.Now;
            DateTimeDefault.AddDays(1);
            DateTimePicker.DefaultValue = DateTimeDefault;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (InputIsValid())
            {
                MealShare MealShare = new MealShare(Cook.Id, Eater.Id, SelectedDateTime, Meal);
                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddMealShare(MealShare);
                ((MainWindow)App.Current.MainWindow).Main.Content = new CookHomeView(Cook);
            }
        }

        private bool InputIsValid()
        {
            SelectedDateTime = (DateTime)DateTimePicker.Value;
            Eater = (Eater)SelectEaterBox.SelectedItem;
            Meal = TxtMeal.Text;

            if (Eater == null)
            {
                TxtWarning.Text = "Please select an eater";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (SelectedDateTime == null)
            {
                TxtWarning.Text = "Please select a data and time to propose";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            if (Meal == "")
            {
                TxtWarning.Text = "Please write the type of meal you want to share";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

    }
}
