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
    /// Logique d'interaction pour add_location.xaml
    /// </summary>
    public partial class LocationAjouterView : Page
    {
        public LocationAjouterView()
        {
            InitializeComponent();
            ObservableCollection<Client> client = ClientViewModel.GetAllClients();

            if (client != null)
            {

                for (int i = 0; i < client.Count; i++)
                {

                    ComboBoxItem box = new ComboBoxItem();
                    box.Content = $"{client[i].Firstname} {client[i].Lastname}";
                    box.Tag = client[i].ClientID;
                    MaComboBox.Items.Add(box);
                    if (i == 0)
                    {
                        box.IsSelected = true;
                    }
                }
            }
            else
            {
                ComboBoxItem box = new ComboBoxItem();
                box.Content = "Aucune location enregister";
                box.IsSelected = true;
                MaComboBox.Items.Add(box);
            }

            ObservableCollection<DVD> DVD = DVDViewModel.GetAllDVDs();

            if (DVD != null)
            {

                for (int i = 0; i < DVD.Count; i++)
                {

                    ComboBoxItem box = new ComboBoxItem();
                    box.Content = $"{DVD[i].Title}";
                    box.Tag = DVD[i].DVDId;
                    MaComboBoxDVD.Items.Add(box);
                    if (i == 0)
                    {
                        box.IsSelected = true;
                    }
                }
            }
            else
            {
                ComboBoxItem box = new ComboBoxItem();
                box.Content = "Aucune location enregister";
                box.IsSelected = true;
                MaComboBoxDVD.Items.Add(box);
            }


        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            ComboBoxItem selectedItem = MaComboBox.SelectedItem as ComboBoxItem;
            ComboBoxItem selectedItems = MaComboBoxDVD.SelectedItem as ComboBoxItem;

            if (empreunt.Text != "" && retour.Text != "")
            {
                DateTime dateValue = (DateTime)empreunt.SelectedDate;
                string empreuntString = dateValue.ToString("yyyy-MM-dd");

                dateValue = (DateTime)retour.SelectedDate;
                string retourtString = dateValue.ToString("yyyy-MM-dd");

                if (LocationViewModel.AddLocation(selectedItem.Tag.ToString(), selectedItems.Tag.ToString(), empreuntString, retourtString))
                {
                    MessageBox.Show("Ajout effectuer");
                }

            }
            else
            {
                MessageBox.Show("Erreur, Veuillez remplir les date svp");
            }






        }

        private void MaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
