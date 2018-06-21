using ProjectAutoSupplying.Models;
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
    public partial class CreateDowntime : Form
    {
        DatabaseEntities2 db = new DatabaseEntities2();

        public CreateDowntime()
        {
            InitializeComponent();
            wayListComboBox.DataSource = db.WayLists.Select(x => x.Id).ToList();
            beginDateTimePicker.Value = endDateTimePicker.Value = DateTime.Now;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nameTextBox.Text.Trim().Length == 0 || wayListComboBox.SelectedIndex == -1 || codeTextBox.Text.Trim().Length == 0)
                return;
            db.DownTime_on_Lines.Add(new DownTime_on_Line()
            {
                Name = nameTextBox.Text.Trim(),
                End_time = endDateTimePicker.Value,
                Start_time = beginDateTimePicker.Value,
                Code = codeTextBox.Text.Trim(),
                WayList_ID = int.Parse(wayListComboBox.SelectedItem.ToString())
            });
            db.SaveChanges();
            this.Close();
        }
    }
}
