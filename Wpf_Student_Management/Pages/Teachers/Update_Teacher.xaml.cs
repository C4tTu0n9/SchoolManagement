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

namespace Wpf_Student_Management.Pages.Teachers
{
    /// <summary>
    /// Interaction logic for Update_Teacher.xaml
    /// </summary>
    public partial class Update_Teacher : Window
    {
        private Teacher _teacher;

        public Update_Teacher(Teacher? teacher = null)
        {
            InitializeComponent();

            if (teacher != null)
            {
                _teacher = teacher;
                txtFirstName.Text = teacher.FirstName;
                txtLastName.Text = teacher.LastName;
                dpDateOfBirth.SelectedDate = teacher.Dob;
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
            else if (dateOfBirth.Value < eighteenYearsAgo)
            {
                MessageBox.Show("Teacher must be 18 years old or older.");
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
                        Teacher newTeacher = new()
                    {
                        TeacherId = _teacher.TeacherId,
                        FirstName = firstName,
                        LastName = lastName,
                        Dob = dateOfBirth.Value // Assuming you have a DateOfBirth property
                    };

                    context.Teachers.Update(newTeacher);
                    context.SaveChanges();
                }

                MessageBox.Show("Student updated successfully!");
            }
            this.Close();
        }

    }
}
