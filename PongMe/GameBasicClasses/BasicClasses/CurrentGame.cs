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

        private GameModel gameModel;
        public GameModel GameModel { 
            get { return this.gameModel; } 
            set 
            { 
                this.gameModel = value;
                this.GameEngine = new GameEngine(this.GameModel);
            }
        }

        private GameEngine gameEngine;
        public GameEngine GameEngine { get { return this.gameEngine; } set { this.gameEngine = value;} }

        public bool stopped { get; set; }

        private CurrentGame()
        {
            this.stopped = true;
            this.gameModel = GameFactory.defaultGame();
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
                this.stopped = false;
                this.gameEngine.startGame();
            }
        }

        public void StopGame()
        {
            if (this.gameEngine != null)
            {
                this.stopped = true;
                this.gameEngine.stopGame();
            }
        }

        public void ToggleGame()
        {
            //play/pause
            if (this.gameEngine != null)
            {
                this.stopped = !this.stopped;
            }
        }

        public void addPoint(bool left)
        {
            foreach (GameBasicClasses.Gamer.Gamer g in this.GameModel.ListeGamer)
            {
                if (g.Paddle.Left == left)
                {
                    g.incPoints();
                }
            }
	    }

        public int getPoints(bool left)
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

        public bool isGameOver()
        {
            int nbOfBallsOut = 0;
            foreach (Ball ball in this.GameModel.ListeBall)
            {
                if (ball.isOutRight || ball.isOutLeft)
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

        public void keyEvent(Keys e)
        {
            if (this.stopped && e == Keys.Space)
            {
                this.stopped = false;
            }
            this.gameModel.keyEvent(e, this.stopped);
        }
    }
}
