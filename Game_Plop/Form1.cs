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


            // Create the DGV with an Image column
            this.Controls.Add(dataGridView1);
            

            for (int i=0; i < size; i++)
            {
                //dataGridView1.Columns.Add(i.ToString(), i.ToString());
                //DataGridViewColumn column = dataGridView1.Columns[i];

                DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
                dataGridView1.Columns.Add(imageCol);



                //DataGridViewImageColumn col = dataGridView1.Columns[i];
                //column.Width = formWidth/(size);                           // WIRD NICHT BENÖTIGT --> Eigenschaft der Tabelle "AutoSizeCollomnsMode" auf Fill
                //column.DefaultHeaderCellType =    TODODODODODDO

                for (int x=0; x < size; x++)
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[x].Cells[i].Value = img;
                }
            }

            // Testing
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
