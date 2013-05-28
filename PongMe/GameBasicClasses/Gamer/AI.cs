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
    public class AI : Gamer
    {
        public AI(Keys up, Keys down, Paddle paddle) : base(up, down, paddle)
        {

        }

        public override void run(Keys e)
        {
            CurrentGame cg = CurrentGame.GetInstance();
            foreach (Ball b in cg.GameModel.ListeBall)
            {
                if (b.isMoving && !b.isOutLeft && !b.isOutRight)
                {
                    this.Paddle.Position = new Vector(this.Paddle.Position.X, b.Position.Y + b.Diameter/2 - this.Paddle.bounds.Height/2);
                    return;
                }
            }
        }
    }
}
