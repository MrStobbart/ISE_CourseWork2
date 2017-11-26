using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{

    public enum PvgStatus {None, AwaitingCheck, AwaitingResult, Rejected, Ok}

    public enum FoodHygieneStatus {None, RenewalWithinThreeMonths, Ok}

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
        private DateTime FoodHygieneUploadTime { get; set; }

        private string foodHygieneCertificatePath;
        public string FoodHygieneCertificatePath
        {
            get { return foodHygieneCertificatePath; }
            set
            {
                foodHygieneCertificatePath = value;
                FoodHygieneUploadTime = DateTime.Now;
            }
        }

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

        public void CheckAndUpdateFoodHygieneAccordingToTime()
        {
            TimeSpan DurationSinceOk = DateTime.Now - FoodHygieneOkDateTime;
            double YearLength = 365.25;
            if (FoodHygiene == FoodHygieneStatus.Ok && DurationSinceOk.TotalDays > YearLength * 1.75)
            {
                FoodHygiene = FoodHygieneStatus.RenewalWithinThreeMonths;
            }
            
            if(FoodHygiene == FoodHygieneStatus.RenewalWithinThreeMonths && DurationSinceOk.TotalDays > YearLength * 2)
            {
                FoodHygiene = FoodHygieneStatus.None;
                FoodHygieneCertificatePath = null;
            }
        }

        public bool FoodHygieneCertificateNeedsCheck()
        {
            bool NewCertificateCheck = FoodHygieneCertificatePath != null && FoodHygiene == FoodHygieneStatus.None;

            bool CertificateRenewalCheck = FoodHygieneCertificatePath != null && (DateTime.Now - FoodHygieneUploadTime).TotalDays > 100 && FoodHygiene == FoodHygieneStatus.RenewalWithinThreeMonths;

            return NewCertificateCheck || CertificateRenewalCheck;
        }

    }
}
