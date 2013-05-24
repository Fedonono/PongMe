using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;

namespace GameBasicClasses.BasicClasses
{
    public class Human : Gamer
    {
        public Human(Keys up, Keys down, Paddle paddle) : base(up,down,paddle)
        {

        }

        public Human()
        {
            throw new System.NotImplementedException();
        }

        public override void run(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == this.up)
            {
                this.paddle.up();
            }
            else if (e.KeyCode == this.down)
            {
                this.paddle.down();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                CurrentGame.getInstance().stopGame();
            }
        }
    }
}
