namespace Display
{
    public class MenuGameOver
    {
        // Fond du menu GamOver
        public static string[] Background = {
           "  _____                       ____     ",
    " / ____|                     / __ \\    ",
    "| |  __  __ _ _ __ ___   ___| |  | |_   _____ _ __",
    "| | |_ |/ _` | '_ ` _ \\ / _ \\ |  | \\ \\ / / _ \\ '__|",
    "| |__| | (_| | | | | | |  __/ |__| |\\ V /  __/ |",
    " \\_____|\\__,_|_| |_| |_|\\___|\\____/  \\_/ \\___|_|"

        };

        public static string[] Save= {

    "   _____                 ",
    "  / ____|                ",
    " | (___   __ ___   _____ ",
    "  \\___ \\ / _` \\ \\ / / _ \\",
    "  ____) | (_| |\\ V /  __/",
    " |_____/ \\__,_| \\_/ \\___|"
};


        public static string[] Replay = {

    "  _____            _             ",
    " |  __ \\          | |            ",
    " | |__) |___ _ __ | | __ _ _   _ ",
    " |  _  // _ \\ '_ \\| |/ _` | | | |",
    " | | \\ \\  __/ |_) | | (_| | |_| |",
    " |_|  \\_\\___| .__/|_|\\__,_|\\__, |",
    "            | |             __/ |",
    "            |_|            |___/ "
};


        public static string[] Quitter = {

    " ____        _ _   _            ",
    " / __ \\      (_) | | |           ",
    " | |  | |_   _ _| |_| |_ ___ _ __ ",
    " | |  | | | | | | __| __/ _ \\ '__|",
    " | |__| | |_| | | |_| ||  __/ |   ",
    " \\___\\_\\__,_|_|\\__|\\__\\___|_|   "
};


    /// <summary>
    /// On affiche la forme du titre
    /// </summary>
    public static void DrawBackgrounGamOver()
        {
            for (int i = 0; i < Background.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 18, 0 + i);
                Console.WriteLine(Background[i]);
            }

        }

        /// <summary>
        /// On affiche la forme du save
        /// </summary>
        public static void DrawSave()
        {
            for (int i = 0; i < Save.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 18, 8 + i);
                Console.WriteLine(Save[i]);
            }

        }

        /// <summary>
        /// On affiche la forme du replay
        /// </summary>
        public static void DrawReplay()
        {
            for (int i = 0; i < Replay.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 18, 16 + i);
                Console.WriteLine(Replay[i]);
            }

        }


        /// <summary>
        /// On affiche la forme du quitter
        /// </summary>
        public static void DrawQuit()
        {
            for (int i = 0; i < Quitter.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 18, 24 + i);
                Console.WriteLine(Quitter[i]);
            }

        }
    }


}

