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
    public partial class Update_Student : Window
    {
        private Student _student;

        public Update_Student(Student student = null)
        {
            InitializeComponent();

            if (student != null)
            {
                _student = student;
                txtFirstName.Text = student.FirstName;
                txtLastName.Text = student.LastName;
                dpDateOfBirth.SelectedDate = student.Dob;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;

            DateTime? dateOfBirth = dpDateOfBirth.SelectedDate;
            DateTime currentTime = DateTime.Now;
            DateTime eighteenYearsAgo = currentTime.AddYears(-18);

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
            else if (dateOfBirth.Value < eighteenYearsAgo)
            {
                MessageBox.Show("Student must be 18 years old or older.");
                return;
            }
            else
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    Student newStudent = new()
                    {
                        StudentId = _student.StudentId,
                        FirstName = firstName,
                        LastName = lastName,
                        Dob = dateOfBirth.Value // Assuming you have a DateOfBirth property
                    };

                    context.Students.Update(newStudent);
                    context.SaveChanges();
                }

                MessageBox.Show("Student updated successfully!");
            }
            this.Close();
        }

    }
}
