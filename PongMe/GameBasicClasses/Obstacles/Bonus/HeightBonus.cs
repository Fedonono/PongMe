using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;
using System.Drawing;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class HeightBonus : Bonus
    {
        public HeightBonus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.companion_cube_in_a_jar_by_shinobitokobot_d4ayx1u;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void StopBonus()
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.gamers)
            {
                Rectangle bounds = new Rectangle(g.Paddle.InitialBounds.X, g.Paddle.Bounds.Y, g.Paddle.InitialBounds.Width, g.Paddle.InitialBounds.Height);
                g.Paddle.Bounds = bounds;
            }
        }

        protected override void RunBonus()
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.gamers)
            {
                g.Paddle.Bounds = new Rectangle(g.Paddle.Bounds.X, g.Paddle.Bounds.Y, g.Paddle.Bounds.Width, new Random().Next(g.Paddle.Bounds.Height, this.ClientHeight));
            }
        }
    }
}
