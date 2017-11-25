using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class IPerson
    {
        public IPerson(string FirstName, string Surname, string PhoneNumber, Address Address)
        {
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;

            Id = Guid.NewGuid().ToString();
        }

        public IPerson(IPerson Person)
        {
            FirstName = Person.FirstName;
            Surname = Person.Surname;
            PhoneNumber = Person.PhoneNumber;
            Address = Person.Address;
            Id = Person.Id;
        }

        public IPerson()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public string Id { get; }

        public string GetFullName()
        {
            return FirstName + " " + Surname;
        }
    }
}
