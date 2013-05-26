using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Gamer;
using System.Drawing;

namespace GameBasicClasses.BasicClasses
{
    public class GameFactory
    {
        public static GameModel defaultGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(0.5f, 35, Color.Empty, GameBasicClasses.Properties.Resources.Ball, 1000, 600));
            gm.addBall(new Ball(0.2f, 35, Color.Empty, GameBasicClasses.Properties.Resources.Ball, 1000, 600));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.Raquette, 20, 50, 10, 1000, 600);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.Raquette, 20, 50, 10, 1000, 600);
            gm.addGamer(new Human(true, Keys.Up, Keys.Down, p));
            gm.addGamer(new Human(false, Keys.Z, Keys.S, p2));
            return gm;
        }
    }
}
