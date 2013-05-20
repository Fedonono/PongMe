using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public class GameFactory
    {
        public static GameModel defaultGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(3, 10, 500, 300, 1000, 600));
            Paddle p = new Paddle(0, 0, 20, 100, 30, 1000, 600);
            Paddle p2 = new Paddle(880, 0, 20, 100, 30, 1000, 600);
            gm.addGamer(new Human(Keys.Up, Keys.Down, p));
            gm.addGamer(new AI(Keys.Z, Keys.S, p2));
            return gm;
        }
    }
}
