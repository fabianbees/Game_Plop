using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
	public class Wolf : Animal
	{
        public Wolf() {
            TextureId = "wolf";

        }

		public void wuff (Form1 form) {
            form.textBox1.Text += "Wuff! Wuff!" + Environment.NewLine;

        }
    }
}

