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
   public class classDAO
    {
        static SqlConnection con;
        private static classDAO instance;
        private classDAO() { }
        public static classDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new classDAO();
                return instance;
            }
        }
        // hàm load danh sách lớp học (để đưa vào comboBox)
        public static List<ClassDTO> loadListClass()
        {
            string sTruyVan = @"Select* from Class";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ClassDTO> result = new List<ClassDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClassDTO Class = new ClassDTO();
                Class.Name = dt.Rows[i]["nameClass"].ToString();
                Class.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                Class.IdMaster = dt.Rows[i]["IDMaster"].ToString();
                result.Add(Class);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        public static List<ClassDTO> loadListClass(string schoolYear)
        {
            string sTruyVan = @"Select* from Class where schoolYear ='"+schoolYear+"'";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sTruyVan, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<ClassDTO> result = new List<ClassDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ClassDTO Class = new ClassDTO();
                Class.Name = dt.Rows[i]["nameClass"].ToString();
                Class.SchoolYear = dt.Rows[i]["schoolYear"].ToString();
                Class.IdMaster = dt.Rows[i]["IDMaster"].ToString();
                result.Add(Class);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        public static List<string> loadSchoolYear()
        {
            string sCommand = @"Select distinct schoolYear from dbo.Class";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<string> result = new List<string>();
            for (int i=0;i<dt.Rows.Count;i++)
            {
                string schoolyear = dt.Rows[i]["schoolYear"].ToString();
                result.Add(schoolyear);
            }

            DataProvider.CloseConnection(con);
            return result.Distinct().ToList();
        }

        public static bool updateClass(string IDStudent, string nameClass, string schoolYear)
        {
            string sCommand = @"Update Student_Class set nameClass = '" + nameClass + "' where IDStudent = '" + IDStudent + "' and schoolYear ='" + schoolYear + "'";
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
