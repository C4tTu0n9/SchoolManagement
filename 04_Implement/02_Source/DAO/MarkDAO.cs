using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class MarkDAO
    {
        private static MarkDAO instance;
        private MarkDAO() { }
        static SqlConnection con;
        public static MarkDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new MarkDAO();
                return instance;
            }
        }

        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string schoolYear, string semester)
        {
            string sCommand = @"select* from dbo.Mark where IDStudent = '" + idStudent + "' and nameClass = '" + nameClass + "' and schoolYear = '" + schoolYear + "' and semester = " + int.Parse(semester);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            List<MarkDTO> result = new List<MarkDTO>();
            if (dt.Rows.Count <=0)
            {
                return null;
            }
            else
            {
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                    //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                return result;
            }
        }

        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string semester)
        {
            string sCommand = @"select* from dbo.Mark where IDStudent = '" + idStudent + "' and nameClass = '" + nameClass + "' and semester = " + int.Parse(semester);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            List<MarkDTO> result = new List<MarkDTO>();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                    //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                return result;
            }
        }



        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string schoolYear, string semester, string nameSubject)
        {
            string sCommand = @"select* from dbo.Mark where IDStudent = '" + idStudent + "' and nameClass = '" + nameClass + "' and schoolYear = '" + schoolYear + "' and semester = " + int.Parse(semester) + "and IDSubject = '" + SubjectDTO.getIDSubject(nameSubject) + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            List<MarkDTO> result = new List<MarkDTO>();
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                 //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }


        public static List<MarkDTO> loadMarkByNameWithoutSchoolYear(string idStudent, string nameClass, string semester, string nameSubject)
        {
            string sCommand = @"select* from dbo.Mark where IDStudent = '" + idStudent + "' and nameClass = '" + nameClass + "' and semester = " + int.Parse(semester) + "and IDSubject = '" + SubjectDTO.getIDSubject(nameSubject) + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            List<MarkDTO> result = new List<MarkDTO>();
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                    //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static string getNameStudent(string idStudent)
        {
            string sCommand = @"Select Name from Student where IDStudent = '" + idStudent + "'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                return dt.Rows[0]["Name"].ToString();
            }
        }

        public static List<MarkDTO> loadMarkByNameSubject(string nameSubject, string nameClass, string schoolYear, string semester)
        {
            string sCommand = @"Select * from Mark M join Student S on (M.IDStudent = S.IDStudent) where M.IDSubject = '" + SubjectDTO.getIDSubject(nameSubject) + "' and M.nameClass = '" + nameClass + "' and M.schoolYear = '" + schoolYear + "' and M.Semester = "+int.Parse(semester);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                int n = dt.Rows.Count;
                List<MarkDTO> result = new List<MarkDTO>();
                for (int i=0;i<n;i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                    //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.NameStudent = getNameStudent(temp.IDStudent);
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static List<MarkDTO> loadMarkByClass(string nameClass, string schoolYear, string semester)
        {
            string sCommand = @"Select * from Mark M where M.nameClass = '" + nameClass + "' and M.schoolYear = '" + schoolYear + "' and M.Semester = " + int.Parse(semester);
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count <= 0)
            {
                DataProvider.CloseConnection(con);
                return null;
            }
            else
            {
                int n = dt.Rows.Count;
                List<MarkDTO> result = new List<MarkDTO>();
                for (int i = 0; i < n; i++)
                {
                    MarkDTO temp = new MarkDTO();
                    temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                    //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                    temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                    temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                    temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                    temp.NameStudent = getNameStudent(temp.IDStudent);
                    temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                    temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                    if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                        temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                    if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                        temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                        temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                    if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                        temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                        temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                        temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                    if (dt.Rows[i]["SemesterMark"].ToString() != "")
                        temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                    result.Add(temp);
                }
                DataProvider.CloseConnection(con);
                return result;
            }
        }

        public static List<MarkDTO> searchStudent_Mark(string keyWord, string nameSubject, string nameClass, string schoolYear, string semester)
        {
            if (nameSubject == "All")
            {
                string sCommand = @"Select * from Mark M join Student S on (S.IDStudent = M.IDStudent) where ((S.IDStudent like '%" + keyWord + "%') or (S.Name like N'%" + keyWord + "%')) and M.nameClass = '" + nameClass + "' and M.schoolYear = '" + schoolYear + "' and M.Semester = " + int.Parse(semester);
                con = DataProvider.OpenConnection();
                DataTable dt = DataProvider.GetDataTable(sCommand, con);
                if (dt.Rows.Count <= 0)
                {
                    DataProvider.CloseConnection(con);
                    return null;
                }
                else
                {
                    int n = dt.Rows.Count;
                    List<MarkDTO> result = new List<MarkDTO>();
                    for (int i = 0; i < n; i++)
                    {
                        MarkDTO temp = new MarkDTO();
                        temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                        //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                        temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                        temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                        temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                        temp.NameStudent = getNameStudent(temp.IDStudent);
                        temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                        temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                        if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                            temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                        if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                            temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                        if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                            temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                        if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                            temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                            temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                            temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["SemesterMark"].ToString() != "")
                            temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                        result.Add(temp);
                    }
                    DataProvider.CloseConnection(con);
                    return result;
                }
            }
            else
            {
                string sCommand = @"Select * from Mark M join Student S on (S.IDStudent = M.IDStudent) where ((S.IDStudent like '%" + keyWord + "%') or (S.Name like N'%" + keyWord + "%')) and M.nameClass = '" + nameClass + "' and M.schoolYear = '" + schoolYear + "' and M.Semester = " + int.Parse(semester) + "and M.IDSubject = '" + SubjectDTO.getIDSubject(nameSubject) + "'";
                con = DataProvider.OpenConnection();
                DataTable dt = DataProvider.GetDataTable(sCommand, con);
                if (dt.Rows.Count <= 0)
                {
                    DataProvider.CloseConnection(con);
                    return null;
                }
                else
                {
                    int n = dt.Rows.Count;
                    List<MarkDTO> result = new List<MarkDTO>();
                    for (int i = 0; i < n; i++)
                    {
                        MarkDTO temp = new MarkDTO();
                        temp.IDStudent = dt.Rows[i]["IDStudent"].ToString();
                        //   temp.IdTeacher = dt.Rows[i]["IDTeacher"].ToString();
                        temp.NameClass = dt.Rows[i]["nameClass"].ToString();
                        temp.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                        temp.Subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                        temp.NameStudent = getNameStudent(temp.IDStudent);
                        temp.Subject.NameSubject = SubjectDTO.getNameSubject(temp.Subject.IdSubject);
                        temp.Semester = int.Parse(dt.Rows[i]["Semester"].ToString());
                        if (dt.Rows[i]["FirstFifteenMinutes"].ToString() != "")
                            temp.FirstFifteenMinutesMark = double.Parse(dt.Rows[i]["FirstFifteenMinutes"].ToString());
                        if (dt.Rows[i]["SecondFifteenMinutes"].ToString() != "")
                            temp.SecondFifteenMinutesMark = double.Parse(dt.Rows[i]["SecondFifteenMinutes"].ToString());
                        if (dt.Rows[i]["ThirdFifteenMinutes"].ToString() != "")
                            temp.ThirdFifteenMinutesMark = double.Parse(dt.Rows[i]["ThirdFifteenMinutes"].ToString());
                        if (dt.Rows[i]["FirstFortyFiveMinutes"].ToString() != "")
                            temp.FirstFortyFiveMinutesMark = double.Parse(dt.Rows[i]["FirstFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["SecondFortyFiveMinutes"].ToString() != "")
                            temp.SecondFortyFiveMinutesMark = double.Parse(dt.Rows[i]["SecondFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["ThirdFortyFiveMinutes"].ToString() != "")
                            temp.ThirdFortyFiveMinutesMark = double.Parse(dt.Rows[i]["ThirdFortyFiveMinutes"].ToString());
                        if (dt.Rows[i]["SemesterMark"].ToString() != "")
                            temp.SemesterScore = double.Parse(dt.Rows[i]["SemesterMark"].ToString());
                        result.Add(temp);
                    }
                    DataProvider.CloseConnection(con);
                    return result;
                }
            }
        }


        public static bool UpdateScore(string idStudent, string nameClass, string schoolYear, string idSubject,string semester, MarkDTO mark)
        {
            string sCommand = @"Update Mark
                                set FirstFifteenMinutes = " + mark.FirstFifteenMinutesMark + ", SecondFifteenMinutes =" + mark.SecondFifteenMinutesMark + ", ThirdFifteenMinutes ="
                                + mark.ThirdFifteenMinutesMark + ", FirstFortyFiveMinutes =" + mark.FirstFortyFiveMinutesMark + ", SecondFortyFiveMinutes ="
                                + mark.SecondFortyFiveMinutesMark + ", ThirdFortyFiveMinutes=" + mark.ThirdFortyFiveMinutesMark +
                                ", SemesterMark =" + mark.SemesterScore +
                                "where IDStudent ='" + idStudent + "'and nameClass ='" + nameClass + "'and schoolYear ='" + schoolYear + "'and IDSubject ='" + idSubject + "' and Semester ="+int.Parse(semester);
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

        public static bool removeMark(string IDStudent, string nameClass, string schoolYear)
        {
            string sCommand = @"Delete from Mark where IDStudent ='" + IDStudent + "' and nameClass ='" + nameClass + "' and schoolYear ='" + schoolYear + "'";
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


    }

   
}
