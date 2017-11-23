using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{

    enum PvgStatusEnum {None, AwaitingResult, Rejected, Ok}
    enum FoodHygieneStatusEnum {None, RenewalWithinThreeMonths, Ok}

    public class Cook: Person
    {
        public Cook (Person Person, string FoodPreferences, List<string> TravelCapabilities) : base(Person)
        {
            this.FoodPreferences = FoodPreferences;
            this.TravelCapabilities = TravelCapabilities;
            FoodHygieneStatus = FoodHygieneStatusEnum.None.ToString();
            PvgStatus = PvgStatusEnum.None.ToString();
        }

        public Cook(Person Person) : base(Person)
        {
            FoodPreferences = "";
            TravelCapabilities = new List<string>();
            FoodHygieneStatus = FoodHygieneStatusEnum.None.ToString();
            PvgStatus = PvgStatusEnum.None.ToString();
        }

        public DateTime FoodHygieneStatusOkDateTime{ get; set; }

        public string FoodHygieneStatus { get; set; }

        public string PvgStatus { get; set; }

        public string FoodPreferences { get; set; }

        public List<string> TravelCapabilities { get; set; }

        public void SetFoodHygieneStatusOk()
        {
            FoodHygieneStatus = FoodHygieneStatusEnum.Ok.ToString();
            FoodHygieneStatusOkDateTime = DateTime.Now;
        }

        public void CheckForFoodHygieneRenewal()
        {
            TimeSpan DurationSinceOk = DateTime.Now - FoodHygieneStatusOkDateTime;
            float YearLength = 365.25F;
            if (DurationSinceOk.TotalDays > YearLength * 1.75F)
            {
                FoodHygieneStatus = FoodHygieneStatusEnum.RenewalWithinThreeMonths.ToString();
            }
        }

        public void SetPvgStatusAwaitingResult()
        {
            PvgStatus = PvgStatusEnum.AwaitingResult.ToString();
        }

        public void SetPvgStatusRejected()
        {
            PvgStatus = PvgStatusEnum.Rejected.ToString();
        }

        public void SetPvgStatusOk()
        {
            PvgStatus = PvgStatusEnum.Ok.ToString();
        }

    }
}
