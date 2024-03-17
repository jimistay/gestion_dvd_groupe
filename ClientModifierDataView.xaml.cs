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
    /// Logique d'interaction pour Ajout.xaml
    /// </summary>
    public partial class ClientModifierDataView : Page
    {

        public int Id { get; set; }
        public ClientModifierDataView(int cID, string Fn, string Ln, string adress, string Phone)
        {
            InitializeComponent();
            Id = cID;
            Lname.Text = Ln;
            Fname.Text = Fn;
            adr.Text = adress;
            Pnumber.Text = Phone;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Fname.Text != "" && Lname.Text != "" && Pnumber.Text != "" && adr.Text != "")
            {
                try
                {
                    int numTel = int.Parse(Pnumber.Text);
                    if (Pnumber.Text.Length == 10)
                    {
                        if (ClientViewModel.UpdateClient(Id, Lname.Text, Fname.Text, Pnumber.Text, adr.Text))
                        {
                            NavigationService.Navigate(new ClientModifierView());
                        }
                        else
                        {
                            MessageBox.Show("Problème de base de donnée");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Merci d'entrée un numéro de telephone valide.");
                    }
                }
                catch (Exception error)
                {
                    Console.WriteLine("ERROR -> " + error);
                    MessageBox.Show("Merci d'entrée un numéro de telephone valide.");
                }
            }
            else
            {
                MessageBox.Show("Merci de remplir la totalité des champs.");
            }
        }
    }
}
