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
    /// Interaction logic for Add_Subject.xaml
    /// </summary>
    public partial class Add_Subject : Window
    {
        public Add_Subject()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string subjectId = txtSubjectId.Text;
            string subjectTitle = txtSubjectTitle.Text;

            if (string.IsNullOrEmpty(subjectId) || string.IsNullOrEmpty(subjectTitle) )
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }
            else if (subjectId.Length > 7 )
            {
                MessageBox.Show("Subject must be less than 7 letters.");
                return;
            }
            else if (subjectTitle.Length > 128)
            {
                MessageBox.Show("Title must be less than 128 letters.");
                return;
            }
            else
            {
                try
                {
                    using (var context = new PRN212_Student_ManagementContext())
                    {
                        Subject newSubject = new()
                        {
                            SubjectId = subjectId,
                            Title = subjectTitle
                        };

                        context.Subjects.Add(newSubject);
                        context.SaveChanges();
                    }

                    MessageBox.Show("Subject added successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot added Subject!");
                }
            }
            this.Close();
        }
    }
}
