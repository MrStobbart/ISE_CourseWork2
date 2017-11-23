using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Eater : Person
    {

        public Eater(Person Person, string FoodPreferences) : base(Person)
        {
            this.FoodPreferences = FoodPreferences;
        }

        public Eater(Person Person) : base(Person)
        {

        }

        public string FoodPreferences { get; set; }
    }
}
