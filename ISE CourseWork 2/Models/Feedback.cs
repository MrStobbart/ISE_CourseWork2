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
        public string Id { get; }
        public DateTime DateTime { get;  }

        public FeedbackType Type { get; set; }

        public int Rating { get; set; }

        public string Comment { get; set; } = "";

        public string AccountId { get; set; } = "";

        public string MealShareId { get; set; } = "";



        public Feedback(FeedbackType Type)
        {
            Id = Guid.NewGuid().ToString();
            DateTime = DateTime.Now;
            this.Type = Type;
        }

        public Feedback(FeedbackType Type, int Rating)
        {
            Id = Guid.NewGuid().ToString();
            DateTime = DateTime.Now;
            this.Rating = Rating;
            this.Type = Type;
        }

    }
}
