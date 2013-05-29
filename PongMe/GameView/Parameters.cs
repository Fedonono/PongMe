using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Options;

namespace GameView
{
    public partial class Parameters : Form
    {
        private CurrentGame game;
        private List<RadioButton> radios;
        private List<GamerOptions> options;

        public Parameters(CurrentGame currentGame)
        {
            InitializeComponent();
            this.game = currentGame;

            int count = this.game.GetPlayerCount();

            this.options = game.GetGamerOptions();
            this.radios = new List<RadioButton>();

            this.radios.Add(this.radioButton1);
            this.radios.Add(this.radioButton2);
            this.radios.Add(this.radioButton3);
            this.radios.Add(this.radioButton4);

            for (int i = this.radios.Count - 1; i >= count; i--)
            {
                this.radios[i].Hide();
            }

            this.toogle.Text = GamerOptions.Pause.ToString();
            this.stop.Text = GamerOptions.Stop.ToString();
            this.launch.Text = GamerOptions.Launch.ToString();
        }

        private void PlayerSetup(object sender, int i)
        {
            RadioButton rb = sender as RadioButton;
            if (rb != null)
            {
                if (rb.Checked)
                {
                    

                    this.groupBox2.Text = rb.Text;

                    this.up.Text = this.options[i].Up.ToString();
                    this.down.Text = this.options[i].Down.ToString();
                }
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            this.PlayerSetup(sender, 0);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.PlayerSetup(sender, 1);
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            this.PlayerSetup(sender, 2);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            this.PlayerSetup(sender, 3);
        }
    }
}
