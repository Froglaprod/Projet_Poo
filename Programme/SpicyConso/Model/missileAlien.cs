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
    /// <summary>
    /// La classe Missile alien contient les caratéristques de bases du missile alien et les actions qu'il peut effectuer
    /// </summary>
    public class missileAlien : Missile
    {

        public int height = 40;

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

                if (this.y == height - 5)// Quand il dépasse la bordure il s'enlève
                {
                    missileIsLaunched = false;
                }
            }

        }
    }
}
