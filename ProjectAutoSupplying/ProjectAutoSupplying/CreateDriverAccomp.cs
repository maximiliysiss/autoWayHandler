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
    public partial class CreateDriverAccomp : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public CreateDriverAccomp()
        {
            InitializeComponent();
            roleComboBox.DataSource = (from role in db.Roles select role.Name).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Models.Driver_Accompanying driver_Accompanying = new Models.Driver_Accompanying()
            {
                Name = nameTextBox.Text,
                Surname = surnameTextBox.Text,
                Thridname = thirdNameTextBox.Text,
                Adress = adressRichBox.Text,
                Certification = certificateTextBox.Text,
                DateStart = startTime.Value,
                Phone = phoneTextBox.Text,
                Role_ID = db.Roles.Where(x => x.Name == roleComboBox.SelectedItem.ToString()).ToList()[0].Id
            };
            db.Driver_Accompanying.Add(driver_Accompanying);
            db.SaveChanges();
            this.Close();
        }
    }
}
