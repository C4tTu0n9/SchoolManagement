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

namespace Wpf_Student_Management.Pages.Subjects
{
    /// <summary>
    /// Interaction logic for Update_Subject.xaml
    /// </summary>
    public partial class Update_Subject : Window
    {
        private Subject _subject;

        public Update_Subject(Subject? subject = null)
        {
            InitializeComponent();

            if (subject != null)
            {
                _subject = subject;
                txtSubjectTitle.Text = subject.Title;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string subjectTitle = txtSubjectTitle.Text;

            if (string.IsNullOrEmpty(subjectTitle))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (subjectTitle.Length > 128)
            {
                MessageBox.Show("Title must be less than 128 letters.");
                return;
            }
            else
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    Subject newSubject = new()
                    {
                        SubjectId = _subject.SubjectId,
                        Title = subjectTitle
                    };

                    context.Subjects.Update(newSubject);
                    context.SaveChanges();
                }

                MessageBox.Show("Student updated successfully!");
            }
            this.Close();
        }
    }
}
