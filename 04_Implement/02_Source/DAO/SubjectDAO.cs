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
    public class SubjectDAO
    {
        private static SubjectDAO instance;
        private SubjectDAO() { }
        public static SubjectDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new SubjectDAO();
                return instance;
            }
        }
        public static SqlConnection con;
        // load danh sách môn học
        public static List<SubjectDTO> loadListSubject()
        {
            string sCommand = @"Select* from Subject";
            con = DataProvider.OpenConnection();
            DataTable dt = DataProvider.GetDataTable(sCommand, con);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            List<SubjectDTO> result = new List<SubjectDTO>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                SubjectDTO subject = new SubjectDTO();
                subject.IdSubject = dt.Rows[i]["IDSubject"].ToString();
                subject.NameSubject = dt.Rows[i]["NameSubject"].ToString();
               
                result.Add(subject);
            }
            DataProvider.CloseConnection(con);
            return result;
        }

        
        
    }
}
