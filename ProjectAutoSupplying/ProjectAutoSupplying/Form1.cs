using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAutoSupplying
{
    public partial class Form1 : Form
    {

        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public Form1()
        {
            InitializeComponent();
            dataGridView21.DataSource = db.WayBills.ToList();
            dataGridView22.DataSource = db.WayLists.ToList();
            dataGridView2.DataSource = db.Car_Trailer.ToList();
            dataGridView3.DataSource = db.Driver_Accompanying.ToList();
            dataGridView9.DataSource = db.DownTime_on_Lines.ToList();
            dataGridView10.DataSource = db.Fuels.ToList();
        }

        private void dataGridView21_DoubleClick(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }

        private void dataGridView21_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView21.SelectedRows.Count < 0)
                return;
            Form3 form3 = new Form3(int.Parse(dataGridView21.SelectedCells[0].Value.ToString()));
            form3.ShowDialog();
        }

        private void dataGridView22_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void dataGridView22_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView21.SelectedRows.Count < 0)
                return;
            Form2 form2 = new Form2(int.Parse(dataGridView21.SelectedCells[0].Value.ToString()));
            form2.ShowDialog();
        }
    }
}
