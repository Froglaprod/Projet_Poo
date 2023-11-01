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
    public class missileAlien : Missile
    {

        /// <summary>
        /// Constructor du missile avec ces valeurs par défault
        /// </summary>
        /// <param name="damage"></param>
        public missileAlien(int damage)
        {
            this.damage = damage;
        }


        /// <summary>
        /// On déplace notre missile
        /// </summary>
        public void UpdateMisille()
        {
            if (missileIsLaunched)
            {

                this.y++;

                if (this.y == Alien.width - 5)// Quand il dépasse la bordure il s'enlève
                {
                    missileIsLaunched = false;
                }
            }

        }
    }
}
