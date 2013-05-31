using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class NoPortalBonus : Bonus
    {
        public NoPortalBonus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.portal_turret_icon_3_by_squeekbot_d3gwm7t;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void stopBonus()
        {
            this.setPortalMode(true);
        }

        protected override void runBonus()
        {
            this.setPortalMode(false);
        }

        private void setPortalMode(bool b)
        {
            List<GameBasicClasses.Obstacles.Paddle.Paddle> liste = new List<Paddle.Paddle>();
            foreach (Gamer.Gamer g in this.gamers)
            {
                liste.Add(g.Paddle);
            }
            foreach (Paddle.Paddle p in liste)
            {
                p.PortalMode = b;
            }
        }
    }
}
