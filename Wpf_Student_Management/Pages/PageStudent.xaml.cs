using Microsoft.EntityFrameworkCore;
using Repository.Models;
using Repository.Services;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Student_Management.Pages.Students;

namespace Wpf_Student_Management.Page
{
    /// <summary>
    /// Interaction logic for PageStudent.xaml
    /// </summary>
    public partial class PageStudent : UserControl
    {
        public PageStudent()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                studentsGrid.ItemsSource = context.Students.ToList();
                classComboBox.ItemsSource = context.Classes.ToList();
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Add_Students page = new Add_Students();
            page.Closed += Form_Students_Closed; // Subscribe to the Closed event
            page.Show();
        }

        private void Form_Students_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var studentId = button.Tag as string;

            // Find the student by StudentId
            using (var context = new PRN212_Student_ManagementContext())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    // Show the update student window (implement this window similarly to Add_Students)
                    Update_Student updateWindow = new Update_Student(student);
                        
                    updateWindow.Closed += Form_Students_Closed; // Reload data when update window is closed
                    updateWindow.Show();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the StudentId from the button's Tag property
            var button = sender as Button;
            var studentId = button.Tag as string;

            // Confirm delete
            if (MessageBox.Show("Are you sure you want to delete this student?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
                        if (student != null)
                        {
                            context.Students.Remove(student);
                            context.SaveChanges();
                            LoadData(); // Reload data after deletion
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Cannot remove student");
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchLastname = txtSearchValue.Text;
            using (var context = new PRN212_Student_ManagementContext())
            {
                studentsGrid.ItemsSource = context.Students
                    .Where(s => s.LastName.Contains(searchLastname))
                    .ToList();
            }

        }
        private void EditMarksButton_Click(Object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var studentId = button.Tag as string;

            // Find the student by StudentId
            using (var context = new PRN212_Student_ManagementContext())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    // Show the update student window (implement this window similarly to Add_Students)
                    EditMarks editMarks= new EditMarks(student);

                    editMarks.Closed += Form_Students_Closed; // Reload data when update window is closed
                    editMarks.Show();
                }
            }
        }

        private void EditClassesButton_Click(Object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var studentId = button.Tag as string;

            // Find the student by StudentId
            using (var context = new PRN212_Student_ManagementContext())
            {
                var student = context.Students.FirstOrDefault(s => s.StudentId == studentId);
                if (student != null)
                {
                    // Show the update student window (implement this window similarly to Add_Students)
                    Edit_Class window = new Edit_Class(student);

                    window.Closed += Form_Students_Closed; // Reload data when update window is closed
                    window.Show();
                }
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (classComboBox.SelectedValue != null)
            {
                // Get the selected SubjectId
                var classId = classComboBox.SelectedValue.ToString();

                using (var context = new PRN212_Student_ManagementContext())
                {
                    // Find the subject based on the selected SubjectId
                    studentsGrid.ItemsSource = context.StudentClasses.Where(sc => sc.ClassId == classId)
                        .Select(sc => sc.Student).ToList();
                }   
            }
        }
    }

}
