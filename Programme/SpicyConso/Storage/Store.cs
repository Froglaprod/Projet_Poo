///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
using MySql.Data.MySqlClient;
/// <summary>
/// La classe store permet de se connecter à notre db et d'y faire des requetes, il faut seulement changer le port corrspondant
/// </summary>
public class Store
{
    // Stocke le score du joueur
    public static int intscore = 0;
    // Position y de l'affichage des joueurs
    public static int inty = 12;
    // Permet de se connecter au serveur (changer le port en fonction)
    public static string strconnexionDb = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
    // Requêtes pour sélectionner les meilleurs joueurs
    public static string strsqlQuery = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";
    // Requêtes pour insert le score du joueur
    public static string strinsertQuery = "INSERT INTO t_joueur (jouPseudo, jouNombrePoints) VALUES (@pseudo, @score)";


    /// <summary>
    /// On affiche sélectionnent les données voulu et on affiche les 5 meilleur joueurs 
    /// </summary>
    public static void StoreData()
    {
        // Utilise l'instruction using MySqlConnection, pour se connecter à la db
        using (MySqlConnection connexion = new MySqlConnection(strconnexionDb))
        {
            //Ouverture de la connexion
            connexion.Open();

            // Utilise l'instruction using MySqlCommand, pour éxecuter des commandes
            using (MySqlCommand cmd = new MySqlCommand(strsqlQuery, connexion))
            {

                using (MySqlDataReader select = cmd.ExecuteReader())
                {
                    // Récupère les données des colonnes
                    while (select.Read())
                    {
                        int id = select.GetInt32("idJoueur");
                        string nom = select.GetString("jouPseudo");
                        int points = select.GetInt32("jouNombrePoints");

                        //Affichage des scores des 5 meilleurs joueurs
                        Console.SetCursorPosition(Console.WindowWidth / 3 + 8, inty);
                        Console.WriteLine($"Nom: {nom}, Points: {points}");

                        inty += 1;
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
        // Pseudo que le joueur entre
        string strpseudo = Console.ReadLine();

        // On regarde si le pseudo est vide
        if (!string.IsNullOrEmpty(strpseudo))
        {

            // Utilise l'instruction using MySqlConnection, pour se connecter à la db
            using (MySqlConnection connexion = new MySqlConnection(strconnexionDb))
            {
                //Ouverture de la connexion
                connexion.Open();

                // Utilise l'instruction using MySqlCommand, pour éxecuter des commandes 
                using (MySqlCommand cmd = new MySqlCommand(strinsertQuery, connexion))
                {
                    //Insert du score et du pseudo dans la base de données
                    cmd.Parameters.AddWithValue("@pseudo", strpseudo);
                    cmd.Parameters.AddWithValue("@score", intscore);

                    cmd.ExecuteNonQuery();

                    //Affichage message de réussite 
                    Console.SetCursorPosition(Console.WindowWidth / 3 + 8, 20);
                    Console.WriteLine($"Score de {intscore} sauvegardé pour {strpseudo}.");

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
