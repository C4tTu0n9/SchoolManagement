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
using BUS;
using DTO;
namespace GUI
{
    /// <summary>
    /// Interaction logic for test1.xaml
    /// </summary>
    public partial class TeacherMyInformation : Page
    {
      //  private TeacherDTO test = new TeacherDTO { Name = "Leo Nguyen Teacher test", Gender = "Male", Email = "testing@gmail.com", DateofBith = "01.01.1998 test", Phone = "0123456789", Id = "leonguyeteachertest" };
      //  private TeacherDTO Teacher = Global.Teacher;
        public TeacherMyInformation()
        {
            InitializeComponent();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            phone_tc_infor.IsReadOnly = false;
            email_tc_infor.IsReadOnly = false;
            birthofday_tc_infor.IsReadOnly = false;
            gender_tc_infor.IsReadOnly = false;
            gender_tc_infor.IsEnabled = true;

            btnEdit.Visibility = Visibility.Collapsed;
            btnDoneOfEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            gender_tc_infor.IsEnabled = false;
            phone_tc_infor.IsReadOnly = true;
            email_tc_infor.IsReadOnly = true;
            birthofday_tc_infor.IsReadOnly = true;
            gender_tc_infor.IsReadOnly = true;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            string idTeacher = id_tc_infor.Text;
            string Name = fullname_tc_infor.Text;
            string Gender = gender_tc_infor.Text;
            string Email = email_tc_infor.Text;
            string Phone = phone_tc_infor.Text;
            string BirthDay = birthofday_tc_infor.Text;
            if (TeacherBUS.changeMyInfomation(idTeacher,Name,Gender,Email,Phone,BirthDay))
            {
                Global.Teacher.Name = Name;
                Global.Teacher.Gender = Gender;
                Global.Teacher.Email = Email;
                Global.Teacher.Phone = Phone;
            
                Global.Teacher.DateofBith = BirthDay;

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

               // Teacher = Global.Teacher;
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

                MessageBox.Show("Update your information failed");
            }

        }
        private void Window_Loaded_AdminInformation(object sender, RoutedEventArgs e)
        {
            /* fullname_tc_infor.Text = test.Name;
             id_tc_infor.Text = test.Id;
             birthofday_tc_infor.Text = test.DateofBith;
             phone_tc_infor.Text = test.Phone;
             email_tc_infor.Text = test.Email;
             if (test.Gender == "Male")
             {
                 gender_tc_infor.SelectedIndex = 1;
             }
             else if (test.Gender == "Female")
             {
                 gender_tc_infor.SelectedIndex = 2;
             }
             else
             {
                 gender_tc_infor.SelectedIndex = 0;
             }*/


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
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            phone_tc_infor.IsReadOnly = true;
            email_tc_infor.IsReadOnly = true;
            birthofday_tc_infor.IsReadOnly = true;
            gender_tc_infor.IsReadOnly = true;
            gender_tc_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            Window_Loaded_AdminInformation(sender, e);
        }
    }
}
