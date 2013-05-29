using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Gamer;
using GameBasicClasses.Obstacles.Bonus;
using GameBasicClasses.Obstacles;
using System.Drawing;
using System.Media;

namespace GameView
{
    public partial class MainForm
    {
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
            {
                keysPressed.Remove(e.KeyCode);
            }
            keysPressed.Add(e.KeyCode);
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (keysPressed.Contains(e.KeyCode))
            {
                keysPressed.Remove(e.KeyCode);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            List<Ball> listeBall = this.currentGame.GameModel.ListeBall;
            foreach (Ball ball in listeBall)
            {
                ball.ClientSize = this.gameBoard.Size;
                if(!this.gameBoard.Controls.Contains(ball.Box))
                {
                    this.gameBoard.Controls.Add(ball.Box);
                }
            }
            List<Gamer> listeGamer = this.currentGame.GameModel.ListeGamer;
            foreach (Gamer gamer in listeGamer)
            {
                gamer.Paddle.ClientSize = this.gameBoard.Size;
                if (!this.gameBoard.Controls.Contains(gamer.Paddle.Box))
                {
                    this.gameBoard.Controls.Add(gamer.Paddle.Box);
                }
            }
            List<Bonus> listeBonus = this.currentGame.GameModel.ListeBonus;
            foreach (Bonus bonus in listeBonus)
            {
                if (!bonus.Active)
                {
                    bonus.ClientSize = this.gameBoard.Size;
                    if (!this.gameBoard.Controls.Contains(bonus.Box))
                    {
                        this.gameBoard.Controls.Add(bonus.Box);
                    }
                }
                else
                {
                    if (this.gameBoard.Controls.Contains(bonus.Box))
                    {
                        this.gameBoard.Controls.Remove(bonus.Box);
                    }
                }
            }
            List<Brick> listeBrick = this.currentGame.GameModel.ListeBrick;
            foreach (Brick b in listeBrick)
            {
                if (b.Active)
                {
                    b.ClientSize = this.gameBoard.Size;
                    if (!this.gameBoard.Controls.Contains(b.Box))
                    {
                        this.gameBoard.Controls.Add(b.Box);
                    }
                }
                else
                {
                    if (this.gameBoard.Controls.Contains(b.Box))
                    {
                        this.gameBoard.Controls.Remove(b.Box);
                    }
                }
            }
            this.leftPointsLabel.Text = this.currentGame.getPoints(true).ToString();
            this.rightPointsLabel.Text = this.currentGame.getPoints(false).ToString();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
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

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //this.gameBoard.Refresh();
        }

        private SoundPlayer soundPlayer;
        private void MainForm_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(GameBasicClasses.Properties.Resources.gameMusic);
            soundPlayer.Load();
            soundPlayer.PlayLooping();
        }

        private void bonusTimer_Tick(object sender, EventArgs e)
        {
            List<Bonus> overBonuses = new List<Bonus>();
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b.Active && b.checkTimeOut())
                {
                    overBonuses.Add(b);
                }
            }
            this.removeOverBonuses(overBonuses);

            if(this.currentGame.GameModel.ListeBonus.Count <= 1)
            {
                Bonus b = this.getRandomBonus();
                this.currentGame.GameModel.addBonus(b);
            }
            this.gameBoard.Refresh();
        }

        private Bonus getRandomBonus()
        {
            Random r = new Random();
            Vector v = new Vector(r.Next(20, this.gameBoard.Width - 70), r.Next(0, this.gameBoard.Height-50));
            int i = r.Next(1,6);
            switch (i)
            {
                case 1:
                    return new HeightBonus(this.gameBoard.Width, this.gameBoard.Height, 10, v);
                case 2:
                    return new BallTrajectoryMalus(this.gameBoard.Width, this.gameBoard.Height, 3, v);
                case 3:
                    return new ReverseCommandsMalus(this.gameBoard.Width, this.gameBoard.Height, 20, v);
                case 4:
                    return new SpeedBonus(this.gameBoard.Width, this.gameBoard.Height, 3, v);
                case 5:
                    return new SpeedMalus(this.gameBoard.Width, this.gameBoard.Height, 5, v);
                case 6:
                    return new BallDiameterBonus(this.gameBoard.Width, this.gameBoard.Height, 5, v);
            }
            return new SpeedMalus(this.gameBoard.Width, this.gameBoard.Height, 5, v);
        }

        private void removeOverBonuses(List<Bonus> overBonuses)
        {
            foreach (Bonus b in overBonuses)
            {
                this.currentGame.GameModel.ListeBonus.Remove(b);
            }
        }

        private void brickTimer_Tick(object sender, EventArgs e)
        {
            List<Brick> overBricks = new List<Brick>();
            foreach (Brick b in this.currentGame.GameModel.ListeBrick)
            {
                if (!b.Active)
                {
                    overBricks.Add(b);
                }
            }
            this.removeOverBricks(overBricks);

            if (this.currentGame.GameModel.ListeBrick.Count <= 1)
            {
                Random r = new Random();
                Vector v = new Vector(r.Next(20, this.gameBoard.Width - 70), r.Next(0, this.gameBoard.Height-50));
                Brick b = new Brick(this.gameBoard.Width, this.gameBoard.Height, r.Next(3,10), v);
                this.currentGame.GameModel.addBrick(b);
            }
            this.gameBoard.Refresh();
        }

        private void removeOverBricks(List<Brick> overBricks)
        {
            foreach (Brick b in overBricks)
            {
                this.currentGame.GameModel.ListeBrick.Remove(b);
            }
        }
    }
}
