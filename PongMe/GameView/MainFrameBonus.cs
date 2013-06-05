using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GameBasicClasses.Obstacles.Bonus;
using GameBasicClasses.BasicClasses;

namespace GameView
{
    public partial class MainForm
    {
        private int nbOfWheatley;
        private int previousNbOfWheatley = -1;
        private void BonusTimer_Tick(object sender, EventArgs e)
        {
            List<Bonus> overBonuses = new List<Bonus>();
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b.Active && b.CheckTimeOut())//on vérifie sur des bonus sont terminés et on les supprime
                {
                    overBonuses.Add(b);
                }
            }
            this.RemoveOverBonuses(overBonuses);

            nbOfWheatley = this.gameBoard.Height / 80;//calcul du nombre de cube à récupérer
            if (previousNbOfWheatley != nbOfWheatley || this.currentGame.GameModel.ListeBonus.Count == 0 || this.getNbOfWeathley() == 0)//si la fenetre s'agradit ou qu'il n'y a plus
            //de cube, on en ajoute
            {
                this.RemoveOverBonuses(this.RemoveOverWheatley());//on supprime les cubes encore restant
                for (int i = 0; i < nbOfWheatley; i++)
                {
                    Bonus b = new WheatleyBonus(this.gameBoard.Width, this.gameBoard.Height, 1, new Vector(this.gameBoard.Width / 2 - 25, i * 80));//80 est la distance entre les cubes
                    this.currentGame.GameModel.AddBonus(b);//on ajoute les cubes
                }
                previousNbOfWheatley = nbOfWheatley;
            }

            if (this.currentGame.GameModel.ListeBonus.Count - this.getNbOfWeathley() <= 5)//on ne veut que 6 bonus sur la carte
            {
                Bonus b = this.GetRandomBonus();
                this.currentGame.GameModel.AddBonus(b);
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

        private List<Bonus> RemoveOverWheatley()
        {
            List<Bonus> liste = new List<Bonus>(); ;
            foreach (Bonus b in this.currentGame.GameModel.ListeBonus)
            {
                if (b is WheatleyBonus)
                {
                    liste.Add(b);
                }
            }
            this.RemoveOverObstacles(liste);
            return liste;
        }//supprime tous les cubes

        private Bonus GetRandomBonus()
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
            } while (this.CheckCollision(b));
            return b;
        }

        private void RemoveOverBonuses(List<Bonus> overBonuses)
        {
            foreach (Bonus b in overBonuses)
            {
                this.currentGame.GameModel.ListeBonus.Remove(b);
            }
        }//supprime les bonus de la liste de bonus
    }
}
