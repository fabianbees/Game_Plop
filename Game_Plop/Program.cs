using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Plop
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Console.WriteLine("IT work's!");

            Wolf shredder = new Wolf();
            Quest quest = new Quest("sub1", shredder);

            shredder.wuff();
            shredder.plop();
            //shredder = null;
            //TEST über Browser
            //TEST über VS

            //new version 17.05.2017, 18:45

        }
    }
}
