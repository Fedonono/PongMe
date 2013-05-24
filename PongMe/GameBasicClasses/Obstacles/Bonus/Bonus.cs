using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles
{
    public class Brick : Obstacle
    {
        public Brick(int clientWidth, int clientHeight) : base(clientWidth, clientHeight)
        {

        }

        public Brick()
        {
            throw new System.NotImplementedException();
        }

        public override bool contains(Ball b)
        {
            throw new NotImplementedException();
        }
    }
}
