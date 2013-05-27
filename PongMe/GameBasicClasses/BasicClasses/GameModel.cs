using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;
using GameBasicClasses.Gamer;
using GameBasicClasses.Obstacles.Bonus;
using GameBasicClasses.Obstacles.Paddle;

namespace GameBasicClasses.BasicClasses
{
    public class GameModel : Model
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
        }

        public void addBall(Ball b)
        {
            this.listeBall.Add(b);
        }

        public void addBonus(Bonus b)
        {
            this.listeBonus.Add(b);
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
            if (e == Keys.Space)
            {
                foreach (Ball ball in this.ListeBall)
                {
                    if (stop)
                    {
                        ball.isMoving = false;
                    }
                    else
                    {
                        ball.isMoving = true;
                    }
                }
            }
            foreach (GameBasicClasses.Gamer.Gamer g in this.listeGamer)
            {
                if (g is Human)
                {
                    g.run(e);
                }
            }
        }

        public List<Paddle> listePaddle()
        {
            List<Paddle> liste = new List<Paddle>();
            foreach (GameBasicClasses.Gamer.Gamer g in this.ListeGamer)
            {
                liste.Add(g.Paddle);
            }
            return liste;
        }
    }
}
