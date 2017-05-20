using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
	public class Item
	{
		public int[] position = new int[2];
		public String texture;
        public String type;

		public Item ()
		{
			//TODO
		}


        public void ShowOnMap(int x, int y, String type, DataGridView dataGridView1)
        {
            try
            {
                var rm = new System.Resources.ResourceManager(((System.Reflection.Assembly)System.Reflection.Assembly.GetExecutingAssembly()).GetName().Name
                    + ".Properties.Resources", ((System.Reflection.Assembly)System.Reflection.Assembly.GetExecutingAssembly()));

                //Create Texture
                Bitmap img = (Bitmap)rm.GetObject(type);

                //Show on Map
                dataGridView1.Rows[y].Cells[x].Value = img;

            }
            catch (Exception e)
            {

            }
        }
    }
}

