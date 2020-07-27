using QuanLyDeThi.Views;
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
using QuanLyDeThi.Models;
using QuanLyDeThi.Utils;

namespace QuanLyDeThi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginWindow login;
        public MainWindow()
        {
            InitializeComponent();
            login = new LoginWindow();
            this.Hide();
            login.OnLoginDone += Login_OnLoginDone;
            login.ShowDialog();
            login = null;
        }

        private void Login_OnLoginDone(bool active,User theUser)
        {
            if (active) {
                AppDataConfig.Instance.userData = theUser;
                this.Show();
            }
            else
                Application.Current.Shutdown();
        }

        private void OnExamClicked(object sender,EventArgs e)
        {
            LessonWindow temp = new LessonWindow();
            temp.ShowDialog();
        }
        private void OnResultClicked(object sender, EventArgs e)
        {

        }
        private void OnLogoutClicked(object sender, EventArgs e)
        {
            login = new LoginWindow();
            this.Hide();
            login.OnLoginDone += Login_OnLoginDone;
            login.ShowDialog();
        }
    }
}
