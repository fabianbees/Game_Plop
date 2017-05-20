using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
	public class Wolf : Animal
	{
        public Wolf() {
			String TextureId = "wolf";
		}

		public void wuff (Form1 form) {
            form.textBox1.Text += "Wuff! Wuff!" + Environment.NewLine;

        }

        // Not needed anymore, see Creature.cs ShowOnMap()
        public void ShowWulfOnMap(int x, int y, DataGridView dataGridView1)
        {
            //Show Wolf on Map
            // Add Wolf texture (now using plop.png for texting)
            dataGridView1.Rows[y].Cells[x].Value = Properties.Resources.wolf;
        }

    }
}

