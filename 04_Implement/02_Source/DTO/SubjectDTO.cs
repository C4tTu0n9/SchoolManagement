using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class SubjectDTO
    {
        private string idSubject;
        private string nameSubject;
    

        public string IdSubject { get => idSubject; set => idSubject = value; }
        public string NameSubject { get => nameSubject; set => nameSubject = value; }
       

        public SubjectDTO()
        {
            idSubject = NameSubject = "";
        }
        public static string getNameSubject(string id)
        {
            if (id =="MATH")
            {
                return "Math";
            }
            else if (id == "AV")
            {
                return "English";
            }
            else if (id == "CN")
            {
                return "Technology";
            }
            else if (id == "DL")
            {
                return "Geography";
            }
            else if (id == "GDCD")
            {
                return "Civic Education";
            }
            else if (id == "GDQP")
            {
                return "Defense Education";
            }
            else if (id == "LS")
            {
                return "History";
            }
            else if (id == "NV")
            {
                return "Literature";
            }
            else if (id == "SH")
            {
                return "Biology";
            }
            else
            {
                return "Infomation Techonogy";
            }
        }

        public static string getIDSubject(string name)
        {
            if (name == "Math")
            {
                return "MATH";
            }
            else if (name == "Literature")
            {
                return "NV";
            }
            else if (name == "English")
            {
                return "AV";
            }
            else if (name == "Biology")
            {
                return "SH";
            }
            else if (name == "Geography")
            {
                return "DL";
            }
            else if (name == "Infomation Technology")
            {
                return "TH";
            }
            else if (name =="Civic Education")
            {
                return "GDCD";
            }
            else if (name == "Technology")
            {
                return "CN";
            }
            else if (name == "Defense Education")
            {
                return "GDQP";
            }
            else
            {
                return "LS";
            }
        }
    }
}
