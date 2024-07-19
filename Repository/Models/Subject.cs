using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Subject
    {
        public Subject()
        {
            Marks = new HashSet<Mark>();
        }

        public string SubjectId { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Mark> Marks { get; set; }
    }
}
