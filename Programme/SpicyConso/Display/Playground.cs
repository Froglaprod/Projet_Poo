///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
using Model;
namespace Display
{
    public class Playground
    {
        //Hauteur de la fenetre
        public const int SCREEN_HEIGHT = 40;
        //Largeur de la fenetre
        public const int SCREEN_WIDTh = 150;

        //Forme de la séparation
        public static string SEPARATION = "-";


        //Forme de l'invaders
        public static string[] INVADER = {
            @"     ___     ",
            @" ___/   \___ ",
            @"/   '---'   \",
            @"'--_______--'"

        };

        //Forme des hp
        public static string[] HP = {
            @"( ' )",
            @" \ / ",
            @"  ' "
        };

        //Forme du joueur
        public static string[] PLAYER = {

            @"    /|\",
            @"   (   )",
            @"  /|/ \|\",
            @" /_|| ||_\"
        };


        //Forme du missile
        public static string MISSILE = "|";

        //Forme de l'exlposion
        public static string[] BOOM = {
               @".---.",
              @"(\|/)",
              @"--0--",
               @"(/|\)"
        };

        //Forme de l'invaders
        public static string[] BOSSEASY = {
"              _____            ",
    "           ,-\"     \"-.",
    "          /  o       o \\",
    "         /    \\     /   \\",
    "        /      )-\"-(     \\",
    "       /      ( 6 6 )     \\",
    "      /        \\ \" /       \\",
    "     /          )=(         \\",
    "    /    o   .--\"-\"--.   o   \\",
    "   /     I  /  -   -  \\  I    \\",
    ".--(    (_}y/\\       /\\y{_)    )--.",
    "(   \".___l\\/__\\_____/__\\/l___,\"  )",
    " \\                                /",
    "  \"-._      o O o O o O o      _,-",
    "      `--Y--.___________.--Y--'",
    "        |==.___________.==| ",
    "        `==.___________.==' "
       };

        public static string[] Cthree = {
            "  ____  ",
            " |___ \\ ",
            "   __) |",
            "  |__ < ",
            "  ___) |",
            " |____/ ",
            "        ",
        };

        public static string[] Ctwo = {
             " |__ \\ ",
            "    ) |",
            "   / / ",
            "  / /_ ",
            " |____|",
        };

        public static string[] Cone = {
            " __ ",
            "/_ |",
            " | |",
            " | |",
            " | |",
            " |_|"
        };

        public static string[] Cgo = {
           "   _____  ____  ",
            "  / ____|/ __ \\ ",
            " | |  __| |  | |",
            " | | |_ | |  | |",
            " | |__| | |__| |",
            "  \\_____|\\____/ ",
        };

        /// <summary>
        /// On Initialise la config du playground
        /// </summary>
        public static void Init()
        {
            //Dimension de la fenetre
            Console.SetWindowSize(SCREEN_WIDTh, SCREEN_HEIGHT);
            Console.CursorVisible = false;
            Console.SetBufferSize(SCREEN_WIDTh, SCREEN_HEIGHT);
        }
        public static void Clear()
        {
            Console.Clear();
        }

        /// <summary>
        /// On affiche la séparation 
        /// </summary>
        public static void DrawSeparation()
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.SetCursorPosition(0 + i, 4);
                Console.WriteLine(SEPARATION);
            }
        }

        /// <summary>
        /// On affiche chaque ligne du tableau invader pour avoir sa forme au complet.
        /// </summary>
        /// <param name="alien"></param>
        public static void DrawAlien(Alien alien)
        {
            if (alien == null) return;
            if (alien.AlienisAlife)
            {
                ConsoleColor defaultColor = Console.ForegroundColor; // Couleur par défault

                for (int i = 0; i < INVADER.Length; i++)
                {
                    Console.SetCursorPosition(alien.x, alien.y + i);

                    if (alien.hpDefault <= 29 && alien.hpDefault >= 20)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (alien.hpDefault <= 19 && alien.hpDefault >= 10)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    if (alien.hpDefault <= 9 && alien.hpDefault >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(INVADER[i]);
                }

                Console.ForegroundColor = defaultColor;
            }
        }

        /// <summary>
        /// On affiche les hp
        /// </summary>
        public static void DrawHP(Hpcoeur1 coeur)
        {
            ConsoleColor defaultColor = Console.ForegroundColor; // Couleur par défault
            for (int i = 0; i < HP.Length; i++)
            {
                Console.SetCursorPosition(coeur.x + 132, coeur.y + i);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(HP[i]);

            }

            Console.ForegroundColor = defaultColor;

        }


        /// <summary>
        /// On affiche chaque ligne du tableau joueur pour avoir sa forme au complet.
        /// </summary>
        /// <param name="player"></param>
        public static void DrawPlayer(Player player)
        {

            if (player == null) return;
            if (player.PlayerisAlife)
            {
                ConsoleColor defaultColor = Console.ForegroundColor; // Couleur par défault

                for (int i = 0; i < PLAYER.Length; i++)
                {
                    Console.SetCursorPosition(player.x, player.y + i);

                    if (player.hpDefault <= 100 && player.hpDefault >= 51)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    if (player.hpDefault <= 50 && player.hpDefault >= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine(PLAYER[i]);
                }

                Console.ForegroundColor = defaultColor;
            }
        }

        /// <summary>
        /// On affiche la forme du missile du joueur
        /// </summary>
        /// <param name="missile"></param>
        /// <param name="alien"></param>
        public static void DrawMissileJoueur(missileJoueur missile, Alien alien)
        {
            if (missile.missileIsLaunched)
            {
                if (MISSILE == null) return;
                Console.SetCursorPosition(missile.x + 5, missile.y);
                Console.WriteLine(MISSILE);
            }


        }

        /// <summary>
        /// On affiche la forme du missile de l'alien
        /// </summary>
        /// <param name="missile"></param>
        /// <param name="alien"></param>
        public static void DrawMissileAlien(missileAlien missile, Player player)
        {
            if (missile.missileIsLaunched)
            {
                if (MISSILE == null) return;
                Console.SetCursorPosition(missile.x + 6, missile.y + 4);
                Console.WriteLine(MISSILE);
            }

        }

        /// <summary>
        /// On affiche la forme du missile de l'alien
        /// </summary>
        /// <param name="missile"></param>
        /// <param name="alien"></param>
        public static void DrawMissileBoss(missileAlien missile, Player player)
        {
            if (missile.missileIsLaunched)
            {
                if (MISSILE == null) return;
                Console.SetCursorPosition(missile.x + 16, missile.y);
                Console.WriteLine(MISSILE);
            }

        }

        /// <summary>
        /// On affiche chaque ligne du tableau BOOM pour avoir sa forme au complet.
        /// </summary>
        /// <param name="alien"></param>
        public static void DrawAlienBOOM(Alien alien)
        {
            if (!alien.AlienisAlife)
            {
                for (int i = 0; i < BOOM.Length; i++)
                {
                    Console.SetCursorPosition(alien.x + 3, alien.y + i);
                    Console.WriteLine(BOOM[i]);
                    alien.BoomNotArrived = false;
                }
            }
        }

        /// <summary>
        /// On affiche le 3 du décompte
        /// </summary>
        public static void Drawthree()
        {

            for (int i = 0; i < Cthree.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + i);
                Console.WriteLine(Cthree[i]);
            }

        }

        /// <summary>
        /// On affiche le 2 du décompte
        /// </summary>
        public static void Drawtwo()
        {

            for (int i = 0; i < Ctwo.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + i);
                Console.WriteLine(Ctwo[i]);
            }

        }

        /// <summary>
        /// On affiche le 1 du décompte
        /// </summary>
        public static void Drawone()
        {

            for (int i = 0; i < Cone.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2, Console.WindowHeight / 2 + i);
                Console.WriteLine(Cone[i]);
            }

        }

        /// <summary>
        /// On affiche le go du décompte
        /// </summary>
        public static void Drawgo()
        {

            for (int i = 0; i < Cgo.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 6, Console.WindowHeight / 2 + i);
                Console.WriteLine(Cgo[i]);
            }

        }

        /// <summary>
        /// On affiche le decompte assemble
        /// </summary>
        public static void DrawDecount()
        {
            //Affichage décompte
            Playground.Drawthree();
            Thread.Sleep(1000);
            Console.Clear();
            Playground.Drawtwo();
            Thread.Sleep(1000);
            Console.Clear();
            Playground.Drawone();
            Thread.Sleep(1000);
            Console.Clear();
            Playground.Drawgo();
            Thread.Sleep(1000);
            Console.Clear();
        }

        /// <summary>
        /// On affiche le score
        /// </summary>
        public static void DrawScore(int score)
        {
            Console.SetCursorPosition(4, 2);
            Console.WriteLine($"Score : {score}");
        }

        /// <summary>
        /// On affiche la manche
        /// </summary>
        public static void DrawManche(int manche)
        {
            Console.SetCursorPosition(Console.WindowWidth / 2 - 5, 2);
            Console.WriteLine($"Manche n°: {manche}");
        }

        /// <summary>
        /// On affiche chaque ligne du tableau du boss pour avoir sa forme au complet.
        /// </summary>
        /// <param name="boss"></param>
        public static void DrawBOSSeasy(AlienBoss1 boss)
        {
            if (boss == null) return;
            if (boss.AlienisAlife)
            {
                ConsoleColor defaultColor = Console.ForegroundColor; // Couleur par défault

                for (int i = 0; i < BOSSEASY.Length; i++)
                {
                    Console.SetCursorPosition(boss.x, boss.y + i);
                    Console.WriteLine(BOSSEASY[i]);
                }

            }
        }
    }
}
