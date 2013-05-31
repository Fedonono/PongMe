using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;

namespace GameBasicClasses.Obstacles.Bonus
{
    public class WheatleyBonus : Bonus
    {
        public WheatleyBonus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.portal_2_jumping_cube_icon_by_thebrokenegg_d3fzgwo;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void stopBonus()
        {
            
        }

        protected override void runBonus()
        {
            CurrentGame.GetInstance().addWheatleyPoint();
        }
    }
}
