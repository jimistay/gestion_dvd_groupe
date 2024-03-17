using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    internal class ClientAjoutViewModel
    {
        public ObservableCollection<Client> ClientList { get; set; }

        public ClientAjoutViewModel()

        {
            ClientList = GetAllClients();
        }
        public ObservableCollection<Client> GetAllClients()

        {

            ObservableCollection<Client> clients = new ObservableCollection<Client>();

            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";
            //requete en lien avec la bdd
            string query = "SELECT * FROM Client";

            using (MySqlConnection connection = new MySqlConnection(connectionString))

            {


                MySqlCommand command = new MySqlCommand(query, connection);

                try

                {

                    connection.Open();

                    using (MySqlDataReader reader = command.ExecuteReader())

                    {

                        while (reader.Read())

                        {
                            //Faire correspondre avec ce entrer dans les textes box
                            int cId = reader.GetInt32(0);

                            string Fname = reader.GetString(1);

                            string Lname = reader.GetString(2);

                            string Adr = reader.GetString(3);

                            string Pnumber = reader.GetString(4);
                            //Lier avec la base de données
                            Client client = new Client { Firstname = Fname, Lastname = Lname, ClientID = cId, Adresse = Adr, Phonenumber = Pnumber };

                            clients.Add(client);

                        }

                    }


                }

                catch (Exception ex)

                {

                    Console.WriteLine("Erreur : " + ex.Message);

                }

            }

            return clients;

        }

        public bool addClient(String fname, String lname, String pnumber, String adr)

        {
            try
            {

                string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

                //faire un lien avec les données de la base données
                string query = "INSERT INTO `client` (`ClientId`, `FirstName`, `LastName`, `Adresse`, `PhoneNumber`) VALUES (null, @FirstName, @LastName, @Adresse, @PhoneNumber);";

                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);

                    {
                        command.Parameters.AddWithValue("@FirstName", fname);
                        command.Parameters.AddWithValue("@LastName", lname);
                        command.Parameters.AddWithValue("@Adresse", adr);
                        command.Parameters.AddWithValue("@PhoneNumber", pnumber);


                        command.ExecuteNonQuery();
                        Client client = new Client { Firstname = fname, Lastname = lname, Adresse = adr, Phonenumber = pnumber };
                        return true;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la modification du client:" + ex.Message);
                return false;
            }


        }
    }

}
