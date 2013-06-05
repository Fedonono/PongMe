using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public class CurrentGame
    {
        private static CurrentGame instance = null;
        public static int width = 1460;
        public static int height = 878;

        private GameModel gameModel;
        public GameModel GameModel { 
            get { return this.gameModel; } 
            set 
            {
                this.Stopped = true;
                this.StopGame();
                this.gameModel = value;
                this.GameEngine = new GameEngine(this.GameModel);
            }
        }

        private GameEngine gameEngine;
        public GameEngine GameEngine { get { return this.gameEngine; } set { this.gameEngine = value;} }

        public bool Stopped { get; set; }

        private CurrentGame()
        {
            this.Stopped = true;
            this.gameModel = GameFactory.OnePlayerGame();
            this.GameEngine = new GameEngine(this.GameModel);
        }

        public static CurrentGame GetInstance()
        {
            if (instance == null)
            {
                instance = new CurrentGame();
            }
            return instance;
        }

        public void StartGame()
        {
            if (this.gameEngine != null)
            {
                this.Stopped = false;
                this.gameEngine.StartGame();
            }
        }

        public void StopGame()
        {
            if (this.gameEngine != null)
            {
                this.Stopped = true;
                this.GameModel.ListeBonus.Clear();
                this.GameModel.ListeBrick.Clear();
                this.gameEngine.StopGame();
            }
        }

        public void ToggleGame()
        {
            if (this.gameEngine != null)
            {
                this.Stopped = !this.Stopped;
                this.gameEngine.ToogleGame(this.Stopped);
            }
        }

        public void AddPoint(bool left)
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.GameModel.ListeGamer)
            {
                if (g.Paddle.Left == left)
                {
                    g.IncPoints();
                }
            }
	    }

        public int GetPoints(bool left)
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.GameModel.ListeGamer)
            {
                if (g.Paddle.Left == left)
                {
                    return g.Points;
                }
            }
            return 0;
        }

        public bool IsGameOver()
        {
            int nbOfBallsOut = 0;
            foreach (Ball ball in this.GameModel.ListeBall)
            {
                if (ball.IsOutRight || ball.IsOutLeft)
                {
                    nbOfBallsOut++;
                }
            }
            if (nbOfBallsOut == this.GameModel.ListeBall.Count)
            {
                return true;
            }
            return false;
        }

        public void KeyEvent(Keys e)
        {
            if (this.Stopped && e == Keys.Space)
            {
                this.Stopped = false;
            }
            this.gameModel.KeyEvent(e, this.Stopped);
        }

        public void AddWheatleyPoint()
        {
            this.GameModel.WeathleyPoint++;
        }

        public void ResetWeathleyPoint()
        {
            this.GameModel.WeathleyPoint = 0;
        }
    }
}
