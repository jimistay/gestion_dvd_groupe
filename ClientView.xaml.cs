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
    /// Logique d'interaction pour ClientView.xaml
    /// </summary>
    public partial class ClientView : Window
    {
        public ClientView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClientAjouterView();
            MainTitle.Content = "Ajouter un Client";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClientModifierView();
            MainTitle.Content = "Modifier un Client";
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClientAffichageView();
            MainTitle.Content = "Liste des clients";
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Main.Content = new ClientSupprimerView();
            MainTitle.Content = "Supprimer un Client";
        }
    }
}
