using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class ClassDTO
    {
        private string name;
        private string schoolYear;
        private string idMaster;

        public string Name { get => name; set => name = value; }
        public string SchoolYear { get => schoolYear; set => schoolYear = value; }
        public string IdMaster { get => idMaster; set => idMaster = value; }
    }
}
