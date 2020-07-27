using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using QuanLyDeThi.Models;
using QuanLyDeThi.Utils;

namespace QuanLyDeThi.Views
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public  delegate void OnLoginDelegate(bool data,User theUser);
        public event OnLoginDelegate OnLoginDone;
        private bool isLogin = false;

        public LoginWindow()
        {
            InitializeComponent();
        }

        void Close_Window(object sender,CancelEventArgs e)
        {
            if (!isLogin)
            {
                if (OnLoginDone != null)
                    OnLoginDone.Invoke(false, null);
            }
        }

        public void OnRegister(object sender,EventArgs e)
        {
            User theUser = new User();
            theUser.UserName = txtUserName.Text.Trim();
            theUser.Password = Cryptography.MD5Hash(Cryptography.Encrypt(txtPassword.Password));
            theUser.IdRole = 1;
            theUser.DisplayName = "Administrator";
            theUser.CreateDate = DateTime.Now;
            theUser.ModifyDate = DateTime.Now;
            DataProvider.Instance.DB.Users.Add(theUser);
            DataProvider.Instance.DB.SaveChanges();
        }

        public void OnButtonLoginClicked(object sender, EventArgs e)
        {
            Login();
        }

        private void Login()
        {
            if (!CheckUserName(txtUserName.Text.Trim()))
            {
                return;
            }

            if (!CheckPassword(txtPassword.Password))
            {
                return;
            }
            string passwordBase64 = Cryptography.Encrypt(txtPassword.Password);
            string passwordMd5 = Cryptography.MD5Hash(passwordBase64);
            var user = DataProvider.Instance.DB.Users.Where(x => x.UserName.Equals(txtUserName.Text) && x.Password.Equals(passwordMd5)).FirstOrDefault();

            if (user == null)
            {
                // user not found
                txtError.Text = "Tên đăng nhập hoặc mật khẩu không đúng !";
                return;
            }
            isLogin = true;
            this.Close();
            if (OnLoginDone != null)
                OnLoginDone.Invoke(true, user);
        }

        private bool CheckUserName(string username)
        {
            Console.WriteLine(username);
            Regex usernameRegex0 = new Regex(@"^[\S]+$");
            Regex usernameRegex1 = new Regex(@"^[\w]+$");
            Regex usernameRegex2 = new Regex(@"^(\w{3,30})$");
            Regex usernameRegex3 = new Regex(@"^([A-z]+\w{2,14})$");

            if (string.IsNullOrEmpty(username))
            {
                Console.WriteLine("Tên đăng nhập không được để trống !");
                txtError.Text = "Tên đăng nhập không được để trống !";
                return false;
            }
            if (!usernameRegex0.IsMatch(username))
            {
                txtError.Text = "Tên đăng nhập không được có khoảng trắng !";
                return false;
            }
            if (!usernameRegex1.IsMatch(username))
            {
                txtError.Text = "Tên đăng nhập không được chứa ký tự đặc biệt !";
                return false;
            }
            if (!usernameRegex2.IsMatch(username))
            {
                txtError.Text = "Tên đăng nhập dài từ 3 đến 30 ký tự !";
                return false;
            }
            if (!usernameRegex3.IsMatch(username))
            {
                txtError.Text = "Tên đăng nhập không được bắt đầu bằng chữ số !";
                return false;
            }
            return true;
        }

        private bool CheckPassword(string password)
        {
            Regex passwordRegex2 = new Regex(@"^(\w{3,30})$");
            if (string.IsNullOrEmpty(password))
            {
                txtError.Text = "Mật khẩu không được để trống !";
                return false;
            }
            if (!passwordRegex2.IsMatch(password))
            {
                txtError.Text = "Mật khẩu dài từ 3 đến 30 ký tự !";
                return false;
            }
            return true;
        }

        private void BtnLogin_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Return)
            {
                Login();
            }
        }
    }
}
