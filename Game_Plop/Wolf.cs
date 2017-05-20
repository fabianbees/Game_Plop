using System;
using System.Drawing;

namespace Game_Plop
{
	public class Wolf : Animal
	{
        public Wolf() {
			id = "Wolf";

            //Create Wolf Texture
            //Bitmap texture = Properties.Resources.wolf;

            texture = id+".png";
		}

		public void wuff (Form1 form) {
            form.textBox1.Text += "Wuff! Wuff!" + Environment.NewLine;

        }

    }
}

