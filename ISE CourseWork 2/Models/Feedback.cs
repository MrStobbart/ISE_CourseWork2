using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public enum FeedbackType { MealShare, System }

    public class Feedback
    {
        public string Comment { get; set; }

        public string Id { get; }

        public string UserId { get; set; }

        public string Type { get; set; }

        public int Rating { get; set; }

        public Feedback()
        {
            Id = Guid.NewGuid().ToString();
        }

        public Feedback(int Rating, string Comment, string UserId)
        {
            Id = Guid.NewGuid().ToString();
            this.UserId = UserId;
            this.Comment = Comment;
            this.Rating = Rating;
        }

        public Feedback(int Rating, string Comment)
        {
            Id = Guid.NewGuid().ToString();
            this.Comment = Comment;
            this.Rating = Rating;
        }

        public Feedback(int Rating)
        {
            Id = Guid.NewGuid().ToString();
            this.Rating = Rating;
        }

    }
}
