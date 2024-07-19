using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Student
    {
        public Student()
        {
            Marks = new HashSet<Mark>();
        }

        public string StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
