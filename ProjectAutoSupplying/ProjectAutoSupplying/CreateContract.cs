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
    public partial class CreateContract : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public CreateContract()
        {
            InitializeComponent();
            contractCargoComboBox.DataSource = db.Cargoes.Select(x => x.Name).ToList();
            contractLegalComboBox.DataSource = db.Legal_Entities.Select(x => x.Name).ToList();
            contractArriveDateTimePicker.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contractCompanyTextBox.Text.Trim().Length == 0 || contractCountTripTextBox.Text.Trim().Length == 0
                || contractDistanceTextBox.Text.Trim().Length == 0 || contractFromTextBox.Text.Trim().Length == 0
                || contractTonnesTextBox.Text.Trim().Length == 0 || contractToTextBox.Text.Trim().Length == 0)
                return;
            var cargo = db.Cargoes.Where(x => x.Name == contractCargoComboBox.SelectedItem.ToString()).First();
            var legal = db.Legal_Entities.Where(x => x.Name == contractLegalComboBox.SelectedItem.ToString()).First();
            var elem = new Models.Contract()
            {
                Arrive_time = contractArriveDateTimePicker.Value.TimeOfDay,
                Cargo_ID = cargo.Id,
                Legal_entity_ID = legal.Id,
                Company = contractCompanyTextBox.Text.Trim(),
                Count_trips = int.Parse(contractCountTripTextBox.Text.Trim()),
                Distance = double.Parse(contractDistanceTextBox.Text.Trim()),
                Tonnes = double.Parse(contractTonnesTextBox.Text.Trim()),
                Where_to_get_cargo = contractFromTextBox.Text.Trim(),
                Where_to_deliver_cargo = contractToTextBox.Text.Trim()
            };
            db.Contracts.Add(elem);
            db.SaveChanges();
            Close();
        }
    }
}
