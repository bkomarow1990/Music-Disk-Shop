using BLL.Services;
using DAL.Enties;
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

namespace Authorization_UI_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region property
        IUserService userService = new UserService();
        #endregion
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SignIn()
        {
            if(txtLogin.Text == userService.GetLogin().ToString())
            {
                if(txtPassword.Text == userService.GetPassword().ToString())
                {
                    MessageBox.Show("Welcome!");
                }
                else
                {
                    throw new Exception("Error password!");
                }
            }
            else
            {
                throw new Exception("Login failed!");
            }
        }

        private void Registration()
        {
            if (txtLogin.Text == userService.GetLogin().ToString())
            {
                MessageBox.Show("Account is alredy exists!");
                SignIn();
            }
            else if(txtLogin.Text != userService.GetLogin().ToString() && txtLogin.Text != null)
            {
                if(txtPassword.Text.Length > 8 && txtPassword != null)
                {
                    userService.Add(new User() { Login = txtLogin.Text, Password = txtPassword.Text });
                }
                else
                {
                    throw new Exception("Error with Password!");
                }
            }
            else
            {
                throw new Exception("Login failed!");
            }
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            //Registration();
        }
    }
}
