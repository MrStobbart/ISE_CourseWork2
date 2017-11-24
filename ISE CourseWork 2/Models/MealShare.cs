using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    class MealShare
    {
        public enum MealShareStatus { Done, Accepted, Proposal }

        public string Id { get; set; }

        public string CookId { get; set; }

        public string EaterId { get; set; }

        public DateTime DateTime { get; set; }

        public List<DateTime> ProposedDateTimes { get; set; }

        public MealShareStatus Status { get; set; }

        public MealShare(string CookId, string EaterId, List<DateTime> ProposedDateTimes)
        {
            this.CookId = CookId;
            this.EaterId = EaterId;
            this.ProposedDateTimes = ProposedDateTimes;
            Id = Guid.NewGuid().ToString();
            Status = MealShareStatus.Proposal;
        }

    }
}
