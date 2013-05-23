using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.Obstacles;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public class GameModel : Model
    {
        private List<Ball> listeBall;
        private List<Brick> listeBonus;
        private List<Wall> listeWall;
        private List<Gamer> listeGamer;

        public GameModel()
        {
            this.listeBall = new List<Ball>();
            this.listeBonus = new List<Brick>();
            this.listeWall = new List<Wall>();
            this.listeGamer = new List<Gamer>();
        }

        public void addBall(Ball b)
        {
            this.listeBall.Add(b);
        }

        public void addBonus(Brick b)
        {
            this.listeBonus.Add(b);
        }

        public void addWall(Wall w)
        {
            this.listeWall.Add(w);
        }

        public void addGamer(Gamer g)
        {
            if (this.listeGamer.Count < 4)
            {
                this.listeGamer.Add(g);
            }
        }

        public void keyEvent(object sender, KeyEventArgs e)
        {
            foreach (Gamer g in this.listeGamer)
            {
                if (g is Human)
                {
                    g.run(sender, e);
                }
            }
        }

        public Gamer getGamer(int i)
        {
            if (this.listeGamer.Count - 1 > i)
            {
                return this.listeGamer.ElementAt(i);
            }
            return null;
        }
    }
}
