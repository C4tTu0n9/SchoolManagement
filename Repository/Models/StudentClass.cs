using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class StudentClass
    {
        public string StudentId { get; set; }
        public string ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Student Student { get; set; }
    }
}
