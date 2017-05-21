using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
    public partial class Form1 : Form
    {
        Avatar me = new Avatar();

        public Form1()
        {
            InitializeComponent();
            //Initialize Key Events.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(keyup);
            KeyPreview = true;


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

        }


        //Creates 2 Nodes on our TreeView
        public void Treetest()
        {
            treeView1.Nodes.Add("Quest1");
            treeView1.Nodes.Add("Nichts");
            
        }

        //Just for testing
        public void CreateAvatar()
        {
            
            me.setXvalue(10);
            me.setYvalue(10);
            me.ShowOnMap("avatar", dataGridView1);
        }

        //Just for testing
        public void CreateWolf()            
        {
            //Moved from Program.cs
            textBox1.Text = "IT work's" + Environment.NewLine;

            Wolf shredder = new Wolf();
            Quest quest = new Quest("sub1", shredder);
            shredder.wuff(this);
            shredder.plop(this);

            int x = 3;
            int y = 9;

            shredder.setXvalue(x);
            shredder.setYvalue(y);

            //Show Wolf on Map
            shredder.ShowOnMap(Wolf.TextureId, dataGridView1);
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
                //Add Rows, Set images
                for (int x=0; x < size; x++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[i].Value = img;
                }
            }
        }


        //needed for Processing Keyevents
        private Boolean KeyisPressed;

        //Process Key Events
        private void keydown(object sender, KeyEventArgs e)
        {
            if (!KeyisPressed)
            {
                //textBox1.Text += e.KeyCode + Environment.NewLine;
                if(e.KeyCode == Keys.Right)
                {                 
                    me.MoveRight();
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    me.MoveLeft();
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    me.MoveUp();
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    me.MoveDown();
                    me.ShowOnMap("avatar", dataGridView1);
                }
                
                KeyisPressed = true;
            }
        }

        //Make everthing ready for next Key Event
        private void keyup(object sender, KeyEventArgs e)
        {
            KeyisPressed = false;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
