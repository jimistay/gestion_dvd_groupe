using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    internal class ClientViewModel
    {
        public ObservableCollection<Client> ClientList { get; set; }

        public ClientViewModel()

        {
            ClientList = GetAllClients();
        }
        public static ObservableCollection<Client> GetAllClients()

        {

            ObservableCollection<Client> cls = new ObservableCollection<Client>();

            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";
            //requete en lien avec la bdd
            string query = "SELECT * FROM client";

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
                            // Récupérer les valeurs des colonnes de la ligne actuelle
                            int cId = reader.GetInt32(0);

                            string Fname = reader.GetString(1);

                            string Lname = reader.GetString(2);

                            string Adr = reader.GetString(3);

                            string Pnumber = reader.GetString(4);
                            //Lier avec la base de données
                            Client client = new Client { Firstname = Fname, Lastname = Lname, ClientID = cId, Adresse = Adr, Phonenumber = Pnumber };

                            cls.Add(client);

                        }
                    }

                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
            return cls;

        }
        public static void DeleteClient(int clientId)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            string query = "DELETE FROM client WHERE ClientId=@clientId;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@clientId", clientId);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Le client avec l'ID {clientId} a été supprimé avec succès.");
                    }
                    else
                    {
                        Console.WriteLine($"Le client avec l'ID {clientId} n'a pas été trouvé dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        public static bool UpdateClient(int id, String fname, String lname, String pnumber, String adr)

        {

            try
            {

                string connectionString =
                     "server=localhost;database=dvd_gestion;uid=root;pwd=;";

                //faire un lien avec les données de la base données
                string query = "UPDATE client SET FirstName = @FirstName, LastName= @LastName, PhoneNumber= @PhoneNumber, Adresse = @Adresse WHERE ClientId = @clientId ;";

                using (MySqlConnection connection = new MySqlConnection(connectionString))

                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    {
                        command.Parameters.AddWithValue("@FirstName", fname);
                        command.Parameters.AddWithValue("@LastName", lname);
                        command.Parameters.AddWithValue("@PhoneNumber", pnumber);
                        command.Parameters.AddWithValue("@Adresse", adr);
                        command.Parameters.AddWithValue("@clientId", id);

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
