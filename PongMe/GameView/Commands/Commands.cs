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
        private bool locked;
        private bool upLock;
        private KeyEventHandler keyEvent;

        public Commands(GameModel gm)
        {
            InitializeComponent();
            this.playerCommandSet(gm.GetCommands());

            this.LLaunch.Text = GamerOptions.Launch.ToString();
            this.LPause.Text = GamerOptions.Pause.ToString();

            this.LLaunch.Click += new EventHandler(this.Lup_Click);
            this.LPause.Click += new EventHandler(this.Lup_Click);

            this.keyEvent = new KeyEventHandler(ReceiveCommand);
        }

        private void playerCommandSet(List<GamerOptions> lg)
        {
            int i = 0;
            foreach (GamerOptions g in lg)
            {
                ControlCommands c = new ControlCommands(i++, g);
                controls.Add(c);
                this.FLPlrs.Controls.Add(c);
            }
        }

        private void Lup_Click(object sender, EventArgs e)
        {
            Label l = sender as Label;
            if (l == null)
            {
                return;
            }

            if (this.locked)
            {
                if (l == this.LLaunch)
                {
                    this.upLock = true;
                }
                else
                {
                    this.upLock = false;
                }

                this.KeyUp += this.keyEvent;
            }


        }

        private void ReceiveCommand(object sender, KeyEventArgs e)
        {
            if (!this.locked)
            {
                return;
            }

            Keys c = e.KeyCode;
            if (this.upLock)
            {
                GamerOptions.Launch = c;
                this.LLaunch.Text = c.ToString();
            }
            else
            {
                GamerOptions.Pause = c;
                this.LPause.Text = c.ToString();
            }

            this.locked = false;
            this.KeyUp -= this.keyEvent;
        }
    }
}
