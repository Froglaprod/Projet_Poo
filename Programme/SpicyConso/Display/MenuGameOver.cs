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



        /// <summary>
        /// On affiche la forme du fond
        /// </summary>
        public static void DrawBackgrounGamOver()
        {
            for (int i = 0; i < Background.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 25, 0 + i);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Background[i]);
            }

        }
    }


}

