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
using GameBasicClasses.Obstacles.Paddle;

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

        private void Panel1_Paint(object sender, PaintEventArgs e)
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
            this.leftPointsLabel.Text = this.currentGame.GetPoints(false).ToString();
            this.rightPointsLabel.Text = this.currentGame.GetPoints(true).ToString();
            this.wheatleyLabel.Text = this.currentGame.GameModel.WeathleyPoint.ToString();
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            foreach (Ball ball in this.currentGame.GameModel.ListeBall)
            {
                ball.NextPosition();
                if (ball.IsOutRight && ball.IsMoving)
                {
                    ball.IsMoving = false;
                    this.currentGame.AddPoint(false);
                }
                else if (ball.IsOutLeft && ball.IsMoving)
                {
                    ball.IsMoving = false;
                    this.currentGame.AddPoint(true);
                }
            }

            if (keysPressed.Count > 0)
            {
                foreach (Keys key in keysPressed)
                {
                    this.currentGame.KeyEvent(key);
                }
            }
            else
            {
                this.currentGame.KeyEvent(Keys.A);//AI
            }

            if (this.currentGame.IsGameOver())
            {
                this.currentGame.StopGame();
                SoundPlayer soundPlayerEnd;
                soundPlayerEnd = new SoundPlayer(Properties.Resources.Portal2_Buzzer);
                soundPlayerEnd.Load();
                soundPlayerEnd.Play();

                this.ClearGameBoard(false);
                System.Threading.Thread.Sleep(2000);
                soundPlayerEnd.Dispose();
                this.PlayGameMusic();
            }
            this.gameBoard.Refresh();
        }

        private bool CheckCollision(Obstacle b)
        {
            if(this.CheckCollisionOb(this.currentGame.GameModel.ListePaddle(false,0,null), b) || 
                this.CheckCollisionOb(this.currentGame.GameModel.ListeBrick, b) ||
                this.CheckCollisionOb(this.currentGame.GameModel.ListeBonus, b))
            {
                return true;
            }
            return false;
        }

        private bool CheckCollisionOb<T>(List<T> liste, Obstacle ob) where T : Obstacle
        {
            foreach (Obstacle ib in liste)
            {
                if (Rectangle.Intersect(ib.Bounds, ob.Bounds) != Rectangle.Empty || ib.Bounds.Contains(ob.Bounds))
                {
                    return true;
                }
            }
            return false;
        }

        private void RemoveOverObstacles<T>(List<T> liste) where T : Obstacle//supprime les obstacles de la fenetre
        {
            foreach (Obstacle ob in liste)
            {
                if(this.gameBoard.Controls.Contains(ob.Box))
                {
                    this.gameBoard.Controls.Remove(ob.Box);
                }
            }
        }
    }
}
