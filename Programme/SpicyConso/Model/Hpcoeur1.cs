using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Hpcoeur1
    {
        //Position x de l'hp
        public int x;
        //Position y de l'hp
        public int y;

        /// <summary>
        /// Constructor d'un hp pour définir ces paramétres par défault
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public Hpcoeur1(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
