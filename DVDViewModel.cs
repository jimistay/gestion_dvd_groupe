using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Location_DVD
{
    internal class DVDViewModel
    {
        //Premiere partie : AFFICHAGE
        public static ObservableCollection<DVD> GetAllDVDs() 
        {
            ObservableCollection<DVD> dvs = new ObservableCollection<DVD>();
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";


            string query = "SELECT * FROM dvd";


            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                try
                {
                    connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        // Parcourir les lignes de données
                        while (reader.Read())
                        {
                            // Récupérer les valeurs des colonnes de la ligne actuelle
                            int DVDId = reader.GetInt32(0);
                            string Title = reader.GetString(1);
                            string Director = reader.GetString(2);
                            string Genre = reader.GetString(3);
                            string ReleaseYear = reader.GetString(4);
                            string IsAvailable = reader.GetString(5);
                            DVD dvd = new DVD { DVDId = DVDId, Title = Title, Director = Director, Genre = Genre, ReleaseYear = ReleaseYear, IsAvailable = IsAvailable };
                            dvs.Add(dvd);

                        }
                    }

                }
                catch (Exception ex)
                {

                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
            return dvs;
        }

        //Deuxième partie : AJOUTER 

        public static bool AddDVD(string title, string realisateur, string genre, string date, string dispo)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            // Vérifier la longueur de la chaîne de caractères pour chaque paramètre
            if (title.Length > 50)
            {
                Console.WriteLine("Le titre du DVD ne doit pas dépasser 50 caractères.");
                return false;
            }

            if (realisateur.Length > 50)
            {
                Console.WriteLine("Le nom du réalisateur ne doit pas dépasser 50 caractères.");
                return false;
            }

            if (genre.Length > 50)
            {
                Console.WriteLine("Le genre du DVD ne doit pas dépasser 50 caractères.");
                return false;
            }

            // Vérifier la longueur de la chaîne de caractères pour ReleaseYear
            if (date.Length != 4 || !int.TryParse(date, out _))
            {
                Console.WriteLine("La date de sortie du DVD doit contenir 4 chiffres.");
                return false;
            }

            string query = "INSERT INTO `dvd` (`Title`, `Director`, `Genre`, `ReleaseYear`, `IsAvailable`) VALUES (@Title, @Director, @Genre, @ReleaseYear, @IsAvailable)";

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        // Ajout des paramètres
                        command.Parameters.AddWithValue("@Title", title);
                        command.Parameters.AddWithValue("@Director", realisateur);
                        command.Parameters.AddWithValue("@Genre", genre);
                        command.Parameters.AddWithValue("@ReleaseYear", date);
                        command.Parameters.AddWithValue("@IsAvailable", dispo);

                        connection.Open();
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Une erreur est survenue lors de l'ajout du DVD: " + ex.Message);
                return false;
            }
        }

        //Partie 3: SUPPRMIER 
        public static void DeleteDVD(int dvdId)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            string query = "DELETE FROM dvd WHERE DVDId=@dvdId;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@dvdId", dvdId);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine($"Le DVD avec l'ID {dvdId} a été supprimé avec succès.");
                    }
                    else
                    {
                        Console.WriteLine($"Le DVD avec l'ID {dvdId} n'a pas été trouvé dans la base de données.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erreur : " + ex.Message);
                }
            }
        }

        //Partie 4 : MODIFIER 

        private readonly string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";
        public ObservableCollection<DVD> DVDs { get; set; }

        public DVDViewModel()
        {
            LoadDVDs();
        }

        private void LoadDVDs()
        {
            DVDs = new ObservableCollection<DVD>();

            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (var command = new MySqlCommand("SELECT * FROM dvd", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var dvd = new DVD
                            {
                                DVDId = reader.GetInt32("DVDId"),
                                Title = reader.GetString("Title"),
                                Director = reader.GetString("Director"),
                                Genre = reader.GetString("Genre"),
                                ReleaseYear = reader.GetString("ReleaseYear"),
                                IsAvailable = reader.GetString("IsAvailable")
                            };

                            DVDs.Add(dvd);
                        }
                    }
                }
            }
        }
        public static bool UpdateDVD(int id, string title, string director, string genre, string year, string IsAvailable)
        {
            string connectionString = "server=localhost;database=dvd_gestion;uid=root;pwd=;";

            // Vérifier la longueur de la chaîne de caractères pour chaque paramètre
            if (title.Length > 50)
            {
                Console.WriteLine("Le titre du DVD ne doit pas dépasser 50 caractères.");
                return false;
            }

            if (director.Length > 50)
            {
                Console.WriteLine("Le nom du réalisateur ne doit pas dépasser 50 caractères.");
                return false;
            }

            if (genre.Length > 50)
            {
                Console.WriteLine("Le genre du DVD ne doit pas dépasser 50 caractères.");
                return false;
            }

            // Vérifier la longueur de la chaîne de caractères pour ReleaseYear
            if (year.Length != 4 || !int.TryParse(year, out _))
            {
                Console.WriteLine("La date de sortie du DVD doit contenir 4 chiffres.");
                return false;
            }

            string query = "UPDATE dvd SET Title = @Title, Director = @Director, Genre = @Genre, ReleaseYear = @ReleaseYear, IsAvailable = @IsAvailable WHERE DVDId = @DVDId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // Ajouter les paramètres
                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Director", director);
                    command.Parameters.AddWithValue("@Genre", genre);
                    command.Parameters.AddWithValue("@ReleaseYear", year);
                    command.Parameters.AddWithValue("@IsAvailable", IsAvailable);
                    command.Parameters.AddWithValue("@DVDId", id);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            Console.WriteLine($"Le DVD avec l'ID {id} a été modifié avec succès.");
                            return true;
                        }
                        else
                        {
                            Console.WriteLine($"Le DVD avec l'ID {id} n'a pas été trouvé dans la base de données.");
                            return false;
                        }
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
}
