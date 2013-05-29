using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class BonusBrick : Brick
    {
        public Bonus Bonus { get { return this.Bonus; } set { this.Bonus = value; } }

        public BonusBrick(int clientWidth, int clientHeight, int health, Vector position) : base(clientWidth,clientHeight,health,position)
        {
            throw new System.NotImplementedException();
        }
    }
}
