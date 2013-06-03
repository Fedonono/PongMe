using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Options;
using GameBasicClasses.BasicClasses;

namespace GameView.Resources
{
    public partial class Commands : UserControl
    {
        private List<ControlCommands> controls;

        public Commands(GameModel gm)
        {
            InitializeComponent();
            this.playerCommandSet(gm.GetCommands());
        }

        private void playerCommandSet(List<GamerOptions> lg)
        {
            foreach (GamerOptions g in lg)
            {
                ControlCommands c = new ControlCommands(g.Up.ToString(), g.Down.ToString());
                controls.Add(c);
                this.Controls.Add(c);
            }
        }

        private void Commands_Load(object sender, EventArgs e)
        {

        }
    }
}
