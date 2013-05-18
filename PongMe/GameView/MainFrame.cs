using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using GameBasicClasses.Obstacles;
using GameBasicClasses.BasicClasses;

namespace GameView
{
    class MainForm : Form
    {
        private Timer timer = new Timer();

        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }

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
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(984, 564);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PongMe";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.MainForm_Paint);
            this.ResumeLayout(false);

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.Red);
            Racket racket = new Racket(0,0,10,100,3);
            Ball ball = new Ball(1, 50, 100, 100);
            bool b = racket.contains(ball);
            g.FillRectangle(sb, racket.RacketRepresentation);
            g.FillEllipse(sb, ball.BallRepresentation);
            racket.Position = new Point(0, 100);
            sb.Color = Color.PaleVioletRed;
            g.FillRectangle(sb, racket.RacketRepresentation);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}
