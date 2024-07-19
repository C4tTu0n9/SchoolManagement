using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Student_Management.Pages.Subjects
{
    public class SubjectViewModel
    {
        public string SubjectId { get; set; }
        public string Title { get; set; }
        public int NumberOfStudents { get; set; }
        public int NumberOfTeachers { get; set; }
        public int NumberOfClasses { get; set; }
    }
}
