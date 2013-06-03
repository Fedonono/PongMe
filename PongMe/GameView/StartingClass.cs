using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GameView
{
    public class StartingClass
    {
        [STAThread]
        static void Main()
        {
            Application.Run(new MainForm());
        }
    }
}
