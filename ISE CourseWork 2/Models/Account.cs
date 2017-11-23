using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISE_CourseWork_2.Models
{
    public class Account
    {
        public Account(string Email, string Password, string Type, string PersonId)
        {
            this.Email = Email;
            this.Password = Password;
            this.Type = Type;
            this.PersonId = PersonId;
            Id = Guid.NewGuid().ToString();
        }
        public Account()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; }

        public string PersonId { get; set; }

        public string Email { get; set; }

        public string Type { get; set; }

        public string Password { get; set; }

    }
}
