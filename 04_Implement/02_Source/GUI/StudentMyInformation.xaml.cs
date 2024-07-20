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
    /// Interaction logic for test1.xaml
    /// </summary>
    public partial class StudentMyInformation : Page
    {
        private StudentDTO test = new StudentDTO { Name = "Leo Nguyen Student test", NameClass = "K16 Student test", Gender="Male", Email="testing@gmail.com", DateofBith="01.01.1998 test", Phone="0123456789", Id="leonguyenstudenttest"};
        public StudentMyInformation()
        {
            InitializeComponent();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            phone_st_infor.IsReadOnly = false;
            email_st_infor.IsReadOnly = false;
            birthofday_st_infor.IsReadOnly = false;
            gender_st_infor.IsReadOnly = false;
            btnEdit.Visibility = Visibility.Collapsed;
            btnDoneOfEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            gender_st_infor.IsEnabled = true;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            phone_st_infor.IsReadOnly = true;
            email_st_infor.IsReadOnly = true;
            birthofday_st_infor.IsReadOnly = true;
            gender_st_infor.IsReadOnly = true;
            gender_st_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;

            string idStudent = id_st_infor.Text;
            string Name = Global.Student.Name;
            string Gender = gender_st_infor.Text;
            string Email = email_st_infor.Text;
            string Phone = phone_st_infor.Text;
            string BirthDay = birthofday_st_infor.Text;

            if (StudentBUS.changeMyInfomation(idStudent, Name, Gender, Email, Phone, BirthDay))
            {
                Global.Student.Name = Name;
                Global.Student.Gender = Gender;
                Global.Student.Email = Email;
                Global.Student.Phone = Phone;

                Global.Student.DateofBith = BirthDay;

               
                id_st_infor.Text = Global.Student.Id;
                birthofday_st_infor.Text = Global.Student.DateofBith;
                phone_st_infor.Text = Global.Student.Phone;
                email_st_infor.Text = Global.Student.Email;


                if (Global.Student.Gender == "Male")
                {
                    gender_st_infor.SelectedIndex = 1;
                }
                else if (Global.Student.Gender == "Female")
                {
                    gender_st_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_st_infor.SelectedIndex = 0;
                }

                // Teacher = Global.Teacher;
            }
            else
            {
                id_st_infor.Text = Global.Student.Id;
                birthofday_st_infor.Text = Global.Student.DateofBith;
                phone_st_infor.Text = Global.Student.Phone;
                email_st_infor.Text = Global.Student.Email;


                if (Global.Student.Gender == "Male")
                {
                    gender_st_infor.SelectedIndex = 1;
                }
                else if (Global.Student.Gender == "Female")
                {
                    gender_st_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_st_infor.SelectedIndex = 0;
                }


                MessageBox.Show("Update your information failed");
            }

        }
        private void Window_Loaded_StudentInformation(object sender, RoutedEventArgs e)
        {
            fullname_st_infor.Text = Global.Student.Name;
            id_st_infor.Text = Global.Student.Id;
            birthofday_st_infor.Text = Global.Student.DateofBith;
            phone_st_infor.Text = Global.Student.Phone;
            email_st_infor.Text = Global.Student.Email;
            if (Global.Student.Gender == "Male")
            {
                gender_st_infor.SelectedIndex = 1;
            }
            else if (Global.Student.Gender == "Female")
            {
                gender_st_infor.SelectedIndex = 2;
            }
            else
            {
                gender_st_infor.SelectedIndex = 0;
            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            phone_st_infor.IsReadOnly = true;
            email_st_infor.IsReadOnly = true;
            birthofday_st_infor.IsReadOnly = true;
            gender_st_infor.IsReadOnly = true;
            gender_st_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            Window_Loaded_StudentInformation(sender, e);
        }
    }
}
