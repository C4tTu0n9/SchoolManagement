using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DTO;
using BUS;
namespace GUI
{
    /// <summary>
    /// Interaction logic for ReviewStudentScore.xaml
    /// </summary>
    public partial class ReviewStudentScore : Window
    {
        List<MarkDTO> marks = new List<MarkDTO>();
        string nameClass = "";
        string semester = "";
        List<string> listSubject = new List<string>();
        bool isLoaded = false;
        public ReviewStudentScore()
        {
           /* marks.Add(new MarkDTO { FirstFifteenMinutesMark = 1, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "Information Technology" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 2, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "A" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 3, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "B" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 4, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "C" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 5, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "D" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 6, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "E" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 7, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "F" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 8, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "G" });
            marks.Add(new MarkDTO { FirstFifteenMinutesMark = 9, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "H" });*/
            InitializeComponent();
        }
        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Window_Loaded_ReviewScore(object sender, RoutedEventArgs e)
        {
            isLoaded = true;
            id_title.Content = Global.Student.Id;
            if (Global.Teacher.Type == "PDT")
            {
                listSubject.Add("All");
                List<string> temp = SubjectBUS.loadListNameSubject();
                int n = temp.Count;
                for (int i=0;i<n;i++)
                {
                    listSubject.Add(temp[i]);
                }
                chooseSubject.ItemsSource = listSubject;
                chooseSubject.SelectedIndex = 0;

                chooseYear.ItemsSource = AcademicAffairsOfficeBUS.getNameClassWithIDStudent(Global.Student.Id);
                chooseYear.SelectedIndex = 0;
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }


               // MessageBox.Show(chooseSemester.SelectedValue.ToString());
                //MessageBox.Show(chooseSubject.SelectedValue.ToString());
                if (chooseSubject.SelectedValue.ToString() == "All")
                {

                    test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester);
                }
                else
                {
                    // test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, Global.Student.NameClass, Global.Student.SchoolYear, semester);
                    test.ItemsSource = MarkBUS.loadMarkByNameWithoutSchoolYear(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester, chooseSubject.SelectedValue.ToString());
                }
                
            }
            else
            {
                listSubject = TeacherBUS.loadListSubjectToComboBoxInUpdate(Global.Teacher.Id, Global.Student.NameClass, Global.Student.SchoolYear);
                chooseSubject.ItemsSource = listSubject;
                chooseSubject.SelectedIndex = 0;

                chooseYear.ItemsSource = AcademicAffairsOfficeBUS.getNameClassWithIDStudent(Global.Student.Id);
                chooseYear.SelectedIndex = 0;


                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }


                // MessageBox.Show(chooseSemester.SelectedValue.ToString());
                //MessageBox.Show(chooseSubject.SelectedValue.ToString());
                if (chooseSubject.SelectedValue.ToString() == "All")
                {

                    test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester);
                }
                else
                {
                    // test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, Global.Student.NameClass, Global.Student.SchoolYear, semester);
                    test.ItemsSource = MarkBUS.loadMarkByNameWithoutSchoolYear(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester, chooseSubject.SelectedValue.ToString());
                }
            }
        

        }

        private void ChooseSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded == true)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }


                if (chooseSubject.SelectedValue.ToString() == "All" && chooseYear.SelectedValue != null)
                {
                    
                    test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester);
                }
                else if (chooseYear.SelectedValue != null)
                {
                    // test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, Global.Student.NameClass, Global.Student.SchoolYear, semester);
                    test.ItemsSource = MarkBUS.loadMarkByNameWithoutSchoolYear(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester, chooseSubject.SelectedValue.ToString());
                }
            }
        }

        private void ChooseSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded == true)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                if (chooseSubject.SelectedValue.ToString() == "All" && chooseYear.SelectedValue != null && chooseSemester.SelectedValue != null)
                {

                    test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester);
                }
                else if (chooseYear.SelectedValue != null && chooseSemester.SelectedValue != null)
                {
                    // test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, Global.Student.NameClass, Global.Student.SchoolYear, semester);
                    test.ItemsSource = MarkBUS.loadMarkByNameWithoutSchoolYear(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester, chooseSubject.SelectedValue.ToString());
                }
            }
        }

        private void ChooseYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded == true)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                if (chooseSubject.SelectedValue.ToString() == "All" && chooseYear.SelectedValue != null && chooseSemester.SelectedValue != null)
                {

                    test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester);
                }
                else if (chooseYear.SelectedValue != null && chooseSemester.SelectedValue != null)
                {
                    // test.ItemsSource = MarkBUS.loadMark(Global.Student.Id, Global.Student.NameClass, Global.Student.SchoolYear, semester);
                    test.ItemsSource = MarkBUS.loadMarkByNameWithoutSchoolYear(Global.Student.Id, chooseYear.SelectedValue.ToString(), semester, chooseSubject.SelectedValue.ToString());
                }
            }
        }
    }
}
