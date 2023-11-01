///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class AlienBoss1 : Alien
    {
        /// <summary>
        /// Constructor du boss alien pour définir ces paramétres par défault
        /// </summary>
        /// <param name = "x" ></ param >
        /// < param name="y"></param>
        public AlienBoss1(int x, int y, int hpDefault) : base(x, y, hpDefault)
        {
            this.x = x;
            this.y = y;
            this.hpDefault = hpDefault;
        }

        /// <summary>
        /// On bouge a droite de 1, et dés qu'on arrive a la fin de la fenetre on chnage de sens
        /// </summary>
        public override void moveRight()
        {
            if (invaderDirection)
            {
                this.x += 1;

                if (this.x == Console.WindowWidth - 32)
                {
                    invaderDirection = false;
                }
            }
        }


        /// <summary>
        /// On bouge a gauche de 1, et dés qu'on arrive a la fin de la fenetre on change de sens
        /// </summary>
        public override void moveLeft()
        {
            if (!invaderDirection)
            {
                this.x -= 1;

                if (this.x == 1)
                {
                    invaderDirection = true;
                }
            }
        }
    }
}
