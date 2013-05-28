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

        public override void run(Keys e)
        {
            throw new NotImplementedException();
        }
    }
}
