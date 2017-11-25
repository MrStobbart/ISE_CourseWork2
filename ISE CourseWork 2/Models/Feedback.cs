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
        public string Comment { get; set; } = "";

        public string Id { get; }

        public string UserId { get; set; } = "";

        public FeedbackType Type { get; set; }

        public string RegardingPersonId { get; set; } = "";

        public DateTime DateTime { get;  }

        public int Rating { get; set; }

        public Feedback()
        {
            Id = Guid.NewGuid().ToString();
            DateTime = DateTime.Now;
        }

        public Feedback(FeedbackType Type, int Rating, string RegardingPersonId)
        {
            Id = Guid.NewGuid().ToString();
            this.RegardingPersonId = RegardingPersonId;
            this.Rating = Rating;
            this.Type = Type;
            DateTime = DateTime.Now;
        }

        public Feedback(FeedbackType Type, int Rating)
        {
            Id = Guid.NewGuid().ToString();
            this.Rating = Rating;
            this.Type = Type;
            DateTime = DateTime.Now;
        }

    }
}
