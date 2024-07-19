using Repository.Models;
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

namespace Wpf_Student_Management.Pages.Classes
{
    /// <summary>
    /// Interaction logic for Update_Class.xaml
    /// </summary>
    public partial class Update_Class : Window
    {
        private Class _class;

        public Update_Class(Class c = null)
        {
            InitializeComponent();

            if (c != null)
            {
                _class = c;
                txtClassName.Text = c.Name;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string className = txtClassName.Text;

            if ( string.IsNullOrEmpty(className) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (className.Length > 128)
            {
                MessageBox.Show("Class name must be less than 128 letters.");
                return;
            }
            else
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    _class.Name = className;

                    context.Classes.Update(_class);
                    context.SaveChanges();
                }

                MessageBox.Show("Class updated successfully!");
            }
            this.Close();
        }

    }
}
