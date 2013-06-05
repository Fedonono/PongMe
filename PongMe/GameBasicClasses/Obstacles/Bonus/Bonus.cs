using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;
using System.Drawing;

namespace GameBasicClasses.Obstacles.Bonus
{
    public abstract class Bonus : Obstacle
    {
        public bool Active { get; protected set; }

        private int timeout;
        public int Timeout
        {
            get { return timeout; }
            set {
                if (value <= 0)
                {
                    value = 5;
                }
                timeout = value;
            }
        }

        protected Ball ball;
        protected List<GameBasicClasses.Gamer.Gamer> gamers;

        public Bonus(int clientWidth, int clientHeight, int timeout, Vector position)
        {
            this.ClientHeight = clientHeight;
            this.ClientWidth = clientWidth;
            this.Timeout = timeout;
            this.Image = null;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Blue;
            this.InitialColor = this.Color;
            this.Position = position;
            this.Bounds = new Rectangle((int)this.Position.X, (int)this.Position.Y, 50, 50);
            this.InitialBounds = this.Bounds;
        }

        /// <summary>
        /// Decremente le timeout, lance la fin du bonus s'il est à 0.
        /// Retourne true si le bonus est terminé.
        /// </summary>
        /// <returns></returns>
        public bool CheckTimeOut()
        {
            this.timeout--;
            if (this.timeout == 0)
            {
                this.Active = false;
                this.StopBonus();
                return true;
            }
            return false;
        }

        public void StartTimeOut(Ball ball)
        {
            this.ball = ball;
            this.gamers = CurrentGame.GetInstance().GameModel.ListeGamer;
            this.Active = true;
            this.RunBonus();
        }

        protected abstract void StopBonus();

        protected abstract void RunBonus();
    }
}
