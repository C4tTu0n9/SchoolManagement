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
    public sealed partial class TeacherManageTeacher : Page
    {
        private List<TeacherDTO> users = new List<TeacherDTO>();
        bool isLoaded = false;
        public TeacherManageTeacher()
        {
           // users.Add(new TeacherDTO { NamePosition="Master",Id ="1612556",NameClass="12C1",SchoolYear="2018-2019",Name="Nguyen Hoang Sang", Type="Teacher", Status="Active",DateofBith="16/8/1998",Gender="Male",Email="test@gmail.com",Password="123",Phone="0123456789"});
          //  users.Add(new TeacherDTO { NamePosition = "Subject Teacher", Id = "1612556", Name = "Nguyen Hoang Sang", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1612557", Name = "Le Hoang Sang", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1512383", Name = "Nguyen Thuy Nhien", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1612553", Name = "Tran Ngoc Quang", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1234523", Name = "Nguyen Van A", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1612336", Name = "Nguyen Van B", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1621556", Name = "Nguyen Van C", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { NamePosition = "Homeroom Teacher", Id = "1235562", Name = "Nguyen Van D", Type = "Teacher", Status = "Active" });
            users.Add(new TeacherDTO { Id = "1343564", Name = "Nguyen Van E", Type = "Teacher", Status = "Active" });
            InitializeComponent();
        }

        private void Window_Loaded_Teacher(object sender, RoutedEventArgs e)
        {
            isLoaded = true;
            listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListTeacher();
            btnEdit.IsEnabled = false;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnDoneOfEdit.Visibility = Visibility.Visible;
            fullname_tc_infor.IsReadOnly =false;
            birthofday_tc_infor.IsReadOnly = false;
            email_tc_infor.IsReadOnly = false;
            gender_tc_infor.IsReadOnly = false;
            gender_tc_infor.IsEnabled = true;
            phone_tc_infor.IsReadOnly = false;
            position_tc_infor.IsEnabled = true;
            btnCancel.Visibility = Visibility.Visible;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            gender_tc_infor.IsEnabled = false;
            phone_tc_infor.IsReadOnly = true;
            email_tc_infor.IsReadOnly = true;
            birthofday_tc_infor.IsReadOnly = true;
            gender_tc_infor.IsReadOnly = true;
            position_tc_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnEdit.IsEnabled = false;
            btnCancel.Visibility = Visibility.Collapsed;
            string idTeacher = id_tc_infor.Text;
            string Name = fullname_tc_infor.Text;
            string Gender = gender_tc_infor.Text;
            string Email = email_tc_infor.Text;
            string Phone = phone_tc_infor.Text;
            string BirthDay = birthofday_tc_infor.Text;
            if (TeacherBUS.changeMyInfomation(idTeacher, Name, Gender, Email, Phone, BirthDay))
            {
                Global.Teacher.Name = Name;
                Global.Teacher.Gender = Gender;
                Global.Teacher.Email = Email;
                Global.Teacher.Phone = Phone;
                Global.Teacher.Id = idTeacher;
                Global.Teacher.DateofBith = BirthDay;

                fullname_tc_infor.Text = Global.Teacher.Name;
                id_tc_infor.Text = idTeacher;
                birthofday_tc_infor.Text = Global.Teacher.DateofBith;
                phone_tc_infor.Text = Global.Teacher.Phone;
                email_tc_infor.Text = Global.Teacher.Email;


                if (Global.Teacher.Gender == "Male")
                {
                    gender_tc_infor.SelectedIndex = 1;
                }
                else if (Global.Teacher.Gender == "Female")
                {
                    gender_tc_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_tc_infor.SelectedIndex = 0;
                }

                if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Academic Affair Office Staff")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListAAOS();
                }
                else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject Teacher")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListSubjectTeacher(Global.schoolYear);
                }
                else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Homeroom Teacher")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListHomeRoomTeacher(Global.schoolYear);
                }
                else
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListTeacher();
                }

                
            }
            else
            {
                fullname_tc_infor.Text = Global.Teacher.Name;
                id_tc_infor.Text = Global.Teacher.Id;
                birthofday_tc_infor.Text = Global.Teacher.DateofBith;
                phone_tc_infor.Text = Global.Teacher.Phone;
                email_tc_infor.Text = Global.Teacher.Email;
                if (Global.Teacher.Gender == "Male")
                {
                    gender_tc_infor.SelectedIndex = 1;
                }
                else if (Global.Teacher.Gender == "Female")
                {
                    gender_tc_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_tc_infor.SelectedIndex = 0;
                }

                MessageBox.Show("Update information failed");
            }
        }


        private void test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            if (listviewUser.SelectedItems.Count > 0)
            {
                TeacherDTO item = (TeacherDTO)listviewUser.SelectedItems[0];
                fullname_tc_infor.Text = item.Name;
                birthofday_tc_infor.Text = item.DateofBith;
                email_tc_infor.Text = item.Email;
                id_tc_infor.Text = item.Id;
                if (item.Gender == "Male")
                {
                    gender_tc_infor.SelectedIndex = 1;
                }
                else if (item.Gender == "Female")
                {
                    gender_tc_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_tc_infor.SelectedIndex = 0;
                }
                phone_tc_infor.Text = item.Phone;
                if (item.NamePosition == "AAO Staff")
                {
                    position_tc_infor.SelectedIndex = 2;
                }
                else if (item.NamePosition == "Subject Teacher")
                {
                    position_tc_infor.SelectedIndex = 0;
                }
                else if (item.NamePosition == "Homeroom Teacher")
                {
                    position_tc_infor.SelectedIndex = 1;
                }
                else
                {
                    position_tc_infor.SelectedIndex = 3;
                }


            }
        }

        private void btnViewScore_Click(object sender, RoutedEventArgs e)
        {
            var window = new ReviewStudentScore();
            window.Show();
        }

        private void ChoosePosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded == true)
            {
                if (choosePosition.SelectedValue.ToString()== "System.Windows.Controls.ComboBoxItem: Academic Affair Office Staff")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListAAOS();
                }
                else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject Teacher")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListSubjectTeacher(Global.schoolYear);
                }
                else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Homeroom Teacher")
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListHomeRoomTeacher(Global.schoolYear);
                }
                else
                {
                    listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListTeacher();
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            listviewUser.ItemsSource = AcademicAffairsOfficeBUS.searchTeacher(searchUser.Text, Global.schoolYear, choosePosition.SelectedValue.ToString());
        }

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchUser.Text))
            {
                if (choosePosition.SelectedValue != null)
                {
                    if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Academic Affair Office Staff")
                    {
                        listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListAAOS();
                    }
                    else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Subject Teacher")
                    {
                        listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListSubjectTeacher(Global.schoolYear);
                    }
                    else if (choosePosition.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Homeroom Teacher")
                    {
                        listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListHomeRoomTeacher(Global.schoolYear);
                    }
                    else
                    {
                        listviewUser.ItemsSource = AcademicAffairsOfficeBUS.loadListTeacher();
                    }
                }
            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            gender_tc_infor.IsEnabled = false;
            phone_tc_infor.IsReadOnly = true;
            email_tc_infor.IsReadOnly = true;
            birthofday_tc_infor.IsReadOnly = true;
            gender_tc_infor.IsReadOnly = true;
            position_tc_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;

            btnCancel.Visibility = Visibility.Collapsed;
            Window_Loaded_Teacher(sender, e);
        }
    }
}
