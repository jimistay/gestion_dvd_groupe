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
    /// Logique d'interaction pour LocationModifierDataView.xaml
    /// </summary>
    public partial class LocationModifierDataView : Page
    {
        public int LocationID { get; set; }
        public ObservableCollection<Client> client = ClientViewModel.GetAllClients();
        public LocationModifierDataView(int id, string client, string dvd, string dateEmprun, string dateRetour)
        {
            InitializeComponent();
            LocationID = id;
            empreunt.Text = dateEmprun;
            retour.Text = dateRetour;

            if (client != null)
            {
                for (int i = 0; i < this.client.Count; i++)
                {
                    ComboBoxItem box = new ComboBoxItem();
                    box.Content = $"{this.client[i].Firstname} {this.client[i].Lastname}";
                    box.Tag = this.client[i].ClientID;
                    MaComboBox.Items.Add(box);
                    if (this.client[i].ClientID == int.Parse(client))
                    {
                        box.IsSelected = true;
                    }
                }
            }
            else
            {
                ComboBoxItem box = new ComboBoxItem();
                box.Content = "Aucune location enregistrée";
                box.IsSelected = true;
                MaComboBox.Items.Add(box);
            }

            ObservableCollection<DVD> DVDs = DVDViewModel.GetAllDVDs();

            if (DVDs != null)
            {
                for (int i = 0; i < DVDs.Count; i++)
                {
                    ComboBoxItem box = new ComboBoxItem();
                    box.Content = $"{DVDs[i].Title}";
                    box.Tag = DVDs[i].DVDId;
                    MaComboBoxDVD.Items.Add(box);
                    if (DVDs[i].DVDId == int.Parse(dvd))
                    {
                        box.IsSelected = true;
                    }
                }
            }
            else
            {
                ComboBoxItem box = new ComboBoxItem();
                box.Content = "Aucun DVD enregistré";
                box.IsSelected = true;
                MaComboBoxDVD.Items.Add(box);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem selectedItem = MaComboBox.SelectedItem as ComboBoxItem;
            ComboBoxItem selectedItems = MaComboBoxDVD.SelectedItem as ComboBoxItem;

            if (empreunt.Text != "" && retour.Text != "")
            {
                DateTime dateEmprunt;
                DateTime dateRetour;
                bool isEmpruntValid = DateTime.TryParse(empreunt.Text, out dateEmprunt);
                bool isRetourValid = DateTime.TryParse(retour.Text, out dateRetour);

                if (isEmpruntValid && isRetourValid)
                {
                    if (LocationViewModel.UpdateLocation(LocationID, selectedItem.Tag.ToString(), selectedItems.Tag.ToString(), dateEmprunt.ToString(), dateRetour.ToString()))
                    {
                        MessageBox.Show("Modification effectuée avec succès.");
                    }
                    else
                    {
                        MessageBox.Show("Échec de la modification.");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer des dates valides au format AAAA/MM/JJ.");
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une date valide.");
            }
        }
    }
}
