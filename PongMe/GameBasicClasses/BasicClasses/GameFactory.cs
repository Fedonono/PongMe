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
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, true, 1460, 911);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 10, true, 1460, 911);
            gm.addGamer(new AI(Keys.Up, Keys.Down, p2));
            gm.addGamer(new AI(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel onePlayerGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(0.8f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, 1460, 911));
            gm.addBall(new Ball(0.4f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, 1460, 911));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, true, 1460, 911);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 10, true, 1460, 911);
            gm.addGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.addGamer(new AI(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel twoPlayerGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(0.8f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, 1460, 911));
            gm.addBall(new Ball(0.4f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, 1460, 911));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, true, 1460, 911);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 10, true, 1460, 911);
            gm.addGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.addGamer(new Human(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel fourPlayerGame()
        {
            GameModel gm = new GameModel();
            gm.addBall(new Ball(0.8f, 50, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, 1460, 911));
            gm.addBall(new Ball(0.4f, 40, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, 1460, 911));
            gm.addBall(new Ball(0.5f, 20, Color.Empty, GameBasicClasses.Properties.Resources.adventure_core_avatar_by_the_rebexorcist_d3gzj02, 1460, 911));
            gm.addBall(new Ball(1f, 30, Color.Empty, GameBasicClasses.Properties.Resources.fact_core_avatar_by_the_rebexorcist_d3h18dn, 1460, 911));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, true, 1460, 911);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 10, true, 1460, 911);
            Paddle p3 = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 2, 14, 60, 10, true, 1460, 911);
            Paddle p4 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 2, 14, 60, 10, true, 1460, 911);
            gm.addGamer(new Human(Keys.Z, Keys.S, p));
            gm.addGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.addGamer(new Human(Keys.T, Keys.G, p3));
            gm.addGamer(new Human(Keys.I, Keys.K, p4));
            return gm;
        }
    }
}
