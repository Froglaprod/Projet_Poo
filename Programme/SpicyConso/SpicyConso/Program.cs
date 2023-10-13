using Display;
using Model;
using Storage;

bool SelectJouer = false;// Savoir si on a sélectionner jouer
bool alienspawn = false;// Savoir si les aliens onz spawn
bool GameStart = false;//Si la partie a commencé ou non
bool MenuEndDiplay = false;//Si on affiche game over ou non
bool GameLooseEND = false;//Si la partie perdu est fini ou non
bool GameWinEND = false;//Si la partie est gagner fini ou non
int clear = 8;
uint frameNumber = 0; // Comptage du nombre d'images à affichées
int manche = 1;
Playground.Init();// Initialisation de la config playground

Random random = new Random();// Instancie le random
List<missileJoueur> missileJoueur = new List<missileJoueur>();
List<missileAlien> missileAlien = new List<missileAlien>();
List<Alien> aliensDefault = new List<Alien>();
List<Hpcoeur1> coeurdefault = new List<Hpcoeur1>();
Player player = new Player(Console.WindowWidth / 2 - 5, Console.WindowHeight - 5, 150);
AlienBoss1 boss1 = null;




//Nombre de hp (coeur) a creer
for (int i = 0; i < 2; i++)
{
    Hpcoeur1 coeur = new Hpcoeur1(i * 6, 1);
    coeurdefault.Add(coeur);
}

//Menu principale
while (true)
{
    ConsoleKeyInfo keyPressed = Console.ReadKey(true);

    switch (keyPressed.Key)
    {
        case ConsoleKey.Escape:

            break;

        case ConsoleKey.W:
            if (Menu.SousMenu < 3)
            {
                Menu.SousMenu++;
            }
            break;

        case ConsoleKey.S:
            if (Menu.SousMenu > 1)
            {
                Menu.SousMenu--;
            }
            break;

        case ConsoleKey.Enter:
            if (Menu.SousMenu == 3)
            {
                SelectJouer = true;
            }

            break;
    }


    ConsoleColor defaultColor = Console.ForegroundColor;

    // Affichage du Menu principal
    Menu.DrawTitre();

    if (Menu.SousMenu == 3)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }

    Menu.DrawJouer();
    Console.ForegroundColor = defaultColor;

    if (Menu.SousMenu == 2)
    {
        Console.ForegroundColor = ConsoleColor.Blue;
    }
    Menu.DrawScore();
    Console.ForegroundColor = defaultColor;

    if (Menu.SousMenu == 1)
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
}


//Affichage décompte 
Playground.DrawDecount();


//Partie lance
while (SelectJouer)
{
    GameStart = true;//La partie a commencé

    if (!alienspawn)
    {
        if (manche != 10)
        {
            //Nombre d'invaders à créer
            for (int i = 0; i < 8; i++)
            {
                Alien invader = new Alien(i * 16, 5, 30);
                aliensDefault.Add(invader);
            }
        }


        //Apparition du boss
        if (manche == 10)
        {
            boss1 = new AlienBoss1(Console.WindowWidth / 2 - 16, 5, 500);
        }

        alienspawn = true;
    }

    // Action de l'utilisateur par apport a sa saisie
    if (Console.KeyAvailable) //Si l'utilisateur presse une touche
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
                missileJoueur missileJoueurDefault = new missileJoueur(10);//Initialisation du missile de base
                missileJoueur.Add(missileJoueurDefault);
                player.chargement(missileJoueurDefault);//On charge le missile dans le joueeur
                player.dropMissile();//On lance le missile
                break;
        }
    }

    if (frameNumber % clear == 0) //Affichage
    {

        Playground.Clear();//Clear de la console
        Playground.DrawSeparation();//Affichage séparation du haut

        foreach (Hpcoeur1 coeur in coeurdefault)
        {
            Playground.DrawHP(coeur);//Affichage des hps (coeurs)
        }

        Playground.DrawScore(Store.score);
        Playground.DrawManche(manche);

        foreach (Alien invader in aliensDefault)
        {
            Playground.DrawAlien(invader);//Affichage de l'alien
            Playground.DrawAlienBOOM(invader);//Affichage de l'alien mort
        }

        Playground.DrawPlayer(player);//Affichage du joueur

        foreach (Alien invader in aliensDefault)
        {
            foreach (missileJoueur missileDefault in missileJoueur)
            {
                Playground.DrawMissileJoueur(missileDefault, invader);// Affichage du missile du joueur
            }
        }

        foreach (Alien invader in aliensDefault)
        {
            foreach (missileAlien missileAlienDefault in missileAlien)
            {
                Playground.DrawMissileAlien(missileAlienDefault, player);// Affichage du missile de l'alien
            }
        }
        if (manche == 10)
        {
            Playground.DrawBOSSeasy(boss1);//Affichage du boss

            foreach (missileAlien missileAlienDefault in missileAlien)
            {
                
                Playground.DrawMissileBoss(missileAlienDefault, player);// Affichage du missile de l'alien
            }
        }
    }

    frameNumber++;

    if (frameNumber % 5 == 0)//Vitesse de l'invaders
    {
        foreach (Alien invader in aliensDefault)
        {
            invader.moveRight();//Déplacement alien droite
            invader.moveLeft();//Déplacement alien gauche
        }
    }

    if (manche == 10)//Déplacement du boss lors de la manche 2
    {
        if (frameNumber % 15 == 0)//Vitesse du boss1
        {
            boss1.moveRight();
            boss1.moveLeft();
        }
    }



    for (int i = missileJoueur.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste de missile a l'envers 
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

    for (int i = missileJoueur.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste des missiles
    {
        missileJoueur missileDefault = missileJoueur[i];

        foreach (Alien invader in aliensDefault)
        {
            invader.TakeDamage(missileDefault); // Dégat du missile sur l'invader
        }

        if (missileDefault.missileIsTouched)
        {
            missileJoueur.RemoveAt(i);
        }
    }

    if (manche == 10)
    {
        for (int i = missileJoueur.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste des missiles
        {
            missileJoueur missileDefault = missileJoueur[i];

            foreach (Alien invader in aliensDefault)
            {
                boss1.TakeDamage(missileDefault); // Dégat du missile sur le boss
            }

            if (missileDefault.missileIsTouched)
            {
                missileJoueur.RemoveAt(i);
            }
        }
    }

    

    for (int i = aliensDefault.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste des aliens à l'envers 
    {
        Alien invader = aliensDefault[i];

        if (!invader.AlienisAlife && !invader.BoomNotArrived)
        {
            aliensDefault.RemoveAt(i);
            Store.score += 23;
        }

        if (aliensDefault.Count == 0)//Savoir si le joueur gagne la partie
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
            if (random.Next(0, 100) < 20) //Tire aléatoire de l'alien avec une probabilité de 20%
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
            if (random.Next(0, 100) < 20) //Tire aléatoire de l'alien avec une probabilité de 20%
            {
                missileAlien missileAlienDefault = new missileAlien(25);
                missileAlien.Add(missileAlienDefault);

                boss1.chargementAlien(missileAlienDefault);
                boss1.dropMissileAlien();
            }
        }


    }



    for (int i = missileAlien.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste de missile a l'envers 
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

        player.TakeDamage(missileDefaultAlien); // Dégat du missile sur l'invader

        for (int i = coeurdefault.Count - 1; i >= 0; i--)//Boucle qui parcours ma liste des coeurs afficher a l'envers 
        {
            Hpcoeur1 coeur = coeurdefault[i];

            //Quand le joueur prend un missile d'in alien un coueur se supprime

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
            GameLooseEND = true;//La partie est fini car le joueur est mort
        }

    }

    //Temp d'attente
    Thread.Sleep(3);

    //Menu partie gagnée
    while (GameWinEND)
    {
        if (!MenuEndDiplay)
        {
            Playground.Clear();
            MenuWin.DrawBackgroundWin();// Affichez le fond du menu
            Playground.DrawScore(Store.score);
            MenuEndDiplay = true;
        }

    }

    //Menu partie perdu
    while (GameLooseEND)
    {
        if (!MenuEndDiplay)
        {
            Playground.Clear();
            MenuGameOver.DrawBackgrounGamOver(); // Affichez le fond du menu
            Playground.DrawScore(Store.score);
            MenuEndDiplay = true;
        }
    }

}
