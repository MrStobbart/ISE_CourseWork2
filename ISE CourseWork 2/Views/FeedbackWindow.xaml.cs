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

        private string UserId { get; set; }

        private string RegardingPersonId { get; set; }


        public FeedbackWindow(string UserId, string RegardingPersonId)
        {
            InitializeComponent();
            this.UserId = UserId;
            this.RegardingPersonId = RegardingPersonId;

            Cook Cook = ((MainWindow)App.Current.MainWindow).RuntimeDb.FindCook(RegardingPersonId);

            TxtInformation.Text = "Please give your feedback regarding the meal you shared with the cook " + Cook.FirstName + " " + Cook.Surname + ".";

        }

        public FeedbackWindow(string UserId)
        {
            InitializeComponent();
            this.UserId = UserId;
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

                if (RegardingPersonId != "")
                {
                    Feedback.RegardingPersonId = RegardingPersonId;
                }

                if (((MainWindow)App.Current.MainWindow).RuntimeDb.SignedIn)
                {
                    Feedback.UserId = ((MainWindow)App.Current.MainWindow).RuntimeDb.SignedInAccount.Id;
                }

                ((MainWindow)App.Current.MainWindow).RuntimeDb.AddFeedback(Feedback);

                RuntimeDb test = ((MainWindow)App.Current.MainWindow).RuntimeDb;
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
