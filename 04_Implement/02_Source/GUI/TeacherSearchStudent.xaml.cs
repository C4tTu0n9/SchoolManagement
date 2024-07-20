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
    public sealed partial class TeacherSearchStudent : Page
    {
        private List<StudentDTO> users = new List<StudentDTO>();
        List<String> classes = new List<string>();
        List<String> years = new List<string>();
        public TeacherSearchStudent()
        {
            classes.Add("All");
            classes.Add("10C1");
            classes.Add("11C1");
            classes.Add("12C1");
            classes.Add("10C2");
            classes.Add("10C3");
            classes.Add("11C2");
            classes.Add("12C2");
            classes.Add("10C3");
            years.Add("All");
            years.Add("2014-2015");
            years.Add("2015-2016");
            years.Add("2016-2017");
            years.Add("2018-2019");
            years.Add("2019-2020");
            users.Add(new StudentDTO { Id ="1612556",Name="Nguyen Hoang Sang", Type="Student", Status="Active",DateofBith="16/8/1998",Gender="Male",Email="test@gmail.com",Password="123",Phone="0123456789",NameClass="12C1",SchoolYear="2018-2019"});
            users.Add(new StudentDTO { Id = "1612556", Name = "Nguyen Hoang Sang", Type = "Student", Status = "Active",Gender="Male"});
            users.Add(new StudentDTO { Id = "1612557", Name = "Le Hoang Sang", Type = "Teacher", Status = "Active", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1512383", Name = "Nguyen Thuy Nhien", Type = "Student", Status = "Active", Gender = "Female" });
            users.Add(new StudentDTO { Id = "1612553", Name = "Tran Ngoc Quang", Type = "Student", Status = "Deactive", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1234523", Name = "Nguyen Van A", Type = "Student", Status = "Active", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1612336", Name = "Nguyen Van B", Type = "Teacher", Status = "Active", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1621556", Name = "Nguyen Van C", Type = "Student", Status = "Active", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1235562", Name = "Nguyen Van D", Type = "Teacher", Status = "Active", Gender = "Male" });
            users.Add(new StudentDTO { Id = "1343564", Name = "Nguyen Van E", Type = "Student", Status = "Deactive", Gender = "Male" });
            InitializeComponent();
        }

        private void Window_Loaded_Student(object sender, RoutedEventArgs e)
        {
            if (Global.Teacher.Type == "PDT")
            {
                chooseYear.ItemsSource = AcademicAffairsOfficeBUS.loadListSchoolYearToComboBox();
                chooseYear.SelectedIndex = 0;

                chooseClass.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox(chooseYear.SelectedValue.ToString());
                chooseClass.SelectedIndex = 0;
              
                Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedValue.ToString(), chooseYear.SelectedValue.ToString());
                listviewStudent.ItemsSource = Global.listStudent;
            }
            else
            {
                chooseYear.ItemsSource = TeacherBUS.loadSchoolYearToComboBox(Global.Teacher.Id);
                chooseYear.SelectedIndex = 0;
                chooseClass.ItemsSource = TeacherBUS.loadListClassToComboBox(Global.Teacher.Id, chooseYear.SelectedValue.ToString());
                chooseClass.SelectedIndex = 0;
                Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedValue.ToString(), chooseYear.SelectedValue.ToString());
                listviewStudent.ItemsSource = Global.listStudent;
                listviewStudent.SelectedIndex = 0;
            }
         //  Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedItem.ToString(), chooseYear.SelectedItem.ToString());

         //   listviewStudent.ItemsSource = Global.listStudent;
            
        }

        private void test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnViewScore.IsEnabled = true;
        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            btnViewScore.IsEnabled = false;
            btnViewScore.Visibility = Visibility.Visible;
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            if (listviewStudent.SelectedItems.Count > 0)
            {
                StudentDTO item = (StudentDTO)listviewStudent.SelectedItems[0];
                fullname_st_infor.Content = item.Name;
                birthofday_st_infor.Content = item.DateofBith;
                email_st_infor.Content = item.Email;
                gender_st_infor.Content = item.Gender;
                phone_st_infor.Content = item.Phone;
                nameclass_st_infor.Content = item.NameClass;
                yearSchool_st_infor.Content = item.SchoolYear;
            }
        }

        private void ComboBox_Classes_Loaded(object sender, RoutedEventArgs e)
        {
           /* if (Global.Teacher.NamePosition == "PDT")
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox();
                combo.SelectedIndex = 0;
            }
            else
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = classes;
                combo.SelectedIndex = 0;
            }*/
        }

        private void ComboBox_Years_Loaded(object sender, RoutedEventArgs e)
        {
           /* if (Global.Teacher.NamePosition == "PDT")
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = AcademicAffairsOfficeBUS.loadListSchoolYearToComboBox();
                combo.SelectedIndex = 0;
            }
            else
            {
                var combo = sender as ComboBox;
                combo.ItemsSource = years;
                combo.SelectedIndex = 0;
            }*/
        }

        private void btnViewScore_Click(object sender, RoutedEventArgs e)
        {
            
            Global.Student = (StudentDTO)listviewStudent.SelectedItem;
           
            var window = new ReviewStudentScore();
            window.Show();
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            

            Global.listStudent = AcademicAffairsOfficeBUS.searchStudent(searchUser.Text, chooseClass.SelectedItem.ToString(), chooseYear.SelectedItem.ToString());
            /* if (Global.listStudent != null)
             {
                 listviewStudent.ItemsSource = Global.listStudent;
             }*/
            listviewStudent.ItemsSource = Global.listStudent;
        }

        private void ChooseClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseClass.SelectedValue != null && chooseYear.SelectedValue != null)
            {
                Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedItem.ToString(), chooseYear.SelectedItem.ToString());
                listviewStudent.ItemsSource = Global.listStudent;
            }
        }

        private void ChooseYear_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseClass.SelectedValue != null && chooseYear.SelectedValue != null)
            {
                if (Global.Teacher.Type == "PDT")
                {
                    chooseClass.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox(chooseYear.SelectedValue.ToString());
                    chooseClass.SelectedIndex = 0;
                }
                else
                {
                    chooseClass.ItemsSource = TeacherBUS.loadListClassToComboBox(Global.Teacher.Id, chooseYear.SelectedValue.ToString());
                    chooseClass.SelectedIndex = 0;
                }
                Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedItem.ToString(), chooseYear.SelectedItem.ToString());
                listviewStudent.ItemsSource = Global.listStudent;
            }
        }

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchUser.Text))
            {
                Global.listStudent = AcademicAffairsOfficeBUS.loadListStudent(chooseClass.SelectedItem.ToString(), chooseYear.SelectedItem.ToString());
                listviewStudent.ItemsSource = Global.listStudent;
            }
        }
    }
}
