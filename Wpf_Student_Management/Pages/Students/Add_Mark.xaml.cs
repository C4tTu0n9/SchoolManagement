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
    /// Interaction logic for Add_Mark.xaml
    /// </summary>
    public partial class Add_Mark : Window
    {
        private readonly string _studentId;
        public Add_Mark(String studentId)
        {
            _studentId = studentId;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                // Combo box
                var subjects = context.Subjects.ToList();
                subjectComboBox.ItemsSource = subjects;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get selected SubjectId from ComboBox
            string selectedSubjectId = subjectComboBox.SelectedValue as string;

            if (string.IsNullOrEmpty(selectedSubjectId))
            {
                MessageBox.Show("Please select a subject.");
                return;
            }
            // Get mark value from TextBox
            if (!int.TryParse(txtNewMark.Text.Trim(), out int markValue))
            {
                MessageBox.Show("Please enter a valid integer for the mark.");
                return;
            }

            // Create a new mark entity
            Mark newMark = new Mark
            {
                StudentId = _studentId,
                SubjectId = selectedSubjectId,
                Date = DateTime.Now, // Set the date as needed
                Mark1 = markValue
            };

            // Save newMark to database using Entity Framework
            using (var context = new PRN212_Student_ManagementContext())
            {
                context.Marks.Add(newMark);
                context.SaveChanges();

                
            }
            MessageBox.Show("Mark added successfully.");
            this.Close();
        }
    }
}
