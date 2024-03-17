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
    /// Logique d'interaction pour Affichage.xaml
    /// </summary>
    public partial class ClientAffichageView : Page

    {
        ClientViewModel affichageModel;
        public ClientAffichageView()
        {
            InitializeComponent();
            affichageModel = new ClientViewModel();
            DataContext = affichageModel;

        }

        private void ClientListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
