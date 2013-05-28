using System.Drawing;
using GameBasicClasses.Obstacles.Paddle;
using GameBasicClasses.Gamer;
using System.Windows.Forms;

namespace GameBasicClasses.BasicClasses
{
    public class GameFactory
    {
        public static GameModel defaultGame()
        {
            GameModel gm = new GameModel();
<<<<<<< HEAD
            gm.addBall(new Ball(0.5f, 35, Color.Empty, GameBasicClasses.Properties.Resources.Ball, ClientDim));
            //gm.addBall(new Ball(0.2f, 35, Color.Empty, GameBasicClasses.Properties.Resources.Ball, 1000, 600));
            
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.Raquette, 20, 50, 10, 1000, 600);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.Raquette, 20, 50, 10, 1000, 600);
            gm.addGamer(new Human(true, Keys.Up, Keys.Down, p));
            gm.addGamer(new Human(false, Keys.Z, Keys.S, p2));
=======
            gm.addBall(new Ball(0.5f, 20, Color.Empty, GameBasicClasses.Properties.Resources.balle, 1000, 600));
            gm.addBall(new Ball(0.2f, 20, Color.Empty, GameBasicClasses.Properties.Resources.balle, 1000, 600));
            Paddle p = new Paddle(true, Color.Empty, GameBasicClasses.Properties.Resources.bat, 14, 60, 10, 1000, 600);
            Paddle p2 = new Paddle(false, Color.Empty, GameBasicClasses.Properties.Resources.bat, 14, 60, 10, 1000, 600);
            gm.addGamer(new Human(Keys.Up, Keys.Down, p2));
            gm.addGamer(new Human(Keys.Z, Keys.S, p));
>>>>>>> 5dc767122a80e3da5bd96d8957cc00c59c4df4f2
            return gm;
        }

        
    }
}
