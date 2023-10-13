namespace Display
{
    public class MenuWin
    {
        // Fond du menu Win
        public static string[] Background = {
     "   _____                       __          ___       ",
    "  / ____|                      \\ \\        / (_)      ",
    " | |  __  __ _ _ __ ___   ___   \\ \\  /\\  / / _ _ __  ",
    " | | |_ |/ _` | '_ ` _ \\ / _ \\   \\ \\/  \\/ / | | '_ \\ ",
    " | |__| | (_| | | | | | |  __/    \\  /\\  /  | | | | |",
    "  \\_____|\\__,_|_| |_| |_|\\___|     \\/  \\/   |_|_| |_|",

        };



        /// <summary>
        /// On affiche la forme du fond
        /// </summary>
        public static void DrawBackgroundWin()
        {
            for (int i = 0; i < Background.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 25, 0 + i);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(Background[i]);
            }

        }
    }
}
