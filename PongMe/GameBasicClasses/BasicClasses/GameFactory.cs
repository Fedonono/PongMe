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
        public static GameModel AIGame()
        {
            GameModel gm = new GameModel();
            gm.AddBall(new Ball(1.5f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1.2f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, CurrentGame.width, CurrentGame.height));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            gm.AddGamer(new AI(Keys.Up, Keys.Down, p2));
            gm.AddGamer(new AI(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel OnePlayerGame()
        {
            GameModel gm = new GameModel();
            gm.AddBall(new Ball(1.5f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1.2f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, CurrentGame.width, CurrentGame.height));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            gm.AddGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.AddGamer(new AI(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel TwoPlayerGame()
        {
            GameModel gm = new GameModel();
            gm.AddBall(new Ball(1.8f, 30, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1.5f, 30, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, CurrentGame.width, CurrentGame.height));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            gm.AddGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.AddGamer(new Human(Keys.Z, Keys.S, p));
            return gm;
        }

        public static GameModel FourPlayerGame()
        {
            GameModel gm = new GameModel();
            gm.AddBall(new Ball(1.6f, 50, Color.Empty, GameBasicClasses.Properties.Resources.emotion_core_avatar_by_the_rebexorcist_d3h0qpp, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1.5f, 40, Color.Empty, GameBasicClasses.Properties.Resources.space_core_avatar_by_the_rebexorcist_d3h0wyn, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1.2f, 20, Color.Empty, GameBasicClasses.Properties.Resources.adventure_core_avatar_by_the_rebexorcist_d3gzj02, CurrentGame.width, CurrentGame.height));
            gm.AddBall(new Ball(1f, 30, Color.Empty, GameBasicClasses.Properties.Resources.fact_core_avatar_by_the_rebexorcist_d3h18dn, CurrentGame.width, CurrentGame.height));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batred, 1, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p3 = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 2, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            Paddle p4 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.batblue, 2, 14, 60, 20, true, CurrentGame.width, CurrentGame.height);
            gm.AddGamer(new Human(Keys.Z, Keys.S, p));
            gm.AddGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.AddGamer(new Human(Keys.T, Keys.G, p3));
            gm.AddGamer(new Human(Keys.I, Keys.K, p4));
            return gm;
        }
    }
}
