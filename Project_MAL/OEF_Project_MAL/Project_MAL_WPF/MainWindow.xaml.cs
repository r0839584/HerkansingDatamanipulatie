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
using Project_MAL_DAL;

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
            this.Close();
        }

        private void BtnExtraInfo_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Manga");

            if (datagridMangaCollection.SelectedItem is Manga manga)
            {
                HelperClass.mangaId = manga.mangaId;

                MangaInfo_Window mangaInfoWindow = new MangaInfo_Window();
                mangaInfoWindow.Show();
            }
            else
            {
                MessageBox.Show(foutmelding, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            datagridMangaCollection.ItemsSource = DatabaseOperations.OphalenMangaCollections();
        }

        private void BtnDeleteManga_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("Manga");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Manga manga = datagridMangaCollection.SelectedItem as Manga;

                int ok = DatabaseOperations.VerwijderenManga(manga);


                // een manga deleten werkt nog niet helemaal
                if (ok > 0)
                {
                    datagridMangaCollection.ItemsSource = DatabaseOperations.OphalenMangaCollections();
                }
                else
                {
                    MessageBox.Show("Manga is not deleted!");
                }
            }
            else
            {
                MessageBox.Show(foutmelding, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public string Valideer(string columnName)
        {
            if (columnName == "Manga" && datagridMangaCollection.SelectedItem == null)
            {
                return "Select a manga!" + Environment.NewLine;
            }
            return "";
        }
    }
}
