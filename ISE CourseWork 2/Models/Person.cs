using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Person
    {
        public Person(string FirstName, string Surname, string PhoneNumber, Address Address)
        {
            this.FirstName = FirstName;
            this.Surname = Surname;
            this.PhoneNumber = PhoneNumber;
            this.Address = Address;

            Id = Guid.NewGuid().ToString();
            Console.WriteLine("We created this id " + Id);
        }

        public Person()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string FirstName { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public Address Address { get; set; }

        public string Id { get; }
    }
}
