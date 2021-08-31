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
    /// Interaction logic for CharacterInfo_Window.xaml
    /// </summary>
    public partial class CharacterInfo_Window : Window
    {
        public CharacterInfo_Window()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Character character = DatabaseOperations.OphalenMangaCharacters();

            lblName.Content = character.name + " " + character.lastname;
            lblAppearance.Content = character.appearance;
            lblAge.Content = character.age;
            lblBloodType.Content = character.bloodtype.PadLeft(1);
            lblHeight.Content = character.height.PadLeft(7);

            string url = "CharactersImages/" + character.name + ".jpg";
            imgCharacter.Source = new BitmapImage(new Uri(url, UriKind.Relative));
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
