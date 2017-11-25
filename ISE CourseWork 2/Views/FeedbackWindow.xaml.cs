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

            Feedback Feedback = new Feedback(Rating);

            if(Comment != "")
            {
                Feedback.Comment = Comment;
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
}
