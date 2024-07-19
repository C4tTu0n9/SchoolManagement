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
    /// Interaction logic for Add_SubjectTeacher.xaml
    /// </summary>
    public partial class Add_SubjectTeacher : Window
    {
        private readonly string _teachertId;
        public Add_SubjectTeacher(String teachertId)
        {
            _teachertId = teachertId;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                var subjects = context.Subjects.ToList();
                subjectComboBox.ItemsSource = subjects;

                var classes = context.Classes.ToList();
                classComboBox.ItemsSource = classes;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get selected SubjectId from ComboBox
            string selectedSubjectId = subjectComboBox.SelectedValue as string;
            string selectedClassId = classComboBox.SelectedValue as string;

            if (string.IsNullOrEmpty(selectedSubjectId) || string.IsNullOrEmpty(selectedClassId))
            {
                MessageBox.Show("Please select all.");
                return;
            }

            // Create a new mark entity
            SubjectTeacher newSubjectTeacher= new ()
            {
                TeacherId = _teachertId,
                ClassId = selectedClassId,
                SubjectId = selectedSubjectId
            };

            try {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    context.SubjectTeachers.Add(newSubjectTeacher);
                    context.SaveChanges();
                }
                MessageBox.Show("Assign successfully.");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Cannot add teacher to class and subject");
                return;
            }
        }
    }
}
