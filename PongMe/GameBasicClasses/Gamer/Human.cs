using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Gamer
{
    public class Human : Gamer
    {
        public Human(bool left, Keys up, Keys down, Paddle paddle) : base(left, up,down,paddle)
        {

        }

        public override void run(Keys e)
        {
            if (e == this.up)
            {
                this.paddle.up();
            }
            else if (e == this.down)
            {
                this.paddle.down();
            }
            else if (e == Keys.Escape)
            {
                CurrentGame.getInstance().stopGame();
            }
        }
    }
}
