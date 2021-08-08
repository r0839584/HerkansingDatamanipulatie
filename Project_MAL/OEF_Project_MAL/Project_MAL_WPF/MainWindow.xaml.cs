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

namespace Project_MAL_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnAddManga_Click(object sender, RoutedEventArgs e)
        {
            AddManga_Window addMangaWindow = new AddManga_Window();
            addMangaWindow.Show();
        }

        private void BtnExtraInfo_Click(object sender, RoutedEventArgs e)
        {
            MangaInfo_Window mangaInfoWindow = new MangaInfo_Window();
            mangaInfoWindow.Show();
        }
    }
}
