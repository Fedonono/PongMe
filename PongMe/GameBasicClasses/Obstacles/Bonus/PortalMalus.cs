using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class PortalMalus : Bonus
    {
        public PortalMalus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.portalMalus;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void StopBonus()
        {
        }

        protected override void RunBonus()
        {
            List<GameBasicClasses.Obstacles.Paddle.Paddle> liste = new List<Paddle.Paddle>();
            foreach (Gamer.Gamer g in this.gamers)
            {
                liste.Add(g.Paddle);
            }
            foreach (Paddle.Paddle p in liste)
            {
                if (this.ball.Direction.X > 0 && p.Left)
                {
                    this.ball.Position = new Vector(p.Position.X + p.Bounds.Width + 1, p.Position.Y + p.Bounds.Height / 2 - this.ball.Diameter / 2);
                }
                else if (this.ball.Direction.X < 0 && !p.Left)
                {
                    this.ball.Position = new Vector(p.Position.X - this.ball.Diameter - 1, p.Position.Y + p.Bounds.Height / 2 - this.ball.Diameter / 2);
                }
            }
        }
    }
}
