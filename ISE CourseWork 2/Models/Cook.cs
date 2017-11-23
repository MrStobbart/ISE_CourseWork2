using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Cook: Person
    {
        public Cook (Person Person, string FoodPreferences, List<string> TravelCapabilities) : base(Person)
        {
            this.FoodPreferences = FoodPreferences;
            this.TravelCapabilities = TravelCapabilities;
            FoodHygieneStatus = "None";
            PvgStatus = "None";
        }

        public Cook(Person Person) : base(Person)
        {
            FoodPreferences = "";
            TravelCapabilities = new List<string>();
            FoodHygieneStatus = "None";
            PvgStatus = "None";
        }

        public string FoodHygieneStatus { get; }

        public string PvgStatus { get; }

        public string FoodPreferences { get; set; }

        public List<string> TravelCapabilities { get; set; }

    }
}
