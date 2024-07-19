using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Teacher
    {
        public string TeacherId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }
    }
}
