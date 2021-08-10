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
            string foutmelding = Valideer("Character");

            if (datagridCharacters.SelectedItem is Character character)
            {
                HelperClass.characterId = character.characterId;

                CharacterInfo_Window characterInfoWindow = new CharacterInfo_Window();
                characterInfoWindow.Show();
            }
            else
            {
                MessageBox.Show(foutmelding, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Manga manga = DatabaseOperations.OphalenMangaAuthorViaId();
            datagridCharacters.ItemsSource = manga.Characters;
            // List voor genre nog achter vragen

            string url = "MangaImages/" + manga.name + ".jpg";
            imgManga.Source = new BitmapImage(new Uri(url, UriKind.Relative));

            lblNameManga.Content = manga.name;
            lblChapters.Content = manga.chapters;
            lblAuthor.Content = manga.Author.name + " " + manga.Author.lastname;


        }

        private void BtnDeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            // nog testen

            string foutmelding = Valideer("Character");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                Character character = datagridCharacters.SelectedItem as Character;
                int ok = DatabaseOperations.VerwijderenCharacter(character);

                if (ok > 0)
                {
                    datagridCharacters.ItemsSource = DatabaseOperations.OphalenMangaCollections();
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
            if (columnName == "Character" && datagridCharacters.SelectedItem == null)
            {
                return "Select a Character!" + Environment.NewLine;
            }
            return "";
        }
    }
}
