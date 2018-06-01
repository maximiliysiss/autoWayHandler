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
    public partial class CreateCarTrailer : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();
        public CreateCarTrailer()
        {
            InitializeComponent();
            typeComboBox.DataSource = (from type in db.Transport_Types select type.Name).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Car_Trailer car_Trailer = new Models.Car_Trailer()
            {
                Name = nameTextBox.Text,
                Model = modelTextBox.Text,
                State_number = numberTextBox.Text,
                Type_ID = db.Transport_Types.Where(x => x.Name == typeComboBox.SelectedItem.ToString()).ToList()[0].Id
            };
            db.Car_Trailer.Add(car_Trailer);
            db.SaveChanges();
            Close();
        }
    }
}
