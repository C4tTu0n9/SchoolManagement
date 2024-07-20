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
    public class AcademicAffairsOfficeDAO
    {
        // load danh sách sinh viên theo lớp, theo năm học
        static SqlConnection con;
        private static AcademicAffairsOfficeDAO instance;
        private AcademicAffairsOfficeDAO() { }
        public static AcademicAffairsOfficeDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AcademicAffairsOfficeDAO();
                return instance;
            }
        }
        public static List<StudentDTO> LoadStudent(string className, string SchoolYear)
        {
            string sTruyVan = @"Select * from Student S join Student_Class SC on (S.IDStudent = SC.IDStudent) where SC.nameClass = '" + className + @"' and SC.schoolYear = '" + SchoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<StudentDTO> result = new List<StudentDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentDTO student = new StudentDTO();
                student.Id = dt.Rows[i]["IDStudent"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Gender = dt.Rows[i]["Gender"].ToString();
                student.Email = dt.Rows[i]["Email"].ToString();
                student.Phone = dt.Rows[i]["Phone"].ToString();
                student.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                student.NameClass = dt.Rows[i]["nameClass"].ToString();
                student.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                result.Add(student);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        // Xem điểm sinh viên theo lớp, theo môn và theo năm học, theo học kỳ
        public static DataTable LoadMark(string className, string nameSubject, string schoolYear, string Semester)
        {
            string sCommand = @"Select Student.IDStudent, Student.Name, Mark.FirstFifteenMinutes, Mark.SecondFifteenMinutes, Mark.ThirdFifteenMinutes, Mark.FirstFortyFiveMinutes, Mark.SecondFortyFiveMinutes, Mark.ThirdFortyFiveMinutes, Mark.SemesterMark
                                from Mark join Student on Mark.IDStudent = Student.IDStudent join Subject on Mark.IDSubject = Subject.IDSubject 
                                where Mark.nameClass = '" + className + @"'and Mark.schoolYear = '" + schoolYear + @"'and Subject.NameSubject = N'" + nameSubject + @"'and Mark.Semester = '" + Semester + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            DataProvider.CloseConnection(con);
            return dt;
        }

        // Tìm sinh viên theo tên, trả về ID sinh viên
        public static List<string> FindStudentByName(string nameStudent)
        {
            string sCommand = @"Select IDStudent from Student where Name = N'" + nameStudent + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<string> result = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[0][0].ToString();
                result.Add(id);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        // Tìm sinh viên theo ID, trả về ID sinh viên
        public static string FindStudentByID(string ID)
        {
            string sCommand = @"Select IDStudent from Student where IDStudent = '" + ID + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            string result;
            result = dt.Rows[0][0].ToString();
            DataProvider.CloseConnection(con);
            return result;
        }

        // Tìm sinh viên theo lớp, trả về ID sinh viên
        public static List<string> FindStudentByClass(string Class)
        {
            string sCommand = @"Select IDStudent from Student where nameClass = '" + Class + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<string> result = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[0][0].ToString();
                result.Add(id);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        // Hàm phục vụ cho việc tìm kiếm sinh viên lúc đang xem điểm (theo tên)
        public static DataTable FindStudentByNameWhenGetListMark(string nameStudent, string className, string nameSubject, string schoolYear, string Semester)
        {
            List<string> listID = FindStudentByName(nameStudent);
            string endCommand = "(N'";
            int n = listID.Count;
            for (int i = 0; i < n; i++)
            {
                if (i != n - 1)
                {
                    endCommand += listID[i] + "',N'";
                }
                else
                {
                    endCommand += listID[i] + "')";
                }

            }

            string sCommand = @"Select Student.IDStudent, Student.Name, Mark.FirstFifteenMinutes, Mark.SecondFifteenMinutes, Mark.ThirdFifteenMinutes, Mark.FirstFortyFiveMinutes, Mark.SecondFortyFiveMinutes, Mark.ThirdFortyFiveMinutes, Mark.SemesterMark
                                from Mark join Student on Mark.IDStudent = Student.IDStudent join Subject on Mark.IDSubject = Subject.IDSubject 
                                where Mark.nameClass = '" + className + @"'and Mark.schoolYear = '" + schoolYear + @"'and Subject.NameSubject = N'" + nameSubject + @"'and Mark.Semester = '" + Semester + "' and Student.IDStudent in " + endCommand;
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            DataProvider.CloseConnection(con);
            return dt;
        }

        // Hàm phục vụ cho việc tìm kiếm sinh viên lúc đang xem điểm (theo ID)
        public static DataTable FindStudentByIDWhenGetListMark(string id, string className, string nameSubject, string schoolYear, string Semester)
        {
            string ID = FindStudentByID(id);
            string sCommand = @"Select Student.IDStudent, Student.Name, Mark.FirstFifteenMinutes, Mark.SecondFifteenMinutes, Mark.ThirdFifteenMinutes, Mark.FirstFortyFiveMinutes, Mark.SecondFortyFiveMinutes, Mark.ThirdFortyFiveMinutes, Mark.SemesterMark
                                from Mark join Student on Mark.IDStudent = Student.IDStudent join Subject on Mark.IDSubject = Subject.IDSubject 
                                where Mark.nameClass = '" + className + @"'and Mark.schoolYear = '" + schoolYear + @"'and Subject.NameSubject = N'" + nameSubject + @"'and Mark.Semester = '" + Semester + "' and Student.IDStudent = '" + ID + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            DataProvider.CloseConnection(con);
            return dt;
        }

        // Thêm học sinh mới
        public static bool AddNewStudent(StudentDTO student)
        {
            string sCommand = string.Format(@"Insert into Student(IDStudent,Name,Gender,Email,Phone,BirthDay,PassWord, isActive) values ('{0}',N'{1}','{2}','{3}','{4}','{5}','{6}','{7}')", student.Id, student.Name, student.Gender, student.Email, student.Phone, student.DateofBith, student.Password, student.IsActive);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static List<string> loadListClassToComboBox()
        {
            var temp = classDAO.loadListClass();
            int n = temp.Count;
            List<string> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string class_ = temp[i].Name;
                result.Add(class_);
            }
            return result.Distinct().ToList();

        }

        public static List<string> loadListClassToComboBox(string schoolYear)
        {
            var temp = classDAO.loadListClass(schoolYear);
            int n = temp.Count;
            List<string> result = new List<string>();
            for (int i = 0; i < n; i++)
            {
                string class_ = temp[i].Name;
                result.Add(class_);
            }
            return result.Distinct().ToList();

        }

        public static List<string> loadSchoolYearToComboBox()
        {
            return classDAO.loadSchoolYear();
        }

        public static List<StudentDTO> searchStudent(string textToSearch, string nameClass, string schoolYear)
        {
            string sCommand = @"Select* from Student S join Student_Class SC on (S.IDStudent = SC.IDStudent) where ((S.Name like N'%" + textToSearch + "%') or (SC.IDStudent like '%" + textToSearch + "%')) and SC.nameClass = '" + nameClass + "' and SC.schoolYear = '" + schoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<StudentDTO> result = new List<StudentDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentDTO student = new StudentDTO();
                student.Id = dt.Rows[i]["IDStudent"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Gender = dt.Rows[i]["Gender"].ToString();
                student.Email = dt.Rows[i]["Email"].ToString();
                student.Phone = dt.Rows[i]["Phone"].ToString();
                student.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                student.NameClass = dt.Rows[i]["nameClass"].ToString();
                student.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                if (dt.Rows[i]["isActive"].ToString() == "T")
                {
                    student.IsActive = "Active";
                }
                else

                {
                    student.IsActive = "Deactive";
                }
                result.Add(student);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        public static List<StudentDTO> loadStudentNotInClass(string schoolYear)
        {
            string sCommand = @"select distinct S.*
                                from Student S, Student_Class SC
                                where S.IDStudent in (select IDStudent from Student) and S.IDStudent not in (select IDStudent from Student_Class) and SC.schoolYear ='" + schoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            int n = dt.Rows.Count;
            List<StudentDTO> result = new List<StudentDTO>();
            for (int i = 0; i < n; i++)
            {
                StudentDTO student = new StudentDTO();
                student.Id = dt.Rows[i]["IDStudent"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Gender = dt.Rows[i]["Gender"].ToString();
                student.Email = dt.Rows[i]["Email"].ToString();
                student.Phone = dt.Rows[i]["Phone"].ToString();
                student.DateofBith = dt.Rows[i]["BirthDay"].ToString();

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

        public static List<StudentDTO> searchStudentNotInClass(string textToSearch, string schoolYear)
        {
            string sCommand = @"select distinct S.*
                                from Student S, Student_Class SC
                                where S.IDStudent in (select IDStudent from Student) and S.IDStudent not in (select IDStudent from Student_Class) and SC.schoolYear ='" + schoolYear + "' and ((S.IDStudent like '%" + textToSearch + "%') or (S.Name like N'%" + textToSearch + "%'))";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            int n = dt.Rows.Count;
            List<StudentDTO> result = new List<StudentDTO>();
            for (int i = 0; i < n; i++)
            {
                StudentDTO student = new StudentDTO();
                student.Id = dt.Rows[i]["IDStudent"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Gender = dt.Rows[i]["Gender"].ToString();
                student.Email = dt.Rows[i]["Email"].ToString();
                student.Phone = dt.Rows[i]["Phone"].ToString();
                student.DateofBith = dt.Rows[i]["BirthDay"].ToString();

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

        public static List<StudentDTO> LoadStudent(string nameClass, string schoolYear, string status)
        {
            string sCommand = "";
            if (status == "System.Windows.Controls.ComboBoxItem: Active")
            {
                sCommand = @"Select * from Student S join Student_Class SC on (S.IDStudent = SC.IDStudent) where SC.nameClass = '" + nameClass + @"' and SC.schoolYear = '" + schoolYear + "' and S.IsActive = 'T'";
            }
            else if (status == "System.Windows.Controls.ComboBoxItem: Deactive")
            {
                sCommand = @"Select * from Student S join Student_Class SC on (S.IDStudent = SC.IDStudent) where SC.nameClass = '" + nameClass + @"' and SC.schoolYear = '" + schoolYear + "' and S.IsActive = 'F'";
            }
            else
            {
                sCommand = @"Select * from Student S join Student_Class SC on (S.IDStudent = SC.IDStudent) where SC.nameClass = '" + nameClass + @"' and SC.schoolYear = '" + schoolYear + "'";
            }
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<StudentDTO> result = new List<StudentDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StudentDTO student = new StudentDTO();
                student.Id = dt.Rows[i]["IDStudent"].ToString();
                student.Name = dt.Rows[i]["Name"].ToString();
                student.Gender = dt.Rows[i]["Gender"].ToString();
                student.Email = dt.Rows[i]["Email"].ToString();
                student.Phone = dt.Rows[i]["Phone"].ToString();
                student.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                student.NameClass = dt.Rows[i]["nameClass"].ToString();
                student.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
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

        public static bool initMark(int semester, string className, string schoolYear, string idSubject, string idStudent)
        {
            string sCommand = @"Insert into Mark values(" + semester.ToString() + ",0,0,0,0,0,0,0,'" + idStudent + "','" + idSubject + "','" + className + "','" + schoolYear + "')";
            con = DataProvider.OpenConnection();
            try
            {
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

        public static bool InsertMark(MarkDTO mark)
        {
            string sCommand = string.Format(@"Insert into Mark values('{0}',{1},{2},{3},{4},{5},{6},{7},'{8}','{9}','{10}','{11}')", mark.Semester.ToString(), mark.FirstFifteenMinutesMark, mark.SecondFifteenMinutesMark, mark.ThirdFifteenMinutesMark, mark.FirstFortyFiveMinutesMark, mark.SecondFortyFiveMinutesMark, mark.ThirdFortyFiveMinutesMark, mark.SemesterScore, mark.IDStudent, mark.Subject.IdSubject, mark.NameClass, mark.SchoolYear);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static bool InsertStudentToClass(string IDStudent, string nameClass, string schoolYear)
        {
            string sCommand = string.Format("Insert into Student_Class values('{0}','{1}','{2}')", IDStudent, nameClass, schoolYear);
            bool result = true;
            con = DataProvider.OpenConnection();
            try
            {
                result = DataProvider.ExecuteQuery(sCommand, con);
                DataProvider.CloseConnection(con);

            }
            catch (Exception ex)
            {
                DataProvider.CloseConnection(con);
                return false;
            }

            if (result == false)
                return false;

            string[] idSubjects = { "MATH", "NV", "AV", "SH", "CN", "LS", "DL", "GDCD", "GDQP", "TH" };

            int n = idSubjects.Length;
            for (int i = 0; i < n; i++)
            {
                initMark(1, nameClass, schoolYear, idSubjects[i], IDStudent);
                initMark(2, nameClass, schoolYear, idSubjects[i], IDStudent);
            }
            return true;

        }

        public static bool updateInfoStudent(StudentDTO student)
        {
            string sCommand = string.Format(@"Update student set Name = N'{0}', BirthDay = '{1}', Email = '{2}', Gender = '{3}', Phone = '{4}' where IDStudent = '{5}'", student.Name, student.DateofBith, student.Email, student.Gender, student.Phone, student.Id);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static bool deActiveStudent(string IDStudent)
        {
            string sCommand = string.Format(@"Update Student set isActive = 'F' where IDStudent = '{0}'", IDStudent);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static bool ActiveStudent(string IDStudent)
        {
            string sCommand = string.Format(@"Update Student set isActive = 'T' where IDStudent = '{0}'", IDStudent);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static bool isMaster(string IDTeacher, string schoolYear)
        {
            string sCommand = @"select* from Class where IDMaster = '" + IDTeacher + "' and schoolYear ='" + schoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return false;
            }
            else
            {
                return true;
            }
        }

        public static List<TeacherDTO> loadListTeacher()
        {
            string sCommand = @"Select* from Teacher";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<TeacherDTO> result = new List<TeacherDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    TeacherDTO teacher = new TeacherDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Type = dt.Rows[i]["TypeTeacher"].ToString();
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }

        }

        public static List<TeacherDTO> loadListHomeRoomTeacher(string schoolYear)
        {
            string sCommand = @"select T.* from Teacher T join Class C on (T.IDTeacher = C.IDMaster) where C.schoolYear = '" + schoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<TeacherDTO> result = new List<TeacherDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    TeacherDTO teacher = new TeacherDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Type = dt.Rows[i]["TypeTeacher"].ToString();
                    teacher.NamePosition = "Homeroom Teacher";
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static List<TeacherDTO> loadListAAOS()
        {
            string sCommand = @"Select* from Teacher where TypeTeacher = 'PDT'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<TeacherDTO> result = new List<TeacherDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    TeacherDTO teacher = new TeacherDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Type = dt.Rows[i]["TypeTeacher"].ToString();
                    teacher.NamePosition = "AAO Staff";
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static List<TeacherDTO> loadListSubjectTeacher(string schoolYear)
        {
            string sCommand = "Select * from Teacher where IDTeacher in (select IDTeacher from Assign where schoolYear = '" + schoolYear + "')";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                List<TeacherDTO> result = new List<TeacherDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    TeacherDTO teacher = new TeacherDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Type = dt.Rows[i]["TypeTeacher"].ToString();
                    teacher.NamePosition = "Subject Teacher";
                    teacher.Phone = dt.Rows[i]["Phone"].ToString();
                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);



                return result;
            }
        }

        public static List<TeacherDTO> searchTeacher(string textToSearch, string schoolYear, string position)
        {
            string sCommand = "";

            if (position == "System.Windows.Controls.ComboBoxItem: Academic Affair Office Staff")
            {
                sCommand = @"Select* from Teacher where TypeTeacher = 'PDT' and ((Name like N'%" + textToSearch + "%') or (IDTeacher like '%+" + textToSearch + "%'))";
            }
            else if (position == "System.Windows.Controls.ComboBoxItem: Homeroom Teacher")
            {
                sCommand = @"select T.* from Teacher T join Class C on (T.IDTeacher = C.IDMaster) where C.schoolYear = '" + schoolYear + "' and ((T.Name like N'%" + textToSearch + "%') or (T.IDTeacher like '%" + textToSearch + "%'))";
            }
            else if (position == "System.Windows.Controls.ComboBoxItem: Subject Teacher")
            {
                sCommand = "Select * from Teacher where IDTeacher in (select IDTeacher from Assign where schoolYear = '" + schoolYear + "') and ((Name like N'%" + textToSearch + "%') or (IDTeacher like '%" + textToSearch + "%'))";
            }
            else
            {
                sCommand = @"Select* from Teacher where ((Name like N'%" + textToSearch + "%') or (IDTeacher like '%" + textToSearch + "%'))";
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
                List<TeacherDTO> result = new List<TeacherDTO>();
                int n = dt.Rows.Count;
                for (int i = 0; i < n; i++)
                {
                    TeacherDTO teacher = new TeacherDTO();
                    teacher.Id = dt.Rows[i]["IDTeacher"].ToString();
                    teacher.Name = dt.Rows[i]["Name"].ToString();
                    teacher.Gender = dt.Rows[i]["Gender"].ToString();
                    teacher.Email = dt.Rows[i]["Email"].ToString();
                    teacher.DateofBith = dt.Rows[i]["BirthDay"].ToString();
                    teacher.Type = dt.Rows[i]["TypeTeacher"].ToString();
                    if (position == "System.Windows.Controls.ComboBoxItem: Academic Affair Office Staff")
                    {
                        teacher.NamePosition = "AAO Staff";
                    }
                    else if (position == "System.Windows.Controls.ComboBoxItem: Homeroom Teacher")
                    {
                        teacher.NamePosition = "Homeroom Teacher";
                    }
                    else if (position == "System.Windows.Controls.ComboBoxItem: Subject Teacher")
                    {
                        teacher.NamePosition = "Subject Teacher";
                    }


                    result.Add(teacher);
                }
                DataProvider.CloseConnection(con);



                return result;
            }

        }

        public static int getSumStudent(string nameClass, string schoolYear)
        {
            string sCommand = @"Select IDStudent from Student_Class where nameClass ='" + nameClass + "' and schoolYear ='" + schoolYear + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            return dt.Rows.Count;
        }

        public static int getMinAge()
        {
            string sCommand = @"Select minAge from Role";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0]["minAge"].ToString());
        }

        public static int getMaxAge()
        {
            string sCommand = @"Select maxAge from Role";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0]["maxAge"].ToString());
        }

        public static int getPassScore()
        {
            string sCommand = @"Select passScore from Role";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0]["passScore"].ToString());
        }

        public static int getTotalStudent()
        {
            string sCommand = @"Select totalStudent from Role";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0]["totalStudent"].ToString());
        }

        public static bool updateRole(int minAge, int maxAge, double passScore, int totalStudent)
        {
            string sCommand = string.Format(@"update Role set minAge = {0}, maxAge = {1}, passScore = {2}, totalStudent = {3}", minAge, maxAge, passScore, totalStudent);
            con = DataProvider.OpenConnection();
            try
            {
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

        public static int getCurrentStudent(string nameClass, string schoolYear)
        {
            string sCommand = string.Format(@"Select Count(Student.IDStudent) from Student_Class join Student on (Student_Class.IDStudent = Student.IDStudent) where nameClass = '{0}' and schoolYear = '{1}' and Student.isActive = 'T'", nameClass, schoolYear);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return 0;
            }
            return int.Parse(dt.Rows[0][0].ToString());
        }

        public static List<string> getNameClassWithIDStudent(string IDStudent)
        {
            string sCommand = string.Format(@"Select nameClass from Student_Class where IDStudent = '{0}'", IDStudent);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            List<string> result = new List<string>();
            int n = dt.Rows.Count;
            for (int i=0;i<n;i++)
            {
                result.Add(dt.Rows[i][0].ToString());
            }
            return result;
        }
    }

}
