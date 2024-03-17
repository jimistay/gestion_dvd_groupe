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

namespace Location_DVD
{
    /// <summary>
    /// Logique d'interaction pour DVDAjouterView.xaml
    /// </summary>
    public partial class DVDAjouterView : Page
    {
        public DVDAjouterView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
            if (title.Text.Length > 50 || realisateur.Text.Length > 50 || genre.Text.Length > 50) 
            {
                MessageBox.Show("Le genre, le titre et le réalisateur ne doit pas contenir plus de 50 caractères");
            }
            else 
            {
                if (date.Text.Length != 4 || !int.TryParse(date.Text, out _))
                {
                    MessageBox.Show("La date doit être composé de 4 nombres (2004)");
                }
                else 
                {
                    if (DVDViewModel.AddDVD(title.Text, realisateur.Text, genre.Text, date.Text, disponibility))
                    {
                        MessageBox.Show("Ajout effectué");
                    }
                    else
                    {
                        MessageBox.Show("Une erreur de la base de données");
                    }
                }
            }

        }
    }
}
