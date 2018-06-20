﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectAutoSupplying
{
    public partial class MainFrame : Form
    {

        Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        private Models.Car_Trailer selectedCar = null;
        private Models.Driver_Accompanying selectedDriver = null;

        private void ReloadCarsData()
        {
            dataGridView2.DataSource = (from car in db.Car_Trailer
                                        select new
                                        {
                                            ID = car.Id,
                                            Модель = car.Model,
                                            Название = car.Name,
                                            Номер = car.State_number,
                                            Тип = car.Transport_Type.Name
                                        }).ToList();
        }

        private void ReloadDriversData()
        {
            dataGridView3.DataSource = (from driver in db.Driver_Accompanying
                                        select new
                                        {
                                            ID = driver.Id,
                                            Имя = driver.Name,
                                            Фамилия = driver.Surname,
                                            Отчество = driver.Thridname,
                                            Удостоверение = driver.Certification,
                                            Роль = driver.Role.Name,
                                            Адрес = driver.Adress,
                                            Телефон = driver.Phone
                                        }).ToList();
        }

        private void ReloadDownTimesData()
        {
            dataGridView9.DataSource = (from downtime in db.DownTime_on_Lines
                                        select new
                                        {
                                            ID = downtime.Id,
                                            Наименование = downtime.Name,
                                            Начало = downtime.Start_time,
                                            Окончание = downtime.End_time,
                                            Код = downtime.Code,
                                            ПутевойЛист = downtime.WayList_ID
                                        }).ToList();
        }

        private void ReloadFuelData()
        {
            dataGridView10.DataSource = (from fuel in db.Fuels
                                         select new
                                         {
                                             ID = fuel.Id,
                                             Название = fuel.Name,
                                             Номер = fuel.Number,
                                             Цена = fuel.Price
                                         }).ToList();
        }

        enum TypeClear
        {
            Car, Driver, Fuel, Downtime
        }

        private void ClearForm(TypeClear type)
        {
            switch (type)
            {
                case TypeClear.Car:
                    textBox28.Text = "";
                    textBox41.Text = "";
                    textBox42.Text = "";
                    comboBox18.SelectedIndex = 0;
                    selectedCar = null;
                    break;
                case TypeClear.Downtime:
                    break;
                case TypeClear.Driver:
                    textBox26.Text = "";
                    textBox27.Text = "";
                    comboBox16.SelectedIndex = 0;
                    richTextBox3.Text = "";
                    textBox30.Text = "";
                    dateTimePicker1.Value = dateTimePicker1.MinDate;
                    dateTimePicker2.Value = dateTimePicker1.MinDate;
                    selectedDriver = null;
                    break;
                case TypeClear.Fuel:
                    break;
            }
        }

        public MainFrame()
        {
            InitializeComponent();

            /*FileStream fileStream = new FileStream("Settings.settings", FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            String json = streamReader.ReadToEnd();
            JObject jObject = JObject.Parse(json);
            streamReader.Close();
            fileStream.Close();
            var settings = jObject["settings"];
            textBox1.Text = settings["name"].ToString();
            textBox2.Text = settings["inn"].ToString();
            textBox4.Text = settings["okonx"].ToString();
            textBox3.Text = settings["okpo"].ToString();
            textBox5.Text = settings["adress"].ToString();
            textBox6.Text = settings["phone"].ToString();*/

            dataGridView21.DataSource = (from waybill in db.WayBills
                                         select new
                                         {
                                             ID = waybill.Id,
                                             Автопредприятие = waybill.AutoEnterprise,
                                             waybill.Loading_Point,
                                             waybill.Unloading_Point,
                                             Грузоотправитель = waybill.Shipper,
                                             Грузополучатель = waybill.Consignee,
                                             Машина = waybill.Car_Trailer.Name,
                                             Водитель = waybill.Driver_Accompanying.Name,
                                             Вид = waybill.Transport_kind
                                         }).ToList();
            dataGridView22.DataSource = (from waylist in db.WayLists
                                         select new
                                         {
                                             ID = waylist.Id,
                                             Прибытие = waylist.Arrive_time,
                                             Груз = waylist.Contract.Cargo.Name,
                                             Компания = waylist.Contract.Company,
                                             Куда = waylist.Contract.Where_to_deliver_cargo,
                                             Откуда = waylist.Contract.Where_to_get_cargo
                                         }).ToList();
            this.ReloadCarsData();
            this.ReloadDownTimesData();
            this.ReloadDriversData();
            this.ReloadFuelData();
            comboBox16.DataSource = (from role in db.Roles select role.Name).ToList();
            comboBox18.DataSource = (from type in db.Transport_Types select type.Name).ToList();
        }

        private void dataGridView3_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var driver = db.Driver_Accompanying.Find(int.Parse(dataGridView3.SelectedCells[0].Value.ToString()));
            textBox26.Text = $"{driver.Name} {driver.Surname} {driver.Thridname}";
            textBox27.Text = driver.Certification;
            comboBox16.SelectedItem = driver.Role.Name;
            richTextBox3.Text = driver.Adress;
            textBox30.Text = driver.Phone;
            dateTimePicker1.Value = driver.DateStart.Value;
            dateTimePicker2.Value = driver.DateEnd.HasValue ? driver.DateEnd.Value : dateTimePicker2.MinDate;
            selectedDriver = driver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (selectedDriver == null)
                return;
            var driver = db.Driver_Accompanying.Find(int.Parse(dataGridView3.SelectedCells[0].Value.ToString()));
            driver.Name = textBox26.Text.Split(' ')[0];
            driver.Surname = textBox26.Text.Split(' ')[1];
            driver.Thridname = textBox26.Text.Split(' ')[2];
            driver.Certification = textBox27.Text;
            driver.Role_ID = db.Roles.Where(x => x.Name == comboBox16.SelectedItem.ToString()).ToList()[0].Id;
            driver.Adress = richTextBox3.Text;
            if (dateTimePicker2.Value != dateTimePicker2.MinDate)
                driver.DateEnd = dateTimePicker2.Value;
            db.Entry(driver).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            this.ReloadDriversData();
            this.ClearForm(TypeClear.Driver);
        }

        private void dataGridView3_DoubleClick(object sender, EventArgs e)
        {
            CreateDriverAccomp form4 = new CreateDriverAccomp();
            form4.ShowDialog();
            this.ReloadDriversData();
        }

        private void dataGridView2_DoubleClick(object sender, EventArgs e)
        {
            CreateCarTrailer createCarTrailer = new CreateCarTrailer();
            createCarTrailer.ShowDialog();
            this.ReloadCarsData();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (selectedDriver == null)
                return;
            var el = db.Driver_Accompanying.Find(int.Parse(dataGridView3.SelectedCells[0].Value.ToString()));
            db.Driver_Accompanying.Remove(el);
            db.SaveChanges();
            this.ReloadDriversData();
            this.ClearForm(TypeClear.Driver);
        }

        private void dataGridView2_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                int index = int.Parse(dataGridView2.SelectedCells[0].Value.ToString());
                var car = db.Car_Trailer.Find(index);
                textBox28.Text = car.Name;
                textBox41.Text = car.Model;
                textBox42.Text = car.State_number;
                comboBox18.Text = car.Transport_Type.Name;
                selectedCar = car;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (selectedCar == null)
                return;
            try
            {
                var el = db.Car_Trailer.Find(int.Parse(dataGridView2.SelectedCells[0].Value.ToString()));
                db.Car_Trailer.Remove(el);
                db.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            finally
            {
                this.ReloadCarsData();
                this.ClearForm(TypeClear.Car);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (selectedCar == null)
                return;
            var car = db.Car_Trailer.Find(int.Parse(dataGridView2.SelectedCells[0].Value.ToString()));
            car.Name = textBox28.Text;
            car.Model = textBox41.Text;
            car.State_number = textBox42.Text;
            car.Type_ID = db.Transport_Types.Where(x => x.Name == comboBox18.SelectedItem.ToString()).ToList()[0].Id;
            db.Entry(car).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            this.ReloadCarsData();
            this.ClearForm(TypeClear.Car);
        }

        private void dataGridView22_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView22.SelectedRows.Count <= 0)
                return;
            WayList form3 = new WayList(int.Parse(dataGridView22.SelectedCells[0].Value.ToString()));
            form3.ShowDialog();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            WayList wayList = new WayList();
            wayList.ShowDialog();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Waybill waybill = new Waybill();
            waybill.ShowDialog();
        }

        private void dataGridView21_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView21.SelectedRows.Count <= 0)
                return;
            Waybill waybill = new Waybill(int.Parse(dataGridView21.SelectedCells[0].Value.ToString()));
            waybill.ShowDialog();
        }
    }
}