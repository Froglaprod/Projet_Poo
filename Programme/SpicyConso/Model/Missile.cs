///ETML
///Auteur : Mathis Botteau
///Date   : 28.08.2023
///Description : Le but de ce projet est de creer un jeux qui est inspiré du celebre jeu space invader
///
using System.Reflection;

namespace Model
{
    public class Missile
    {
        //Dégat du missile
        public int damage;
        //Etat du missile
        public bool missileIsLaunched = false;
        //Position x du missile
        public int x;
        //Position y du missile
        public int y;
    }
}
