using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class SpeedMalus : Bonus
    {
        public SpeedMalus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.star1;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void stopBonus()
        {
            this.ball.Speed = this.ball.InitialSpeed;
        }

        protected override void runBonus()
        {
            this.ball.Speed *= 2;
        }
    }
}
