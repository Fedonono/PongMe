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
                this.GameEngine = new GameEngine();
            }
        }

        private GameEngine gameEngine;
        public GameEngine GameEngine { get { return this.gameEngine; } set { this.gameEngine = value;} }

        private CurrentGame()
        {
            this.gameModel = GameFactory.defaultGame();
        }

        public static CurrentGame getInstance()
        {
            if (instance == null)
            {
                instance = new CurrentGame();
            }
            return instance;
        }

        public void startGame()
        {
            if (this.gameEngine != null)
            {
                this.gameEngine.startGame();
            }
        }

        public void stopGame()
        {
            if (this.gameEngine != null)
            {
                this.gameEngine.stopGame();
            }
        }

        public void keyEvent(object sender, KeyEventArgs e)
        {
            this.gameModel.keyEvent(sender, e);
        }

    }
}
