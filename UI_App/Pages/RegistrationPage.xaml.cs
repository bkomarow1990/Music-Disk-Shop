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

namespace UI_App.Pages
{
    /// <summary>
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        IUserService userService = new UserService();
        public RegistrationPage()
        {
            InitializeComponent();
        }
        void Registration()
        {
            if(txtLogin.Text != userService.GetLogin().ToString())
            {
                if(txtLogin.Text.Length > 4 && txtPassword.Text.Length > 8)
                {
                    userService.Add(new User() { Login = txtLogin.Text, Password = txtPassword.Text, Email = txtEmail.Text });
                }
                else
                {
                    throw new Exception("Error with length, Maybe user send null!");
                }
            }
            else
            {
                throw new Exception("User already exists!");
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            Registration();
        }
    }
}
