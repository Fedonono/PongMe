using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Gamer;

namespace GameBasicClasses.BasicClasses
{
    public class GameFactory
    {
        public static GameModel defaultGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(5, 50, 1000, 600));
            Paddle p = new Paddle(true, 20, 100, 30, 1000, 600);
            Paddle p2 = new Paddle(false, 20, 100, 30, 1000, 600);
            gm.addGamer(new Human(Keys.Up, Keys.Down, p));
            gm.addGamer(new Human(Keys.Z, Keys.S, p2));
            return gm;
        }
    }
}
