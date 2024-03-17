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
using System.Windows.Navigation;


namespace Location_DVD
{
    /// <summary>
    /// Logique d'interaction pour DVDModifiePage2View.xaml
    /// </summary>
    public partial class DVDModifiePage2View : Page
    {
        // DVDId, selectedDVD.Title, selectedDVD.Director, selectedDVD.Genre, selectedDVD.ReleaseYear, selectedDVD.IsAvailable
        public int DVDId { get; set; }
        public DVDModifiePage2View(int id, string title, string director, string genre, string realeaseYear, string isAvailable)
        {
            InitializeComponent();
            DVDId = id;
            Titre.Text = title;
            Realisateur.Text = director;
            Genre.Text = genre;


            Date.Text = realeaseYear;
            if(isAvailable == "1")
            {
                dispo.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string title = Titre.Text;
            string director = Realisateur.Text;
            string genre = Genre.Text;
            string releaseYear = Date.Text;



            if (title.Length > 50 || director.Length > 50 || genre.Length > 50) 
            {
                MessageBox.Show("Le titre, le genre et le réalisateur ne doit pas dépasser 50 caractères.");
            }
            else
            {
                if (releaseYear.Length != 4 || !int.TryParse(releaseYear, out _))
                {
                    MessageBox.Show("La date doit être composé de 4 nombres (2004)");
                }
                else
                {
                    string disponibility;
                    if ((bool)dispo.IsChecked)
                    {
                        disponibility = "1";
                    }
                    else
                    {
                        disponibility = "0";
                    }
                    if (DVDViewModel.UpdateDVD(DVDId, title, director, genre, releaseYear, disponibility))
                    {
                        MessageBox.Show("Modification effectuée");
                    }
                }
            }


           
        }
    }
}
