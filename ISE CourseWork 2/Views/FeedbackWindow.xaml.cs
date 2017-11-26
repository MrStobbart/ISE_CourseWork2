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
using System.Windows.Shapes;
using ISE_CourseWork_2.Models;

namespace ISE_CourseWork_2.Views
{
    /// <summary>
    /// Interaction logic for Feedback.xaml
    /// </summary>
    public partial class FeedbackWindow : Window
    {
        private int Rating { get; set; }

        private string Comment { get; set; }

        private string MealShareId { get; set; }

        private MealShare MealShare { get; set; }

        private Cook Cook { get; set; }

        private Eater Eater { get; set; }


        public FeedbackWindow(string MealShareId)
        {
            InitializeComponent();
            this.MealShareId = MealShareId;

            MealShare = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindMealShare(MealShareId);
            Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(MealShare.CookId);
            Eater = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindEater(MealShare.EaterId);


            TxtInformation.Text = "Please give your feedback regarding the meal you shared with the cook " + Cook.FirstName + " " + Cook.Surname + ".";

        }

        public FeedbackWindow()
        {
            InitializeComponent();
        }

        private void BtnSendFeedback_Click(object sender, RoutedEventArgs e)
        {
            Rating = RatingField.Value;
            Comment = TxtComment.Text;

            if (RatingWasSelected())
            {
                Feedback Feedback = new Feedback(FeedbackType.System, Rating);

                if (Comment != "")
                {
                    Feedback.Comment = Comment;
                }

                if(MealShare != null)
                {
                    Feedback.Type = FeedbackType.MealShare;
                    Feedback.MealShareId = MealShareId;
                }


                if (((MainWindow)App.Current.MainWindow).RuntimeDb.SignedIn)
                {
                    Feedback.AccountId = ((MainWindow)App.Current.MainWindow).RuntimeDb.SignedInAccount.Id;
                }

                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddFeedback(Feedback);

                Close();
            }
            
        }

        private bool RatingWasSelected()
        {
            if (Rating == 0)
            {
                TxtWarning.Text = "Please select a rating";
                TxtWarning.Visibility = Visibility.Visible;
                return false;
            }

            return true;
        }

    }
}
