using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
   public class MarkBUS
    {
        private static MarkBUS instance;
        private MarkBUS() { }
        public MarkBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new MarkBUS();
                return instance;
            }
        }

        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string schoolYear, string semester)
        {
            List<MarkDTO> result = MarkDAO.loadMark(idStudent, nameClass, schoolYear, semester);
            if (result != null)
            {
                int n = result.Count;
                for (int i=0;i<n;i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }
        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string schoolYear, string semester, string nameSubject)
        {
            List<MarkDTO> result = MarkDAO.loadMark(idStudent, nameClass, schoolYear, semester, nameSubject);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }

        public static List<MarkDTO> loadMark(string idStudent, string nameClass, string semester)
        {
            List<MarkDTO> result = MarkDAO.loadMark(idStudent, nameClass, semester);
            if (result != null)
            {
                int n = result.Count;
                for (int i=0;i<n;i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }

        public static List<MarkDTO> loadMarkByNameWithoutSchoolYear(string idStudent, string nameClass, string semester, string nameSubject)
        {
            List<MarkDTO> result = MarkDAO.loadMarkByNameWithoutSchoolYear(idStudent, nameClass, semester,nameSubject);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }
        public static string getNameStudent(string id)
        {
            return MarkDAO.getNameStudent(id);
        }

        public static List<MarkDTO> loadMarkByNameSubject(string nameSubject, string nameClass, string schoolYear, string semester)
        {
            List<MarkDTO> result = MarkDAO.loadMarkByNameSubject(nameSubject, nameClass, schoolYear, semester);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }

        public static List<MarkDTO> loadMarkByClass(string nameClass, string schoolYear, string semester)
        {
            List<MarkDTO> result = MarkDAO.loadMarkByClass(nameClass, schoolYear, semester);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }

        public static List<MarkDTO> searchStudent_Mark(string keyWord, string nameSubject, string nameClass, string schoolYear, string semester)
        {
            List<MarkDTO> result = MarkDAO.searchStudent_Mark(keyWord, nameSubject, nameClass, schoolYear, semester);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    double a = (result[i].FirstFifteenMinutesMark + result[i].SecondFifteenMinutesMark + result[i].ThirdFifteenMinutesMark + result[i].FirstFortyFiveMinutesMark * 2 + result[i].SecondFortyFiveMinutesMark * 2 + result[i].ThirdFortyFiveMinutesMark * 2 + result[i].SemesterScore * 3) / 12;
                    a = Math.Round(a, 2);
                    result[i].AverageMark = a;
                }
                return result;
            }
            return null;
        }

        public static bool UpdateScore(string idStudent, string nameClass, string schoolYear, string idSubject,string semester, MarkDTO mark)
        {
          return MarkDAO.UpdateScore(idStudent, nameClass, schoolYear, idSubject,semester, mark);
        }

        public static bool removeMark(string IDStudent, string nameClass, string schoolYear)
        {
            return MarkDAO.removeMark(IDStudent, nameClass, schoolYear);
        }


    }

}
