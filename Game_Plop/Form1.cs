using System;
using System.Drawing;
using System.Windows.Forms;
/*
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Game_Plop.Properties;
*/
namespace Game_Plop
{
    public partial class Form1 : Form
    {
        Avatar me = new Avatar();

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            
            /*
            //Hide Mouse
            Rectangle BoundRect;
            Rectangle OldRect = Cursor.Clip;
            //Set Location
            BoundRect = new Rectangle(50, 50, 1, 1);
            Cursor.Clip = BoundRect;
            Cursor.Hide();
            //Application.AddMessageFilter(this);
            */

            //Create DataGridView
            DataGridView dataGridView1 = new DataGridView();

            //Set properties for dataGridView1
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;     //Not sure if correct
            dataGridView1.MultiSelect = false;


            //Create Image (Background)
            //Bitmap img = Properties.Resources.grass;
            Bitmap img = new Bitmap(Properties.Resources.grass, new Size(30, 30));


            //CreateTable
            CreateTable(25, img);



            //TEST for Tree View
            Treetest();
            //Create Wolf Object
            CreateWolf();
            //Create Avatar
            CreateAvatar();

            this.KeyDown += new System.Windows.Forms.KeyEventHandler(keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(keyup);
            KeyPreview = true;

        }


        //Creates 2 Nodes on our TreeView
        public void Treetest()
        {
            treeView1.Nodes.Add("Quest1");
            treeView1.Nodes.Add("Klicke auf die Karte");
            
        }

        //Just for testing
        public void CreateAvatar()
        {
            
            me.position[0] = 10;
            me.position[1] = 10;
            me.ShowOnMap(Avatar.TextureId, dataGridView1);
        }

        //Just for testing
        public void CreateWolf()            
        {
            //Moved from Program.cs
            //Console.WriteLine("IT work's!");
            textBox1.Text = "IT work's" + Environment.NewLine;

            Wolf shredder = new Wolf();
            Quest quest = new Quest("sub1", shredder);
            shredder.wuff(this);
            shredder.plop(this);

            int x = 3;
            int y = 9;

            shredder.position[0] = x;
            shredder.position[1] = y;

            //Show Wolf on Map
            //TODO: Add a Wolf texture (now using plop.png for texting)
            shredder.ShowOnMap(Wolf.TextureId, dataGridView1);

            //textBox1.Text += Avatar.TextureId + Environment.NewLine;
            textBox1.Text += "Wolf X Koordinate:" + shredder.getXvalue() + Environment.NewLine;
            textBox1.Text += "Wolf Y Koordinate:" + shredder.getYvalue() + Environment.NewLine;

        }



        public void CreateTable(int size, Image img)
        {
            int formHeight = dataGridView1.Height;
            //int formWidth = dataGridView1.Width;                              // see column.Width = formWidth/(size);
            //Console.WriteLine(formWidth.ToString());

            dataGridView1.RowTemplate.Height = formHeight / (size);


            // Something ... ???
            //this.Controls.Add(dataGridView1);
            

            for (int i=0; i < size; i++)
            {
                //dataGridView1.Columns.Add(i.ToString(), i.ToString());
                //DataGridViewColumn column = dataGridView1.Columns[i];

                //Use DataGridViewImageColumn to set images to the columns
                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(imageCol);


                //column.Width = formWidth/(size);                           // Not needed any more --> Table Properties "AutoSizeCollomnsMode" to Fill
                //column.DefaultHeaderCellType =    TODODODODODDO

                
                //Add Rows, Set images
                for (int x=0; x < size; x++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[i].Value = img;
                }
            }
        }


        private Boolean KeyisPressed;

        private void keydown(object sender, KeyEventArgs e)
        {
            if (!KeyisPressed)
            {
                textBox1.Text += "TEST" + e.KeyCode + sender + Environment.NewLine;
                if(e.KeyCode == Keys.Right)
                {                 
                    me.position[0]++;
                    me.ShowOnMap(Avatar.TextureId, dataGridView1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    me.position[0]--;
                    me.ShowOnMap(Avatar.TextureId, dataGridView1);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    me.position[1]--;
                    me.ShowOnMap(Avatar.TextureId, dataGridView1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    me.position[1]++;
                    me.ShowOnMap(Avatar.TextureId, dataGridView1);
                }
                
                KeyisPressed = true;
            }
        }

        private void keyup(object sender, KeyEventArgs e)
        {
            KeyisPressed = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Just for testing
            treeView1.Nodes.Clear(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
