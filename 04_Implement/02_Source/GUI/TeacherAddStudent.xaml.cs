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
    public partial class TeacherAddStudent : Page
    {
        private AdminDTO test = new AdminDTO { Name = "Leo Nguyen Student test", Gender="Male test", Email="testing@gmail.com", DateofBith="01.01.1998 test", Phone="0123456789", Id="leonguyenadmintest"};
        List<String> classes = new List<string>();
        List<String> years = new List<string>();
        public TeacherAddStudent()
        {
            classes.Add("10C1");
            classes.Add("11C1");
            classes.Add("12C1");
            classes.Add("10C2");
            classes.Add("10C3");
            classes.Add("11C2");
            classes.Add("12C2");
            classes.Add("10C3");
            years.Add("2014-2015");
            years.Add("2015-2016");
            years.Add("2016-2017");
            years.Add("2018-2019");
            years.Add("2019-2020");
            InitializeComponent();
        }

        private void btnDoneofAddUser_click(object sender, RoutedEventArgs e)
        {
            StudentDTO temp = new StudentDTO();
            temp.Id = id_addstudent.Text;
            temp.Email = email_addstudent.Text;
            temp.DateofBith = birthofday_addstudent.Text;
            temp.Phone = phone_addstudent.Text;
            temp.Gender = gender_addstudent.Text;
            temp.Password = password_addstudent.Password.ToString();
            temp.Name = fname_addstudent.Text;
            
            if (id_addstudent.Text =="" || email_addstudent.Text == "" || birthofday_addstudent.Text == "" || phone_addstudent.Text == "" || gender_addstudent.Text == "" || password_addstudent.Password.ToString()=="" || passwordconfirm_addstudent.Password.ToString()=="")
            {
                MessageBox.Show("You must fill out the infomation");
                return;
            }

            if (password_addstudent.Password.ToString() != passwordconfirm_addstudent.Password.ToString())
            {
                MessageBox.Show("Password and Confirm Password does not match");
                return;
            }

            

            if (AcademicAffairsOfficeBUS.addNewStudent(temp) == false)
            {
                MessageBox.Show("Add student failed");
                return;
            }
            else
            {
                MessageBox.Show("Add successfully");
            }

            id_addstudent.Text = "";
            email_addstudent.Text = "";
            birthofday_addstudent.Text = "";
            phone_addstudent.Text = "";
            fname_addstudent.Text = "";
            chooseYear.SelectedIndex = 0;
            gender_addstudent.Text = "";
            password_addstudent.Clear();
            passwordconfirm_addstudent.Clear();



        }

        /*private void ComboBox_Classes_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = classes;
            combo.SelectedIndex = 0;
        }*/

        private void ComboBox_Years_Loaded(object sender, RoutedEventArgs e)
        {
            var combo = sender as ComboBox;
            combo.ItemsSource = new List<string> { Global.schoolYear };
            combo.SelectedIndex = 0;
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            id_addstudent.Text = "";
            email_addstudent.Text = "";
            birthofday_addstudent.Text = "";
            phone_addstudent.Text = "";
            fname_addstudent.Text = "";
            chooseYear.SelectedIndex = 0;
            gender_addstudent.Text = "";
            password_addstudent.Clear();
            passwordconfirm_addstudent.Clear();
        }
    }
}
