using Game_Plop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_Plop
{
    public partial class Form1 : Form
    {
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
            Bitmap img = Properties.Resources.grass;


            //CreateTable
            CreateTable(25, img);



            //TEST for Tree View
            Treetest();
            //Create Wolf Object
            CreateWolf();

        }


        //Creates 2 Nodes on our TreeView
        public void Treetest()
        {
            treeView1.Nodes.Add("Quest1");
            treeView1.Nodes.Add("Klicke auf die Karte");
            
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

            shredder.position[0] = 3;
            shredder.position[1] = 9;
            textBox1.Text += "Wolf X Koordinate:" + shredder.getXvalue().ToString() + Environment.NewLine;
            textBox1.Text += "Wolf Y Koordinate:" + shredder.getYvalue().ToString() + Environment.NewLine;

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
