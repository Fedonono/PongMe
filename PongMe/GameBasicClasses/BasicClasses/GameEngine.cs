using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.MVC;
using GameBasicClasses.Obstacles.Paddle;

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
                ball.Initialize();
            }
            foreach (Paddle p in this.Model.listePaddle(false, 0, null))
            {
                p.Initialize();
            }
            foreach (Gamer.Gamer g in this.Model.ListeGamer)
            {
                g.Initialize();
            }
        }

    }
}
