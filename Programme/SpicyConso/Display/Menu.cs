namespace Display
{
    public class Menu
    {
        

        public static string[] TITRE =
        {
            " ____                         ___                     _           ",
    "/ ___| _ __   __ _  ___ ___  |_ _|_ ____   ____ _  __| | ___ _ __ ",
    "\\___ \\| '_ \\ / _` |/ __/ _ \\  | || '_ \\ \\ / / _` |/ _` |/ _ \\ '__|",
    " ___) | |_) | (_| | (_|  __/  | || | | \\ V / (_| | (_| |  __/ |   ",
    "|____/| .__/ \\__,_|\\___\\___| |___|_| |_|\\_/ \\__,_|\\__,_|\\___|_|   ",
    "      |_|                                                          "

        };
        public static string[] JOUER =
        {
            "     _                       ",
    "    | | ___  _   _  ___ _ __",
    " _  | |/ _ \\| | | |/ _ \\ '__|",
    "| |_| | (_) | |_|  __/ |   ",
    " \\___/ \\___/ \\__,_|\\___|_|   "
                   };
        public static string[] SCORE =
        {
            " ____                     ",
    "/ ___|  ___ ___  _ __ ___ ",
    "\\___ \\ / __/ _ \\| '__/ _ \\",
    " ___) | (_| (_) | | |  __/",
    "|____/ \\___\\___/|_|  \\___|"
        };
        public static string[] OPTION =
        {
           "   ___        _   _             ",
    "  / _ \\ _ __ | |_(_) ___  _ __  ",
    " | | | | '_ \\| __| |/ _ \\| '_ \\ ",
    " | |_| | |_) | |_| | (_) | | | |",
    "  \\___/| .__/ \\__|_|\\___/|_| |_|",
    "       |_|                       "

        };

        /// <summary>
        /// On affiche le Titre
        /// </summary>
        public static void DrawTitre()
        {
           
            for (int i = 0; i < TITRE.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 2, 0 + i);
                Console.WriteLine(TITRE[i]);

            }

        }

        /// <summary>
        /// On affiche le sous menu Jouer
        /// </summary>
        public static void DrawJouer()
        {

            for (int i = 0; i < JOUER.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 18, 8 + i);
                Console.WriteLine(JOUER[i]);

            }

        }

        /// <summary>
        /// On affiche le sous menu Score
        /// </summary>
        public static void DrawScore()
        {

            for (int i = 0; i < SCORE.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 20, 16 + i);
                Console.WriteLine(SCORE[i]);

            }

        }

        /// <summary>
        /// On affiche le sous menu Option
        /// </summary>
        public static void DrawOption()
        {

            for (int i = 0; i < OPTION.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 16, 24 + i);
                Console.WriteLine(OPTION[i]);

            }

        }

        
    }
}
