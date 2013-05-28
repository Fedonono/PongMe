﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GameBasicClasses.BasicClasses;
using GameBasicClasses.Gamer;
using GameBasicClasses.Obstacles.Bonus;

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
                this.gameBoard.Controls.Add(ball.Box);
            }
            List<Gamer> listeGamer = this.currentGame.GameModel.ListeGamer;
            foreach (Gamer gamer in listeGamer)
            {
                gamer.Paddle.ClientSize = this.gameBoard.Size;
                this.gameBoard.Controls.Add(gamer.Paddle.Box);
            }
            List<Bonus> listeBonus = this.currentGame.GameModel.ListeBonus;
            foreach (Bonus bonus in listeBonus)
            {
                if (!bonus.Active)
                {
                    bonus.ClientSize = this.gameBoard.Size;
                    this.gameBoard.Controls.Add(bonus.Box);
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

        }

        private void bonusTimer_Tick(object sender, EventArgs e)
        {
            if(this.currentGame.GameModel.ListeBonus.Count == 0)
            {
                this.currentGame.GameModel.addBonus(new SpeedMalus(this.gameBoard.Width, this.gameBoard.Height,5,new Vector(50,50)));
            }

            List<Bonus> overBonuses = new List<Bonus>();
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b.Active && b.checkTimeOut())
                {
                    overBonuses.Add(b);
                }
            }
            this.removeOverBonuses(overBonuses);
            
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

        }
    }
}