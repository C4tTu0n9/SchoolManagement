using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
using System.Text.RegularExpressions;
namespace BUS
{
    public class TeacherBUS
    {
        private static TeacherBUS instance;
        private TeacherBUS() { }
        public static TeacherBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new TeacherBUS();
                return instance;
            }
        }

        public static bool marchEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
        }

        public static bool marchBirthDay(string BirthDay)
        {
            return Regex.IsMatch(BirthDay, @"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$");

        }

        public static void StandalizedBirthDayToDatabase(ref string BirthDay)
        {
            string tempMonth = "";
            string tempDay = "";
            string tempYear = "";
            int j = 0;
            int length = BirthDay.Length;

            for (int i = 0; i < length; i++)
            {
                if (BirthDay[i] != '/')
                {
                    tempDay += BirthDay[i].ToString();
                }
                else
                {
                    j = i;
                    break;
                }
            }

            for (int i = j + 1; i < length; i++)
            {
                if (BirthDay[i] != '/')
                {
                    tempMonth += BirthDay[i].ToString();
                }
                else
                {
                    j = i + 1;
                    break;
                }
            }

            tempYear = BirthDay[j].ToString() + BirthDay[j + 1].ToString() + BirthDay[j + 2].ToString() + BirthDay[j + 3].ToString();
            BirthDay = "";
            BirthDay = tempYear + "-" + tempMonth + "-" + tempDay;
        }

        public static void StandalizedBirthDayToUI(ref string BirthDay)
        {
            string tempMonth = "";
            string tempDay = "";
            string tempYear = "";
            int j = 0;
            int length = BirthDay.Length;


            for (int i = 0; i < length; i++)
            {
                if (BirthDay[i] != '/')
                {
                    tempMonth += BirthDay[i].ToString();
                }
                else
                {
                    j = i;
                    break;
                }
            }

            for (int i = j + 1; i < length; i++)
            {
                if (BirthDay[i] != '/')
                {
                    tempDay += BirthDay[i].ToString();
                }
                else
                {
                    j = i + 1;
                    break;
                }
            }
            tempYear = BirthDay[j].ToString() + BirthDay[j + 1].ToString() + BirthDay[j + 2].ToString() + BirthDay[j + 3].ToString();
            BirthDay = "";
            if (tempDay.Length == 1)
                tempDay.Insert(0, "0");
            if (tempMonth.Length == 1)
                tempMonth.Insert(0, "0");
            BirthDay = tempDay + "/" + tempMonth + "/" + tempYear;
        }

        public static TeacherDTO Login(string User, string Password)
        {
            Global.Teacher = TeacherDAO.Login(User, Password);
            if (Global.Teacher == null)
                return null;
            else
            {
                string BirthDay = Global.Teacher.DateofBith;
                StandalizedBirthDayToUI(ref BirthDay);
                Global.Teacher.DateofBith = BirthDay;
                return Global.Teacher;
            }
        }

        public static bool changeMyInfomation(string idTeacher, string Name, string Gender, string Email, string Phone, string BirthDay)
        {
            if (!marchEmail(Email))
            {
                return false;
            }
            if (!marchBirthDay(BirthDay))
            {
                return false;
            }

            StandalizedBirthDayToDatabase(ref BirthDay);

            
            return TeacherDAO.changeMyInfomation(idTeacher, Name, Gender, Email, Phone, BirthDay);
        }
        public static List<string> loadListClassToComboBox(string idTeacher, string schoolYear)
        {
            return TeacherDAO.loadListClassToComboBox(idTeacher, schoolYear);
        }

        public static List<string> loadSchoolYearToComboBox(string idTeacher)
        {
            return TeacherDAO.loadSchoolYearToComboBox(idTeacher);
        }
        public static bool isMaster(string id, string nameClass, string schoolYear)
        {
            return TeacherDAO.isMaster(id, nameClass, schoolYear);
        }
        public static List<string> loadListSubjectToComboBoxInSearch(string idTeacher, string nameClass, string schoolYear)
        {
            if (TeacherBUS.isMaster(idTeacher,nameClass,schoolYear))
            {
                List<string> temp = SubjectBUS.loadListNameSubject();
                List<string> result = new List<string>();
                result.Add("All");
                for (int i=0;i<temp.Count;i++)
                {
                    result.Add(temp[i]);
                }
                return result;
            }
            return TeacherDAO.loadListSubjectToComboBox(idTeacher, nameClass, schoolYear);
        }

        public static List<string> loadListSubjectToComboBoxInUpdate(string idTeacher, string nameClass, string schoolYear)
        {
          
            return TeacherDAO.loadListSubjectToComboBox(idTeacher, nameClass, schoolYear);
        }
    }
}
