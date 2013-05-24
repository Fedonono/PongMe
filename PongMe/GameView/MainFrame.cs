using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameBasicClasses.Obstacles;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Obstacles.Paddle;

namespace GameView
{
    class MainForm : Form
    {
        private MenuStrip MainMenu;
        private ToolStripMenuItem jeuToolStripMenuItem;
        private ToolStripMenuItem nouvellePartieToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripMenuItem jeuToolStripMenuItem1;
        private ToolStripMenuItem nombreDeJoueursToolStripMenuItem;
        private ToolStripMenuItem paramètresToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aideToolStripMenuItem;
        private ToolStripMenuItem aProposToolStripMenuItem;
        private ToolStripMenuItem joueurToolStripMenuItem;
        private ToolStripMenuItem joueursToolStripMenuItem;
        private ToolStripMenuItem joueursToolStripMenuItem1;
        private ToolStripMenuItem joueursToolStripMenuItem2;
        private Panel gameBoard;
        private Timer timer = new Timer();

        public MainForm()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(this.Timer_Tick);
            timer.Interval = 1;
            timer.Enabled = true;
            timer.Start();
        }

        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.jeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nouvellePartieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jeuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeJoueursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueurToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.joueursToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.joueursToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameBoard = new System.Windows.Forms.Panel();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jeuToolStripMenuItem,
            this.jeuToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(984, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // jeuToolStripMenuItem
            // 
            this.jeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nouvellePartieToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
            this.jeuToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.jeuToolStripMenuItem.Text = "Fichier";
            // 
            // nouvellePartieToolStripMenuItem
            // 
            this.nouvellePartieToolStripMenuItem.Name = "nouvellePartieToolStripMenuItem";
            this.nouvellePartieToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.nouvellePartieToolStripMenuItem.Text = "Nouvelle partie";
            this.nouvellePartieToolStripMenuItem.Click += new System.EventHandler(this.nouvellePartieToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // jeuToolStripMenuItem1
            // 
            this.jeuToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreDeJoueursToolStripMenuItem,
            this.paramètresToolStripMenuItem});
            this.jeuToolStripMenuItem1.Name = "jeuToolStripMenuItem1";
            this.jeuToolStripMenuItem1.Size = new System.Drawing.Size(36, 20);
            this.jeuToolStripMenuItem1.Text = "Jeu";
            // 
            // nombreDeJoueursToolStripMenuItem
            // 
            this.nombreDeJoueursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.joueurToolStripMenuItem,
            this.joueursToolStripMenuItem,
            this.joueursToolStripMenuItem1,
            this.joueursToolStripMenuItem2});
            this.nombreDeJoueursToolStripMenuItem.Name = "nombreDeJoueursToolStripMenuItem";
            this.nombreDeJoueursToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nombreDeJoueursToolStripMenuItem.Text = "Nombre de joueurs";
            // 
            // joueurToolStripMenuItem
            // 
            this.joueurToolStripMenuItem.Checked = true;
            this.joueurToolStripMenuItem.CheckOnClick = true;
            this.joueurToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.joueurToolStripMenuItem.Name = "joueurToolStripMenuItem";
            this.joueurToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.joueurToolStripMenuItem.Text = "1 joueur";
            this.joueurToolStripMenuItem.Click += new System.EventHandler(this.joueurToolStripMenuItem_Click);
            // 
            // joueursToolStripMenuItem
            // 
            this.joueursToolStripMenuItem.Checked = true;
            this.joueursToolStripMenuItem.CheckOnClick = true;
            this.joueursToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.joueursToolStripMenuItem.Name = "joueursToolStripMenuItem";
            this.joueursToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.joueursToolStripMenuItem.Text = "2 joueurs";
            this.joueursToolStripMenuItem.Click += new System.EventHandler(this.joueursToolStripMenuItem_Click);
            // 
            // joueursToolStripMenuItem1
            // 
            this.joueursToolStripMenuItem1.Checked = true;
            this.joueursToolStripMenuItem1.CheckOnClick = true;
            this.joueursToolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.joueursToolStripMenuItem1.Name = "joueursToolStripMenuItem1";
            this.joueursToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.joueursToolStripMenuItem1.Text = "3 joueurs";
            this.joueursToolStripMenuItem1.Click += new System.EventHandler(this.joueursToolStripMenuItem1_Click);
            // 
            // joueursToolStripMenuItem2
            // 
            this.joueursToolStripMenuItem2.Checked = true;
            this.joueursToolStripMenuItem2.CheckOnClick = true;
            this.joueursToolStripMenuItem2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.joueursToolStripMenuItem2.Name = "joueursToolStripMenuItem2";
            this.joueursToolStripMenuItem2.Size = new System.Drawing.Size(122, 22);
            this.joueursToolStripMenuItem2.Text = "4 joueurs";
            this.joueursToolStripMenuItem2.Click += new System.EventHandler(this.joueursToolStripMenuItem2_Click);
            // 
            // paramètresToolStripMenuItem
            // 
            this.paramètresToolStripMenuItem.Name = "paramètresToolStripMenuItem";
            this.paramètresToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.paramètresToolStripMenuItem.Text = "Paramètres";
            this.paramètresToolStripMenuItem.Click += new System.EventHandler(this.paramètresToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aideToolStripMenuItem,
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aideToolStripMenuItem
            // 
            this.aideToolStripMenuItem.Name = "aideToolStripMenuItem";
            this.aideToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aideToolStripMenuItem.Text = "Aide";
            this.aideToolStripMenuItem.Click += new System.EventHandler(this.aideToolStripMenuItem_Click);
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem.Text = "A propos";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.aProposToolStripMenuItem_Click);
            // 
            // gameBoard
            // 
            this.gameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameBoard.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gameBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameBoard.Location = new System.Drawing.Point(12, 39);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(960, 513);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PongMe";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        Ball ball = new Ball(5, 50, 1000, 600);
        PictureBox picBoxBall = new PictureBox();
        Paddle paddle = CurrentGame.getInstance().GameModel.getGamer(1).Paddle;
        PictureBox picBoxPaddle = new PictureBox();

        private void Timer_Tick(object sender, EventArgs e)
        {
            ball.nextPosition();
            this.gameBoard.Refresh();
        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void joueurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void joueursToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void joueursToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void joueursToolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void aideToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            CurrentGame.getInstance().keyEvent(sender,e);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ball.ClientSize = this.gameBoard.Size;
            picBoxBall.Size = ball.BallRepresentation.Size;
            picBoxBall.Location = ball.Position;
            picBoxBall.BackColor = Color.Green;
            this.gameBoard.Controls.Add(picBoxBall);

            paddle.ClientSize = this.gameBoard.Size;
            picBoxPaddle.Size = paddle.PaddleRepresentation.Size;
            picBoxPaddle.Location = paddle.Position;
            picBoxPaddle.BackColor = Color.Red;
            this.gameBoard.Controls.Add(picBoxPaddle);
        }


    }
}
