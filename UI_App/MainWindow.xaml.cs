using BLL;
using BLL.Services;
using DAL;
using System;
using System.Windows;
using UI_App.Pages;

namespace UI_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadStartupPage();
        }
        private void LoadStartupPage()
        {
            Main.Content = new StartupPage();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new AdminPanelPage();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new DataInfoPage();
        }
    }
}
