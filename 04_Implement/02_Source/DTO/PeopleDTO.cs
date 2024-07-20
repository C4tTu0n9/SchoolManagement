using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PeopleDTO
    {
        private string id;
        private string password;
        private string type;
        private string name;
        private string dateofBith;
        private string gender;
        private string email;
        private string phone;
        private string status;

        public string Id { get => id; set => id = value; }
        public string Password { get => password; set => password = value; }
        public string Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public string DateofBith { get => dateofBith; set => dateofBith = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Email { get => email; set => email = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Status { get => status; set => status = value; }

        public PeopleDTO()
        {
            Id = Password = Type = Name  = Gender = Email = Phone = "";
        }
    }
}
