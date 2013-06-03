using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.Options;

namespace GameView
{
    public partial class ControlCommands : UserControl
    {
        private GamerOptions gamOpt;
        private bool locked;
        private bool upLock;

        public ControlCommands(int id, GamerOptions g)
        {
            InitializeComponent();

            this.gamOpt = g;
            this.locked = false;

            this.GBPlr.Text = String.Format("Player {0}", id);
            this.Lup.Text = this.gamOpt.Up.ToString();
            this.Ldown.Text = this.gamOpt.Down.ToString();

            this.Lup.Click += new EventHandler(this.Lup_Click);
            this.Ldown.Click += new EventHandler(this.Lup_Click);
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
                if (l == this.Lup)
                {
                    this.upLock = true;
                }
                else
                {
                    this.upLock = false;
                }

                this.KeyUp += new KeyEventHandler(ReceiveCommand);
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
                this.gamOpt.Up = c;
                this.Lup.Text = c.ToString();
            }
            else
            {
                this.gamOpt.Down = c;
                this.Ldown.Text = c.ToString();
            }

            this.locked = false;
        }
    }
}
