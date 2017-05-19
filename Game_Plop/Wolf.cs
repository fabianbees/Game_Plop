using System;

namespace Game_Plop
{
	public class Wolf : Animal
	{
        public Wolf() {
			id = "Wolf";
			texture = id+".png";
		}

		public void wuff (Form1 form) {
            form.textBox1.Text += "Wuff! Wuff!" + Environment.NewLine;

        }

    }
}

