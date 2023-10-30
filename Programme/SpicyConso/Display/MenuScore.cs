using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Display
{
    public class MenuScore
    {
        public static string[] SCORE =
        {
            " ____                     ",
    "/ ___|  ___ ___  _ __ ___ ",
    "\\___ \\ / __/ _ \\| '__/ _ \\",
    " ___) | (_| (_) | | |  __/",
    "|____/ \\___\\___/|_|  \\___|"
        };

        /// <summary>
        /// On affiche le titre Score
        /// </summary>
        public static void DrawScore()
        {

            for (int i = 0; i < SCORE.Length; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth / 3 + 10, 4 + i);
                Console.WriteLine(SCORE[i]);

            }

        }

    }
}
