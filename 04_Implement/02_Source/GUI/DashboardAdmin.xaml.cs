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
    /// Interaction logic for DashboardAdmin.xaml
    /// </summary>
    public partial class DashboardAdmin : Window
    {
        public DashboardAdmin()
        {
          
            InitializeComponent();
            fullname_title.Content = Global.Admin.Name;
            class_title.Content = Global.Admin.Type;
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
           this.WindowState = WindowState.Minimized;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                    GridPrincipal.Content = new AdminMyInformation();
                    break;
                case 1:
                    GridPrincipal.Content = new AdminCreateUser();
                    break;
                case 2:
                    GridPrincipal.Content = new AdminManageUser();
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
