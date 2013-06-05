using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class BallDiameterBonus : Bonus
    {
        public BallDiameterBonus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.potados_by_sungoddessokami_d481k83;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void StopBonus()
        {
            this.ball.Diameter = this.ball.InitialDiameter;
        }

        protected override void RunBonus()
        {
            this.ball.Diameter *= 2;
        }
    }
}
