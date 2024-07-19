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
    /// Interaction logic for Add_StudentClass.xaml
    /// </summary>
    public partial class Add_StudentClass : Window
    {
        private readonly string _studentId;
        public Add_StudentClass(String studentId)
        {
            _studentId = studentId;
            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            using (var context = new PRN212_Student_ManagementContext())
            {
                // Lấy tất cả các lớp học
                var allClasses = context.Classes.ToList();

                // Lấy danh sách các lớp học mà học sinh hiện tại đã tham gia
                var studentClasses = context.StudentClasses
                    .Where(sc => sc.StudentId == _studentId)
                    .Select(sc => sc.ClassId)
                    .ToList();

                // Lọc ra các lớp học mà học sinh hiện tại chưa tham gia
                var availableClasses = allClasses
                    .Where(c => !studentClasses.Contains(c.ClassId))
                    .ToList();

                classComboBox.ItemsSource = availableClasses;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Get selected SubjectId from ComboBox
            string selectedClassId = classComboBox.SelectedValue as string;

            if ( string.IsNullOrEmpty(selectedClassId))
            {
                MessageBox.Show("Please select all.");
                return;
            }

            // Create a new mark entity
            StudentClass newStudentClass= new()
            {
                StudentId = _studentId,
                ClassId = selectedClassId,
            };

            // Save newMark to database using Entity Framework
            try
            {
                using (var context = new PRN212_Student_ManagementContext())
                {
                    // Kiểm tra xem học sinh đã được gán vào lớp này chưa
                    var existingAssignment = context.StudentClasses
                        .FirstOrDefault(sc => sc.StudentId == _studentId && sc.ClassId == selectedClassId);

                    if (existingAssignment != null)
                    {
                        MessageBox.Show("This student is already assigned to this class.");
                        return;
                    }

                    context.StudentClasses.Add(newStudentClass);
                    context.SaveChanges();
                }
                MessageBox.Show("Assign successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot assign student: " + ex.Message);
            }
            this.Close();
        }
    }
}
