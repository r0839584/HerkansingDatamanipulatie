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
using Project_MAL_DAL;

namespace Project_MAL_WPF
{
    /// <summary>
    /// Interaction logic for MangaInfo_Window.xaml
    /// </summary>
    public partial class MangaInfo_Window : Window
    {
        public MangaInfo_Window()
        {
            InitializeComponent();
        }

        private void BtnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            AddCharacter_Window addCharacterWindow = new AddCharacter_Window();
            addCharacterWindow.Show();
        }

        private void BtnExtraInfo_Click(object sender, RoutedEventArgs e)
        {
            CharacterInfo_Window characterInfoWindow = new CharacterInfo_Window();
            characterInfoWindow.Show();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Manga manga = DatabaseOperations.OphalenMangaAuthorViaId();
            datagridCharacters.ItemsSource = manga.Characters;

            string url = "MangaImages/" + manga.name + ".jpg";
            imgManga.Source = new BitmapImage(new Uri(url, UriKind.Relative));
        }
    }
}
