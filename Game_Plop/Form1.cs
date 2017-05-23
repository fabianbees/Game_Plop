using System;
using System.Drawing;
using System.Windows.Forms;

namespace Game_Plop
{
    public partial class Form1 : Form
    {
        Avatar me = new Avatar();
        Wolf shredder = new Wolf();
        public string collisionObject;  //Object the avatar collides with
        Random random = new Random();   //Random damage during attack

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
            treeViewQuests.Nodes.Add("Quest1");
            treeViewQuests.Nodes.Add("Nichts");

            //InventoryBox
            treeViewInventory.Nodes.Add("Inventory");
        }

        //Just for testing
        public void CreateAvatar()
        {
            me.initialize(10, 10, 100, "avatar", dataGridView1);
            progressBarHealth.Value = me.getHealth();
        }

        //Just for testing
        public void CreateWolf()            
        {
            //Moved from Program.cs

            //now global
            //Wolf shredder = new Wolf();
            Quest quest = new Quest("sub1", shredder);
            shredder.wuff(this);
            //shredder.plop(this);
            shredder.initialize(3, 9, 50, Wolf.TextureId, dataGridView1);

        }

        public void updateHealth(int i)
        {
            if (i < 1)
            {
                //die
                progressBarHealth.Value = 0;
                me.setHealth(0);
                textBox1.Text += "You died. Game Over!" + Environment.NewLine;

            }
            else
            {
                if (i >= progressBarHealth.Maximum)
                {
                    i = progressBarHealth.Maximum;
                }
                progressBarHealth.Value = i;
                me.setHealth(i);
            }
        }


        public void CreateTable(int size, Image img)
        {
            int formHeight = dataGridView1.Height;
            //int formWidth = dataGridView1.Width;                              // see column.Width = formWidth/(size);

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
            Bitmap img = new Bitmap(Properties.Resources.grass, new Size(30, 30));
            if (!KeyisPressed)
            {
                //textBox1.Text += e.KeyCode + Environment.NewLine;
                if(e.KeyCode == Keys.Right)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveRight();
                    if (dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag != null)
                    {
                        textBox1.Text += "Collision with: " + dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString() + Environment.NewLine;
                        collisionObject = dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString();
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Left)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveLeft();
                    if (dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag != null)
                    {
                        textBox1.Text += "Collision with: " + dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString() + Environment.NewLine;
                        collisionObject = dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString();
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Up)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveUp();
                    if (dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag != null)
                    {
                        textBox1.Text += "Collision with: " + dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString() + Environment.NewLine;
                        collisionObject = dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString();
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }
                    me.ShowOnMap("avatar", dataGridView1);
                }
                else if (e.KeyCode == Keys.Down)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveDown();
                    if (dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag != null)
                    {
                        textBox1.Text += "Collision with: " + dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString() + Environment.NewLine;
                        collisionObject = dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString();
                        button1.Enabled = true;
                    }
                    else
                    {
                        button1.Enabled = false;
                    }
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

        //Button for fighting
        private void button1_Click(object sender, EventArgs e)
        {
            int avatarDamage = random.Next(10, 40);
            int damage = random.Next(10, 50);
            int enemyHealth = shredder.getHealth() - damage;  //Just for testing
            if (enemyHealth < 1)
            {
                //enemy died
                enemyHealth = 0;
                //drop something

                //respawn
                shredder.initialize(6, 9, 50, Wolf.TextureId, dataGridView1);
            }
            shredder.setHealth(enemyHealth);
            textBox1.Text += "fight " + collisionObject + " - Health: " + enemyHealth + Environment.NewLine;
            textBox1.Text += "Gesundheit - " + avatarDamage + Environment.NewLine;
            updateHealth(progressBarHealth.Value - avatarDamage);   //Subtract random damage from Avatar health
            
        }

        //Button for healing
        private void button3_Click(object sender, EventArgs e)
        {
            me.heal(this);
            textBox1.Text += "Gesundheit bei: " + me.getHealth() + Environment.NewLine;
        }

        //Button for collecting items
        private void button2_Click(object sender, EventArgs e)
        {
            me.inventory.Add(collisionObject);
        }
    }

}
