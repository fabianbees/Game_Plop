using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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


            //Set properties for dataGridView1
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;     //Not sure if correct
            dataGridView1.MultiSelect = false;




            CreateTable(25);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void CreateTable(int size)
        {
            int formHeight = dataGridView1.Height;
            //int formWidth = dataGridView1.Width;                      // siehe column.Width = formWidth/(size);
            //Console.WriteLine(formWidth.ToString());

            dataGridView1.RowTemplate.Height = formHeight / (size);

            for (int i=0; i < size; i++)
            {
                dataGridView1.Columns.Add(i.ToString(), i.ToString());
                DataGridViewColumn column = dataGridView1.Columns[i];
                //column.Width = formWidth/(size);                      // WIRD NICHT BENÖTIGT --> Eigenschaft der Tabelle "AutoSizeCollomnsMode" auf Fill
                //column.DefaultHeaderCellType =    TODODODODODDO
            }
            dataGridView1.Rows.Add(size);


        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }


}
