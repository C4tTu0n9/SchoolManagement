using Repository.Models;
using System;
using System.CodeDom;
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
    /// Interaction logic for Assign_Student.xaml
    /// </summary>
    public partial class Assign_Student : Window
    {
        private string _classId;
        public Assign_Student(string classId)
        {
            _classId = classId;
            InitializeComponent();
        }

        private void FindButton_Click(object sender, RoutedEventArgs e)
        {
            string studentId = txtStudentId.Text;
            try
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    Student student = context.Students.Where(st => st.StudentId == studentId.Trim()).Single();
                    if (student != null)
                    {
                        lblStudentName.Content = student.FirstName + " " + student.LastName;
                    }
                    else
                    {
                        lblStudentName.Content = "Not Found";
                    }
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Cannot find Student");
            }
        }

        private void AssignButton_Click(object sender, RoutedEventArgs e)
        {
            string studentId = txtStudentId.Text;
            try
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    Student student = (Student)context.Students.Where(st => st.StudentId == studentId.Trim()).Single();
                    if (student != null)
                    {
                        StudentClass studentClass = new StudentClass();
                        studentClass.StudentId = studentId;
                        studentClass.ClassId = _classId;
                        context.StudentClasses.Add(studentClass);
                        context.SaveChanges();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Cannot find student.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot add student.");
            }
        }
    }
}
