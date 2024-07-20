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
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Interaction logic for test2.xaml
    /// </summary>
    public sealed partial class TeacherUpdateScore : Page
    {
        List<string> subjects = new List<string>();
        List<MarkDTO> marks = new List<MarkDTO>();
        List<String> classes = new List<string>();
        List<string> listSubject = new List<string>();
        bool isLoaded = false;
        string semester = "";
        public TeacherUpdateScore()
        {
            classes.Add("10C1");
            classes.Add("11C1");
            classes.Add("12C1");
            classes.Add("10C2");
            classes.Add("10C3");
            classes.Add("11C2");
            classes.Add("12C2");
            classes.Add("10C3");
            subjects.Add("All");
            subjects.Add("English");
            subjects.Add("Technology");
            subjects.Add("Math");
            subjects.Add("Information Technology");
            subjects.Add("Defense Education");
            marks.Add(new MarkDTO {Semester=4 ,NameClass="12C1",IDStudent="321312",FirstFifteenMinutesMark = 1, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5 });
            marks.Add(new MarkDTO { NameClass = "12C2", IDStudent = "31312", FirstFifteenMinutesMark = 2, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5 });
            marks.Add(new MarkDTO { NameClass = "12C3", IDStudent = "32312", FirstFifteenMinutesMark = 3, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5 });
           /* marks.Add(new MarkDTO { NameClass = "12C2", IDStudent = "312", FirstFifteenMinutesMark = 4, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "C" });
            marks.Add(new MarkDTO { NameClass = "12C1", IDStudent = "312", FirstFifteenMinutesMark = 5, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "D" });
            marks.Add(new MarkDTO { NameClass = "12C2", IDStudent = "32112", FirstFifteenMinutesMark = 6, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "E" });
            marks.Add(new MarkDTO { NameClass = "12C13", IDStudent = "3312", FirstFifteenMinutesMark = 7, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "F" });
            marks.Add(new MarkDTO { NameClass = "12C2", IDStudent = "321312", FirstFifteenMinutesMark = 8, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "G" });
            marks.Add(new MarkDTO { NameClass = "12C5", IDStudent = "312", FirstFifteenMinutesMark = 9, SecondFifteenMinutesMark = 5, ThirdFifteenMinutesMark = 9, FirstFortyFiveMinutesMark = 10, SecondFortyFiveMinutesMark = 3, ThirdFortyFiveMinutesMark = 8.5, SemesterScore = 9.5, IdSubject = "H" });*/
            InitializeComponent();
        }

        private void Window_Loaded_User(object sender, RoutedEventArgs e)
        {
            //listviewUser.ItemsSource = marks;
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
                chooseSubject.SelectedIndex = 1;

                chooseClass.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox();
                chooseClass.SelectedIndex = 0;

                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }
               
                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                }
            }
            else
            {
                chooseClass.ItemsSource = TeacherBUS.loadListClassToComboBox(Global.Teacher.Id, Global.schoolYear);
                chooseClass.SelectedIndex = 0;

                chooseSubject.ItemsSource = TeacherBUS.loadListSubjectToComboBoxInUpdate(Global.Teacher.Id, chooseClass.SelectedValue.ToString(), Global.schoolYear);
                chooseSubject.SelectedIndex = 0;

                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);


            }
            btnEdit.IsEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.IsEnabled = false;

            btnDoneOfEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            m15st_st_infor.IsReadOnly = false;
            m15nd_st_infor.IsReadOnly = false;
            m15rd_st_infor.IsReadOnly = false;
            m45st_st_infor.IsReadOnly = false;
            m45nd_st_infor.IsReadOnly = false;
            m45rd_st_infor.IsReadOnly = false;
            semester_st_infor.IsReadOnly = false;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.IsEnabled = false;
            m15st_st_infor.IsReadOnly = true;
            m15nd_st_infor.IsReadOnly = true;
            m15rd_st_infor.IsReadOnly = true;
            m45st_st_infor.IsReadOnly = true;
            m45nd_st_infor.IsReadOnly = true;
            m45rd_st_infor.IsReadOnly = true;
            semester_st_infor.IsReadOnly = true;
            btnCancel.Visibility = Visibility.Collapsed;
            MarkDTO item = (MarkDTO)listviewUser.SelectedItems[0];
            MarkDTO mark = new MarkDTO();
            mark.FirstFifteenMinutesMark = double.Parse(m15st_st_infor.Text);
            mark.SecondFifteenMinutesMark = double.Parse(m15nd_st_infor.Text);
            mark.ThirdFifteenMinutesMark = double.Parse(m15rd_st_infor.Text);
            mark.FirstFortyFiveMinutesMark = double.Parse(m45st_st_infor.Text);
            mark.SecondFortyFiveMinutesMark = double.Parse(m45nd_st_infor.Text);
            mark.ThirdFortyFiveMinutesMark = double.Parse(m45rd_st_infor.Text);
            mark.SemesterScore = double.Parse(semester_st_infor.Text);
            
            if (MarkBUS.UpdateScore(item.IDStudent, item.NameClass, item.SchoolYear, item.Subject.IdSubject,item.Semester.ToString(), mark))
            {
                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                    listviewUser.SelectedIndex = 0;
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                    listviewUser.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("Cập nhật điểm thất bại");
            }
            
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            if (listviewUser.SelectedItems.Count > 0)
            {
                MarkDTO item = (MarkDTO)listviewUser.SelectedItems[0];
                //subject_st_infor.Text = item.IdSubject;
                fullname_st_infor.Text = item.NameStudent;
                id_st_infor.Text = item.IDStudent;
                class_st_infor.Text = item.NameClass;
                m15st_st_infor.Text = item.FirstFifteenMinutesMark.ToString();
                m15nd_st_infor.Text = item.SecondFifteenMinutesMark.ToString();
                m15rd_st_infor.Text = item.ThirdFifteenMinutesMark.ToString();
                m45st_st_infor.Text = item.FirstFortyFiveMinutesMark.ToString();
                m45nd_st_infor.Text = item.SecondFortyFiveMinutesMark.ToString();
                m45rd_st_infor.Text = item.ThirdFortyFiveMinutesMark.ToString();
                subject_st_infor.Text = item.Subject.NameSubject;
                semester_st_infor.Text = item.SemesterScore.ToString();
            }
        }

        private void ComboBox_Classes_Loaded(object sender, RoutedEventArgs e)
        {
          /*  var combo = sender as ComboBox;
            combo.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox();
            combo.SelectedIndex = 0;*/
        }

        private void Combobox_Loaded_Subject(object sender, RoutedEventArgs e)
        {
           /*var combo = sender as ComboBox;
            combo.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox();
            combo.SelectedIndex = 0;*/
        }

        private void ChooseSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseSubject.SelectedItem != null && chooseClass.SelectedItem != null && chooseSemester.SelectedItem != null)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }
            }
        }

        private void ChooseClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseSubject.SelectedItem != null && chooseClass.SelectedItem != null && chooseSemester.SelectedItem != null)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }

            }
        }

        private void ChooseSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (chooseSubject.SelectedItem != null && chooseClass.SelectedItem != null && chooseSemester.SelectedItem != null)
            {
                if (chooseSemester.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: I")
                {
                    semester = "1";
                }
                else
                {
                    semester = "2";
                }

                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), "2018-2019", semester);
                }
            }
        }

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchUser.Text))
            {
                if (chooseSubject.SelectedValue.ToString() != "All")
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByNameSubject(chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                }
                else
                {
                    listviewUser.ItemsSource = MarkBUS.loadMarkByClass(chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            listviewUser.ItemsSource = MarkBUS.searchStudent_Mark(searchUser.Text, chooseSubject.SelectedValue.ToString(), chooseClass.SelectedValue.ToString(), Global.schoolYear, semester);
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.IsEnabled = false;

            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            m15st_st_infor.IsReadOnly = true;
            m15nd_st_infor.IsReadOnly = true;
            m15rd_st_infor.IsReadOnly = true;
            m45st_st_infor.IsReadOnly = true;
            m45nd_st_infor.IsReadOnly = true;
            m45rd_st_infor.IsReadOnly = true;
            semester_st_infor.IsReadOnly = true;
            btnCancel.Visibility = Visibility.Collapsed;
            Window_Loaded_User(sender, e);
        }
    }
}
