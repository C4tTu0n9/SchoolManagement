using System;
using System.Collections.Generic;

#nullable disable

namespace Repository.Models
{
    public partial class Mark
    {
        public int MarkId { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
        public DateTime? Date { get; set; }
        public int? Mark1 { get; set; }

        public virtual Student Student { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
