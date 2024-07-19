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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf_Student_Management.Pages.Students;
using Wpf_Student_Management.Pages.Teachers;

namespace Wpf_Student_Management.Page
{
    /// <summary>
    /// Interaction logic for PageTeacher.xaml
    /// </summary>
    public partial class PageTeacher : UserControl
    {
        public PageTeacher()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                teachersGrid.ItemsSource = context.Teachers.ToList();
                subjectComboBox.ItemsSource = context.Subjects.ToList();
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Add_Teacher page = new Add_Teacher();
            page.Closed += Form_Teachers_Closed; // Subscribe to the Closed event
            page.Show();
        }

        private void Form_Teachers_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var teacherId = button.Tag as string;

            // Find the student by StudentId
            using (var context = new PRN212_Student_ManagementContext())
            {
                var teacher = context.Teachers.FirstOrDefault(s => s.TeacherId == teacherId);
                if (teacher != null)
                {
                    // Show the update student window (implement this window similarly to Add_Students)
                    Update_Teacher updateWindow = new Update_Teacher(teacher);

                    updateWindow.Closed += Form_Teachers_Closed; // Reload data when update window is closed
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
                        var teacher = context.Teachers.FirstOrDefault(s => s.TeacherId == studentId);
                        if (teacher != null)
                        {
                            context.Teachers.Remove(teacher);
                            context.SaveChanges();
                            LoadData(); // Reload data after deletion
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Cannot remove teacher");
                }
                
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchLastname = txtSearchValue.Text;
            using (var context = new PRN212_Student_ManagementContext())
            {
                teachersGrid.ItemsSource = context.Teachers
                    .Where(t => t.LastName.Contains(searchLastname))
                    .ToList();
            }
        }

        public void JoinButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the StudentId from the button's Tag property
            var button = sender as Button;
            var studentId = button.Tag as string;

            // Confirm delete
            
                using (var context = new PRN212_Student_ManagementContext())
                {
                    var teacher = context.Teachers.FirstOrDefault(s => s.TeacherId == studentId);
                    if (teacher != null)
                    {
                        Join join = new Join(teacher);
                        join.Show();
                    }
                }
            
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (subjectComboBox.SelectedValue != null)
            {
                // Get the selected SubjectId
                var subjectId = subjectComboBox.SelectedValue.ToString();

                using (var context = new PRN212_Student_ManagementContext())
                {
                    // Find the subject based on the selected SubjectId
                    teachersGrid.ItemsSource = context.SubjectTeachers.Where(st => st.SubjectId == subjectId)
                        .Select(st => st.Teacher).ToList();
                }
            }
        }
    }
}
