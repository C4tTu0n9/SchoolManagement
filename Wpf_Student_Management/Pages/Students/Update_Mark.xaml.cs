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
    /// Interaction logic for Update_Mark.xaml
    /// </summary>
    public partial class Update_Mark : Window
    {
        private readonly Mark _mark;
        public Update_Mark(Mark mark)
        {
            InitializeComponent();
            _mark = mark;
        }

       


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string newMark = txtNewMark.Text.Trim(); // Assuming txtNewMark is a TextBox

            // Check if newMark is an integer
            if (int.TryParse(newMark, out int mark))
            {
                using(var context = new PRN212_Student_ManagementContext())
                {
                    _mark.Mark1 = mark;
                    _mark.Date = DateTime.Now;
                    context.Update(_mark);
                    context.SaveChanges();                    
                }
                MessageBox.Show($"Mark update successful");
                this.Close();
            }
            else
            {
                // newMark is not a valid integer
                MessageBox.Show("Please enter a valid integer for the new mark.");
            }
        }
    }
}
