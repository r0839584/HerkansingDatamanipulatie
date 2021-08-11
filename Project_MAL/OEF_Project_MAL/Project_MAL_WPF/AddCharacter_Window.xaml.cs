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
    /// Interaction logic for AddCharacter_Window.xaml
    /// </summary>
    public partial class AddCharacter_Window : Window
    {
        public AddCharacter_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbManga.ItemsSource = DatabaseOperations.OphalenMangaCollections();
            cmbManga.DisplayMemberPath = "name";
        }

        private void BtnAddCharacter_Click(object sender, RoutedEventArgs e)
        {
            string foutmelding = Valideer("txtCharacterName");
            foutmelding += Valideer("txtCharacterLastame");
            foutmelding += Valideer("txtAppearance");
            foutmelding += Valideer("txtAge");
            foutmelding += Valideer("txtBloodType");
            foutmelding += Valideer("txtHeight");
            foutmelding += Valideer("cmbManga");

            if (string.IsNullOrWhiteSpace(foutmelding))
            {
                if (int.TryParse(txtAge.Text, out int age) /* && int.TryParse(cmbManga.Text, out int manga) */)
                {

                    Character character = new Character();
                    character.name = txtCharacterName.Text;
                    character.lastname = txtCharacterLastame.Text;
                    character.appearance = txtAppearance.Text;
                    character.age = age;
                    character.bloodtype = txtBloodType.Text;
                    character.height = txtHeight.Text;
                    //character.mangaId = manga;

                    if (character.IsGeldig())
                    {
                        DatabaseOperations.ToevoegenCharacter(character);

                        MangaInfo_Window mangaInfoWindow = new MangaInfo_Window();
                        mangaInfoWindow.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show(character.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show(foutmelding, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private string Valideer(string columnName)
        {
            if (columnName == nameof(txtCharacterName) && string.IsNullOrWhiteSpace(txtCharacterName.Text))
            {
                return "Character needs to have a name!" + Environment.NewLine;
            }
            if (columnName == nameof(txtCharacterLastame) && string.IsNullOrWhiteSpace(txtCharacterLastame.Text))
            {
                return "Character needs to have a lastname!" + Environment.NewLine;
            }
            if (columnName == nameof(txtAppearance) && string.IsNullOrWhiteSpace(txtAppearance.Text))
            {
                return "Character needs to have a first appearance!" + Environment.NewLine;
            }
            if (columnName == nameof(txtAge) && int.TryParse(txtAge.Text, out int age) == false)
            {
                return "Character needs to have an age!" + Environment.NewLine;
            }
            if (columnName == nameof(txtBloodType) && string.IsNullOrWhiteSpace(txtBloodType.Text))
            {
                return "Character needs to have a blood type!" + Environment.NewLine;
            }
            if (columnName == nameof(txtHeight) && string.IsNullOrWhiteSpace(txtHeight.Text))
            {
                return "Character needs to have a Height!" + Environment.NewLine;
            }
            //if (columnName == nameof(cmbManga) && cmbManga.SelectedItem == null)
            //{
            //    return "The manga needs to have a manga!" + Environment.NewLine;
            //}
            return "";
        }
    }
}
