using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;
using GameBasicClasses.Gamer;
using GameBasicClasses.Obstacles.Bonus;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Options;

namespace GameBasicClasses.BasicClasses
{
    public class GameModel
    {
        private List<Ball> listeBall;
        public List<Ball> ListeBall { get { return this.listeBall; } }
        private List<Bonus> listeBonus;
        public List<Bonus> ListeBonus { get { return this.listeBonus; } }
        private List<Brick> listeBrick;
        public List<Brick> ListeBrick { get { return this.listeBrick; } }
        private List<GameBasicClasses.Gamer.Gamer> listeGamer;
        public List<GameBasicClasses.Gamer.Gamer> ListeGamer { get { return this.listeGamer; } }

        public GameModel()
        {
            this.listeBall = new List<Ball>();
            this.listeBonus = new List<Bonus>();
            this.listeBrick = new List<Brick>();
            this.listeGamer = new List<GameBasicClasses.Gamer.Gamer>();
            this.WeathleyPoint = 0;
        }

        public void addBall(Ball b)
        {
            this.listeBall.Add(b);
        }

        public void addBonus(Bonus b)
        {
            this.listeBonus.Add(b);
        }

        public void addBonus(List<Bonus> b)
        {
            this.listeBonus.AddRange(b);
        }

        public void addBrick(Brick b)
        {
            this.listeBrick.Add(b);
        }

        public void addGamer(GameBasicClasses.Gamer.Gamer g)
        {
            if (this.listeGamer.Count < 4)
            {
                this.listeGamer.Add(g);
            }
        }

        public void keyEvent(Keys e, bool stop)
        {
            if (e == GamerOptions.Launch)
            {
                foreach (Ball ball in this.ListeBall)
                {
                    ball.isMoving = !stop;
                }
            }
            else if (e == GamerOptions.Stop && CurrentGame.GetInstance().stopped == false)
            {
                CurrentGame.GetInstance().StopGame();
            }
            else if (e == GamerOptions.Stop && CurrentGame.GetInstance().stopped == true)
            {
                CurrentGame.GetInstance().StartGame();
            }
            else if (e == GamerOptions.Pause)
            {
                CurrentGame.GetInstance().ToggleGame();
            }
            foreach (GameBasicClasses.Gamer.Gamer g in this.listeGamer)
            {
                g.run(e);
            }
        }

        public List<Paddle> listePaddle(bool corresponding, int id, Paddle reference)
        {
            List<Paddle> liste = new List<Paddle>();
            foreach (GameBasicClasses.Gamer.Gamer g in this.ListeGamer)
            {
                if (!corresponding || (corresponding && g.Paddle.Id == id && g.Paddle != reference))
                {
                    liste.Add(g.Paddle);
                }
            }
            return liste;
        }

        public int WeathleyPoint { get; set; }
    }
}
