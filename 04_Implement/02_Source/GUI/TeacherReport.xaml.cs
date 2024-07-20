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
namespace GUI
{
    /// <summary>
    /// Interaction logic for test2.xaml
    /// </summary>
    public partial class TeacherReport : Page
    {
        List<string> subjects = new List<string>();
        List<Report> studentList = new List<Report>();
        List<string> listNameClass = new List<string>();
        List<string> listNameSubject = new List<string>();
        bool isLoaded = false;
       /* public class Report
        {
            public int stt { get; set; }
            public string nameClass { get; set; }
            public int tt { get; set; }
            public int pass { get; set; }
            public double scale { get; set; }
        }*/
        public TeacherReport()
        {
          /* studentList.Add(new Report { stt = 1, nameClass = "10C1", tt = 40, pass = 39, scale = 39/40});
            studentList.Add(new Report { stt = 2, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 3, nameClass = "10C1", tt = 40, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 4, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 5, nameClass = "10C1", tt = 40, pass = 39, scale = 39 / 40f});
            studentList.Add(new Report { stt = 6, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 7, nameClass = "10C1", tt = 40, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 8, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 9, nameClass = "10C1", tt = 40, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 10, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 11, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 12, nameClass = "10C1", tt = 40, pass = 39, scale = 39 / 40f });
            studentList.Add(new Report { stt = 13, nameClass = "10C2", tt = 39, pass = 39, scale = 39 / 40f });*/

            subjects.Add("All");
            subjects.Add("English");
            subjects.Add("Technology");
            subjects.Add("Math");
            subjects.Add("Information Technology");
            subjects.Add("Defense Education");
            InitializeComponent();
        }

        private void Window_Loaded_Report(object sender, RoutedEventArgs e)
        {
            /* var testGUI = studentList;
              test.ItemsSource = testGUI;*/

            isLoaded = true;
            chooseSubject.ItemsSource = SubjectBUS.loadListNameSubject();
            chooseSubject.SelectedIndex = 0;

            listNameClass = AcademicAffairsOfficeBUS.loadListClassToComboBox(Global.schoolYear);
            listNameSubject = SubjectBUS.loadListNameSubject();

            if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject")
            {
                test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear,chooseSubject.SelectedValue.ToString(), listNameClass);
            }
            else
            {
                test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, listNameSubject, listNameClass);
            }
        }

        private void Combobox_Loaded_Subject(object sender, RoutedEventArgs e)
        {
           /* var combo = sender as ComboBox;
            combo.ItemsSource = subjects;

            combo.SelectedIndex = 0;*/
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            var window = new TeacherReportChart();
            window.Show();
        }

        private void chooseType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Semester")
            {
                chooseSubject.IsEnabled = false;
            }
            else if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject")
            {
                chooseSubject.IsEnabled = true;
            }

            if (isLoaded)
            {
                listNameClass = AcademicAffairsOfficeBUS.loadListClassToComboBox(Global.schoolYear);
                listNameSubject = SubjectBUS.loadListNameSubject();
                if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject")
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, chooseSubject.SelectedValue.ToString(), listNameClass);
                }
                else
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, listNameSubject, listNameClass);
                }
            }
        }
        private void ChooseSubject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                listNameClass = AcademicAffairsOfficeBUS.loadListClassToComboBox(Global.schoolYear);
                listNameSubject = SubjectBUS.loadListNameSubject();
                if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject")
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, chooseSubject.SelectedValue.ToString(), listNameClass);
                }
                else
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, listNameSubject, listNameClass);
                }
            }
        }

        private void ChooseSemester_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                listNameClass = AcademicAffairsOfficeBUS.loadListClassToComboBox(Global.schoolYear);
                listNameSubject = SubjectBUS.loadListNameSubject();
                if (chooseType.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject")
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, chooseSubject.SelectedValue.ToString(), listNameClass);
                }
                else
                {
                    test.ItemsSource = AcademicAffairsOfficeBUS.loadReport(chooseSemester.SelectedValue.ToString(), Global.schoolYear, listNameSubject, listNameClass);
                }
            }
        }
    }
}
