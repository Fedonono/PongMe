using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;

namespace GameBasicClasses.BasicClasses
{
    public class GameEngine : Controller
    {
        public GameModel Model { get; set; }

        public GameEngine(GameModel model)
        {
            this.Model = model;
        }

        public void startGame()
        {
            foreach (Ball ball in this.Model.ListeBall)
            {
                ball.Initialize();
            }
        }

        public void ToogleGame(bool movement)
        {
            foreach (Ball ball in this.Model.ListeBall)
            {
                ball.ToogleMovement(movement);
            }
        }

        public void stopGame()
        {
            foreach (Ball ball in this.Model.ListeBall)
            {
                this.Model.ListeBrick.Clear();
                this.Model.ListeBonus.Clear();
                ball.Initialize();
            }
        }

    }
}
