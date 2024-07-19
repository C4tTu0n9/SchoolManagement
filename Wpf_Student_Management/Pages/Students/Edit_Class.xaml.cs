using Microsoft.EntityFrameworkCore;
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
using Wpf_Student_Management.Model;
using Wpf_Student_Management.Pages.Classes;
using Wpf_Student_Management.Pages.Subjects;

namespace Wpf_Student_Management.Pages.Students
{
    /// <summary>
    /// Interaction logic for Edi_Class.xaml
    /// </summary>
    public partial class Edit_Class : Window
    {
        private readonly Student _student;
        public Edit_Class(Student student)
        {
            _student = student;
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                var data = context.StudentClasses
                    .Include(sc => sc.Class)  // Include the related Class entity
                    .Select(sc => new StudentClassViewModel
                    {
                        StudentId = sc.StudentId,
                        ClassId = sc.ClassId,
                        ClassName = sc.Class.Name  // Access the class name directly from navigation property
                    })
                    .Where(sc => sc.StudentId == _student.StudentId)
                    .ToList();

                editClassesGrid.ItemsSource = data;
            }
        }
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                if (button.Tag is string classId)
                {
                    MessageBoxResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (result == MessageBoxResult.Yes)
                    {
                        using (var context = new PRN212_Student_ManagementContext())
                        {
                            var studentClassToDelete = context.StudentClasses.FirstOrDefault(sc => sc.ClassId == classId);

                            if (studentClassToDelete != null)
                            {
                                context.StudentClasses.Remove(studentClassToDelete);
                                context.SaveChanges();

                                LoadData();
                            }
                            else
                            {
                                MessageBox.Show("Selected record not found in database.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid ClassId.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Form_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_StudentClass window = new Add_StudentClass(_student.StudentId);
            window.Closed += Form_Closed;
            window.Show();
            
        }

        
    }
}
