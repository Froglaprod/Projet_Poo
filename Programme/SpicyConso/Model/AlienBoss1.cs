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
    }
}
