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
    public partial class AdminMyInformation : Page
    {
        private AdminDTO test = new AdminDTO { Name = "Leo Nguyen Admin test", Gender = "Male", Email = "testing@gmail.com", DateofBith = "01.01.1998 test", Phone = "0123456789", Id = "leonguyenadmintest" };
        public AdminMyInformation()
        {
            InitializeComponent();
        }

        private void btnEdit_click(object sender, RoutedEventArgs e)
        {
            btnCancel.Visibility = Visibility.Visible;
            phone_ad_infor.IsReadOnly = false;
            email_ad_infor.IsReadOnly = false;
            birthofday_ad_infor.IsReadOnly = false;
            gender_ad_infor.IsEnabled = true;
            btnEdit.Visibility = Visibility.Collapsed;
            btnDoneOfEdit.Visibility = Visibility.Visible;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            phone_ad_infor.IsReadOnly = true;
            email_ad_infor.IsReadOnly = true;
            birthofday_ad_infor.IsReadOnly = true;
            gender_ad_infor.IsReadOnly = true;
            gender_ad_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;

            string idAdmin = id_ad_infor.Text;
            string Name = Global.Admin.Name;
            string Gender = gender_ad_infor.Text;
            string Email = email_ad_infor.Text;
            string Phone = phone_ad_infor.Text;
            string BirthDay = birthofday_ad_infor.Text;

            if (AdminBUS.changeMyInfomation(idAdmin, Name, Gender, Email, Phone, BirthDay))
            {
                Global.Admin.Name = Name;
                Global.Admin.Gender = Gender;
                Global.Admin.Email = Email;
                Global.Admin.Phone = Phone;

                Global.Admin.DateofBith = BirthDay;


                id_ad_infor.Text = Global.Admin.Id;
                birthofday_ad_infor.Text = Global.Admin.DateofBith;
                phone_ad_infor.Text = Global.Admin.Phone;
                email_ad_infor.Text = Global.Admin.Email;


                if (Global.Admin.Gender == "Male")
                {
                    gender_ad_infor.SelectedIndex = 1;
                }
                else if (Global.Admin.Gender == "Female")
                {
                    gender_ad_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_ad_infor.SelectedIndex = 0;
                }

                // Teacher = Global.Teacher;
            }
            else
            {
                id_ad_infor.Text = Global.Admin.Id;
                birthofday_ad_infor.Text = Global.Admin.DateofBith;
                phone_ad_infor.Text = Global.Admin.Phone;
                email_ad_infor.Text = Global.Admin.Email;


                if (Global.Admin.Gender == "Male")
                {
                    gender_ad_infor.SelectedIndex = 1;
                }
                else if (Global.Admin.Gender == "Female")
                {
                    gender_ad_infor.SelectedIndex = 2;
                }
                else
                {
                    gender_ad_infor.SelectedIndex = 0;
                }


                MessageBox.Show("Update your information failed");
            }

        }
        private void Window_Loaded_AdminInformation(object sender, RoutedEventArgs e)
        {
            fullname_ad_infor.Text = Global.Admin.Name;
            id_ad_infor.Text = Global.Admin.Id;
            birthofday_ad_infor.Text = Global.Admin.DateofBith;
            phone_ad_infor.Text = Global.Admin.Phone;
            email_ad_infor.Text = Global.Admin.Email;
            if (Global.Admin.Gender == "Male")
            {
                gender_ad_infor.SelectedIndex = 1;
            }
            else if (Global.Admin.Gender == "Female")
            {
                gender_ad_infor.SelectedIndex = 2;
            }
            else
            {
                gender_ad_infor.SelectedIndex = 0;
            }
        }

        private void btnCancel_click(object sender, RoutedEventArgs e)
        {
            phone_ad_infor.IsReadOnly = true;
            email_ad_infor.IsReadOnly = true;
            birthofday_ad_infor.IsReadOnly = true;
            gender_ad_infor.IsReadOnly = true;
            gender_ad_infor.IsEnabled = false;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Collapsed;
            Window_Loaded_AdminInformation(sender, e);
        }
    }
}
