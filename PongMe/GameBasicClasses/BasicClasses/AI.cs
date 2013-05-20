using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;

namespace GameBasicClasses.BasicClasses
{
    public class AI : Gamer
    {
        public AI(Keys up, Keys down, Paddle paddle) : base(up, down, paddle)
        {

        }

        public override void run(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
