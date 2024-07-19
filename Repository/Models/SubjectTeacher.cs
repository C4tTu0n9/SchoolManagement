using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class SubjectTeacher
    {
        public string SubjectId { get; set; }
        public string TeacherId { get; set; }
        public string ClassId { get; set; }

        public virtual Class Class { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
