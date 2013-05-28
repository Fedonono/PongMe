﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class BonusBrick : Brick
    {
        public Bonus Bonus { get { return this.Bonus; } set { this.Bonus = value; } }

        public BonusBrick(int clientWidth, int clientHeight, int health)
            : base(clientWidth, clientHeight, health)
        {
            throw new System.NotImplementedException();
        }
    }
}