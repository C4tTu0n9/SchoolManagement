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
using System.Windows.Threading;
using BUS;
namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //string userAdmin = "admin"; //test UI/UX
        //string passAdmin = "";
        string userLogIn, passLogIn = "";
        private DispatcherTimer dispatcherTimer;
        private DispatcherTimer dispatcherTimerForTip;
       
        public MainWindow()
        {
            //Thời gian báo lỗi khi nhập user hoặc pass
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 2);

            //Thời gian của notification hello
            dispatcherTimerForTip = new DispatcherTimer();
            dispatcherTimerForTip.Tick += new EventHandler(dispatcherTimerForTip_Tick);
            dispatcherTimerForTip.Interval = new TimeSpan(0, 0, 4);
            dispatcherTimerForTip.Start();

            InitializeComponent();
            List<string> listSchoolYear = AcademicAffairsOfficeBUS.loadListSchoolYearToComboBox();
            Global.schoolYear = AcademicAffairsOfficeBUS.getCurrentSchoolYear(listSchoolYear);
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            userLogIn = txtbUsername.Text;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TitleBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void btnMini_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {

            passLogIn = passbPassword.Password;
           /* if (userLogIn == null || userLogIn != userAdmin)
            {
                lblErrorMessage_1.Content = "The username that you've entered" + "\n" + "doesn't match any account.";
                lblErrorMessage_1.Visibility = Visibility.Visible;
                uiErrorSp_1.Visibility = Visibility.Visible;

                dispatcherTimer.Start();
            }
            else if (passLogIn != passAdmin)
            {
                lblErrorMessage_2.Content = "The password that you've entered" + "\n" + "is incorrect.";
                lblErrorMessage_2.Visibility = Visibility.Visible;
                uiErrorSp_2.Visibility = Visibility.Visible;
                dispatcherTimer.Start();

            }else if (rb_tc.IsChecked==false&&rb_st.IsChecked==false&&rb_ad.IsChecked==false)
            {
                lblErrorMessage_3.Content = "You must choose a authorities.";
                lblErrorMessage_3.Visibility = Visibility.Visible;
                uiErrorSp_3.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
            else if (userLogIn == userAdmin & passLogIn == passAdmin & rb_st.IsChecked==true)
            {
                var window = new DashboardStudent();
                window.Show();
                this.Close();
            }
            else if (userLogIn == userAdmin & passLogIn == passAdmin & rb_tc.IsChecked == true)
            {
                var window = new DashboardTeacher();
                window.Show();
                this.Close();
            }
            else if (userLogIn == userAdmin & passLogIn == passAdmin & rb_ad.IsChecked == true)
            {
                var window = new DashboardAdmin();
                window.Show();
                this.Close();
            }*/

            
            if (rb_tc.IsChecked == false && rb_st.IsChecked == false && rb_ad.IsChecked == false)
            {
                lblErrorMessage_3.Content = "You must choose a authorities.";
                lblErrorMessage_3.Visibility = Visibility.Visible;
                uiErrorSp_3.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
            else if (rb_tc.IsChecked == true)
            {
                if (TeacherBUS.Login(userLogIn, passLogIn) != null)
                {
                    var window = new DashboardTeacher();
                    window.Show();
                    this.Close();
                }
                else
                {
                    lblErrorMessage_1.Content = "The username that you've entered" + "\n" + "doesn't match any account.";
                    lblErrorMessage_1.Visibility = Visibility.Visible;
                    uiErrorSp_1.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                    lblErrorMessage_2.Content = "The password that you've entered" + "\n" + "is incorrect.";
                    lblErrorMessage_2.Visibility = Visibility.Visible;
                    uiErrorSp_2.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
            else if (rb_ad.IsChecked == true)
            {
                if (AdminBUS.Login(userLogIn, passLogIn) != null)
                {
                    var window = new DashboardAdmin();
                    window.Show();
                    this.Close();
                }
                else
                {
                    lblErrorMessage_1.Content = "The username that you've entered" + "\n" + "doesn't match any account.";
                    lblErrorMessage_1.Visibility = Visibility.Visible;
                    uiErrorSp_1.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                    lblErrorMessage_2.Content = "The password that you've entered" + "\n" + "is incorrect.";
                    lblErrorMessage_2.Visibility = Visibility.Visible;
                    uiErrorSp_2.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
            else if (rb_st.IsChecked == true)
            {
                if (StudentBUS.Login(userLogIn, passLogIn) != null)
                {
                    var window = new DashboardStudent();
                    window.Show();
                    this.Close();
                }
                else
                {
                    lblErrorMessage_1.Content = "The username that you've entered" + "\n" + "doesn't match any account.";
                    lblErrorMessage_1.Visibility = Visibility.Visible;
                    uiErrorSp_1.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                    lblErrorMessage_2.Content = "The password that you've entered" + "\n" + "is incorrect.";
                    lblErrorMessage_2.Visibility = Visibility.Visible;
                    uiErrorSp_2.Visibility = Visibility.Visible;
                    dispatcherTimer.Start();
                }
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            lblErrorMessage_1.Visibility = Visibility.Collapsed;
            uiErrorSp_1.Visibility = Visibility.Collapsed;   
            lblErrorMessage_2.Visibility = Visibility.Collapsed;
            uiErrorSp_2.Visibility = Visibility.Collapsed;
            lblErrorMessage_3.Visibility = Visibility.Collapsed;
            uiErrorSp_3.Visibility = Visibility.Collapsed;
            dispatcherTimer.IsEnabled = false;
        }

        private void dispatcherTimerForTip_Tick(object sender, EventArgs e)
        {
            lblTip.Visibility = Visibility.Collapsed;
            uiTipSp.Visibility = Visibility.Collapsed;
            borderTip.Visibility = Visibility.Collapsed;
        }
    }
}
