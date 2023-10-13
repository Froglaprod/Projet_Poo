using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class missileJoueur : Missile
    {  //Connaitre si le missile a toucher l'alien
        public bool missileIsTouched = false;

        /// <summary>
        /// Constructor du missile avec ces valeurs par défault
        /// </summary>
        /// <param name="damage"></param>
        public missileJoueur(int damage)
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

                this.y--;

                if (this.y == 4)// Quand il dépasse la bordure il s'enlève
                {
                    missileIsLaunched = false;
                }
            }

        }
    }
}
