using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace Game_Plop
{
    public partial class Form1 : Form
    {
        Avatar me = new Avatar();
        Wolf shredder = new Wolf();
        WildBoar boar = new WildBoar();
        Bear beer = new Bear();
        public string collisionObject;  //Object the avatar collides with
        Random random = new Random();   //Random damage during attack
        bool KeyLocked = false;
        int cool = 0;

        public Form1()
        {
            InitializeComponent();
            //Initialize Key Events.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(keydown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(keyup);
            KeyPreview = true;
            button3.Enabled = false;


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
            this.textBox1.SelectionStart = this.textBox1.Text.Length;
            this.textBox1.ScrollToCaret();



            //Create Image (Background)
            //Bitmap img = Properties.Resources.grass;
            Bitmap img = new Bitmap(Properties.Resources.grass, new Size(30, 30));


            //CreateTable
            CreateTable(25, img);



            //TEST for Tree View
            Treetest();
            //Create             
            CreateCreatures();
            //Create Avatar
            CreateAvatar();

        }


        //Creates 2 Nodes on our TreeView
        public void Treetest()
        {
            //InventoryBox
            treeViewInventory.Nodes.Add("Inventory:");
        }

        //Just for testing
        public void CreateAvatar()
        {
            me.initialize(10, 10, 100, "avatar", dataGridView1);
            progressBarHealth.Value = me.getHealth();
        }

        //Just for testing
        public void CreateCreatures()            
        {
            //Moved from Program.cs

            //now global
            //Wolf shredder = new Wolf();
            Quest quest = new Quest("sub1", shredder);
            shredder.wuff(this);
            //shredder.plop(this);
            shredder.initialize(3, 9, 50, "wolf", dataGridView1);
            quest.LoadQuest(this);
            beer.initialize(19, 1, 50, "bear", dataGridView1);
            boar.initialize(20, 18, 100, "wildboar", dataGridView1);

            
        }

        public void updateHealth(int i)
        {
            if (i < 1)
            {
                //die
                progressBarHealth.Value = 0;
                me.setHealth(0);
                textBox1.Text += "You died. Game Over!" + Environment.NewLine;
                KeyLocked = true;
                Bitmap plop = new Bitmap(Properties.Resources.plop, new Size(30, 30));
                dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = plop;
                button3.Enabled = false;

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
            if (!KeyisPressed && !KeyLocked)
            {
                if(e.KeyCode == Keys.Right)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveRight();
                }
                else if (e.KeyCode == Keys.Left)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveLeft();
                }
                else if (e.KeyCode == Keys.Up)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveUp();
                }
                else if (e.KeyCode == Keys.Down)
                {
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Value = img;
                    dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag = null;
                    me.MoveDown();
                }
                if (dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag != null)
                {
                    collisionObject = dataGridView1.Rows[me.getYvalue()].Cells[me.getXvalue()].Tag.ToString();
                    button1.Enabled = true;
                    KeyLocked = true;
                }
                else
                {
                    button1.Enabled = false;
                }
                me.ShowOnMap("avatar", dataGridView1);
                textBox1_TextChanged(sender, e);
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
            this.textBox1.Select(textBox1.Text.Length, 0);
            this.textBox1.ScrollToCaret();
            textBox1.Refresh();
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
                button1.Enabled = false;

                shredder.respawn("wolf", dataGridView1);
                KeyLocked = false;
                //bitte wegsschauen! Ist scheiße gemacht :)

                XmlDocument questXML = new XmlDocument();
                //HardCoded not needed!!!
                //We have to use LoadXml() instead of Load()
                //questXML.Load("C:\\Users\\fabia\\Documents\\Visual Studio 2017\\Projects\\Game_Plop\\Game_Plop\\testquest.xml");
                questXML.LoadXml(Properties.Resources.testquest);


                QuestObject quest = new QuestObject(questXML, this, false);
                quest.didSomething(this);
                treeViewInventory.Nodes.Add("Fleisch");
                button3.Enabled = true;
                //Hier weiter...
            }
            else
            {
                shredder.setHealth(enemyHealth);
            }
            textBox1.Text += "fight " + collisionObject + " - Health: " + enemyHealth + Environment.NewLine;
            textBox1.Text += "Gesundheit - " + avatarDamage + Environment.NewLine;
            updateHealth(progressBarHealth.Value - avatarDamage);   //Subtract random damage from Avatar health

            textBox1_TextChanged(sender, e);


        }

        //Button for healing
        private void button3_Click(object sender, EventArgs e)
        {
            me.heal(this);
            textBox1.Text += "Gesundheit bei: " + me.getHealth() + Environment.NewLine;
            textBox1_TextChanged(sender, e);
            cool++;
            if(cool > 2)
            {
                button3.Enabled = false;
                treeViewInventory.Nodes.Clear();
                treeViewInventory.Nodes.Add("Inventory:");
                cool = 0;
            }
        }

        //Button for collecting items
        private void button2_Click(object sender, EventArgs e)
        {
            me.inventory.Add(collisionObject);
        }
    }

}
