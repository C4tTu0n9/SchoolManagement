using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class MarkDTO
    {
        private double firstFifteenMinutesMark;
        private double secondFifteenMinutesMark;
        private double thirdFifteenMinutesMark;
        private double firstFortyFiveMinutesMark;
        private double secondFortyFiveMinutesMark;
        private double thirdFortyFiveMinutesMark;
        private double semesterScore;
        private double averageMark;
        private int semester;
        private string iDStudent;
        private string nameStudent;
        private string nameClass;
        private string schoolYear;
        private string idTeacher;
        private SubjectDTO subject;

        public double FirstFifteenMinutesMark { get => firstFifteenMinutesMark; set => firstFifteenMinutesMark = value; }
        public double SecondFifteenMinutesMark { get => secondFifteenMinutesMark; set => secondFifteenMinutesMark = value; }
        public double ThirdFifteenMinutesMark { get => thirdFifteenMinutesMark; set => thirdFifteenMinutesMark = value; }
        public double FirstFortyFiveMinutesMark { get => firstFortyFiveMinutesMark; set => firstFortyFiveMinutesMark = value; }
        public double SecondFortyFiveMinutesMark { get => secondFortyFiveMinutesMark; set => secondFortyFiveMinutesMark = value; }
        public double ThirdFortyFiveMinutesMark { get => thirdFortyFiveMinutesMark; set => thirdFortyFiveMinutesMark = value; }
        public double SemesterScore { get => semesterScore; set => semesterScore = value; }
        public double AverageMark { get => averageMark; set => averageMark = value; }
        public int Semester { get => semester; set => semester = value; }
        public string IDStudent { get => iDStudent; set => iDStudent = value; }  
        public string NameClass { get => nameClass; set => nameClass = value; }
        public string SchoolYear { get => schoolYear; set => schoolYear = value; }
        public string IdTeacher { get => idTeacher; set => idTeacher = value; }
        public SubjectDTO Subject { get => subject; set => subject = value; }
        public string NameStudent { get => nameStudent; set => nameStudent = value; }

        public MarkDTO()
        {
            firstFifteenMinutesMark = secondFifteenMinutesMark = thirdFifteenMinutesMark = 0;
            FirstFortyFiveMinutesMark = SecondFortyFiveMinutesMark = ThirdFortyFiveMinutesMark = 0;
            semesterScore = 0;
            averageMark = 0;
            Subject = new SubjectDTO();
            nameStudent = "";
        }
    }
}
