using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{

    public enum PvgStatus {None, AwaitingCheck, AwaitingResult, Rejected, Ok}

    public enum FoodHygieneStatus {None, AwaitingCheck, RenewalWithinThreeMonths, Ok}

    public enum TravelCapability { ByFoot, Car, Bike, PublicTransport }

    public class Cook: IPerson
    {
        private DateTime FoodHygieneOkDateTime { get; set; }

        private FoodHygieneStatus foodHygiene;
        public FoodHygieneStatus FoodHygiene
        {
            get { return foodHygiene; }
            set
            {
                foodHygiene = value;
                if(value == FoodHygieneStatus.Ok)
                {
                    FoodHygieneOkDateTime = DateTime.Now;
                }
            }
        }

        public string FoodHygieneCertificatePath { get; set; }

        public PvgStatus Pvg { get; set; }

        public string PvgCertificatePath { get; set; }

        public string FoodPreferences { get; set; }

        public List<TravelCapability> TravelCapabilities { get; set; }


        public Cook (IPerson Person, string FoodPreferences, List<TravelCapability> TravelCapabilities) : base(Person)
        {
            this.FoodPreferences = FoodPreferences;
            this.TravelCapabilities = TravelCapabilities;
            FoodHygiene = FoodHygieneStatus.None;
            Pvg = PvgStatus.None;
        }

        public Cook(IPerson Person) : base(Person)
        {
            FoodPreferences = "";
            TravelCapabilities = new List<TravelCapability>();
            FoodHygiene = FoodHygieneStatus.None;
            Pvg = PvgStatus.None;
        }

        public bool FoodHygieneIsGoingToRunOut()
        {
            TimeSpan DurationSinceOk = DateTime.Now - FoodHygieneOkDateTime;
            float YearLength = 365.25F;
            if (DurationSinceOk.TotalDays > YearLength * 1.75F)
            {
                return true;
            }
            return false;
        }

    }
}
