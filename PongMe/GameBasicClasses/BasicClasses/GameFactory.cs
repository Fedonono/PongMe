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
            gm.addBall(new Ball(0.8f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, 1460, 911));
            gm.addBall(new Ball(0.4f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, 1460, 911));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, 1460, 911);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 10, 1460, 911);
            gm.addGamer(new AI(Keys.Up, Keys.Down, p2));
            gm.addGamer(new AI(Keys.Z, Keys.S, p));
            return gm;
        }
    }
}
