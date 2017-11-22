using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    class Address
    {
        public Address(string Street, string HouseNumber, string City, string ZipCode)
        {
            this.Street = Street;
            this.HouseNumber = HouseNumber;
            this.City = City;
            this.ZipCode = ZipCode;
        }

        public string Street { get; set; }

        public string HouseNumber { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }
    }
}
