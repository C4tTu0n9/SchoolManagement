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
using DTO;
using BUS;
using System.Text.RegularExpressions;

namespace GUI
{
    /// <summary>
    /// Interaction logic for test2.xaml
    /// </summary>
    public sealed partial class TeacherRole : Page
    {
        string tempMinage = "";
        string tempMaxage = "";
        string tempTotal = "";
        string tempPassScore = "";
        public TeacherRole()
        {

            InitializeComponent();
        }

        private void Window_Loaded_Role(object sender, RoutedEventArgs e)
        {
            minage.Text = AcademicAffairsOfficeBUS.getMinAge().ToString();
            maxage.Text = AcademicAffairsOfficeBUS.getMaxAge().ToString();
            passscore.Text = AcademicAffairsOfficeBUS.getPassScore().ToString();
            totalofclass.Text = AcademicAffairsOfficeBUS.getTotalStudent().ToString();
            totalofclass10.Text = totalofclass11.Text = totalofclass12.Text = "3";

            tempMinage = minage.Text;
            tempMaxage = maxage.Text;
            tempTotal = totalofclass.Text;
            tempPassScore = passscore.Text;

            nameclasses10.Text = "10A1, 10A2, 10A3";
            nameclasses11.Text = "11A1, 11A2, 11A3";
            nameclasses12.Text = "12A1, 12A2, 12A3";
            totalofsubject.Text = "10";
            namesubjects.Text = "Math, Literature, English, Biology, Technology, History, Geography, Information Technology, Civic Education, Defense Education";
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9.-]+");
            e.Handled = regex.IsMatch(e.Text);
        }



        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
           /* string tempMinage = minage.Text;
            string tempMaxage = maxage.Text;
            string tempTotal = totalofclass.Text;
            string tempPassScore = passscore.Text;*/

            btnDoneOfEdit.Visibility = Visibility.Visible;
            minage.IsReadOnly = false;
            maxage.IsReadOnly = false;
            passscore.IsReadOnly = false;
            totalofclass.IsReadOnly = false;
            btnCancel.Visibility = Visibility.Visible;
         
        }

        private void btnDoneofEdit_click(object sender, RoutedEventArgs e)
        {
            btnEdit.Visibility = Visibility.Visible;
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            minage.IsReadOnly = true;
            maxage.IsReadOnly = true;
            passscore.IsReadOnly = true;
            totalofclass.IsReadOnly = true;
            totalofclass10.IsReadOnly = true;
            totalofclass11.IsReadOnly = true;
            totalofclass12.IsReadOnly = true;
            totalofsubject.IsReadOnly = true;
            nameclasses10.IsReadOnly = true;
            nameclasses11.IsReadOnly = true;
            nameclasses12.IsReadOnly = true;
            namesubjects.IsReadOnly = true;
            btnCancel.Visibility = Visibility.Collapsed;


           /* string tempMinage = minage.Text;
            string tempMaxage = maxage.Text;
            string tempTotal = totalofclass.Text;
            string tempPassScore = passscore.Text;*/
            if (!AcademicAffairsOfficeBUS.updateRole(int.Parse(minage.Text), int.Parse(maxage.Text), double.Parse(passscore.Text), int.Parse(totalofclass.Text))) 
            {
                MessageBox.Show("Change role failed");
                minage.Text = tempMinage;
                maxage.Text = tempMaxage;
                totalofclass.Text = tempTotal;
                passscore.Text = tempPassScore;
            }
            else
            {
                MessageBox.Show("Change role successfully");
            }
        
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            btnDoneOfEdit.Visibility = Visibility.Collapsed;
            minage.IsReadOnly = true;
            maxage.IsReadOnly = true;
            passscore.IsReadOnly = true;
            totalofclass.IsReadOnly = true;
            btnCancel.Visibility = Visibility.Collapsed;
            btnEdit.Visibility = Visibility.Visible;
            Window_Loaded_Role(sender,e);
        }
    }
}
