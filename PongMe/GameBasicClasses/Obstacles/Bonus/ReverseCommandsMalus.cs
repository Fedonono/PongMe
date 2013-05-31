using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.BasicClasses;
using System.Windows.Forms;


namespace GameBasicClasses.Obstacles.Bonus
{
    public class ReverseCommandsMalus : Bonus
    {
        public ReverseCommandsMalus(int clientWidth, int clientHeight, int timeout, Vector position)
            : base(clientWidth, clientHeight, timeout, position)
        {
            this.Image = Properties.Resources.portal_2_turret_defending_icon_by_thebrokenegg_d3fdjxe;
            this.InitialImage = this.Image;
            this.Color = System.Drawing.Color.Transparent;
            this.InitialColor = this.Color;
        }

        protected override void stopBonus()
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.gamers)
            {
                g.Commands.SwapCommands();
            }
        }

        protected override void runBonus()
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.gamers)
            {
                g.Commands.SwapCommands();
            }
        }
    }
}
