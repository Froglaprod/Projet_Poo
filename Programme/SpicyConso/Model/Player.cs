///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
namespace Model
{
    public class Player
    {
        List<missileJoueur> missileJoueur = new List<missileJoueur>();
        //Position x du joueur
        public int x;
        //Position y du joueur
        public int y;
        //Point de vie du joueur
        public int hpDefault;
        //Connaitre si le missile a toucher le joueur
        public bool missileIsTouched = false;
        //Connaitre si le jouer est vivant ou non
        public bool PlayerisAlife = true;
        //Si on a deja enlevé le coeur ou nn
        public bool CoeurRemove = true;

        /// <summary>
        /// Constructor du joueur pour définir ces paramétres par défault
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Player(int x, int y, int hpDefault)
        {
            this.hpDefault = hpDefault;
            this.x = x;
            this.y = y;
        }


        /// <summary>
        /// On décale à droite de 1 l'axe x du joueur
        /// </summary>
        public void moveRight()
        {
            x++;

            if (x == Console.WindowWidth - 8)
            {
                this.x = 0;
            }
        }

        /// </summary>
        // On décale vers le bas de 1 l'axe y du joueur
        /// </summary>
        public void moveDown()
        {
            if (y < Console.WindowHeight - 4)
            {
                y++;
            }
        }

        /// </summary>
        // On décale vers le haut de 1 l'axe y du joueur
        /// </summary>
        public void moveUp()
        {
            if (y > 5)
            {
                y--;
            }
        }

        

        /// <summary>
        /// On décale à gauche de 1 l'axe x du joueur
        /// </summary>
        public void moveLeft()
        {
            x--;

            if (x == 0)
            {
                this.x = Console.WindowWidth - 8;
            }
        }

        /// <summary>
        /// On ajoute nos missile dans le joueur
        /// </summary>
        public void chargement(missileJoueur missileDefault)
        {
            this.missileJoueur.Add(missileDefault);
        }

        /// <summary>
        /// On lance nos missiles et on les enlevent du joueur
        /// </summary>
        public Missile dropMissile()
        {
            missileJoueur Missiledrop = this.missileJoueur.First();
            missileJoueur.Remove(Missiledrop);
            Missiledrop.x = x;
            Missiledrop.y = y;
            Missiledrop.missileIsLaunched = true;
            return Missiledrop;
        }

        /// <summary>
        ///  On inflige des dégats a au joueur si il est toucher par le missile de l'alien
        /// </summary>
        /// <param name="MissileAlien"></param>
        public void TakeDamage(missileAlien MissileAlien)
        {
            //Quand le missile touche l'invader on rentre dans le if
            if ((MissileAlien.x >= this.x - 7  && MissileAlien.x <= this.x ) && MissileAlien.y == this.y)
            {
                this.hpDefault -= MissileAlien.damage;
                CoeurRemove = false;//On donne la possibilité de supprimer un coeur

                if (this.hpDefault < 0)
                {
                    PlayerisAlife = false;
                }
            }
        }
    }
}
