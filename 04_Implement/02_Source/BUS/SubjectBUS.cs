using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAO;
namespace BUS
{
    public class SubjectBUS
    {
        private static SubjectBUS instance;
        private SubjectBUS() { }
        public static SubjectBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new SubjectBUS();
                return instance;
            }
        }

        public static List<SubjectDTO> loadListSubject()
        {
            return SubjectDAO.loadListSubject();
        }

        public static List<string> loadListNameSubject()
        {
            List<SubjectDTO> temp = SubjectDAO.loadListSubject();
            if (temp!=null)
            {
                List<string> result = new List<string>();
                int n = temp.Count;
                for (int i=0;i<n;i++)
                {
                    result.Add(temp[i].NameSubject);
             
                }
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
