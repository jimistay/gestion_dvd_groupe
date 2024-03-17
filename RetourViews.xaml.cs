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

namespace Location_DVD
{
    /// <summary>
    /// Logique d'interaction pour RetourViews.xaml
    /// </summary>
    public partial class RetourViews : Window
    {
        public RetourViews()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RetourAfficherView();
            MainTitle.Content = "Afficher les retours";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new RetourEnregView();
            MainTitle.Content = "Ajouter un retour";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Main.Content = new RetourModifierView();
            MainTitle.Content = "Modifier un retour";
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new RetourSupprimerView();
            MainTitle.Content = "Supprimer un retour";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}