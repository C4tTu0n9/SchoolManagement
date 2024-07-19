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

namespace Wpf_Student_Management.Pages.Students
{
    /// <summary>
    /// Interaction logic for Add_Students.xaml
    /// </summary>
    public partial class Add_Students : Window
    {
        public Add_Students()
        {
            InitializeComponent();
        }

        private String CreateStudentId()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                var lastStudent = context.Students
                                  .OrderByDescending(s => s.StudentId)
                                  .FirstOrDefault();
                string newId;
                if (lastStudent != null)
                {
                    int lastIdNumber = int.Parse(lastStudent.StudentId.Substring(2));
                    int newIdNumber = lastIdNumber + 1;
                    newId = $"HE{newIdNumber:D4}";
                }
                else
                {
                    newId = "HE0001";
                }
                return newId;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || !dateOfBirth.HasValue)
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (firstName.Length > 128 || lastName.Length > 128)
            {
                MessageBox.Show("First and last name must be less than 128 letters.");
                return;
            }
            else
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    string newStudentId = CreateStudentId();
                    Student newStudent = new()
                    {
                        StudentId = newStudentId,
                        FirstName = firstName,
                        LastName = lastName,
                        Dob = dateOfBirth.Value
                    };
                    context.Students.Add(newStudent);
                    context.SaveChanges();
                }
                MessageBox.Show("Student added successfully!");
            }
            this.Close();
        }

    }
}
