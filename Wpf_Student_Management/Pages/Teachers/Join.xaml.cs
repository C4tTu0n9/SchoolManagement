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
using Wpf_Student_Management.Model;
using Wpf_Student_Management.Pages.Students;
using Wpf_Student_Management.Pages.Subjects;

namespace Wpf_Student_Management.Pages.Teachers
{
    /// <summary>
    /// Interaction logic for Join.xaml
    /// </summary>
    public partial class Join : Window
    {
        private readonly Teacher _teacher;
        public Join(Teacher teacher)
        {
            _teacher = teacher;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                // Data grid
                var data = context.SubjectTeachers.Select(st => new TeacherSubjectViewModel
                {
                    TeacherId = st.TeacherId,
                    SubjectId = st.SubjectId,
                    SubjectTitle = st.Subject.Title,
                    ClassId = st.ClassId,  
                    ClassName = st.Class.Name,
                })
                    .Where(st => st.TeacherId == _teacher.TeacherId)
                    .ToList();

                joinGrid.ItemsSource = data;
                
            }
        }

        private void Fomr_Closed(object sender, EventArgs e)
        {
            LoadData(); // Reload data when the Add_Students window is closed
        }
        


        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                var tuple = button.Tag as Tuple<object, object>;
                if (tuple != null)
                {
                    var classId = tuple.Item1.ToString();
                    var subjectId = tuple.Item2.ToString();
                    try
                    {
                        using (var context = new PRN212_Student_ManagementContext())
                        {
                            var subjectTeacher = context.SubjectTeachers
                                .FirstOrDefault(st => st.ClassId == classId && st.SubjectId == subjectId && st.TeacherId == _teacher.TeacherId);
                            if (subjectTeacher != null)
                            {
                                context.SubjectTeachers.Remove(subjectTeacher);
                                context.SaveChanges();
                            }
                            else
                            {
                                MessageBox.Show("SubjectTeacher not found.");
                            }
                        }
                    }
                    catch (Exception ex) {
                        MessageBox.Show("Cannot remove this record.");
                    }
                }
                else
                {
                    MessageBox.Show("Invalid data.");
                }
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Add_SubjectTeacher window = new Add_SubjectTeacher(_teacher.TeacherId);
            window.Closed += Fomr_Closed;
            window.Show();
        }
    }
}
