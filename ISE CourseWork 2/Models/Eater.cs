using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    class Eater : Person
    {
        public Eater(
            string FirstName,
            string Surname,
            string PhoneNumber,
            Address Address,
            string FoodPreferences,
            string TravelCapabilities
        ) : base(FirstName, Surname, PhoneNumber, Address)
        {
            this.FoodPreferences = FoodPreferences;
        }

        public string FoodPreferences { get; set; }
    }
}
