using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class WidthBonus : Bonus
    {
        public WidthBonus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
        }

        protected override void stopBonus()
        {
            throw new NotImplementedException();
        }

        protected override void runBonus()
        {
            throw new NotImplementedException();
        }
    }
}
