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
    public partial class WayList : Form
    {
        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public WayList()
        {
            InitializeComponent();
            button1.Click += createRecord;
        }

        private void createRecord(object sender, EventArgs e)
        {

        }

        private void reloadRecord(object sender, EventArgs e)
        {

        }

        public WayList(int index)
        {
            InitializeComponent();
            button1.Click += reloadRecord;
            button1.Text = "Изменить запись";
            var waylist = db.WayLists.Find(index);
            listBox2.DataSource = (from trailers in db.Car_Trailer
                                   where db.Car_Tralers_in_WayList.Where(x => x.WayList_ID == index
                                   && x.Car_Trailer_ID == trailers.Id).ToList().Count == 0 && trailers.Transport_Type.Name == "Прицеп"
                                   select trailers.Name + " " + trailers.State_number + " " + trailers.Model).ToList();
            dataGridView14.DataSource = (from trailers in db.Car_Tralers_in_WayList
                                         where trailers.WayList_ID == index &&
                                         trailers.Car_Trailer.Transport_Type.Name == "Прицеп"
                                         select new
                                         {
                                             trailers.Car_Trailer.Name,
                                             trailers.Car_Trailer.Model,
                                             trailers.Car_Trailer.State_number
                                         }).ToList();
            dataGridView15.DataSource = (from accomp in db.Driver_Accompanying_in_WayList
                                         where accomp.WayList_ID == index &&
                                         accomp.Driver_Accompanying.Role.Name == "Сопровождающий"
                                         select new
                                         {
                                             accomp.Driver_Accompanying.Name,
                                             accomp.Driver_Accompanying.Surname,
                                             accomp.Driver_Accompanying.Thridname,
                                             accomp.Driver_Accompanying.Phone,
                                             accomp.Driver_Accompanying.Certification
                                         }).ToList();
        }
    }
}
