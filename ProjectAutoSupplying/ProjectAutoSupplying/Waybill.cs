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
    public partial class Waybill : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public Waybill()
        {
            InitializeComponent();
            button1.Click += createWaybill;
        }
        public Waybill(int index)
        {
            InitializeComponent();
            button1.Click += reloadWaybill;
            button1.Text = "Изменить запись";
            var waybill = db.WayBills.Find(index);
            textBox103.Text = waybill.AutoEnterprise;
        }


        private void createWaybill(object sender, EventArgs e)
        {

        }

        private void reloadWaybill(object sender, EventArgs e)
        {

        }
    }
}
