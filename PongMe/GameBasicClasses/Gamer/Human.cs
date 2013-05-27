using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Obstacles;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Options;

namespace GameBasicClasses.Gamer
{
    public class Human : Gamer
    {
<<<<<<< HEAD
        public Human(bool left, Keys up, Keys down, Paddle paddle) : base(left, up,down,paddle)
        {}
=======
        public Human(Keys up, Keys down, Paddle paddle) : base(up,down,paddle)
        {

        }
>>>>>>> 5dc767122a80e3da5bd96d8957cc00c59c4df4f2

        public override void run(Keys e) //pourquoi pas la définir dans Gamer?
        {
            if (e == base.options.UpKey())
            {
                this.paddle.up();
            }
            else if (e == base.options.DownKey())
            {
                this.paddle.down();
            }
            else if (e == GamerOptions.EscapeKey())
            {
                CurrentGame.getInstance().stopGame();
            }
        }
    }
}
