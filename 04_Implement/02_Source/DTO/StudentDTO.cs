using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class StudentDTO:PeopleDTO
    {
        private string nameClass;
        private string schoolYear;
        private string isActive;
        public StudentDTO()
        {
            NameClass = SchoolYear = "";
            isActive = "T";
        }

        public string NameClass { get => nameClass; set => nameClass = value; }
        public string SchoolYear { get => schoolYear; set => schoolYear = value; }
        public string IsActive { get => isActive; set => isActive = value; }
    }
}
