using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Eater : IPerson
    {

        public Eater(IPerson Person, string FoodPreferences) : base(Person)
        {
            this.FoodPreferences = FoodPreferences;
        }

        public Eater(IPerson Person) : base(Person)
        {

        }

        public string FoodPreferences { get; set; }

        public override string ToString()
        {
            return FirstName + " " + Surname;
        }
    }
}
