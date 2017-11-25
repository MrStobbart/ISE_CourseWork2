using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace ISE_CourseWork_2.Models
{
    public enum AccountType { Eater, Cook, Administrator}
    public class Account
    {

        public Account(string Email, string Password, AccountType Type, string PersonId)
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

        public AccountType Type { get; set; }


        public string Username { get; set; }

        private string _password;

        public string Password
        {
            get
            {
                return _password;
            }

            set
            {
                // TODO encrypt password
                _password = value;
            }
        }
    }
}
