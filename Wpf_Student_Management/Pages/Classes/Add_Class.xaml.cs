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
    /// Interaction logic for Add_Class.xaml
    /// </summary>
    public partial class Add_Class : Window
    {
        public Add_Class()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string classId = txtClassId.Text;
            string name = txtClassName.Text;

            if (string.IsNullOrEmpty(classId) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (classId.Length > 6 )
            {
                MessageBox.Show("Class Id must be less than 6 letters.");
                return;
            }
            else if (name.Length > 128)
            {
                MessageBox.Show("Class name must be less than 128 letters.");
                return;
            }
            else
            {
                try
                {
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        Class newClass = new()
                        {
                            ClassId = classId,
                            Name = name,
                        };

                        context.Classes.Add(newClass);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Class added successfully!");
                    this.Close();

                }
                catch (Exception ex) {
                    MessageBox.Show("Cannot added class!");
                }

            }
        }

    }
}
