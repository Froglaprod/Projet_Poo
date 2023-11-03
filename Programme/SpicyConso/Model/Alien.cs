///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
using System.Reflection;

namespace Model
{
    /// <summary>
    /// La classe Alien contient les caratéristques de bases de l'alien et contient les actions qu'il peut effectuer
    /// </summary>
    public class Alien
    {
        List<missileAlien> missileAlien = new List<missileAlien>();
        //Largeur de la fenetre
        public const int width = 150;
        //Position x de l'invader
        public int x;
        //Position y de l'invader
        public int y;
        //Point de vie de l'invader
        public int hpDefault;
        //Connaitre si il va a droite ou a gauche
        public bool invaderDirection = true;
        //Connaitre si l'alien est vivant ou non
        public bool AlienisAlife = true;
        //Connaitre si l'afficahge de l'alien a été afficher
        public bool BoomNotArrived = true;

        /// <summary>
        /// Constructor de l'invader pour définir ces paramétres par défault
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Alien(int x, int y, int hpDefault)
        {
            this.x = x;
            this.y = y;
            this.hpDefault = hpDefault;
        }

        /// <summary>
        /// On bouge a droite de 1, et dés qu'on arrive a la fin de la fenetre on descend de 2
        /// </summary>
        public virtual void moveRight()
        {
            if (invaderDirection)
            {
                this.x += 1;

                if (this.x == width - 13)
                {
                    this.y += 4;
                    invaderDirection = false;
                }
            }
        }


        /// <summary>
        /// On bouge a gauche de 1, et dés qu'on arrive a la fin de la fenetre on descend de 2
        /// </summary>
        public virtual void moveLeft()
        {
            if (!invaderDirection)
            {
                this.x -= 1;

                if (this.x == 1)
                {
                    this.y += 4;
                    invaderDirection = true;
                }
            }
        }

        /// <summary>
        /// On ajoute nos missile dans l'alien
        /// </summary>
        public virtual void chargementAlien(missileAlien missileDefault)
        {
            this.missileAlien.Add(missileDefault);
        }

        /// <summary>
        /// On lance nos missiles et on les enlevent du alien
        /// </summary>
        public missileAlien dropMissileAlien()
        {
            missileAlien Missiledrop = this.missileAlien.First();
            missileAlien.Remove(Missiledrop);
            Missiledrop.x = x;
            Missiledrop.y = y;
            Missiledrop.missileIsLaunched = true;
            return Missiledrop;
        }

        /// <summary>
        ///  On inflige des dégats a l'alien si il est toucher par le missile du joueur
        /// </summary>
        /// <param name="Missilejoueur"></param>
        public virtual void TakeDamage(missileJoueur Missilejoueur)
        {
            //Quand le missile touche l'invader on rentre dans le if
            if ((Missilejoueur.x >= this.x - 6 && Missilejoueur.x <= this.x + 6) && Missilejoueur.y == this.y)
            {
                Missilejoueur.missileIsTouched = true;
                this.hpDefault -= Missilejoueur.damage;
                if (this.hpDefault < 0)
                {
                    AlienisAlife = false;
                }
            }
        }
    }
}
