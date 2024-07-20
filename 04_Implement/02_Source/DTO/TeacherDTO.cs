using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TeacherDTO:PeopleDTO
    {
        private string namePosition;
        public string NamePosition { get => namePosition; set => namePosition = value; }

        public TeacherDTO()
        {
            this.namePosition = "";
        }
    }
}
