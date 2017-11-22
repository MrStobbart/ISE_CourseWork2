using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    class Cook: Person
    {
        public Cook (
            string FirstName, 
            string Surname, 
            string PhoneNumber, 
            Address Address, 
            string FoodPreferences, 
            string TravelCapabilities
        ) : base(FirstName, Surname, PhoneNumber, Address)
        {
            this.FoodPreferences = FoodPreferences;
            this.TravelCapabilities = TravelCapabilities;
            FoodHygieneStatus = "None";
            PvgStatus = "None";
        }

        public Cook() : base()
        {
            FoodHygieneStatus = "None";
            PvgStatus = "None";
        }
        public string FoodHygieneStatus { get; }

        public string PvgStatus { get; }

        public string FoodPreferences { get; set; }

        public string TravelCapabilities { get; set; }

    }
}
