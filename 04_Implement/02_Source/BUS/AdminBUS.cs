using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class AdminBUS
    {
        private static AdminBUS instance;
        private AdminBUS() { }

        public static AdminBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new AdminBUS();
                return instance;
            }
        }

        public static AdminDTO Login(string User, string Password)
        {
            Global.Admin = AdminDAO.Login(User, Password);
            if (Global.Admin == null)
                return null;
            else
            {
                string BirthDay = Global.Admin.DateofBith;
                BUS.TeacherBUS.StandalizedBirthDayToUI(ref BirthDay);
                Global.Admin.DateofBith = BirthDay;
                return Global.Admin;
            }
        }
        public static bool changeMyInfomation(string id, string Name, string Gender, string Email, string Phone, string BirthDay)
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

            return AdminDAO.changeMyInfomation(id, Name, Gender, Email, Phone, BirthDay);
        }

        public static List<PeopleDTO> loadListUser(string status)
        {
            List<PeopleDTO> result = AdminDAO.loadListUser(status);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith.ToString();
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }

        public static List<PeopleDTO> loadListStudent(string status)
        {
            List<PeopleDTO> result = AdminDAO.loadListStudent(status);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith.ToString();
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }

        public static List<PeopleDTO> loadListTeacher(string status)
        {
            List<PeopleDTO> result = AdminDAO.loadListTeacher(status);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith.ToString();
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }

        public static List<PeopleDTO> searchUser(string authories, string status, string textToSearch)
        {
            List<PeopleDTO> result = AdminDAO.searchUser(authories, status, textToSearch);
            if (result != null)
            {
                int n = result.Count;
                for (int i=0;i<n;i++)
                {
                    string birthDay = result[i].DateofBith.ToString();
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }

        public static bool resetPassword(string ID, string newPassWord, string type)
        {
            return AdminDAO.resetPassword(ID, newPassWord, type);
        }

        public static bool ActiveUser(string id, string type)
        {
            return AdminDAO.ActiveUser(id, type);
        }

        public static bool DeActiveUser(string id, string type)
        {
            return AdminDAO.DeActiveUser(id, type);
        }
    }
}
