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
        public AI(Keys up, Keys down, Paddle paddle) : base(up, down, paddle)
        {

        }

        public AI()
        {
            throw new System.NotImplementedException();
        }

        public override void run(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
