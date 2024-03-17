using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    internal class RetourViewModel
    {
        public RetourViewModel()
        {

        }

        public static List<string> GetDVD()
        {
            List<string> data = new List<string>();
            string connectionString =
            "server=localhost;database=dvd_gestion;uid=root;pwd=;";
            // Créer une connexion à la base de données


            string query = "SELECT * FROM `location`";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer un objet Command
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    // Ouvrir la connexion
                    connection.Open();
                    // Exécuter la requête SQL et récupérer les données dans un DataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcourir les lignes de données


                        while (reader.Read())
                        {
                            string uId = reader.GetString(0);
                            data.Add(uId);
                        }
                        return data;


                    }

                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
            return null;

        }
        public static ObservableCollection<Retour> GetRetour()
        {
            ObservableCollection<Retour> Retours = new ObservableCollection<Retour>();
            string connectionString =
            "server=localhost;database=dvd_gestion;uid=root;pwd=;";
            // Créer une connexion à la base de données


            string query = "SELECT * FROM `retour`";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                // Créer un objet Command
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    // Ouvrir la connexion
                    connection.Open();
                    // Exécuter la requête SQL et récupérer les données dans un DataReader
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcourir les lignes de données


                        while (reader.Read())
                        {
                            int ID = reader.GetInt32(0);
                            string Location = reader.GetString(1);
                            string DateReturn = reader.GetString(2);

                            Retour Locations = new Retour { RetourId = ID, LaLocation = Location, DateReturned = DateReturn.ToString() };
                            Retours.Add(Locations);
                        }
                        return Retours;


                    }

                }
                catch (Exception ex)
                {
                    // Gérer les erreurs de connexion ou d'exécution de la requête SQL
                    Console.WriteLine("Erreur : " + ex.Message);
                    return null;
                }
            }

        }
        public static bool AddRetour(string id, string date)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";
            string query = "INSERT INTO `retour` (`RetourId`, `LaLocation`, `DateReturned`) VALUES (NULL, @LaLocation, @DateReturned);";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LaLocation", id);
                        command.Parameters.AddWithValue("@DateReturned", date);

                        connection.Open();
                        command.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception error)
            {
                Console.WriteLine("ERROR : " + error);
                return false;
            }



        }


        public static void DeleteRetour(int ID)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            string query = "DELETE FROM retour WHERE RetourId=@ID;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@ID", ID);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Le retour avec l'ID {ID} a été supprimé avec succès.");
                    }
                    else
                    {
                        Console.WriteLine($"Le retour avec l'ID {ID} n'a pas été trouvé dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }
        public static bool UpdateLocation(int id, string location, string dateReturn)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            string query = "UPDATE retour SET LaLocation = @LaLocation, dateReturned = @DateReturned WHERE RetourId = @RetourId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@RetourId", id);
                command.Parameters.AddWithValue("@LaLocation", location);
                command.Parameters.AddWithValue("@DateReturned", dateReturn);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }

                    return false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                    return false;
                }
            }
        }

    }
}