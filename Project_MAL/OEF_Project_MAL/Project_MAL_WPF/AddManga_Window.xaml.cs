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
    /// Interaction logic for AddManga_Window.xaml
    /// </summary>
    public partial class AddManga_Window : Window
    {
        public AddManga_Window()
        {
            InitializeComponent();
        }

        private void BtnAddManga_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtMangaName");
            foutmelding += Valideer("txtAuthor");
            foutmelding += Valideer("cmbGenre");
            foutmelding += Valideer("txtChapters");
            foutmelding += Valideer("txtMangaType");
            if (string.IsNullOrWhiteSpace(foutmelding))
            {

                if (int.TryParse(txtChapters.Text, out int chapters))
                {
                    Author author = cmbAuthor.SelectedItem as Author;
                    // nog uitzoeken hoe ik genre kan toevoegen.

                    //ICollection<Genre> genre = new List<Genre>();
                    //genre.Add(cmbGenre.SelectedItem as Genre);

                    Manga manga = new Manga();
                    manga.name = txtMangaName.Text;
                    manga.type = txtMangaType.Text;
                    manga.chapters = chapters;
                    manga.authorId = author.authorId;

                    if (manga.IsGeldig())
                    {
                        DatabaseOperations.ToevoegenManga(manga);

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(manga.Error);
                    }
                }

            }
            else
            {
                MessageBox.Show(foutmelding);
            }
        }

        private string Valideer(string columnName)
        {
            if (columnName == nameof(txtMangaName) && string.IsNullOrWhiteSpace(txtMangaName.Text))
            {
                return "The manga needs to have a name!" + Environment.NewLine;
            }
            if (columnName == nameof(cmbAuthor) && cmbAuthor.SelectedItem == null)
            {
                return "The manga needs to have an author!" + Environment.NewLine;
            }
            //if (columnName == nameof(cmbGenre) && cmbGenre.SelectedItem == null)
            //{
            //    return "The manga needs to have a genre!" + Environment.NewLine;
            //}
            if (columnName == nameof(txtChapters) && int.TryParse(txtChapters.Text, out int chapters) == false)
            {
                return "Chapters needs to be a number!" + Environment.NewLine;
            }
            if (columnName == nameof(txtMangaType) && string.IsNullOrWhiteSpace(txtMangaType.Text))
            {
                return "Your manga needs to have a type!";
            }
            return "";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbGenre.ItemsSource = DatabaseOperations.OphalenGenre();
            cmbGenre.DisplayMemberPath = "nameGenre";
            cmbAuthor.ItemsSource = DatabaseOperations.OphalenAuthor();
            cmbAuthor.DisplayMemberPath = "name";
        }
    }
}
