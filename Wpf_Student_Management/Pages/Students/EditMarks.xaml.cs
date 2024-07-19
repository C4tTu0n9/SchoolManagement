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
    /// Interaction logic for EditMarks.xaml
    /// </summary>
    public partial class EditMarks : Window
    {
        private readonly Student _student;
        public EditMarks(Student student)
        {
            _student = student;
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

                // Data grid
                editMarksGrid.ItemsSource = context.Marks.Where(x => x.StudentId == _student.StudentId).ToList();
            }
        }

        private void subjectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Ensure the selection is not null
            if (subjectComboBox.SelectedValue != null)
            {
                // Get the selected SubjectId
                var selectedSubjectId = subjectComboBox.SelectedValue.ToString();

                using (var context = new PRN212_Student_ManagementContext())
                {
                    // Find the subject based on the selected SubjectId
                    editMarksGrid.ItemsSource = context.Marks.Where(m => m.SubjectId == selectedSubjectId && m.StudentId == _student.StudentId).ToList();
                }
            }
        }
        private void Form_Mark_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }
        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Attempt to convert button.Tag to an int
                if (button.Tag is int markId)
                {
                    // Use markId as needed
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        var mark = context.Marks.FirstOrDefault(m => m.MarkId == markId);
                        if (mark != null)
                        {
                            // Show the update mark window
                            Update_Mark updateWindow = new Update_Mark(mark);

                            updateWindow.Closed += Form_Mark_Closed; // Reload data when update window is closed
                            updateWindow.Show();
                        }
                        else
                        {
                            MessageBox.Show($"Mark with ID {markId} not found.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid MarkId.");
                }
            }
        }


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null)
            {
                // Attempt to convert button.Tag to an int
                if (button.Tag is int markId)
                {
                    // Use markId to find the mark entity
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        var mark = context.Marks.FirstOrDefault(m => m.MarkId == markId);
                        if (mark != null)
                        {
                            // Remove mark from the context and save changes
                            context.Marks.Remove(mark);
                            context.SaveChanges();

                            // Optionally, notify the user or perform any additional actions
                            MessageBox.Show($"Mark has been deleted.");
                            LoadData();
                        }
                        else
                        {
                            MessageBox.Show($"Mark not found.");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid MarkId.");
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_Mark window = new Add_Mark(_student.StudentId);
            window.Closed += Form_Mark_Closed;
            window.Show();
        }
    }
}
