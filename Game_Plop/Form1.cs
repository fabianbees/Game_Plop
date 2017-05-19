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
            //TODO: rekursiver Pfad
            //Image img = Image.FromFile(@"C:\Users\Fabian\Documents\Visual Studio 2017\Projects\Game_Plop\Game_Plop\textures\grass.jpg");
            //Image img = Image.FromFile("C:\\Users\\Fabian\\Documents\\Visual Studio 2017\\Projects\\Game_Plop\\Game_Plop\\textures\\grass.jpg");

            //Bitmap img = new Bitmap(Image.FromFile(@"C:\Users\Fabian\Documents\Visual Studio 2017\Projects\Game_Plop\Game_Plop\textures\grass.jpg"));

            //object O = Resources.ResourceManager.GetObject("grass.jpg");

            Bitmap img = Properties.Resources.grass;







            CreateTable(25, img);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CreateTable(int size, Image img)
        {
            int formHeight = dataGridView1.Height;
            //int formWidth = dataGridView1.Width;                              // siehe column.Width = formWidth/(size);
            //Console.WriteLine(formWidth.ToString());

            dataGridView1.RowTemplate.Height = formHeight / (size);



            //create a DataGridView Image Cell
            //DataGridViewImageCell DGic = new DataGridViewImageCell();
            //DGic.Value = img;

            // Create the DGV with an Image column
            this.Controls.Add(dataGridView1);
            //DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            //dataGridView1.Columns.Add(imageCol);


            //Icon treeIcon = new Icon(this.GetType(), "tree.ico");
            //DataGridViewImageColumn imgColumn = new DataGridViewImageColumn();
            //imageCol.Image = img;
            //imageCol.Name = "grass";
            //imageCol.HeaderText = "Nice grass";
            //dataGridView1.Columns.Insert(1, imageCol);



            for (int i=0; i < size; i++)
            {
                //dataGridView1.Columns.Add(i.ToString(), i.ToString());
                //DataGridViewColumn column = dataGridView1.Columns[i];

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(imageCol);



                //dataGridView1.Columns.Add(imageCol);






                //DataGridViewImageColumn col = dataGridView1.Columns[i];
                //column.Width = formWidth/(size);                           // WIRD NICHT BENÖTIGT --> Eigenschaft der Tabelle "AutoSizeCollomnsMode" auf Fill
                //column.DefaultHeaderCellType =    TODODODODODDO

                for (int x=0; x < size; x++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[i].Value = img;
                }
                




            }
            //dataGridView1.Rows.Add(size);
            
            //dataGridView1.Rows[0].Cells[0].Value = img;

            //dataGridView1.Rows.Add(size);

            //Add Grass background
            //this.dataGridView1[0, 0] = DGic;


            // Create the image
            //Bitmap img;
            //img = new Bitmap(@"D:\Windows\Zapotec.bmp");



            // Add a row and set its value to the image
            //dataGridView1.Rows.Add();
            //dataGridView1.Rows[0].Cells[0].Value = img;



        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
