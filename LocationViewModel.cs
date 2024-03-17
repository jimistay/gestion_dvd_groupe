using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Location_DVD
{
    internal class LocationViewModel
    {
        private static readonly string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

        public static ObservableCollection<Location> GetAllLocation()
        {
            ObservableCollection<Location> Locations = new ObservableCollection<Location>();

            string query = "SELECT * FROM location";

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
                            int LocationID = reader.GetInt32(0);
                            string Client = reader.GetString(1);
                            string DVD = reader.GetString(2);
                            string dateRented = reader.GetString(3);
                            string dateReturned = reader.GetString(4);

                            Location Location = new Location
                            {
                                LocationId = LocationID,
                                LeClient = Client,
                                LeDVD = DVD,
                                DateRented = dateRented.ToString(),
                                DateReturned = dateReturned.ToString()
                            };

                            Locations.Add(Location);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

            return Locations;
        }

        public static bool AddLocation(string client, string DVD, string dateEmprunt, string dateRetour)
        {
            string query = "INSERT INTO `location` (`LocationId`, `LeClient`, `LeDVD`, `dateRented`, `dateReturned`) VALUES (NULL, @Client, @DVD, @DateEmprunt, @DateRetour)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Client", client);
                    command.Parameters.AddWithValue("@DVD", DVD);
                    command.Parameters.AddWithValue("@DateEmprunt", dateEmprunt);
                    command.Parameters.AddWithValue("@DateRetour", dateRetour);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static List<string> GetDVD()
        {
            List<string> data = new List<string>();
            string query = "SELECT * FROM `location`";

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
                            string uId = reader.GetString(0);
                            data.Add(uId);
                        }

                        return data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }

            return null;
        }

        public static List<string> GetClient()
        {
            List<string> data = new List<string>();
            string query = "SELECT * FROM `client`";

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
                            string uId = reader.GetString(0);
                            data.Add(uId);
                        }

                        return data;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                    return null;
                }
            }
        }
        public static bool UpdateLocation(int id, string client, string dvd, string dateRented, string dateReturn)
        {
            string query = "UPDATE location SET LeClient = @Client, LeDVD = @DVD, dateRented = @DateRented, dateReturned = @DateReturned WHERE LocationId = @LocationId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Client", client);
                    command.Parameters.AddWithValue("@DVD", dvd);
                    command.Parameters.AddWithValue("@DateRented", dateRented);
                    command.Parameters.AddWithValue("@DateReturned", dateReturn);
                    command.Parameters.AddWithValue("@LocationId", id);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erreur : " + ex.Message);
                        return false;
                    }
                }
            }
        }

        public static void DeleteLocation(int LocationId)
        {
            string query = "DELETE FROM location WHERE LocationId=@LocationId";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@LocationId", LocationId);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show($"La location avec l'ID {LocationId} a été supprimée avec succès.");
                    }
                    else
                    {
                        MessageBox.Show($"La location avec l'ID {LocationId} n'a pas été trouvée dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur : " + ex.Message);
                }
            }
        }
    }
}
