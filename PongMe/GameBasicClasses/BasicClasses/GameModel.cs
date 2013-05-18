using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.Obstacles;

namespace GameBasicClasses.BasicClasses
{
    public class GameModel : Model
    {
        private LinkedList<Ball> listeBall;
        private LinkedList<Racket> listeRacket;
        private LinkedList<Bonus> listeBonus;
        private LinkedList<Wall> listeWall;

        public GameModel()
        {
            this.listeBall = new LinkedList<Ball>();
            this.listeRacket = new LinkedList<Racket>();
            this.listeBonus = new LinkedList<Bonus>();
            this.listeWall = new LinkedList<Wall>();
        }
    }
}
