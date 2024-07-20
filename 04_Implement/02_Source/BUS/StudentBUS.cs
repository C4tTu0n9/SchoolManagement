using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Text.RegularExpressions;
namespace BUS
{
    public class StudentBUS
    {
        private static StudentBUS instance;
        private StudentBUS() { }

        public static StudentBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new StudentBUS();
                return instance;
            }
        }

      /*  public static bool marchEmail(string Email)
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
        }*/

        public static StudentDTO Login(string User,string Password)
        {
            Global.Student = StudentDAO.Login(User, Password);
            if (Global.Student == null)
                return null;
            else
            {
                string BirthDay = Global.Student.DateofBith;
                BUS.TeacherBUS.StandalizedBirthDayToUI(ref BirthDay);
                Global.Student.DateofBith = BirthDay;
                return Global.Student;
            }
        }
        public static bool changeMyInfomation(string idStudent, string Name, string Gender, string Email, string Phone, string BirthDay)
        {
            if (!TeacherBUS.marchEmail(Email))
            {
                return false;
            }
            if (!TeacherBUS.marchBirthDay(BirthDay))
            {
                return false;
            }

           TeacherBUS.StandalizedBirthDayToDatabase(ref BirthDay);

            return StudentDAO.changeMyInfomation(idStudent, Name, Gender, Email, Phone, BirthDay);
        }
    }
}
