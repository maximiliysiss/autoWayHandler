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
    public partial class CreateLegal : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public CreateLegal()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (legalAccountTextBox.Text.Trim().Length == 0 || legalAdressTextBox.Text.Trim().Length == 0
                || legalBankNameTextBox.Text.Trim().Length == 0 || legalINNTextBox.Text.Trim().Length == 0
                || legalNameTextBox.Text.Trim().Length == 0 || legalOKONXTextBox.Text.Trim().Length == 0
                || legalOKPOTextBox.Text.Trim().Length == 0)
                return;
            var elem = new Models.Legal_Entity()
            {
                Account = legalAccountTextBox.Text.Trim(),
                Legal_Adress = legalAdressTextBox.Text.Trim(),
                Bank_Name = legalBankNameTextBox.Text.Trim(),
                INN = legalINNTextBox.Text.Trim(),
                OKONX = legalOKONXTextBox.Text.Trim(),
                OKPO = legalOKPOTextBox.Text.Trim(),
                Name = legalNameTextBox.Text.Trim()
            };
            db.Legal_Entities.Add(elem);
            db.SaveChanges();
            Close();
        }
    }
}
