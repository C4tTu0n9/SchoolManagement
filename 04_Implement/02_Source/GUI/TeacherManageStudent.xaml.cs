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
    public sealed partial class TeacherManageStudent : Page
    {
        private List<StudentDTO> users = new List<StudentDTO>();
        public TeacherManageStudent()
        {
            users.Add(new StudentDTO { Id ="1612556",NameClass="12C1",SchoolYear="2018-2019",Name="Nguyen Hoang Sang", Type="Student", Status="Active",DateofBith="16/8/1998",Gender="Male",Email="test@gmail.com",Password="123",Phone="0123456789"});
            users.Add(new StudentDTO { Id = "1612556", Name = "Nguyen Hoang Sang", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1612557", Name = "Le Hoang Sang", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1512383", Name = "Nguyen Thuy Nhien", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1612553", Name = "Tran Ngoc Quang", Type = "Student", Status = "Deactive" });
            users.Add(new StudentDTO { Id = "1234523", Name = "Nguyen Van A", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1612336", Name = "Nguyen Van B", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1621556", Name = "Nguyen Van C", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1235562", Name = "Nguyen Van D", Type = "Student", Status = "Active" });
            users.Add(new StudentDTO { Id = "1343564", Name = "Nguyen Van E", Type = "Student", Status = "Deactive" });
            InitializeComponent();
        }

        private void Window_Loaded_Student(object sender, RoutedEventArgs e)
        {


            chooseClass.ItemsSource = AcademicAffairsOfficeBUS.loadListClassToComboBox(Global.schoolYear);
            chooseClass.SelectedIndex = 0;

            listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnDoneOfEdit.Visibility = Visibility.Visible;
            fullname_st_infor.IsReadOnly =false;
            birthofday_st_infor.IsReadOnly = false;
            email_st_infor.IsReadOnly = false;
            phone_st_infor.IsReadOnly = false;
            gender_st_infor.IsEnabled = true;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            StudentDTO item = (StudentDTO)listviewUser.SelectedItems[0];
            item.Gender = gender_st_infor.Text;
            item.DateofBith = birthofday_st_infor.Text;
            item.Name = fullname_st_infor.Text;
            item.Email = email_st_infor.Text;
            item.NameClass = class_st_infor.Text;
            item.Phone = phone_st_infor.Text;
            item.SchoolYear = schoolyear_st_infor.Text;

            if (!AcademicAffairsOfficeBUS.updateInfoStudent(item))
            {
                MessageBox.Show("Update information student failed");
                return;
            }
            listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());

            btnEdit.IsEnabled = false;
            btnEdit.Visibility = Visibility.Visible;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            gender_st_infor.IsEnabled = false ;
            fullname_st_infor.IsReadOnly = true;
            birthofday_st_infor.IsReadOnly = true;
            email_st_infor.IsReadOnly = true;
            phone_st_infor.IsReadOnly = true;
            btnDelete.Visibility = Visibility.Collapsed;
            btnActive.Visibility = Visibility.Collapsed;
            btnViewScore.IsEnabled = false;
            schoolyear_st_infor.IsReadOnly = true;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (listviewUser.SelectedItems.Count > 0)
            {
                StudentDTO item = (StudentDTO)listviewUser.SelectedItems[0];
                if (!AcademicAffairsOfficeBUS.deActiveStudent(item.Id))
                {
                    MessageBox.Show("Deactive Faidled");
                }
                listviewUser.ItemsSource = listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());

                btnDelete.Visibility = Visibility.Collapsed;
                btnActive.Visibility = Visibility.Collapsed;
                btnEdit.IsEnabled = false;
                btnViewScore.IsEnabled = false;
            }
        }



        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            if (listviewUser.SelectedItems.Count > 0)
            {
                StudentDTO item = (StudentDTO)listviewUser.SelectedItems[0];
                if (!AcademicAffairsOfficeBUS.ActiveStudent(item.Id))
                {
                    MessageBox.Show("Active Faidled");
                }
                listviewUser.ItemsSource = listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());
                btnDelete.Visibility = Visibility.Collapsed;
                btnActive.Visibility = Visibility.Collapsed;
                btnEdit.IsEnabled = false;
                btnViewScore.IsEnabled = false;
            }
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            if (listviewUser.SelectedItems.Count > 0)
            {
                StudentDTO item = (StudentDTO)listviewUser.SelectedItems[0];
                fullname_st_infor.Text = item.Name;
                birthofday_st_infor.Text = item.DateofBith;
                email_st_infor.Text = item.Email;
                class_st_infor.Text = item.NameClass;
                if (item.Gender == "Male")
                {
                    gender_st_infor.SelectedIndex = 1;
                }
                else if (item.Gender == "Female")
                {
                    gender_st_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_st_infor.SelectedIndex = 0;
                }
                phone_st_infor.Text = item.Phone;
                schoolyear_st_infor.Text = item.SchoolYear;
                if (item.Status == "Active")
                {
                    btnDelete.Visibility = Visibility.Visible;
                    btnActive.Visibility = Visibility.Collapsed;
                }
                else if (item.Status == "Deactive")
                {
                    btnActive.Visibility = Visibility.Visible;
                    btnDelete.Visibility = Visibility.Collapsed;
                }
            }
        }

        private void btnViewScore_Click(object sender, RoutedEventArgs e)
        {
            Global.Student = (StudentDTO)listviewUser.SelectedItems[0];
            var window = new ReviewStudentScore();
            window.Show();
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

        private void ChooseClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseClass.SelectedValue != null && chooseStatus.SelectedValue != null)
            {
                listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());
            }
        }

        private void ChooseStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (chooseClass.SelectedValue != null && chooseStatus.SelectedValue != null)
            {
                listviewUser.ItemsSource = AcademicAffairsOfficeBUS.LoadStudent(chooseClass.SelectedValue.ToString(), Global.schoolYear, chooseStatus.SelectedValue.ToString());
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            listviewUser.ItemsSource = AcademicAffairsOfficeBUS.searchStudent(searchUser.Text, chooseClass.SelectedValue.ToString(), Global.schoolYear);
        }

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(searchUser.Text))
            {
                listviewUser.ItemsSource = AcademicAffairsOfficeBUS.searchStudent(searchUser.Text, chooseClass.SelectedValue.ToString(), Global.schoolYear);
            }
        }

        private void listviewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
