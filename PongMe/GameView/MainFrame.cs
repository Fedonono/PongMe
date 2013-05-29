using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameBasicClasses.Obstacles;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Gamer;

namespace GameView
{
    class MainForm : Form
    {
        private MenuStrip MainMenu;
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
        private Label leftPointsLabel;
        private Label rightPointsLabel;
        private CurrentGame currentGame = CurrentGame.GetInstance();
        private List<Keys> keysPressed = new List<Keys>();

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
            this.rightPointsLabel = new System.Windows.Forms.Label();
            this.leftPointsLabel = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.gameBoard.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.jeuToolStripMenuItem1,
            this.toolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(979, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu_ItemClicked);
            // 
            // jeuToolStripMenuItem1
            // 
            this.jeuToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreDeJoueursToolStripMenuItem,
            this.paramètresToolStripMenuItem});
            this.jeuToolStripMenuItem1.Name = "jeuToolStripMenuItem1";
            this.jeuToolStripMenuItem1.Size = new System.Drawing.Size(36, 20);
            this.jeuToolStripMenuItem1.Text = "Jeu";
            this.jeuToolStripMenuItem1.Click += new System.EventHandler(this.jeuToolStripMenuItem1_Click);
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
            this.gameBoard.BackColor = System.Drawing.Color.Transparent;
            this.gameBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameBoard.Controls.Add(this.rightPointsLabel);
            this.gameBoard.Controls.Add(this.leftPointsLabel);
            this.gameBoard.Location = new System.Drawing.Point(12, 39);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(960, 513);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // rightPointsLabel
            // 
            this.rightPointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPointsLabel.AutoSize = true;
            this.rightPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightPointsLabel.Location = new System.Drawing.Point(790, 57);
            this.rightPointsLabel.Name = "rightPointsLabel";
            this.rightPointsLabel.Size = new System.Drawing.Size(30, 31);
            this.rightPointsLabel.TabIndex = 1;
            this.rightPointsLabel.Text = "0";
            // 
            // leftPointsLabel
            // 
            this.leftPointsLabel.AutoSize = true;
            this.leftPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPointsLabel.Location = new System.Drawing.Point(132, 57);
            this.leftPointsLabel.Name = "leftPointsLabel";
            this.leftPointsLabel.Size = new System.Drawing.Size(30, 31);
            this.leftPointsLabel.TabIndex = 0;
            this.leftPointsLabel.Text = "0";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(979, 564);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.gameBoard);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PongMe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.gameBoard.ResumeLayout(false);
            this.gameBoard.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void nouvellePartieToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Parameters param = new Parameters(currentGame);
            param.Show();
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
            if (keysPressed.Contains(e.KeyCode))
            {
                keysPressed.Remove(e.KeyCode);
            }
            keysPressed.Add(e.KeyCode);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            List<Ball> listeBall = this.currentGame.GameModel.ListeBall;
            foreach (Ball ball in listeBall)
            {
                ball.ClientSize = this.gameBoard.Size;
                this.gameBoard.Controls.Add(ball.Box);
            }
            List<Gamer> listeGamer = this.currentGame.GameModel.ListeGamer;
            foreach (Gamer gamer in listeGamer)
            {
                gamer.Paddle.ClientSize = this.gameBoard.Size;
                this.gameBoard.Controls.Add(gamer.Paddle.Box);
            }
            this.leftPointsLabel.Text = this.currentGame.getPoints(true).ToString();
            this.rightPointsLabel.Text = this.currentGame.getPoints(false).ToString();
        }


        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in this.currentGame.GameModel.ListeBall)
            {
                ball.nextPosition();
                if (ball.isOutRight && ball.isMoving)
                {
                    ball.isMoving = false;
                    this.currentGame.addPoint(false);
                }
                else if (ball.isOutLeft && ball.isMoving)
                {
                    ball.isMoving = false;
                    this.currentGame.addPoint(true);
                }
            }

            if (keysPressed.Count > 0)
            {
                foreach (Keys key in keysPressed)
                {
                    this.currentGame.keyEvent(key);
                }
            }
            else
            {
                this.currentGame.keyEvent(Keys.A);//AI
            }
            
            

            if (this.currentGame.isGameOver())
            {
                this.currentGame.StopGame();
            }
            this.gameBoard.Refresh();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
            {
                keysPressed.Remove(e.KeyCode);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainMenu_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void jeuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jeuToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
