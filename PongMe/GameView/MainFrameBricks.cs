using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles;
using GameBasicClasses.BasicClasses;

namespace GameView
{
    public partial class MainForm
    {
        private Brick GetRandomBrick()
        {
            Random r = new Random();
            Brick b = null;
            do
            {
                Vector v = new Vector(r.Next(20, this.gameBoard.Width - Brick.Width - 20), r.Next(0, this.gameBoard.Height - Brick.Width));
                int i = r.Next(1, 5);
                b = new Brick(this.gameBoard.Width, this.gameBoard.Height, i, v);
            } while (this.CheckCollision(b));
            return b;
        }

        private int nbOfBricks;
        private int previousNbOfBricks = -1;
        private void BrickTimer_Tick(object sender, EventArgs e)
        {
            List<Brick> overBricks = new List<Brick>();
            foreach (Brick b in this.currentGame.GameModel.ListeBrick)
            {
                if (!b.Active)//on vérifie si des briques n'ont plus de vie
                {
                    overBricks.Add(b);
                }
            }
            this.RemoveOverBricks(overBricks);

            nbOfBricks = (this.gameBoard.Height / 2 - 10) / Brick.Width;//nombre de briques à placer
            if (this.currentGame.GameModel.ListeBrick.Count == 0 || nbOfBricks != previousNbOfBricks)//s'il n'y a plus de briques ou si le fenetre est redimensionnée
            {
                this.RemoveOverObstacles(this.currentGame.GameModel.ListeBrick);//supprime les briques encore restantes
                this.currentGame.GameModel.ListeBrick.Clear();
                Random r = new Random();
                for (int i = 0; i < 4; i++)//place les briques
                {
                    for (int j = 0; j < nbOfBricks; j++)
                    {
                        Vector v = null;
                        if (i == 0)
                        {
                            v = new Vector(this.gameBoard.Width / 2 - 50 - Brick.Width, Brick.Width * j);
                        }
                        else if (i == 1)
                        {
                            v = new Vector(this.gameBoard.Width / 2 - 50 - Brick.Width, this.gameBoard.ClientRectangle.Height - Brick.Width * j);
                        }
                        else if (i == 2)
                        {
                            v = new Vector(this.gameBoard.Width / 2 + 50, Brick.Width * j);
                        }
                        else if (i == 3)
                        {
                            v = new Vector(this.gameBoard.Width / 2 + 50, this.gameBoard.ClientRectangle.Height - Brick.Width * j);
                        }
                        Brick b = new Brick(this.gameBoard.Width, this.gameBoard.Height, r.Next(4, 8), v);
                        this.currentGame.GameModel.AddBrick(b);
                    }
                }
                previousNbOfBricks = nbOfBricks;
            }
            if (this.currentGame.GameModel.ListeBrick.Count < 15)
            {
                this.currentGame.GameModel.AddBrick(this.GetRandomBrick());
            }
            this.gameBoard.Refresh();
        }

        private void RemoveOverBricks(List<Brick> overBricks)
        {
            foreach (Brick b in overBricks)
            {
                this.currentGame.GameModel.ListeBrick.Remove(b);
            }
        }//supprime les briques de la liste de briques
    }
}
