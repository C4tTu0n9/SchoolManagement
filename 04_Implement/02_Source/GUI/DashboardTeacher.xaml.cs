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
using System.Windows.Shapes;
using BUS;
namespace GUI
{
    /// <summary>
    /// Interaction logic for DashboardTeacher.xaml
    /// </summary>
    public partial class DashboardTeacher : Window
    {
        public DashboardTeacher()
        {
            InitializeComponent();
            fullname_title.Content = Global.Teacher.Name;
            if (Global.Teacher.Type == "GV")
            {
                class_title.Content = "Teacher";
                ListViewMenu.Items.RemoveAt(8);
                ListViewMenu.Items.RemoveAt(7);
                ListViewMenu.Items.RemoveAt(6);
                ListViewMenu.Items.RemoveAt(5);
                ListViewMenu.Items.RemoveAt(4);
                ListViewMenu.Items.RemoveAt(3);
            }
            else
            {
                class_title.Content = "AcademicAffairOffice Staff";
            }
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = ListViewMenu.SelectedIndex;
            MoveCursorMenu(index);

            switch (index)
            {
                case 0:
                    GridPrincipal.Content = new TeacherMyInformation(); 
                    break;
                case 1:
                    GridPrincipal.Content = new TeacherSearchStudent();
                    break;
                case 2:
                    GridPrincipal.Content = new TeacherUpdateScore();
                    break;
                case 3:
                    GridPrincipal.Content = new TeacherAddStudent();
                    break;
                case 4:
                    GridPrincipal.Content = new TeacherManageClasses();//manage classes
                    break;
                case 5:
                    GridPrincipal.Content = new TeacherManageStudent();//manage students
                    break;
                case 6:
                    GridPrincipal.Content = new TeacherManageTeacher();//manage teachers
                    break;
                case 7:
                    GridPrincipal.Content = new TeacherReport();//report
                    break;
                case 8:
                    GridPrincipal.Content = new TeacherRole();//role
                    break;
                default:
                    break;
            }
        }

       

        private void MoveCursorMenu(int index)
        {
            GridCursor.Margin = new Thickness(0, (100 + (60 * index)), 0, 0);
        }
    }
}
