using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
	public class Wolf : Animal
	{
        public Wolf() {
			id = "Wolf";

            //Create Wolf Texture
            //Bitmap texture = Properties.Resources.wolf;

            //texture = id+".png";
		}

		public void wuff (Form1 form) {
            form.textBox1.Text += "Wuff! Wuff!" + Environment.NewLine;

        }

        public void ShowWulfOnMap(int x, int y, DataGridView dataGridView1)
        {
            //Show Wolf on Map
            // Add Wolf texture (now using plop.png for texting)
            dataGridView1.Rows[y].Cells[x].Value = Properties.Resources.wolf;
        }

    }
}

