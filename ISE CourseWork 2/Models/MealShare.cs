using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class MealShare
    {
        public enum MealShareStatus { Done, Accepted, Proposal }

        public string Id { get; set; }

        public string CookId { get; set; }

        public string EaterId { get; set; }

        public string Meal { get; set; }

        public DateTime DateTime { get; set; }

        public DateTime ProposedDateTime { get; set; }

        public MealShareStatus Status { get; set; }

        public MealShare(string CookId, string EaterId, DateTime ProposedDateTime, string Meal)
        {
            this.CookId = CookId;
            this.EaterId = EaterId;
            this.ProposedDateTime = ProposedDateTime;
            this.Meal = Meal;
            Id = Guid.NewGuid().ToString();
            Status = MealShareStatus.Proposal;
        }

    }
}
