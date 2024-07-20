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
    public sealed partial class AdminManageUser : Page
    {
        private List<PeopleDTO> users = new List<PeopleDTO>();
        bool isLoaded = false;
        public AdminManageUser()
        {
            users.Add(new PeopleDTO {Id ="1612556",Name="Nguyen Hoang Sang", Type="Student", Status="Active",DateofBith="16/8/1998",Gender="Male",Email="test@gmail.com",Password="123",Phone="0123456789"});
            users.Add(new PeopleDTO { Id = "1612556", Name = "Nguyen Hoang Sang", Type = "Student", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1612557", Name = "Le Hoang Sang", Type = "Teacher", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1512383", Name = "Nguyen Thuy Nhien", Type = "Student", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1612553", Name = "Tran Ngoc Quang", Type = "Student", Status = "Deactive" });
            users.Add(new PeopleDTO { Id = "1234523", Name = "Nguyen Van A", Type = "Student", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1612336", Name = "Nguyen Van B", Type = "Teacher", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1621556", Name = "Nguyen Van C", Type = "Student", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1235562", Name = "Nguyen Van D", Type = "Teacher", Status = "Active" });
            users.Add(new PeopleDTO { Id = "1343564", Name = "Nguyen Van E", Type = "Student", Status = "Deactive" });
            InitializeComponent();
        }

        private void Window_Loaded_User(object sender, RoutedEventArgs e)
        {

            isLoaded = true;
            // listviewUser.ItemsSource = users;    
           if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
            {
                listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
            }
           else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
            {
                listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
            }
           else
            {
                listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            btnDoneOfEdit.Visibility = Visibility.Visible;
            btnCancel.Visibility = Visibility.Visible;
            password_user_infor.IsEnabled = true;
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            PeopleDTO item = (PeopleDTO)listviewUser.SelectedItems[0];
            if (!AdminBUS.resetPassword(item.Id,password_user_infor.Password,item.Type))
            {
                MessageBox.Show("Change password failed");
                return;
            }

            btnEdit.Visibility = Visibility.Visible;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            password_user_infor.IsEnabled = false;
            btnCancel.Visibility = Visibility.Collapsed;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            PeopleDTO item = (PeopleDTO)listviewUser.SelectedItems[0];
            if (!AdminBUS.DeActiveUser(item.Id,item.Type))
            {
                MessageBox.Show("Error", "Deactive user failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
            {
                listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
            }
            else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
            {
                listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
            }
            else
            {
                listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
            }

            btnDelete.Visibility = Visibility.Collapsed;
            btnActive.Visibility = Visibility.Collapsed;
            btnEdit.IsEnabled = false;
        }

        private void test_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
        }

        private void btnActive_Click(object sender, RoutedEventArgs e)
        {
            PeopleDTO item = (PeopleDTO)listviewUser.SelectedItems[0];
            if (!AdminBUS.ActiveUser(item.Id, item.Type))
            {
                MessageBox.Show("Error", "Active user failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
            {
                listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
            }
            else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
            {
                listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
            }
            else
            {
                listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
            }


            btnDelete.Visibility = Visibility.Collapsed;
            btnActive.Visibility = Visibility.Collapsed;
            btnEdit.IsEnabled = false;
        }

        private void SelectItem(object sender, MouseButtonEventArgs e)
        {
            PeopleDTO item = (PeopleDTO)listviewUser.SelectedItems[0];
            fullname_user_infor.Text = item.Name;
            birthofday_user_infor.Text = item.DateofBith;
            email_user_infor.Text = item.Email;
            password_user_infor.Password = item.Password;
            if (item.Gender == "Male")
            {
                gender_user_infor.SelectedIndex = 1;
            }
            else if (item.Gender == "Female")
            {
                gender_user_infor.SelectedIndex = 2;
            }
            else
            {
                gender_user_infor.SelectedIndex = 0;
            }
            phone_user_infor.Text = item.Phone;
            author_user_infor.Text = item.Type;
            if (item.Type == "Student")
            {
                if (item.Status == "Active")
                {
                    btnDelete.Visibility = Visibility.Visible;
                }
                else if (item.Status == "Deactive")
                {
                    btnActive.Visibility = Visibility.Visible;
                }
            }
        }

        private void ChooseAuthor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
                }
                else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
                }
                else
                {
                    listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
                }
            }
        }

        private void ChooseStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (isLoaded)
            {
                if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
                }
                else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
                }
                else
                {
                    listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
                }
            }
        }

        private void Btn_Search_Click(object sender, RoutedEventArgs e)
        {
            listviewUser.ItemsSource = AdminBUS.searchUser(chooseAuthor.SelectedValue.ToString(), chooseStatus.SelectedValue.ToString(), searchUser.Text);
            if (AdminBUS.searchUser(chooseAuthor.SelectedValue.ToString(), chooseStatus.SelectedValue.ToString(), searchUser.Text).Count() == 0)
            {
                listviewUser.IsEnabled = false;
            }
            else
            {
                listviewUser.IsEnabled = true;
            }
        }

        private void SearchUser_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(searchUser.Text))
            {
                if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Student")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListStudent(chooseStatus.SelectedValue.ToString());
                }
                else if (chooseAuthor.SelectedValue.ToString() == "System.Windows.Controls.ComboBoxItem: Teacher")
                {
                    listviewUser.ItemsSource = AdminBUS.loadListTeacher(chooseStatus.SelectedValue.ToString());
                }
                else
                {
                    listviewUser.ItemsSource = AdminBUS.loadListUser(chooseStatus.SelectedValue.ToString());
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            password_user_infor.IsEnabled = false;
            btnCancel.Visibility = Visibility.Collapsed;
            btnActive.Visibility = Visibility.Collapsed;
            btnDelete.Visibility = Visibility.Collapsed;
            btnEdit.IsEnabled = false;
            Window_Loaded_User(sender, e);
        }
    }
}
