using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Eater : IPerson
    {
        public string FoodPreferences { get; set; }

        public Eater(IPerson Person, string FoodPreferences) : base(Person)
        {
            this.FoodPreferences = FoodPreferences.ToLower();
        }

        public Eater(IPerson Person) : base(Person)
        {
            FoodPreferences = null;
        }


        public override string ToString()
        {
            if(FoodPreferences != null)
            {
                return FirstName + " " + Surname + " who likes " + FoodPreferences + " - " + Address.Street + ", " + Address.City;
            }
            return FirstName + " " + Surname + ": " + Address.Street + ", " + Address.City;
        }
    }
}
