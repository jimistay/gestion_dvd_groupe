using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Logique d'interaction pour Modifier.xaml
    /// </summary>
    public partial class ClientModifierView : Page
    {
        public ObservableCollection<Client> Clients { get; set; }
        public ClientModifierView()
        {
            InitializeComponent();
            Clients = ClientViewModel.GetAllClients();

            ClientListView.ItemsSource = Clients;
        }
        private void ClientListView_MouseDoubleclick(object sender, MouseButtonEventArgs e)
        {
            Client selectedClient = (Client)ClientListView.SelectedItem;
            if (selectedClient != null)
            {

                NavigationService.Navigate(new ClientModifierDataView(selectedClient.ClientID, selectedClient.Firstname, selectedClient.Lastname, selectedClient.Adresse, selectedClient.Phonenumber));
            }
        }
    }
}
