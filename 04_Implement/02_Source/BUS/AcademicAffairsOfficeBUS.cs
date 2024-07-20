using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
namespace BUS
{
    public class AcademicAffairsOfficeBUS
    {
        private static AcademicAffairsOfficeBUS instance;
        private AcademicAffairsOfficeBUS() { }

        public static AcademicAffairsOfficeBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new AcademicAffairsOfficeBUS();
                return instance;
            }
        }

        public static string getYear(string birthDay)
        {
            string result = "";
            result = birthDay[0].ToString() + birthDay[1].ToString() + birthDay[2].ToString() + birthDay[3].ToString();
            return result;
        }

        public static List<string> loadListClassToComboBox()
        {
            return AcademicAffairsOfficeDAO.loadListClassToComboBox();
        }

        public static List<string> loadListClassToComboBox(string schoolYear)
        {
            return AcademicAffairsOfficeDAO.loadListClassToComboBox(schoolYear);
        }

        public static List<string> loadListSchoolYearToComboBox()
        {
            return AcademicAffairsOfficeDAO.loadSchoolYearToComboBox();
        }

        public static string getCurrentSchoolYear(List<string> listSchoolYear)
        {
            string tempYear = "";
            string result = "";
            List<string> temp = new List<string>();
            int n = listSchoolYear.Count;
            for (int i=0;i<n;i++)
            {
                string year = listSchoolYear[i][0].ToString() + listSchoolYear[i][1].ToString() + listSchoolYear[i][2].ToString() + listSchoolYear[i][3].ToString();
                temp.Add(year);
            }
            n = temp.Count;
            tempYear = temp[0];
            result = listSchoolYear[0];
            for (int i=1;i<n;i++)
            {
                if (int.Parse(temp[i]) > int.Parse(tempYear))
                {
                    tempYear = temp[i];
                    result = listSchoolYear[i];
                }
            }
            return result;
        }

        public static List<StudentDTO> loadListStudent(string nameClass, string SchoolYear)
        {
            var result = AcademicAffairsOfficeDAO.LoadStudent(nameClass, SchoolYear);
            int n = result.Count;
            for (int i = 0; i < n; i++)
            {
                string temp = result[i].DateofBith;
                TeacherBUS.StandalizedBirthDayToUI(ref temp);
                result[i].DateofBith = temp;
            }
            return result;
        }

        public static List<StudentDTO> searchStudent(string textToSearch, string nameClass, string schoolYear)
        {
            var result = AcademicAffairsOfficeDAO.searchStudent(textToSearch, nameClass, schoolYear);
            if (result == null)
                return null;
            int n = result.Count;
            for (int i = 0; i < n; i++)
            {
                string temp = result[i].DateofBith;
                TeacherBUS.StandalizedBirthDayToUI(ref temp);
                result[i].DateofBith = temp;
            }
            return result;
        }

        public static bool addNewStudent(StudentDTO student)
        {
            // kiểm tra định dạng IDStudent
            if (student.Id.Length <= 4)
                return false;
            if (student.Id[0] != 'H')
                return false;
            if (student.Id[1] != 'S')
                return false;

            if (!TeacherBUS.marchBirthDay(student.DateofBith))
                return false;

            if (!TeacherBUS.marchEmail(student.Email))
                return false;



            string birthDay = student.DateofBith;
            TeacherBUS.StandalizedBirthDayToDatabase(ref birthDay);
            student.DateofBith = birthDay;

            string currentYear = DateTime.Now.Year.ToString();
            string year = getYear(birthDay);
            int age = int.Parse(currentYear) - int.Parse(year);
            if (age< getMinAge() || age > getMaxAge())
            {
                return false;
            }

            return AcademicAffairsOfficeDAO.AddNewStudent(student);
        }

        public static List<StudentDTO> loadStudentNotInClass(string schoolYear)
        {
            return AcademicAffairsOfficeDAO.loadStudentNotInClass(schoolYear);
        }

        public static List<StudentDTO> searchStudentNotInClass(string textToSearch, string schoolYear)
        {
            return AcademicAffairsOfficeDAO.searchStudentNotInClass(textToSearch, schoolYear);
        }

        public static List<StudentDTO> LoadStudent(string nameClass, string schoolYear, string status)
        {
            List<StudentDTO> result = AcademicAffairsOfficeDAO.LoadStudent(nameClass, schoolYear, status);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }

        public static bool InsertStudentToClass(string IDStudent, string nameClass, string schoolYear)
        {
            return AcademicAffairsOfficeDAO.InsertStudentToClass(IDStudent, nameClass, schoolYear);
        }

        public static bool updateClass(string IDStudent, string nameClass, string schoolYear)
        {
            return classDAO.updateClass(IDStudent, nameClass, schoolYear);
        }

        public static bool InsertMark(MarkDTO mark)
        {
            return AcademicAffairsOfficeDAO.InsertMark(mark);
        }

        public static bool updateInfoStudent(StudentDTO student)
        {
            string birthDay = student.DateofBith;

            if (!TeacherBUS.marchBirthDay(student.DateofBith))
                return false;

            if (!TeacherBUS.marchEmail(student.Email))
                return false;

            TeacherBUS.StandalizedBirthDayToDatabase(ref birthDay);
            student.DateofBith = birthDay;
            return AcademicAffairsOfficeDAO.updateInfoStudent(student);
        }

        public static bool deActiveStudent(string IDStudent)
        {
            return AcademicAffairsOfficeDAO.deActiveStudent(IDStudent);
        }

        public static bool ActiveStudent(string IDStudent)
        {
            return AcademicAffairsOfficeDAO.ActiveStudent(IDStudent);
        }

        public static List<TeacherDTO> loadListTeacher()
        {
            List<TeacherDTO> result = AcademicAffairsOfficeDAO.loadListTeacher();
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    if (result[i].Type == "PDT")
                    {
                        result[i].NamePosition = "Academic Affair Offfice Staff";
                    }
                    else if (AcademicAffairsOfficeDAO.isMaster(result[i].Id, Global.schoolYear))
                    {
                        result[i].NamePosition = "Homeroom Teacher";
                    }
                    else
                    {
                        result[i].NamePosition = "Subject Teacher";
                    }

                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }


        public static List<TeacherDTO> loadListHomeRoomTeacher(string schoolYear)
        {
            List<TeacherDTO> result = AcademicAffairsOfficeDAO.loadListHomeRoomTeacher(schoolYear);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }
        public static List<TeacherDTO> loadListAAOS()
        {
            List<TeacherDTO> result = AcademicAffairsOfficeDAO.loadListAAOS();
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;
        }
        public static List<TeacherDTO> loadListSubjectTeacher(string schoolYear)
        {

            List<TeacherDTO> result = AcademicAffairsOfficeDAO.loadListSubjectTeacher(schoolYear);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;
                }
                return result;
            }
            return null;

        }

        public static List<TeacherDTO> searchTeacher(string textToSearch, string schoolYear, string position)
        {
            List<TeacherDTO> result = AcademicAffairsOfficeDAO.searchTeacher(textToSearch, schoolYear, position);
            if (result != null)
            {
                int n = result.Count;
                for (int i = 0; i < n; i++)
                {
                    string birthDay = result[i].DateofBith;
                    TeacherBUS.StandalizedBirthDayToUI(ref birthDay);
                    result[i].DateofBith = birthDay;

                    if (position == "System.Windows.Controls.ComboBoxItem: All")
                    {
                        if (result[i].Type == "PDT")
                        {
                            result[i].NamePosition = "Academic Affair Offfice Staff";
                        }
                        else if (AcademicAffairsOfficeDAO.isMaster(result[i].Id, Global.schoolYear))
                        {
                            result[i].NamePosition = "Homeroom Teacher";
                        }
                        else
                        {
                            result[i].NamePosition = "Subject Teacher";
                        }
                    }
                }
                return result;
            }
            return null;
        }

        public static bool isMaster(string IDTeacher, string schoolYear)
        {
            return AcademicAffairsOfficeDAO.isMaster(IDTeacher, schoolYear);
        }
        public static int getSumStudent(string nameClass, string schoolYear)
        {
            return AcademicAffairsOfficeDAO.getSumStudent(nameClass, schoolYear);
        }

        public static bool isPass(string idStudent, string nameClass, string schoolYear, string subject, string semester)
        {
            List<MarkDTO> mark = MarkBUS.loadMark(idStudent, nameClass, schoolYear, semester, subject);

            double average = mark[0].AverageMark;
            return (average >= AcademicAffairsOfficeBUS.getPassScore());
        }

        public static int getSumStudentPass(string nameClass, string schoolYear, string subject, string semester)
        {
            List<StudentDTO> students = AcademicAffairsOfficeBUS.loadListStudent(nameClass, schoolYear);
            int count = 0;
            int n = students.Count;
            for (int i = 0; i < n; i++)
            {
                if (AcademicAffairsOfficeBUS.isPass(students[i].Id, nameClass, schoolYear, subject, semester))
                {
                    count++;
                }
            }
            return count;
        }

        public static double getRatio(string nameClass, string schoolYear, string subject, string semester)
        {
            double ratio = (double)AcademicAffairsOfficeBUS.getSumStudentPass(nameClass, schoolYear, subject, semester) / getSumStudent(nameClass, schoolYear);
            ratio = Math.Round(ratio, 2);
            return ratio;
        }

        public static List<Report> loadReport(string semester, string schoolYear, string subject, List<string> listNameClass)
        {
            List<Report> result = new List<Report>();
            int n = listNameClass.Count;
            if (semester == "System.Windows.Controls.ComboBoxItem: I")
            {
                for (int i = 0; i < n; i++)
                {
                    Report student = new Report();
                    student.stt = i + 1;
                    student.nameClass = listNameClass[i];
                    student.tt = AcademicAffairsOfficeBUS.getSumStudent(listNameClass[i], schoolYear);
                    student.pass = AcademicAffairsOfficeBUS.getSumStudentPass(listNameClass[i], schoolYear, subject, "1");
                    student.scale = AcademicAffairsOfficeBUS.getRatio(listNameClass[i], schoolYear, subject, "1");
                    result.Add(student);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Report student = new Report();
                    student.stt = i + 1;
                    student.nameClass = listNameClass[i];
                    student.tt = AcademicAffairsOfficeBUS.getSumStudent(listNameClass[i], schoolYear);
                    student.pass = AcademicAffairsOfficeBUS.getSumStudentPass(listNameClass[i], schoolYear, subject, "2");
                    student.scale = AcademicAffairsOfficeBUS.getRatio(listNameClass[i], schoolYear, subject, "2");
                    result.Add(student);
                }
            }
            return result;
        }


        public static bool isPassAllSubject(string idStudent, string nameClass, string schoolYear, List<string> listSubject, string semester)
        {
            int n = listSubject.Count;
            double sum = 0;
            for (int i=0;i<n;i++)
            {
                List<MarkDTO> mark = MarkBUS.loadMark(idStudent, nameClass, schoolYear, semester,listSubject[i]);
                sum += mark[0].AverageMark;
            }
            sum = sum / n;
            sum = Math.Round(sum, 2);
            return (sum >= AcademicAffairsOfficeBUS.getPassScore());
        }

        public static List<Report> loadReport(string semester, string schoolYear, List<string> listSubject, List<string> listNameClass)
        {
            List<Report> result = new List<Report>();
            int n = listNameClass.Count;
           
            if (semester == "System.Windows.Controls.ComboBoxItem: I")
            {
                for (int i = 0; i < n; i++)
                {
                    Report student = new Report();
                    student.stt = i + 1;
                    student.nameClass = listNameClass[i];
                    student.tt = AcademicAffairsOfficeBUS.getSumStudent(listNameClass[i], schoolYear);
                    List<StudentDTO> students = AcademicAffairsOfficeBUS.loadListStudent(listNameClass[i], schoolYear);
                    for (int j=0;j<students.Count;j++)
                    {
                        if (isPassAllSubject(students[j].Id, listNameClass[i], schoolYear, listSubject, "1"))
                        {
                            student.pass++;
                        }
                    }


                    student.scale = (double)student.pass / student.tt;
                    student.scale = Math.Round(student.scale, 2);
                    result.Add(student);
                }
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    Report student = new Report();
                    student.stt = i + 1;
                    student.nameClass = listNameClass[i];
                    student.tt = AcademicAffairsOfficeBUS.getSumStudent(listNameClass[i], schoolYear);
                    List<StudentDTO> students = AcademicAffairsOfficeBUS.loadListStudent(listNameClass[i], schoolYear);
                    for (int j = 0; j < students.Count; j++)
                    {
                        if (isPassAllSubject(students[j].Id, listNameClass[i], schoolYear, listSubject, "2"))
                        {
                            student.pass++;
                        }
                    }


                    student.scale = (double)student.pass / student.tt;
                    student.scale = Math.Round(student.scale, 2);
                    result.Add(student);
                }
            }
            return result;
        }

        public static int getMinAge()
        {
            return AcademicAffairsOfficeDAO.getMinAge();
        }
        public static int getMaxAge()
        {
            return AcademicAffairsOfficeDAO.getMaxAge();
        }
        public static int getPassScore()
        {
            return AcademicAffairsOfficeDAO.getPassScore();
        }
        public static int getTotalStudent()
        {
            return AcademicAffairsOfficeDAO.getTotalStudent();
        }
        public static bool updateRole(int minAge, int maxAge, double passScore, int totalStudent)
        {
            if (totalStudent < getMaxCurrentStudent(Global.schoolYear))
            {
                return false;
            }

            if (minAge < 0 || maxAge < 0 || passScore < 0 || totalStudent < 0)
                return false;
            if (passScore > 10)
                return false;
            return AcademicAffairsOfficeDAO.updateRole(minAge, maxAge, passScore, totalStudent);
        }

        public static int getCurrentStudent(string nameClass, string schoolYear)
        {
            return AcademicAffairsOfficeDAO.getCurrentStudent(nameClass, schoolYear);
        }

        public static int getMaxCurrentStudent(string schoolYear)
        {
            List<string> listNameClass = AcademicAffairsOfficeBUS.loadListClassToComboBox(schoolYear);
            int max = getCurrentStudent(listNameClass[0], schoolYear);
            int n = listNameClass.Count;
            for (int i=1;i<n;i++)
            {
                int temp = getCurrentStudent(listNameClass[i], schoolYear);
                if (temp > max)
                {
                    max = temp;
                }
            }
            return max;
        }

        public static List<string> getNameClassWithIDStudent(string IDStudent)
        {
            return AcademicAffairsOfficeDAO.getNameClassWithIDStudent(IDStudent);
        }
    }
}
