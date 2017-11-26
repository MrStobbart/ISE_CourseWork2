using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public enum MealShareStatus { Done, Accepted, Proposal }

    public class MealShare
    {

        public string Id { get; set; }

        public string CookId { get; set; }

        public string EaterId { get; set; }

        public string Meal { get; set; }

        public DateTime DateTime { get; set; }

        public MealShareStatus Status { get; set; }

        public string PicturePath { get; set; }

        public MealShare(string CookId, string EaterId, DateTime DateTime, string Meal)
        {
            this.CookId = CookId;
            this.EaterId = EaterId;
            this.DateTime = DateTime;
            this.Meal = Meal;
            Id = Guid.NewGuid().ToString();
            Status = MealShareStatus.Proposal;
        }

    }
}
