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

                if (this.y == Console.WindowHeight - 5)// Quand il dépasse la bordure il s'enlève
                {
                    missileIsLaunched = false;
                }
            }

        }
    }
}
