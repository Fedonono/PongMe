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
            this.leftPointsLabel.Text = this.currentGame.getPoints(false).ToString();
            this.rightPointsLabel.Text = this.currentGame.getPoints(true).ToString();
            this.wheatleyLabel.Text = this.currentGame.GameModel.WeathleyPoint.ToString();
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
                SoundPlayer soundPlayerEnd;
                soundPlayerEnd = new SoundPlayer(Properties.Resources.Portal2_Buzzer);
                soundPlayerEnd.Load();
                soundPlayerEnd.Play();

                this.clearGameBoard(false);
                System.Threading.Thread.Sleep(2000);
                soundPlayerEnd.Dispose();
                this.playGameMusic();
            }
            this.gameBoard.Refresh();
        }

        private void animationTimer_Tick(object sender, EventArgs e)
        {
            //this.gameBoard.Refresh();
        }

        private void playGameMusic()
        {
            soundPlayer.PlayLooping();
        }

        private SoundPlayer soundPlayer;
        private void MainForm_Load(object sender, EventArgs e)
        {
            soundPlayer = new SoundPlayer(Properties.Resources.Nyan_Cat___Smooth_Jazz_Cover);
            soundPlayer.Load();
            this.playGameMusic();
        }

        private int nbOfWheatley;
        private int previousNbOfWheatley = -1;
        private void bonusTimer_Tick(object sender, EventArgs e)
        {
            List<Bonus> overBonuses = new List<Bonus>();
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b.Active && b.checkTimeOut())//on vérifie sur des bonus sont terminés et on les supprime
                {
                    overBonuses.Add(b);
                }
            }
            this.removeOverBonuses(overBonuses);

            nbOfWheatley = this.gameBoard.Height / 80;//calcul du nombre de cube à récupérer
            if (previousNbOfWheatley != nbOfWheatley || this.currentGame.GameModel.ListeBonus.Count == 0 || this.getNbOfWeathley() == 0)//si la fenetre s'agradit ou qu'il n'y a plus
                //de cube, on en ajoute
            {
                this.removeOverBonuses(this.removeOverWheatley());//on supprime les cubes encore restant
                for (int i = 0; i < nbOfWheatley; i++)
			    {
                     Bonus b = new WheatleyBonus(this.gameBoard.Width, this.gameBoard.Height, 1, new Vector(this.gameBoard.Width/2-25,i*80));//80 est la distance entre les cubes
                     this.currentGame.GameModel.addBonus(b);//on ajoute les cubes
			    }
                previousNbOfWheatley = nbOfWheatley;
            }

            if(this.currentGame.GameModel.ListeBonus.Count - this.getNbOfWeathley() <= 5)//on ne veut que 6 bonus sur la carte
            {
                Bonus b = this.getRandomBonus();
                this.currentGame.GameModel.addBonus(b);
            }
            this.gameBoard.Refresh();
        }

        private int getNbOfWeathley()
        {
            int i = 0;
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b is WheatleyBonus)
                {
                    i++;
                }
            }
            return i;
        }

        private List<Bonus> removeOverWheatley()
        {
            List<Bonus> liste = new List<Bonus>(); ;
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b is WheatleyBonus)
                {
                    liste.Add(b);
                }
            }
            this.removeOverObstacles(liste);
            return liste;
        }//supprime tous les cubes

        private Bonus getRandomBonus()
        {
            Random r = new Random();
            Bonus b = null;
            do
            {
                Vector v = new Vector(r.Next(20, this.gameBoard.Width - 70), r.Next(0, this.gameBoard.Height - 50));
                int i = r.Next(1, 8);
                switch (i)
                {
                    case 1:
                        b = new HeightBonus(this.gameBoard.Width, this.gameBoard.Height, 5, v);
                        break;
                    case 2:
                        b = new ReverseCommandsMalus(this.gameBoard.Width, this.gameBoard.Height, 10, v);
                        break;
                    case 3:
                        b = new SpeedBonus(this.gameBoard.Width, this.gameBoard.Height, 3, v);
                        break;
                    case 4:
                        b = new SpeedMalus(this.gameBoard.Width, this.gameBoard.Height, 4, v);
                        break;
                    case 5:
                        b = new BallDiameterBonus(this.gameBoard.Width, this.gameBoard.Height, 8, v);
                        break;
                    case 6:
                        b = new PortalMalus(this.gameBoard.Width, this.gameBoard.Height, 1, v);
                        break;
                    case 7:
                        b = new NoPortalBonus(this.gameBoard.Width, this.gameBoard.Height, 10, v);
                        break;
                }
            } while (this.checkCollision(b));
            return b;
        }

        private Brick getRandomBrick()
        {
            Random r = new Random();
            Brick b = null;
            do
            {
                Vector v = new Vector(r.Next(20, this.gameBoard.Width - Brick.Width - 20), r.Next(0, this.gameBoard.Height - Brick.Width));
                int i = r.Next(1, 5);
                b = new Brick(this.gameBoard.Width, this.gameBoard.Height, i, v);
            } while (this.checkCollision(b));
            return b;
        }

        private bool checkCollision(Obstacle b)
        {
            if(this.checkCollisionOb(this.currentGame.GameModel.listePaddle(false,0,null), b) || 
                this.checkCollisionOb(this.currentGame.GameModel.ListeBrick, b) ||
                this.checkCollisionOb(this.currentGame.GameModel.ListeBonus, b))
            {
                return true;
            }
            return false;
        }

        private bool checkCollisionOb<T>(List<T> liste, Obstacle ob) where T : Obstacle
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

        private void removeOverBonuses(List<Bonus> overBonuses)
        {
            foreach (Bonus b in overBonuses)
            {
                this.currentGame.GameModel.ListeBonus.Remove(b);
            }
        }//supprime les bonus de la liste de bonus

        private int nbOfBricks;
        private int previousNbOfBricks = -1;
        private void brickTimer_Tick(object sender, EventArgs e)
        {
            List<Brick> overBricks = new List<Brick>();
            foreach (Brick b in this.currentGame.GameModel.ListeBrick)
            {
                if (!b.Active)//on vérifie si des briques n'ont plus de vie
                {
                    overBricks.Add(b);
                }
            }
            this.removeOverBricks(overBricks);

            nbOfBricks = (this.gameBoard.Height / 2 - 10) / Brick.Width;//nombre de briques à placer
            if (this.currentGame.GameModel.ListeBrick.Count == 0 || nbOfBricks != previousNbOfBricks)//s'il n'y a plus de briques ou si le fenetre est redimensionnée
            {
                this.removeOverObstacles(this.currentGame.GameModel.ListeBrick);//supprime les briques encore restantes
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
                            v = new Vector(this.gameBoard.Width / 2 + 50, this.gameBoard.ClientRectangle.Height -  Brick.Width * j);
                        }
                        Brick b = new Brick(this.gameBoard.Width, this.gameBoard.Height, r.Next(4, 8), v);
                        this.currentGame.GameModel.addBrick(b);
                    }
                }
                previousNbOfBricks = nbOfBricks;
            }
            if (this.currentGame.GameModel.ListeBrick.Count < 15)
            {
                this.currentGame.GameModel.addBrick(this.getRandomBrick());
            }
            this.gameBoard.Refresh();
        }

        private void removeOverBricks(List<Brick> overBricks)
        {
            foreach (Brick b in overBricks)
            {
                this.currentGame.GameModel.ListeBrick.Remove(b);
            }
        }//supprime les briques de la liste de briques

        private void removeOverObstacles<T>(List<T> liste) where T : Obstacle//supprime les obstacles de la fenetre
        {
            foreach (Obstacle ob in liste)
            {
                if(this.gameBoard.Controls.Contains(ob.Box))
                {
                    this.gameBoard.Controls.Remove(ob.Box);
                }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Name = "MainForm";
            this.ResumeLayout(false);

        }
    }
}
