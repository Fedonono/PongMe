﻿using System;
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
        private ToolStripMenuItem paramètresToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem aProposToolStripMenuItem;
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
        private LinkLabel linkLabel3;
        private LinkLabel linkLabel2;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private LinkLabel linkLabel1;
        private Label label1;
        private Panel OptionPanel;

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
            this.paramètresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.aProposToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gameBoard = new System.Windows.Forms.Panel();
            this.wheatleyLabel = new System.Windows.Forms.Label();
            this.rightPointsLabel = new System.Windows.Forms.Label();
            this.leftPointsLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.animationTimer = new System.Windows.Forms.Timer(this.components);
            this.bonusTimer = new System.Windows.Forms.Timer(this.components);
            this.brickTimer = new System.Windows.Forms.Timer(this.components);
            this.OptionPanel = new System.Windows.Forms.Panel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            this.gameBoard.SuspendLayout();
            this.OptionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.quitterToolStripMenuItem});
            this.jeuToolStripMenuItem.Name = "jeuToolStripMenuItem";
            this.jeuToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.jeuToolStripMenuItem.Text = "Fichier";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
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
            this.onePlayerMenu,
            this.twoPlayersMenu,
            this.fourPlayerMenu,
            this.AIPlayerMenu});
            this.nombreDeJoueursToolStripMenuItem.Name = "nombreDeJoueursToolStripMenuItem";
            this.nombreDeJoueursToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.nombreDeJoueursToolStripMenuItem.Text = "Nombre de joueurs";
            // 
            // onePlayerMenu
            // 
            this.onePlayerMenu.Name = "onePlayerMenu";
            this.onePlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.onePlayerMenu.Text = "1 joueur";
            this.onePlayerMenu.Click += new System.EventHandler(this.joueurToolStripMenuItem_Click);
            // 
            // twoPlayersMenu
            // 
            this.twoPlayersMenu.CheckOnClick = true;
            this.twoPlayersMenu.Name = "twoPlayersMenu";
            this.twoPlayersMenu.Size = new System.Drawing.Size(122, 22);
            this.twoPlayersMenu.Text = "2 joueurs";
            this.twoPlayersMenu.Click += new System.EventHandler(this.joueursToolStripMenuItem_Click);
            // 
            // fourPlayerMenu
            // 
            this.fourPlayerMenu.CheckOnClick = true;
            this.fourPlayerMenu.Name = "fourPlayerMenu";
            this.fourPlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.fourPlayerMenu.Text = "4 joueurs";
            this.fourPlayerMenu.Click += new System.EventHandler(this.joueursToolStripMenuItem2_Click);
            // 
            // AIPlayerMenu
            // 
            this.AIPlayerMenu.CheckOnClick = true;
            this.AIPlayerMenu.Name = "AIPlayerMenu";
            this.AIPlayerMenu.Size = new System.Drawing.Size(122, 22);
            this.AIPlayerMenu.Text = "AI";
            this.AIPlayerMenu.Click += new System.EventHandler(this.joueursToolStripMenuItem4_Click);
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
            this.aProposToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "?";
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
            this.gameBoard.Controls.Add(this.wheatleyLabel);
            this.gameBoard.Controls.Add(this.rightPointsLabel);
            this.gameBoard.Controls.Add(this.leftPointsLabel);
            this.gameBoard.Location = new System.Drawing.Point(12, 39);
            this.gameBoard.Name = "gameBoard";
            this.gameBoard.Size = new System.Drawing.Size(1460, 911);
            this.gameBoard.TabIndex = 1;
            this.gameBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
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
            this.wheatleyLabel.SizeChanged += new System.EventHandler(this.wheatleyLabel_SizeChanged);
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
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            this.gameTimer.Interval = 10;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // animationTimer
            // 
            this.animationTimer.Enabled = true;
            this.animationTimer.Interval = 4000;
            this.animationTimer.Tick += new System.EventHandler(this.animationTimer_Tick);
            // 
            // bonusTimer
            // 
            this.bonusTimer.Enabled = true;
            this.bonusTimer.Interval = 1000;
            this.bonusTimer.Tick += new System.EventHandler(this.bonusTimer_Tick);
            // 
            // brickTimer
            // 
            this.brickTimer.Enabled = true;
            this.brickTimer.Interval = 1000;
            this.brickTimer.Tick += new System.EventHandler(this.brickTimer_Tick);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.White;
            this.linkLabel3.Location = new System.Drawing.Point(42, 624);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(86, 42);
            this.linkLabel3.TabIndex = 11;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Quit";
            this.linkLabel3.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.White;
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.White;
            this.linkLabel2.Location = new System.Drawing.Point(42, 565);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(257, 42);
            this.linkLabel2.TabIndex = 10;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Custom Game";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::GameView.Properties.Resources.wheatleyv2;
            this.pictureBox2.Location = new System.Drawing.Point(502, 389);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(232, 199);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::GameView.Properties.Resources.logoPongMe;
            this.pictureBox1.Location = new System.Drawing.Point(49, 324);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 100);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.White;
            this.linkLabel1.Location = new System.Drawing.Point(42, 513);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(225, 42);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Quick Game";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label1.Location = new System.Drawing.Point(502, 667);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(822, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Aidez Wheatley à récupérer ses cubes." + Environment.NewLine + "Utilisez les portails pour le faire bouger" + 
                Environment.NewLine + "mais attention aux objets volant dans l\'espace !";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1484, 962);
            this.Controls.Add(this.OptionPanel);
            this.Controls.Add(this.gameBoard);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.MinimumSize = new System.Drawing.Size(1460, 911);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            // 
            // OptionPanel
            // 
            this.OptionPanel.BackColor = System.Drawing.Color.Black;
            this.OptionPanel.BackgroundImage = global::GameView.Properties.Resources.outer_space_portal_desktop_1920x1080_hd_wallpaper_1043976;
            this.OptionPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.OptionPanel.Controls.Add(this.label1);
            this.OptionPanel.Controls.Add(this.linkLabel3);
            this.OptionPanel.Controls.Add(this.linkLabel2);
            this.OptionPanel.Controls.Add(this.pictureBox2);
            this.OptionPanel.Controls.Add(this.pictureBox1);
            this.OptionPanel.Controls.Add(this.linkLabel1);
            this.OptionPanel.Location = new System.Drawing.Point(0, 0);
            this.OptionPanel.Name = "OptionPanel";
            this.OptionPanel.Size = this.Size;
            this.OptionPanel.TabIndex = 2;
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paramètresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.OptionPanel.Show();
            this.OptionPanel.Enabled = true;
        }

        private void joueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gameBoard.Controls.Clear();
            this.keysPressed.Clear();
            this.currentGame.GameModel = GameFactory.onePlayerGame();
        }

        private void joueursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.gameBoard.Controls.Clear();
            this.keysPressed.Clear();
            this.currentGame.GameModel = GameFactory.twoPlayerGame();
        }

        private void joueursToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            this.gameBoard.Controls.Clear();
            this.keysPressed.Clear();
            this.currentGame.GameModel = GameFactory.fourPlayerGame();
        }

        private void joueursToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            this.gameBoard.Controls.Clear();
            this.keysPressed.Clear();
            this.currentGame.GameModel = GameFactory.AIGame();
        }

        private void aProposToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PongMe" + Environment.NewLine + "Authors :" +
                Environment.NewLine + "Adrien Ecrepont" +
                Environment.NewLine + "Arnaud Babol" +
                Environment.NewLine + "Maxence Prevost" +
                Environment.NewLine + "Guillaume Simonneau" +
                Environment.NewLine + "Eric Allard");
        }

        private void wheatleyLabel_SizeChanged(object sender, EventArgs e)
        {
            this.wheatleyLabel.Location = new Point(this.gameBoard.Width / 2 - this.wheatleyLabel.Size.Width / 2, this.wheatleyLabel.Location.Y);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.OptionPanel.Hide();
            this.OptionPanel.Enabled = false;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            this.OptionPanel.Size = this.Size;
        }
    }
}
