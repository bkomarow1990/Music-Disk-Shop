using BLL;
using DAL;
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

namespace UI_App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IAlbumService albumService = new AlbumService();
        public MainWindow()
        {
            InitializeComponent();

            LoadCountries();

            dataGrid.ItemsSource = albumService.GetAll();
            LoadComboBox();
            LoadAlbums();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(countryNameTB.Text))
            {
                albumService.AddCountry(countryNameTB.Text);
            }
        }

        void LoadCountries()
        {
            countryList.ItemsSource = albumService.GetCountries();
        }

        void LoadAlbums()
        {
            cbAlbums.ItemsSource = albumService.GetAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LoadCountries();
            LoadAlbums();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                albumService.Add(new Album
                {
                    Name = tbName.Text,
                    ArtishId = (int)cbArtishId.SelectedItem,
                    GanreId = (int)cbGanre.SelectedItem,
                    Year = (DateTime)dpYear.SelectedDate
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void LoadComboBox()
        {
            List<int> Id = new List<int> { 1, 2, 3 };
            cbArtishId.ItemsSource = Id;
            cbGanre.ItemsSource = Id;
        }
    }
}
