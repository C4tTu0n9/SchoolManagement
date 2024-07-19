using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
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
    /// Interaction logic for Add_Teacher.xaml
    /// </summary>
    public partial class Add_Teacher : Window
    {
        public Add_Teacher()
        {
            InitializeComponent();
        }
        private String CreateTeacherId()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                var lastStudent = context.Teachers
                                  .OrderByDescending(s => s.TeacherId)
                                  .FirstOrDefault();
                string newId;

                if (lastStudent != null)
                {
                    int lastIdNumber = int.Parse(lastStudent.TeacherId.Substring(1));
                    int newIdNumber = lastIdNumber + 1;

                    newId = $"T{newIdNumber:D2}";
                }
                else
                {
                    // If there are no students, start with T01
                    newId = "T01";
                }

                return newId;
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
            else if (dateOfBirth.Value > eighteenYearsAgo)
            {
                MessageBox.Show("Teacher must be 18 years old or older.");
                return;
            }
            else
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    string newTeacherId = CreateTeacherId();
                    Teacher newTeacher = new()
                    {
                        TeacherId = newTeacherId,
                        FirstName = firstName,
                        LastName = lastName,
                        Dob = dateOfBirth.Value
                    };
                    context.Teachers.Add(newTeacher);
                    context.SaveChanges();
                }
                MessageBox.Show("Teacher added successfully!");
            }
            this.Close();
        }

    }
}
