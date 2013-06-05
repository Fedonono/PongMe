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
using System.Media;

namespace GameView
{
    public partial class MainForm : Form
    {
        private MenuStrip MainMenu;
        private ToolStripMenuItem jeuToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripMenuItem jeuToolStripMenuItem1;
        private ToolStripMenuItem nombreDeJoueursToolStripMenuItem;
        private ToolStripMenuItem parameterToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aProposToolStripMenuItem;
        private ToolStripMenuItem commandsToolStripMenuItem;
        private ToolStripMenuItem onePlayerMenu;
        private ToolStripMenuItem twoPlayersMenu;
        private ToolStripMenuItem fourPlayerMenu;
        private ToolStripMenuItem AIPlayerMenu;
        private Panel gameBoard;
        private Label leftPointsLabel;
        private Label rightPointsLabel;
        private CurrentGame currentGame = CurrentGame.GetInstance();
        private Timer gameTimer;
        private System.ComponentModel.IContainer components;
        private Timer animationTimer;
        private Timer bonusTimer;
        private Timer brickTimer;
        private Label wheatleyLabel;
        private List<Keys> keysPressed = new List<Keys>();
        private MenuItem lbQuit;
        private PictureBox pbWheatley;
        private PictureBox pBLogo;
        private MenuItem lbQuickGame;
        private Label labelHelp;
        private MenuItem lLBack;
        private Panel OptionPanel;
        private bool EnableSound = true;
        private Button bMute;

        public MainForm()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.jeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jeuToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.nombreDeJoueursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onePlayerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.twoPlayersMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.fourPlayerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.AIPlayerMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.parameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameBoard = new Panel();
            this.wheatleyLabel = new System.Windows.Forms.Label();
            this.rightPointsLabel = new System.Windows.Forms.Label();
            this.leftPointsLabel = new System.Windows.Forms.Label();
            this.lLBack = new MenuItem();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.bonusTimer = new System.Windows.Forms.Timer(this.components);
            this.brickTimer = new System.Windows.Forms.Timer(this.components);
            this.OptionPanel = new Panel();
            this.labelHelp = new System.Windows.Forms.Label();
            this.lbQuit = new GameView.MenuItem();
            this.pbWheatley = new System.Windows.Forms.PictureBox();
            this.pBLogo = new System.Windows.Forms.PictureBox();
            this.lbQuickGame = new GameView.MenuItem();
            this.MainMenu.SuspendLayout();
            this.gameBoard.SuspendLayout();
            this.OptionPanel.SuspendLayout();
            this.bMute = new Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbWheatley)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).BeginInit();
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
            this.MainMenu.Size = new System.Drawing.Size(1484, 24);
            this.MainMenu.TabIndex = 0;
            // 
            // jeuToolStripMenuItem
            // 
            this.jeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.parameterToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
            this.jeuToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.jeuToolStripMenuItem.Text = "File";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "Quit";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // jeuToolStripMenuItem1
            // 
            this.jeuToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nombreDeJoueursToolStripMenuItem});
            this.jeuToolStripMenuItem1.Name = "jeuToolStripMenuItem1";
            this.jeuToolStripMenuItem1.Size = new System.Drawing.Size(36, 20);
            this.jeuToolStripMenuItem1.Text = "Game";
            // 
            // nombreDeJoueursToolStripMenuItem
            // 
            this.nombreDeJoueursToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.onePlayerMenu,
            this.twoPlayersMenu,
            this.fourPlayerMenu,
            this.AIPlayerMenu});
            this.nombreDeJoueursToolStripMenuItem.Name = "nombreDeJoueursToolStripMenuItem";
            this.nombreDeJoueursToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nombreDeJoueursToolStripMenuItem.Text = "Number of players";
            // 
            // onePlayerMenu
            // 
            this.onePlayerMenu.Name = "onePlayerMenu";
            this.onePlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.onePlayerMenu.Text = "1 player";
            this.onePlayerMenu.Click += new System.EventHandler(this.JoueurToolStripMenuItem_Click);
            // 
            // twoPlayersMenu
            // 
            this.twoPlayersMenu.CheckOnClick = true;
            this.twoPlayersMenu.Name = "twoPlayersMenu";
            this.twoPlayersMenu.Size = new System.Drawing.Size(122, 22);
            this.twoPlayersMenu.Text = "2 players";
            this.twoPlayersMenu.Click += new System.EventHandler(this.JoueursToolStripMenuItem_Click);
            // 
            // fourPlayerMenu
            // 
            this.fourPlayerMenu.CheckOnClick = true;
            this.fourPlayerMenu.Name = "fourPlayerMenu";
            this.fourPlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.fourPlayerMenu.Text = "4 players";
            this.fourPlayerMenu.Click += new System.EventHandler(this.JoueursToolStripMenuItem2_Click);
            // 
            // AIPlayerMenu
            // 
            this.AIPlayerMenu.CheckOnClick = true;
            this.AIPlayerMenu.Name = "AIPlayerMenu";
            this.AIPlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.AIPlayerMenu.Text = "AI";
            this.AIPlayerMenu.Click += new System.EventHandler(this.JoueursToolStripMenuItem4_Click);
            // 
            // parameterToolStripMenuItem
            // 
            this.parameterToolStripMenuItem.Name = "parameterToolStripMenuItem";
            this.parameterToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.parameterToolStripMenuItem.Text = "Main menu";
            this.parameterToolStripMenuItem.Click += new System.EventHandler(this.ParameterToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aProposToolStripMenuItem, this.commandsToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
            // 
            // aProposToolStripMenuItem
            // 
            this.aProposToolStripMenuItem.Name = "aProposToolStripMenuItem";
            this.aProposToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.aProposToolStripMenuItem.Text = "About";
            this.aProposToolStripMenuItem.Click += new System.EventHandler(this.AProposToolStripMenuItem_Click);
            
            //
            // commandsToolStripMenuItem
            //
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.commandsToolStripMenuItem.Text = "Commands";
            this.commandsToolStripMenuItem.Click += new System.EventHandler(this.CommandsToolStripMenuItem_Click);
            
            
            // 
            // gameBoard
            // 
            this.gameBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gameBoard.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.gameBoard.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gameBoard.Controls.Add(this.wheatleyLabel);
            this.gameBoard.Controls.Add(this.rightPointsLabel);
            this.gameBoard.Controls.Add(this.leftPointsLabel);
            this.gameBoard.Location = new System.Drawing.Point(12, 39);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(1460, 878);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.Panel1_Paint);
            // 
            // wheatleyLabel
            // 
            this.wheatleyLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.wheatleyLabel.AutoSize = true;
            this.wheatleyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wheatleyLabel.Location = new System.Drawing.Point(714, 57);
            this.wheatleyLabel.Name = "wheatleyLabel";
            this.wheatleyLabel.Size = new System.Drawing.Size(30, 31);
            this.wheatleyLabel.TabIndex = 2;
            this.wheatleyLabel.Text = "0";
            this.wheatleyLabel.SizeChanged += new System.EventHandler(this.WheatleyLabel_SizeChanged);
            // 
            // rightPointsLabel
            // 
            this.rightPointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightPointsLabel.AutoSize = true;
            this.rightPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rightPointsLabel.Location = new System.Drawing.Point(1290, 57);
            this.rightPointsLabel.Name = "rightPointsLabel";
            this.rightPointsLabel.Size = new System.Drawing.Size(30, 31);
            this.rightPointsLabel.TabIndex = 1;
            this.rightPointsLabel.Text = "0";
            // 
            // leftPointsLabel
            // 
            this.leftPointsLabel.AutoSize = true;
            this.leftPointsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leftPointsLabel.Location = new System.Drawing.Point(140, 57);
            this.leftPointsLabel.Name = "leftPointsLabel";
            this.leftPointsLabel.Size = new System.Drawing.Size(30, 31);
            this.leftPointsLabel.TabIndex = 0;
            this.leftPointsLabel.Text = "0";
            // 
            // lLBack
            // 
            this.lLBack.AutoSize = true;
            this.lLBack.Location = new System.Drawing.Point(42, 624);
            this.lLBack.Name = "lLBack";
            this.lLBack.Size = new System.Drawing.Size(77, 13);
            this.lLBack.TabIndex = 0;
            this.lLBack.TabStop = true;
            this.lLBack.Text = "Menu Principal";
            this.lLBack.Click += new System.EventHandler(this.ParameterToolStripMenuItem_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 4000;
            this.animationTimer.Tick += new System.EventHandler(this.AnimationTimer_Tick);
            // 
            // bonusTimer
            // 
            this.bonusTimer.Enabled = true;
            this.bonusTimer.Interval = 1000;
            this.bonusTimer.Tick += new System.EventHandler(this.BonusTimer_Tick);
            // 
            // brickTimer
            // 
            this.brickTimer.Enabled = true;
            this.brickTimer.Interval = 1000;
            this.brickTimer.Tick += new System.EventHandler(this.BrickTimer_Tick);
            // 
            // labelHelp
            // 
            this.labelHelp.AutoSize = true;
            this.labelHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHelp.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelHelp.Location = new System.Drawing.Point(502, 500);
            this.labelHelp.Name = "labelHelp";
            this.labelHelp.Size = new System.Drawing.Size(635, 108);
            this.labelHelp.TabIndex = 12;
            this.labelHelp.Text = "Help Wheatley to bring back his jumping cubes.\r\nUse portals to make him move."
                + "\r\nIt's a cooperation game, help you each other." +
                "\r\nRemember to keep an eye open on items floating in space !" +
                "\r\nThey can bring you a lot of troubles !";
            // 
            // lbQuit
            // 
            this.lbQuit.ActiveLinkColor = System.Drawing.Color.White;
            this.lbQuit.AutoSize = true;
            this.lbQuit.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuit.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbQuit.LinkColor = System.Drawing.Color.White;
            this.lbQuit.Location = new System.Drawing.Point(42, 624);
            this.lbQuit.Name = "lbQuit";
            this.lbQuit.Size = new System.Drawing.Size(86, 42);
            this.lbQuit.TabIndex = 11;
            this.lbQuit.TabStop = true;
            this.lbQuit.Text = "Quit";
            this.lbQuit.Click += new System.EventHandler(this.QuitterToolStripMenuItem_Click);
            // 
            // pbWheatley
            // 
            this.pbWheatley.Image = global::GameView.Properties.Resources.wheatleyv2;
            this.pbWheatley.Location = new System.Drawing.Point(502, 389);
            this.pbWheatley.Name = "pbWheatley";
            this.pbWheatley.Size = new System.Drawing.Size(232, 199);
            this.pbWheatley.TabIndex = 9;
            this.pbWheatley.TabStop = false;
            this.pbWheatley.Visible = false;
            // 
            // pBLogo
            // 
            this.pBLogo.Image = global::GameView.Properties.Resources.logoPongMe;
            this.pBLogo.Location = new System.Drawing.Point(49, 324);
            this.pBLogo.Name = "pBLogo";
            this.pBLogo.Size = new System.Drawing.Size(329, 100);
            this.pBLogo.TabIndex = 8;
            this.pBLogo.TabStop = false;
            // 
            // lbQuickGame
            // 
            this.lbQuickGame.ActiveLinkColor = System.Drawing.Color.White;
            this.lbQuickGame.AutoSize = true;
            this.lbQuickGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbQuickGame.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lbQuickGame.LinkColor = System.Drawing.Color.White;
            this.lbQuickGame.Location = new System.Drawing.Point(42, 513);
            this.lbQuickGame.Name = "lbQuickGame";
            this.lbQuickGame.Size = new System.Drawing.Size(225, 42);
            this.lbQuickGame.TabIndex = 7;
            this.lbQuickGame.TabStop = true;
            this.lbQuickGame.Text = "Play";
            this.lbQuickGame.Click += new System.EventHandler(this.LinkLabel1_LinkClicked);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1484, 929);
            this.Controls.Add(this.OptionPanel);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PongMe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.SizeChanged += new System.EventHandler(this.MainForm_SizeChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.gameBoard.ResumeLayout(false);
            this.gameBoard.PerformLayout();
            this.OptionPanel.ResumeLayout(false);
            this.OptionPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbWheatley)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            //
            // bMute
            //
            this.bMute.Name = "buttonMute";
            this.bMute.Text = "";
            this.bMute.UseVisualStyleBackColor = true;
            this.bMute.Location = new System.Drawing.Point(10, 10);
            this.bMute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bMute.Image = global::GameView.Properties.Resources.Mute;
            this.bMute.UseVisualStyleBackColor = true;
            this.bMute.Cursor = System.Windows.Forms.Cursors.No;
            this.bMute.BackColor = System.Drawing.Color.Black;
            this.bMute.Click += new System.EventHandler(this.ToggleSound);
            this.bMute.Size = new Size(50, 40);
            // 
            // OptionPanel
            // 
            this.OptionPanel.BackColor = System.Drawing.Color.Black;
            this.OptionPanel.BackgroundImage = global::GameView.Properties.Resources.wallpaper;
            this.OptionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OptionPanel.Controls.Add(this.labelHelp);
            this.OptionPanel.Controls.Add(this.lbQuit);
            this.OptionPanel.Controls.Add(this.pbWheatley);
            this.OptionPanel.Controls.Add(this.pBLogo);
            this.OptionPanel.Controls.Add(this.lbQuickGame);
            this.OptionPanel.Controls.Add(this.bMute);
            this.OptionPanel.Location = new System.Drawing.Point(0, 0);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.Size = this.Size;
            this.OptionPanel.TabIndex = 2;
        }

        private void QuitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OptionPanel.Show();
            this.OptionPanel.Enabled = true;
        }

        private void JoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearGameBoard(true);
            this.currentGame.GameModel = GameFactory.OnePlayerGame();
        }

        private void JoueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ClearGameBoard(true);
            this.currentGame.GameModel = GameFactory.TwoPlayerGame();
        }

        private void JoueursToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.ClearGameBoard(true);
            this.currentGame.GameModel = GameFactory.FourPlayerGame();
        }

        private void JoueursToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.ClearGameBoard(true);
            this.currentGame.GameModel = GameFactory.AIGame();
        }

        private void AProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PongMe" + Environment.NewLine + "Authors :" +
                Environment.NewLine + "Adrien Ecrepont" +
                Environment.NewLine + "Arnaud Babol" +
                Environment.NewLine + "Maxence Prevost" +
                Environment.NewLine + "Guillaume Simonneau" +
                Environment.NewLine + "Eric Allard");
        }

        private void CommandsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Commands" + Environment.NewLine + Environment.NewLine
                + "Player1:" + Environment.NewLine + "up : z" + Environment.NewLine + "down : s" + Environment.NewLine + Environment.NewLine
                + "Player2:" + Environment.NewLine + "up : arrow top" + Environment.NewLine + "down : arrow down" + Environment.NewLine + Environment.NewLine
                + "Player3:" + Environment.NewLine + "up : t" + Environment.NewLine + "down : g" + Environment.NewLine + Environment.NewLine
                + "Player4:" + Environment.NewLine + "up : i" + Environment.NewLine + "down : k");
        }

        private void WheatleyLabel_SizeChanged(object sender, EventArgs e)
        {
            this.wheatleyLabel.Location = new Point(this.gameBoard.Width / 2 - this.wheatleyLabel.Size.Width / 2, this.wheatleyLabel.Location.Y);
        }

        private void LinkLabel1_LinkClicked(object sender, EventArgs e)
        {
            this.OptionPanel.Hide();
            this.OptionPanel.Enabled = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            CurrentGame.width = this.gameBoard.Width;
            CurrentGame.height = this.gameBoard.Height;
            this.OptionPanel.Size = this.Size;
            this.ClearGameBoard(false);
        }

        private void ClearGameBoard(bool points)
        {
            this.gameBoard.Controls.Clear();
            this.keysPressed.Clear();
            if (points)
            {
                this.wheatleyLabel.Text = "0";
                this.rightPointsLabel.Text = "0";
                this.leftPointsLabel.Text = "0";
            }
            this.gameBoard.Controls.Add(this.wheatleyLabel);
            this.gameBoard.Controls.Add(this.rightPointsLabel);
            this.gameBoard.Controls.Add(this.leftPointsLabel);
        }

        private void ToggleSound(object sender, EventArgs e)
        {
            if (this.EnableSound)
            {
                this.bMute.Image = global::GameView.Properties.Resources.Play;
                this.bMute.Cursor = System.Windows.Forms.Cursors.Hand;
                this.EnableSound = false;
                this.StopGameMusic();
            }
            else
            {
                this.bMute.Image = global::GameView.Properties.Resources.Mute;
                this.bMute.Cursor = System.Windows.Forms.Cursors.No;
                this.EnableSound = true;
                this.PlayGameMusic();
            }
        }
    }
}
