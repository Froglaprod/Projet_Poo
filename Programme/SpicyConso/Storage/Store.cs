using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MySql.Data.MySqlClient;

public class Store
{
    // Stocke le score du joueur
    public static int score = 0;
    // Permet de se connecter au serveur
    public static string connexionDb = "Server=localhost;Port=6033;Database=db_space_invaders;User=root;Password=root;";
    // Requêtes pour sélectionner les meilleurs joueurs
    public static string sqlQuery = "SELECT * FROM t_joueur ORDER BY jouNombrePoints DESC LIMIT 5;";

    public static void StoreAlien(Alien alien)
    {
        Debug.WriteLine("C'est dans la db que je mets " + alien.ToString());
    }

    public static void StoreData()
    {
        // Établit une connexion à la base de données en utilisant une chaîne de connexion
        using (MySqlConnection connexion = new MySqlConnection(connexionDb))
        {
            connexion.Open();

            using (MySqlCommand cmd = new MySqlCommand(sqlQuery, connexion))
            {
                using (MySqlDataReader lancement = cmd.ExecuteReader())
                {
                    // Récupère les données des colonnes
                    while (lancement.Read())
                    {
                        int id = lancement.GetInt32("jouID");
                        string nom = lancement.GetString("jouNom");
                        int points = lancement.GetInt32("jouNombrePoints");

                        //Affichage des scores des 5 meilleurs joueurs
                        Console.WriteLine($"ID: {id}, Nom: {nom}, Points: {points}");
                    }
                }
            }
        }
    }
}
