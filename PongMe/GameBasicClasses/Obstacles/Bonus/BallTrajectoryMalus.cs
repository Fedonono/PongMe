using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class BallTrajectoryMalus : Bonus
    {
        public BallTrajectoryMalus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.watchit1;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void stopBonus()
        {
            this.ball.Direction = this.ball.InitialDirection;
        }

        protected override void runBonus()
        {
            Random r = new Random();
            this.ball.Direction = new Vector(r.Next(1,50),r.Next(1,50));
        }
    }
}
