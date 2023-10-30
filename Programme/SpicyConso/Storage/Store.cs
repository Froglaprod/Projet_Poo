using Model;
using MySql.Data.MySqlClient;
using System.Diagnostics;

public class Store
{
    // Stocke le score du joueur
    public static int score = 0;
    // Permet de se connecter au serveur
    public static string connexionDb = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
    // Requêtes pour sélectionner les meilleurs joueurs
    public static string sqlQuery = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
    // Requêtes pour insert le score du joueur
    public static string insertQuery = "INSERT INTO t_joueur (jouPseudo, jouNombrePoints) VALUES (@pseudo, @score)";
    // Position y de l'affichage des joueurs
    public static int y = 12;

    public static void StoreAlien(Alien alien)
    {
        Debug.WriteLine("C'est dans la db que je mets " + alien.ToString());
    }

    /// <summary>
    /// On affiche sélectionnent les données voulu et on affiche les 5 meilleur joueurs 
    /// </summary>
    public static void StoreData()
    {
        // Connexion à la base de données
        using (MySqlConnection connexion = new MySqlConnection(connexionDb))
        {
            connexion.Open();

            // Récupère les données des colonnes
            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connexion))
            {

                using (MySqlDataReader select = cmd.ExecuteReader())
                {
                    while (select.Read())
                    {
                        int id = select.GetInt32("idJoueur");
                        string nom = select.GetString("jouPseudo");
                        int points = select.GetInt32("jouNombrePoints");

                        //Affichage des scores des 5 meilleurs joueurs
                        Console.SetCursorPosition(Console.WindowWidth / 3 + 8, y);
                        Console.WriteLine($"Nom: {nom}, Points: {points}");

                        y += 1;
                    }
                }
            }

            //Fermeture de la connexion
            connexion.Close();
        }
    }

    /// <summary>
    /// On stock le score du joueur et son pseudo dans la base de données
    /// </summary>
    public static void SaveScore()
    {
        Console.SetCursorPosition(Console.WindowWidth / 3 + 14, 23);
        //Pseudo que le joueur entre
        string pseudo = Console.ReadLine();

        // On regarde si le pseudo est vide
        if (!string.IsNullOrEmpty(pseudo))
        {

            // Connexion à la base de données
            using (MySqlConnection connexion = new MySqlConnection(connexionDb))
            {
                connexion.Open();

                // Insert du score et du pseudo dans la base de données
                using (MySqlCommand cmd = new MySqlCommand(insertQuery, connexion))
                {
                    cmd.Parameters.AddWithValue("@pseudo", pseudo);
                    cmd.Parameters.AddWithValue("@score", score);

                    cmd.ExecuteNonQuery();

                    //Affichage message de réussite 
                    Console.SetCursorPosition(Console.WindowWidth / 3 + 8, 20);
                    Console.WriteLine($"Score de {score} sauvegardé pour {pseudo}.");

                }
                //Fermeture de la connexion
                connexion.Close();
            }
        }

        //Affichage message d'erreur
        else
        {
            Console.SetCursorPosition(Console.WindowWidth / 3 + 8, 22);
            Console.WriteLine("Pseudo non valide. Le score ne sera pas sauvegardé.");
        }
    }
}
