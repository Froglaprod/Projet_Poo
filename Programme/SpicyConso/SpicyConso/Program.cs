using Display;
using Model;


//Savoir si on continuer de jouer
bool play = true;
do
{
    bool replay = false;//Savoir si on relance ou non
    int SousMenu = 4;
    bool SelectSave = false;
    bool SelectScore = false; // Savoir si on a sélectionné score
    bool SelectJouer = false; // Savoir si on a sélectionné jouer
    bool alienspawn = false; // Savoir si les aliens ont spawn
    bool GameStart = false; // Si la partie a commencé ou non
    bool MenuEndDiplay = false; // Si on affiche game over ou non
    bool GameLooseEND = false; // Si la partie perdue est finie ou non
    bool GameWinEND = false; // Si la partie est gagnée finie ou non
    int clear = 8;
    uint frameNumber = 0; // Comptage du nombre d'images à afficher
    int manche = 1;
    Playground.Init(); // Initialisation de la config playground

    Random random = new Random(); // Instancie le random
    List<missileJoueur> missileJoueur = new List<missileJoueur>();
    List<missileAlien> missileAlien = new List<missileAlien>();
    List<Alien> aliensDefault = new List<Alien>();
    List<Hpcoeur1> coeurdefault = new List<Hpcoeur1>();
    Player player = new Player(Console.WindowWidth / 2 - 5, Console.WindowHeight - 5, 150);
    AlienBoss1 boss1 = null;

    // Nombre de hp (coeur) à créer
    for (int i = 0; i < 2; i++)
    {
        Hpcoeur1 coeur = new Hpcoeur1(i * 6, 1);
        coeurdefault.Add(coeur);
    }

    // Menu principal
    while (true)
    {
        ConsoleColor defaultColor = Console.ForegroundColor;

        // Affichage du Menu principal
        Menu.DrawTitre();

        if (SousMenu == 3)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        Menu.DrawJouer();
        Console.ForegroundColor = defaultColor;

        if (SousMenu == 2)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Menu.DrawScore();
        Console.ForegroundColor = defaultColor;

        if (SousMenu == 1)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }
        Menu.DrawOption();
        Console.ForegroundColor = defaultColor;

        if (SelectJouer)
        {
            Playground.Clear();
            break;
        }

        if (SelectScore)
        {
            Playground.Clear();
            break;
        }

        ConsoleKeyInfo keyPressed = Console.ReadKey(true);

        switch (keyPressed.Key)
        {
            case ConsoleKey.Escape:
                break;

            case ConsoleKey.W:
                if (SousMenu < 3)
                {
                    SousMenu++;
                }
                break;

            case ConsoleKey.S:
                if (SousMenu > 1)
                {
                    SousMenu--;
                }
                break;

            case ConsoleKey.Enter:
                if (SousMenu == 3)
                {
                    SelectJouer = true;
                }

                if (SousMenu == 2)
                {
                    SelectScore = true;
                }
                break;
        }
    }

    while (SelectScore)
    {
        MenuScore.DrawScore();
        Store.StoreData();

        while (true)
        {

        }
    }

    // Affichage du décompte
    Playground.DrawDecount();

    // Partie lancée
    while (SelectJouer)
    {
        GameStart = true; // La partie a commencé

        if (!alienspawn)
        {
            if (manche != 10)
            {
                // Nombre d'invaders à créer
                for (int i = 0; i < 8; i++)
                {
                    Alien invader = new Alien(i * 16, 5, 30);
                    aliensDefault.Add(invader);
                }
            }

            // Apparition du boss
            if (manche == 10)
            {
                boss1 = new AlienBoss1(Console.WindowWidth / 2 - 16, 5, 500);
            }

            alienspawn = true;
        }

        // Action de l'utilisateur par rapport à sa saisie
        if (Console.KeyAvailable) // Si l'utilisateur presse une touche
        {
            ConsoleKeyInfo keyPressed = Console.ReadKey(true);
            switch (keyPressed.Key)
            {
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;

                case ConsoleKey.W:
                    player.moveUp();
                    break;

                case ConsoleKey.S:
                    player.moveDown();
                    break;

                case ConsoleKey.A:
                    player.moveLeft();
                    break;

                case ConsoleKey.D:
                    player.moveRight();
                    break;

                case ConsoleKey.Spacebar:
                    missileJoueur missileJoueurDefault = new missileJoueur(10); // Initialisation du missile de base
                    missileJoueur.Add(missileJoueurDefault);
                    player.chargement(missileJoueurDefault); // On charge le missile dans le joueur
                    player.dropMissile(); // On lance le missile
                    break;
            }
        }

        if (frameNumber % clear == 0) // Affichage
        {
            Playground.Clear(); // Clear de la console
            Playground.DrawSeparation(); // Affichage séparation du haut

            foreach (Hpcoeur1 coeur in coeurdefault)
            {
                Playground.DrawHP(coeur); // Affichage des hps (coeurs)
            }

            Playground.DrawScore(Store.score);
            Playground.DrawManche(manche);

            foreach (Alien invader in aliensDefault)
            {
                Playground.DrawAlien(invader); // Affichage de l'alien
                Playground.DrawAlienBOOM(invader); // Affichage de l'alien mort
            }

            Playground.DrawPlayer(player); // Affichage du joueur

            foreach (Alien invader in aliensDefault)
            {
                foreach (missileJoueur missileDefault in missileJoueur)
                {
                    Playground.DrawMissileJoueur(missileDefault, invader); // Affichage du missile du joueur
                }
            }

            foreach (Alien invader in aliensDefault)
            {
                foreach (missileAlien missileAlienDefault in missileAlien)
                {
                    Playground.DrawMissileAlien(missileAlienDefault, player); // Affichage du missile de l'alien
                }
            }
            if (manche == 10)
            {
                Playground.DrawBOSSeasy(boss1); // Affichage du boss

                foreach (missileAlien missileAlienDefault in missileAlien)
                {
                    Playground.DrawMissileBoss(missileAlienDefault, player); // Affichage du missile de l'alien
                }
            }
        }

        frameNumber++;

        if (frameNumber % 5 == 0) // Vitesse de l'invaders
        {
            foreach (Alien invader in aliensDefault)
            {
                invader.moveRight(); // Déplacement alien droite
                invader.moveLeft(); // Déplacement alien gauche
            }
        }

        if (manche == 10) // Déplacement du boss lors de la manche 2
        {
            if (frameNumber % 15 == 0) // Vitesse du boss1
            {
                boss1.moveRight();
                boss1.moveLeft();
            }
        }

        for (int i = missileJoueur.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste de missile à l'envers
        {
            missileJoueur missileDefault = missileJoueur[i];

            if (frameNumber % 1 == 0) // Vitesse du missile
            {
                missileDefault.UpdateMisille(); // Déplacement du missile
                if (!missileDefault.missileIsLaunched)
                {
                    missileJoueur.RemoveAt(i);
                }
            }
        }

        for (int i = missileJoueur.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste des missiles
        {
            missileJoueur missileDefault = missileJoueur[i];

            foreach (Alien invader in aliensDefault)
            {
                invader.TakeDamage(missileDefault); // Dégât du missile sur l'invader
            }

            if (missileDefault.missileIsTouched)
            {
                missileJoueur.RemoveAt(i);
            }
        }

        if (manche == 10)
        {
            for (int i = missileJoueur.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste des missiles
            {
                missileJoueur missileDefault = missileJoueur[i];

                foreach (Alien invader in aliensDefault)
                {
                    boss1.TakeDamage(missileDefault); // Dégât du missile sur le boss
                }

                if (missileDefault.missileIsTouched)
                {
                    missileJoueur.RemoveAt(i);
                }
            }
        }

        for (int i = aliensDefault.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste des aliens à l'envers
        {
            Alien invader = aliensDefault[i];

            if (!invader.AlienisAlife && !invader.BoomNotArrived)
            {
                aliensDefault.RemoveAt(i);
                Store.score += 23;
            }

            if (aliensDefault.Count == 0) // Savoir si le joueur gagne la partie
            {
                alienspawn = false;
                manche++;

                if (manche == 100)
                {
                    GameWinEND = true;
                }
            }
        }

        foreach (Alien invader in aliensDefault)
        {
            if (frameNumber % 20 == 0) // Vitesse avant qu'un autre missile soit tiré
            {
                if (random.Next(0, 100) < 20) // Tir aléatoire de l'alien avec une probabilité de 20%
                {
                    missileAlien missileAlienDefault = new missileAlien(25);
                    missileAlien.Add(missileAlienDefault);

                    invader.chargementAlien(missileAlienDefault);
                    invader.dropMissileAlien();
                }
            }
        }

        if (manche == 10)
        {
            if (frameNumber % 20 == 0) // Vitesse avant qu'un autre missile soit tiré
            {
                if (random.Next(0, 100) < 20) // Tir aléatoire de l'alien avec une probabilité de 20%
                {
                    missileAlien missileAlienDefault = new missileAlien(25);
                    missileAlien.Add(missileAlienDefault);

                    boss1.chargementAlien(missileAlienDefault);
                    boss1.dropMissileAlien();
                }
            }
        }

        for (int i = missileAlien.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste de missile à l'envers
        {
            missileAlien missileDefaultAlien = missileAlien[i];

            if (frameNumber % 3 == 0) // Vitesse du missile
            {
                missileDefaultAlien.UpdateMisille(); // Déplacement du missile
                if (!missileDefaultAlien.missileIsLaunched)
                {
                    missileAlien.RemoveAt(i);
                }
            }
        }

        foreach (missileAlien missileDefaultAlien in missileAlien)
        {
            player.TakeDamage(missileDefaultAlien); // Dégât du missile sur l'invader

            for (int i = coeurdefault.Count - 1; i >= 0; i--) // Boucle qui parcourt ma liste des coeurs affichés à l'envers
            {
                Hpcoeur1 coeur = coeurdefault[i];

                // Quand le joueur prend un missile d'un alien, un cœur se supprime
                if (player.hpDefault <= 99 && player.hpDefault >= 51)
                {
                    if (!player.CoeurRemove)
                    {
                        coeurdefault.RemoveAt(i);
                        player.CoeurRemove = true;
                    }
                }
                if (player.hpDefault <= 50 && player.hpDefault >= 1)
                {
                    if (!player.CoeurRemove)
                    {
                        coeurdefault.RemoveAt(i);
                        player.CoeurRemove = true;
                    }
                }
            }

            if (!player.PlayerisAlife)
            {
                GameLooseEND = true; // La partie est finie car le joueur est mort
            }
        }

        // Temps d'attente
        Thread.Sleep(3);

        // Menu partie gagnée
        while (GameWinEND)
        {
            ConsoleColor defaultColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = defaultColor;

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            Playground.Clear();
            Playground.DrawScore(Store.score);



            switch (keyPressed.Key)
            {

                case ConsoleKey.W:
                    if (SousMenu < 3)
                    {
                        SousMenu++;
                    }
                    break;

                case ConsoleKey.S:
                    if (SousMenu > 1)
                    {
                        SousMenu--;
                    }
                    break;

                case ConsoleKey.Enter:
                    if (SousMenu == 3)
                    {
                        SelectSave = true;
                    }

                    if (SousMenu == 2)
                    {
                        replay = true;
                    }

                    if (SousMenu == 1)
                    {
                        replay = false;
                        Environment.Exit(0);
                    }
                    break;
            }


            // Affichage du Menu principal
            MenuGameOver.DrawBackgrounGamOver();

            if (SousMenu == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            MenuGameOver.DrawSave();
            Console.ForegroundColor = defaultColor;

            if (SousMenu == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            MenuGameOver.DrawReplay();
            Console.ForegroundColor = defaultColor;

            if (SousMenu == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            MenuGameOver.DrawQuit();
            Console.ForegroundColor = defaultColor;

            if (SelectSave)
            {
                Playground.Clear();
                Console.ResetColor();
                break;
            }

            if (replay)
            {
                Playground.Clear();
                Console.ResetColor();
                clear = 8;
                frameNumber = 0;
                manche = 1;
                Playground.Init();
                missileJoueur.Clear();
                missileAlien.Clear();
                aliensDefault.Clear();
                coeurdefault.Clear();
                player = new Player(Console.WindowWidth / 2 - 5, Console.WindowHeight - 5, 150);
                boss1 = null;
                Store.score = 0;
                SelectJouer = false;
                GameLooseEND = false;
                GameWinEND = false;
            }
        }

        // Menu partie perdue
        while (GameLooseEND)
        {
            ConsoleColor defaultColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = defaultColor;

            ConsoleKeyInfo keyPressed = Console.ReadKey(true);

            Playground.Clear();
            Playground.DrawScore(Store.score);



            switch (keyPressed.Key)
            {

                case ConsoleKey.W:
                    if (SousMenu < 3)
                    {
                        SousMenu++;
                    }
                    break;

                case ConsoleKey.S:
                    if (SousMenu > 1)
                    {
                        SousMenu--;
                    }
                    break;

                case ConsoleKey.Enter:
                    if (SousMenu == 3)
                    {
                        SelectSave = true;
                    }

                    if (SousMenu == 2)
                    {
                        replay = true;
                    }

                    if (SousMenu == 1)
                    {
                        replay = false;
                        Environment.Exit(0);
                    }
                    break;
            }


            // Affichage du Menu principal
            MenuGameOver.DrawBackgrounGamOver();

            if (SousMenu == 3)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }

            MenuGameOver.DrawSave();
            Console.ForegroundColor = defaultColor;

            if (SousMenu == 2)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            MenuGameOver.DrawReplay();
            Console.ForegroundColor = defaultColor;

            if (SousMenu == 1)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            MenuGameOver.DrawQuit();
            Console.ForegroundColor = defaultColor;

            if (SelectSave)
            {
                Playground.Clear();
                Console.ResetColor();
                break;
            }

            if (replay)
            {
                Playground.Clear();
                Console.ResetColor();
                clear = 8;
                frameNumber = 0;
                manche = 1;
                Playground.Init();
                missileJoueur.Clear();
                missileAlien.Clear();
                aliensDefault.Clear();
                coeurdefault.Clear();
                player = new Player(Console.WindowWidth / 2 - 5, Console.WindowHeight - 5, 150);
                boss1 = null;
                Store.score = 0;
                SelectJouer = false;
                GameLooseEND = false;
                GameWinEND = false;
            }

        }

        while (SelectSave)
        {
            MenuGameOver.DrawSave();//Affichage du titre
            Console.SetCursorPosition(Console.WindowWidth / 3 + 14, 20);
            Console.WriteLine("Partie terminée. Entrez votre pseudo :");

            Store.SaveScore();

        }
    }
}
while (play);
