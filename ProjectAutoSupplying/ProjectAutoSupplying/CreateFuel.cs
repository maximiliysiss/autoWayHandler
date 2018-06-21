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
    public partial class CreateFuel : Form
    {
        public CreateFuel()
        {
            InitializeComponent();
        }

        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        private void createButton_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0 || numberTextBox.Text.Trim().Length == 0 ||
                priceTextBox.Text.Trim().Length == 0)
                return;
            db.Fuels.Add(new Models.Fuel()
            {
                Name = nameTextBox.Text.Trim(),
                Number = numberTextBox.Text.Trim(),
                Price = int.Parse(priceTextBox.Text.Trim())
            });
            db.SaveChanges();
            Close();
        }
    }
}
