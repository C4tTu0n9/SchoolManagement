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
using Wpf_Student_Management.Pages.Subjects;
using Wpf_Student_Management.Pages.Teachers;

namespace Wpf_Student_Management.Page
{
    /// <summary>
    /// Interaction logic for PageSubject.xaml
    /// </summary>
    public partial class PageSubject : UserControl
    {
        public PageSubject()
        {
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                var subjects = context.Subjects.Select(subject => new SubjectViewModel
                {
                    SubjectId = subject.SubjectId,
                    Title = subject.Title,
                    NumberOfStudents = context.StudentClasses
                                   .Where(sc => context.SubjectTeachers
                                           .Any(st => st.SubjectId == subject.SubjectId && st.ClassId == sc.ClassId))
                                   .Select(sc => sc.StudentId)
                                   .Distinct()
                                   .Count(),
                    NumberOfTeachers = context.SubjectTeachers
                                      .Where(st => st.SubjectId == subject.SubjectId)
                                      .Select(st => st.TeacherId)
                                      .Distinct()
                                      .Count(), 

                    NumberOfClasses = context.SubjectTeachers
                                     .Where(st => st.SubjectId == subject.SubjectId)
                                     .Select(st => st.ClassId)
                                     .Distinct()
                                     .Count()
                }).ToList();

                subjectsGrid.ItemsSource = subjects;
            }
        }

        private void Add_Btn_Click(object sender, RoutedEventArgs e)
        {
            Add_Subject page = new Add_Subject();
            page.Closed += Form_Subjects_Closed; // Subscribe to the Closed event
            page.Show();
        }

        private void Form_Subjects_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var subjectId = button.Tag as string;

            // Find the student by StudentId
            using (var context = new PRN212_Student_ManagementContext())
            {
                var subject = context.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);
                if (subject != null)
                {
                    // Show the update student window (implement this window similarly to Add_Students)
                    Update_Subject updateWindow = new Update_Subject(subject);

                    updateWindow.Closed += Form_Subjects_Closed; // Reload data when update window is closed
                    updateWindow.Show();
                }
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the StudentId from the button's Tag property
            var button = sender as Button;
            var subjectId = button.Tag as string;

            // Confirm delete
            if (MessageBox.Show("Are you sure you want to delete this subject?", "Confirm Delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                try
                {
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        var subject = context.Subjects.FirstOrDefault(s => s.SubjectId == subjectId);
                        if (subject != null)
                        {
                            context.Subjects.Remove(subject);
                            context.SaveChanges();
                            LoadData(); // Reload data after deletion
                        }
                    }
                }
                catch (Exception ex) {
                    MessageBox.Show("Cannot remove subject.");
                }
               
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            var searchTitle = txtSearchValue.Text;

            using (var context = new PRN212_Student_ManagementContext())
            {
                var subjects = context.Subjects
                    .Select(subject => new SubjectViewModel
                    {
                        SubjectId = subject.SubjectId,
                        Title = subject.Title,
                        NumberOfStudents = context.StudentClasses
                            .Where(sc => context.SubjectTeachers
                                .Any(st => st.SubjectId == subject.SubjectId && st.ClassId == sc.ClassId))
                            .Select(sc => sc.StudentId)
                            .Distinct()
                            .Count(),

                        NumberOfTeachers = context.SubjectTeachers
                            .Where(st => st.SubjectId == subject.SubjectId)
                            .Select(st => st.TeacherId)
                            .Distinct()
                            .Count(),

                        NumberOfClasses = context.SubjectTeachers
                            .Where(st => st.SubjectId == subject.SubjectId)
                            .Select(st => st.ClassId)
                            .Distinct()
                            .Count()
                    })
                    .Where(s => s.Title.Contains(searchTitle))
                    .ToList(); // Execute the query and fetch the results

                subjectsGrid.ItemsSource = subjects;
            }
        }

    }
}
