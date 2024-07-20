using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using DTO;

namespace DAO
{
    public class AdminDAO
    {
        private static AdminDAO instance;

        private AdminDAO() { }

        public static AdminDAO Instance()
        {
            if (instance == null)
            {
                instance = new AdminDAO();
            }
            return instance;
        }

        static SqlConnection con;

        public static AdminDTO Login(string id, string pw)
        {
            string sTruyVan = @"select * from Admin where ID= '" + id + @"' and PassWord = '" + pw + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            AdminDTO admin = new AdminDTO();

            admin.Id = dt.Rows[0]["ID"].ToString();
            admin.Name = dt.Rows[0]["Name"].ToString();
            admin.Gender = dt.Rows[0]["Gender"].ToString();
            admin.Email = dt.Rows[0]["Email"].ToString();
            admin.Phone = dt.Rows[0]["Phone"].ToString();
            admin.DateofBith = dt.Rows[0]["BirthDay"].ToString();
            admin.Type = "Admin";
            DataProvider.CloseConnection(con);
            return admin;
        }

        // load danh sách giáo viên từ db
        public static List<TeacherDTO> LoadTeacher()
        {
            List<TeacherDTO> result = new List<TeacherDTO>();

            string sTruyVan = @"Select * From Teacher";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sTruyVan, con);

            if (dt.Rows.Count == 0)
            {
                return null;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TeacherDTO teacher = new TeacherDTO();
                teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                teacher.Name = dt.Rows[i]["Name"].ToString();
                teacher.Gender = dt.Rows[i]["Name"].ToString();
                teacher.Email = dt.Rows[i]["Email"].ToString();
                teacher.Phone = dt.Rows[i]["Phone"].ToString();
                teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                teacher.Password = dt.Rows[i]["PassWord"].ToString();
                result.Add(teacher);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        //xem thông tin giáo viên từ db
        public static DataTable LoadInfo(string idTeacher)
        {
            string sCommand = @"Select * from Teacher where Teacher.IDTeacher = N'" + idTeacher + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            DataProvider.CloseConnection(con);
            return dt;
        }

        //cập nhật điểm vào db
        public static bool changeMark(string idStudent, string subject, string Class, string schoolYear, string semester
            , float FirstFifteenMinutes, float SecondFifteenMinutes
            , float ThirdFifteenMinutes, float FirstFortyFiveMinutes
            , float SecondFortyFiveMinutes, float ThirdFortyFiveMinutes
            , float SemesterMark)
        {
            con = DataProvider.OpenConnection();
            try
            {
                string sTruyVan = @"UPDATE Mark 
                                SET FirstFifteenMinutes = " + FirstFifteenMinutes + @", SecondFifteenMinutes =" + SecondFifteenMinutes + ",ThirdFifteenMinutes =" + ThirdFifteenMinutes + @", FirstFortyFiveMinutes=" + FirstFortyFiveMinutes + @", SecondFortyFiveMinutes=" + SecondFortyFiveMinutes + @", ThirdFortyFiveMinutes=" + ThirdFortyFiveMinutes + @", SemesterMark=" + SemesterMark + @"
                                WHERE IDStudent = N'" + idStudent + @"'and  IDSubject ='" + subject + @"'and Semester='" + semester + @"'and nameClass='" + Class + @"'and schoolYear='" + schoolYear + "'";
                DataProvider.ExecuteQuery(sTruyVan, con);
                DataProvider.CloseConnection(con);
                return true;
            }
            catch (Exception ex)
            {
                DataProvider.CloseConnection(con);
                return false;
            }
        }

        //reset mật khẩu
        public static bool resetPassword(string ID, string newPassWord, string type)
        {
            PeopleDTO Object = new PeopleDTO();
           
            con = DataProvider.OpenConnection();
            if (type == "Student")
            {
                try
                {
                    string sCommand = @"UPDATE Student SET PassWord = '" + newPassWord + "' where IDStudent ='" + ID + "'";
                    bool result  = DataProvider.ExecuteQuery(sCommand, con);
                    DataProvider.CloseConnection(con);
                    return true;
                }
                catch (Exception ex)
                {
                    DataProvider.CloseConnection(con);
                    return false;
                }
            }
            else
            {
                try
                {
                    string sCommand = @"UPDATE Teacher SET PassWord = '" + newPassWord + "' where IDTeacher ='" + ID + "'";
                    bool result = DataProvider.ExecuteQuery(sCommand, con);
                    DataProvider.CloseConnection(con);
                    return result;
                }
                catch (Exception ex)
                {
                    DataProvider.CloseConnection(con);
                    return false;
                }
            }
            
        }

        public static bool changeMyInfomation(string id, string Name, string Gender, string Email, string Phone, string BirthDay)
        {
            string sCommand = @"update Admin
                                set Name = N'" + Name + @"', Gender = '" + Gender + @"', Email = '" + Email + @"', Phone = '" + Phone + @"', BirthDay = '" + BirthDay + @"' 
                                where ID = '" + id + "'";
            con = DataProvider.OpenConnection();
            bool check = DataProvider.ExecuteQuery(sCommand, con);
            DataProvider.CloseConnection(con);
            return check;
        }

        public static List<PeopleDTO> loadListUser(string status)
        {
            List<PeopleDTO> listUser = new List<PeopleDTO>();
            string sCommand = "";
            if (status == "System.Windows.Controls.ComboBoxItem: Active")
            {
                sCommand = @"Select* from Teacher where isActive ='T'";
            }
            else if (status == "System.Windows.Controls.ComboBoxItem: Deactive")
            {
                sCommand = @"Select* from Teacher where isActive ='F'";
            }
            else
            {
                sCommand = @"Select* from Teacher";
            }
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                
            }
            else
            {
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    if (dt.Rows[i]["TypeTeacher"].ToString() == "PDT")
                    {
                        teacher.Type = "AAO Staff";
                    }
                    else
                        teacher.Type = "Teacher";
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    listUser.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                
            }

            // List<PeopleDTO> listStudent = new List<PeopleDTO>();

            if (status == "System.Windows.Controls.ComboBoxItem: Active")
            {
                sCommand = @"Select* from Student where isActive ='T'";
            }
            else if (status == "System.Windows.Controls.ComboBoxItem: Deactive")
            {
                sCommand = @"Select* from Student where isActive ='F'";
            }
            else
            {
                sCommand = @"Select* from Student";
            }
            con = DataProvider.OpenConnection();
            dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);

            }
            else
            {
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO student = new PeopleDTO();
                    student.Id = dt.Rows[i]["IDStudent"].ToString();
                    student.Name = dt.Rows[i]["Name"].ToString();
                    student.Gender = dt.Rows[i]["Gender"].ToString();
                    student.Email = dt.Rows[i]["Email"].ToString();
                    student.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    student.Password = dt.Rows[i]["Password"].ToString();
                    student.Phone = dt.Rows[i]["Phone"].ToString();
                    student.Type = "Student";
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        student.Status = "Active";
                    }
                    else
                    {
                        student.Status = "Deactive";
                    }


                    listUser.Add(student);
                }
                DataProvider.CloseConnection(con);

            }
            return listUser;
        }

        public static List<PeopleDTO> loadListTeacher(string status)
        {
            string sCommand = "";
            if (status == "System.Windows.Controls.ComboBoxItem: Active")
            {
                sCommand = @"Select* from Teacher where isActive = 'T'";
            }
            else if (status == "System.Windows.Controls.ComboBoxItem: Deactive")
            {
                sCommand = @"Select* from Teacher where isActive = 'F'";
            }
            else
            {
                sCommand = @"Select* from Teacher";
            }
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<PeopleDTO> result = new List<PeopleDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    if (dt.Rows[i]["TypeTeacher"].ToString() == "PDT")
                    {
                        teacher.Type = "AAO Staff";
                    }
                    else
                        teacher.Type = "Teacher";
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }



        }

        public static List<PeopleDTO> loadListStudent(string status)
        {
            string sCommand = "";
            if (status == "System.Windows.Controls.ComboBoxItem: Active")
            {
                sCommand = @"Select* from Student where isActive = 'T'";
            }
            else if (status == "System.Windows.Controls.ComboBoxItem: Deactive")
            {
                sCommand = @"Select* from Student where isActive = 'F'";
            }
            else
            {
                sCommand = @"Select* from Student";
            }
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<PeopleDTO> result = new List<PeopleDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO student = new PeopleDTO();
                    student.Id = dt.Rows[i]["IDStudent"].ToString();
                    student.Name = dt.Rows[i]["Name"].ToString();
                    student.Gender = dt.Rows[i]["Gender"].ToString();
                    student.Email = dt.Rows[i]["Email"].ToString();
                    student.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    student.Password = dt.Rows[i]["Password"].ToString();
                    student.Phone = dt.Rows[i]["Phone"].ToString();
                    student.Type = "Student";
                    if (dt.Rows[i]["isActive"].ToString() == "T") 
                    {
                        student.Status = "Active";
                    }
                    else
                    {
                        student.Status = "Deactive";
                    }
                    result.Add(student);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static List<PeopleDTO> searchUser(string authories, string status, string textToSearch)
        {
            string sCommand = "";
            string sCommand2 = "";
            string sCommand3 = "";
            if (authories == "System.Windows.Controls.ComboBoxItem: Student")
            {
                if (status == "System.Windows.Controls.ComboBoxItem: All")
                {
                    sCommand = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%'))";
                }
                else if (status == "System.Windows.Controls.ComboBoxItem: Active")
                {
                    sCommand = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'T'";
                }
                else
                {
                    sCommand = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'F'";
                }
            }
            else if (authories == "System.Windows.Controls.ComboBoxItem: Teacher")
            {
                if (status == "System.Windows.Controls.ComboBoxItem: All")
                {
                    sCommand = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%'))";
                }
                else if (status == "System.Windows.Controls.ComboBoxItem: Active")
                {
                    sCommand = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'T'";
                }
                else
                {
                    sCommand = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'F'";
                }
            }
            else
            {
                if (status == "System.Windows.Controls.ComboBoxItem: All")
                {
                    sCommand2 = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%'))";
                    sCommand3 = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%'))";
                }
                else if (status == "System.Windows.Controls.ComboBoxItem: Active")
                {
                    sCommand2 = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'T'";
                    sCommand3 = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'T'";
                }
                else
                {
                    sCommand2 = @"Select* from Teacher where ((IDTeacher like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'F'";
                    sCommand3 = @"Select* from Student where ((IDStudent like '%" + textToSearch + "%') or (Name like N'%" + textToSearch + "%')) and IsActive = 'F'";
                }
            }


            if (authories == "System.Windows.Controls.ComboBoxItem: Teacher")
            {
                con = DataProvider.OpenConnection();
                DataTable dt = DataProvider.GetDataTable(sCommand, con);
                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                List<PeopleDTO> result = new List<PeopleDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    if (dt.Rows[i]["TypeTeacher"].ToString() == "PDT")
                    {
                        teacher.Type = "AAO Staff";
                    }
                    else
                        teacher.Type = "Teacher";
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;

            }

            else if (authories == "System.Windows.Controls.ComboBoxItem: Student")
            {
                con = DataProvider.OpenConnection();
                DataTable dt = DataProvider.GetDataTable(sCommand, con);
                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                List<PeopleDTO> result = new List<PeopleDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDStudent"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    teacher.Type = "Student";
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }

            else
            {
                List<PeopleDTO> result = new List<PeopleDTO>();
                con = DataProvider.OpenConnection();
                DataTable dt = DataProvider.GetDataTable(sCommand2, con);
                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    if (dt.Rows[i]["TypeTeacher"].ToString() == "PDT")
                    {
                        teacher.Type = "AAO Staff";
                    }
                    else
                        teacher.Type = "Teacher";
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);


                con = DataProvider.OpenConnection();
                dt = DataProvider.GetDataTable(sCommand3, con);
                if (dt.Rows.Count < 0)
                {
                    return null;
                }
                n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    PeopleDTO teacher = new PeopleDTO();
                    teacher.Id = dt.Rows[i]["IDStudent"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Password = dt.Rows[i]["Password"].ToString();
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    teacher.Type = "Student";
                    if (dt.Rows[i]["isActive"].ToString() == "T")
                    {
                        teacher.Status = "Active";
                    }
                    else
                    {
                        teacher.Status = "Deactive";
                    }
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }


        }
       
        public static bool ActiveUser(string id, string type)
        {
            string sCommand = "";
            if (type == "Student")
            {
                sCommand = @"update Student set IsActive = 'T' where IDStudent ='" + id + "'";
            }
            else
            {
                sCommand = @"update Teacher set IsActive = 'T' where IDTeacher ='" + id + "'";
            }
            con = DataProvider.OpenConnection();
            try
            {
                bool result = DataProvider.ExecuteQuery(sCommand, con);
                DataProvider.CloseConnection(con);
                return result;
            }
            catch
            {
                DataProvider.CloseConnection(con);
                return false;
            }
        }

        public static bool DeActiveUser(string id, string type)
        {
            string sCommand = "";
            if (type == "Student")
            {
                sCommand = @"update Student set IsActive = 'F' where IDStudent ='" + id + "'";
            }
            else
            {
                sCommand = @"update Teacher set IsActive = 'F' where IDTeacher ='" + id + "'";
            }
            con = DataProvider.OpenConnection();
            try
            {
                bool result = DataProvider.ExecuteQuery(sCommand, con);
                DataProvider.CloseConnection(con);
                return result;
            }
            catch
            {
                DataProvider.CloseConnection(con);
                return false;
            }
        }

    }
}
