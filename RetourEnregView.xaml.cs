using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Logique d'interaction pour RetourEnregViews.xaml
    /// </summary>
    public partial class RetourEnregView : Page
    {
        public RetourEnregView()
        {
            InitializeComponent();
            List<string> DVD = RetourViewModel.GetDVD();

            if (DVD != null)
            {

                for (int i = 0; i < DVD.Count; i++)
                {

                    ComboBoxItem box = new ComboBoxItem();
                    box.Content = $"Location n°{DVD[i]}";
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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ComboBoxItem selectedItem = MaComboBox.SelectedItem as ComboBoxItem;

            if (selectedItem != null && DateInput.Text != "")
            {
                string location = selectedItem.Content.ToString();
                int index = location.IndexOf("°");
                string numero = location.Substring(index + 1);

                DateTime dateRetour;
                bool SwitchDateInput = DateTime.TryParse(DateInput.Text, out dateRetour);
                DateTime dateFormatted = DateTime.ParseExact(DateInput.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string formattedDate = dateFormatted.ToString("dd/MM/yyyy");

                // Extraire seulement l'année
                int year = dateFormatted.Year;

                if (SwitchDateInput && DateInput.Text.Length == 10)
                {
                    if (year > 1950)
                    {

                        if (RetourViewModel.AddRetour(numero, DateInput.Text))
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
                        MessageBox.Show("Veuillez entrer des dates valides au format JJ/MM/AAAA.");
                    }
                }
                else
                {
                    MessageBox.Show("Veuillez entrer des dates valides au format JJ/MM/AAAA.");
                }

            }
            else
            {
                MessageBox.Show($"Veuillez remplir les champs");
            }
        }
    }
}
