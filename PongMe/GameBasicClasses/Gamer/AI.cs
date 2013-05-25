using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;

namespace GameBasicClasses.Gamer
{
    public class AI : Gamer
    {
        public AI(bool left, Keys up, Keys down, Paddle paddle) : base(left, up, down, paddle)
        {

        }

        public override void run(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
