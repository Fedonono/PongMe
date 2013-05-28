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
        public Human(Keys up, Keys down, Paddle paddle) : base(up,down,paddle)
        {

        }

        public override void run(Keys e)
        {
            if (e == this.commands.Up)
            {
                this.paddle.Up();
            }
            else if (e == this.commands.Down)
            {
                this.paddle.Down();
            }
            else if (e == this.commands.Stop)
            {
                CurrentGame.GetInstance().StopGame();
            }
            else if (e == this.commands.Pause)
            {
                CurrentGame.GetInstance().ToggleGame();
            }
        }
    }
}
