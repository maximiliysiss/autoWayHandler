﻿using System;
using System.Resources;
using System.Windows.Forms;
using System.Linq;

namespace ProjectAutoSupplying
{
    public partial class Waybill : Form
    {
        /// <summary>
        /// Note it's C# therefore method names have to begin with uppercase characters! 
        /// Editor is warning of each metod declaration's line!
        /// </summary>

        private Models.DatabaseEntities2 db = new Models.DatabaseEntities2();

        public Waybill()
        {
            InitializeComponent();
            buttonSubmit.Click += OnSubmitWayBill;
            buttonAddCargo.Click += OnAddCargo;

            cargosView.CellMouseClick += OnSelectCargo;
        }

        public Waybill(int index) : this()
        {
            buttonSubmit.Text = "Изменить";
            
            var waybill = db.WayBills.Find(index);
            if (waybill != null)
            {
                LoadBill(waybill);
            }

            cargosView.DataSource = (from cargoInfo in db.Information_about_the_cargoes
                                    where cargoInfo.Waybill_ID == index
                                    select new
                                    {
                                        ID = cargoInfo.Cargo_ID,
                                        Груз = cargoInfo.Cargo.Name,
                                        Ед = cargoInfo.Cargo.Units,
                                        Количество = cargoInfo.Count,
                                        Масса = cargoInfo.Mass
                                    }).ToList();
        }

        private void LoadBill(Models.WayBill wayBill)
        {
            autoEnterpriseBox.Text = wayBill.AutoEnterprise;
            cargoSupplierBox.Text = wayBill.Shipper;
            cargoReceiverBox.Text = wayBill.Redirect;

            billNameBox.Text = wayBill.WayNumber;

            try
            {
                TryFillLoadingUnloadingInfo(wayBill.Loading_and_unloading_operations.First());
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно отобразить все данные о накладной");
            }

        }

        private Models.Loading_and_unloading_operation LoadLoadingUnloadingInfo()
        {
            double lArrival = double.Parse(loadingArrivalTime.Text);
            double lDeparture = double.Parse(loadingDeparureTime.Text);

            var loadingOperation = new Models.Loading_and_unloading_operation()
            {
                Operation = "Loading",
                Method = loadingCase.Text,
                Arrive_time = TimeSpan.FromMinutes(lArrival),
                Departure_time = TimeSpan.FromMinutes(lDeparture)
            };
            return loadingOperation;
        }

        private void OnSubmitWayBill(object sender, EventArgs e)
        {
            var bill = LoadHeaderInfo();
            var cargoInfo = LoadCargoInfo();
            var luOperations = LoadLoadingUnloadingInfo();

            bill.Information_about_the_cargo.Add(cargoInfo);
            bill.Loading_and_unloading_operations.Add(luOperations);

            db.SaveChanges();
        }

        private void OnAddCargo(object sender, EventArgs e)
        {
            Models.Cargo cargo = new Models.Cargo
            {
                Name = cargoNameBox.Text,
                Units = units.Text
            };

            Models.Information_about_the_cargo cargoInfo = new Models.Information_about_the_cargo
            {
                Count = int.Parse(countBox.Text),
                Mass = int.Parse(weightBox.Text),
                Nomenclature_code = codeBox.Text,
                Preisc__position = prescBox.Text,
                Pack_kind =packageTypeBox.Text,
                Documents_count = int.Parse(docsBox.Text),
                Mass_determination_method = weightDetermCaseBox.Text,
                Price = int.Parse(priceBox.Text)
            };

            cargo.Information_about_the_cargo.Add(cargoInfo);
            db.SaveChanges();
        }

        private Models.WayBill LoadHeaderInfo()
        {
            Models.WayBill bill = new Models.WayBill()
            {
                AutoEnterprise = autoEnterpriseBox.Text,
                Shipper = cargoSupplierBox.Text,
                Redirect = cargoReceiverBox.Text,
                WayNumber = billNameBox.Text
            };

            return bill;
        }

        private Models.Information_about_the_cargo LoadCargoInfo()
        {
            Models.Cargo cargo = new Models.Cargo()
            {
                
            };
  
            Models.Information_about_the_cargo info = new Models.Information_about_the_cargo()
            {

            };

            return info;
        }

        private void OnSelectCargo(object sender, EventArgs e)
        {
            try
            {
                var selectedCargo = db.Information_about_the_cargoes
                .Find(int.Parse(cargosView.SelectedCells[0].Value.ToString()));

                TryFillCargoInfo(selectedCargo);
            } catch (Exception)
            {
                MessageBox.Show("Невозможно отобразить данные о грузе");
            }
         
        }

        private void TryFillLoadingUnloadingInfo(Models.Loading_and_unloading_operation lu)
        {
            loadingCase.Text = lu.Method;
            loadingArrivalTime.Text = lu.Arrive_time.TotalHours.ToString();
            loadingDeparureTime.Text = lu.Departure_time.TotalHours.ToString();
           
        }

        private void TryFillCargoInfo(Models.Information_about_the_cargo cargoInfo)
        {
            cargoNameBox.Text = cargoInfo.Cargo.Name;
            units.Text = cargoInfo.Cargo.Units;
            codeBox.Text = cargoInfo.Nomenclature_code;
            prescBox.Text = cargoInfo.Preisc__position;
            weightBox.Text = cargoInfo.Mass.ToString();
            packageTypeBox.Text = cargoInfo.Pack_kind.First().ToString();
            docsBox.Text = cargoInfo.Documents_count.ToString();
            weightDetermCaseBox.Text = cargoInfo.Mass_determination_method.First().ToString();
            priceBox.Text = cargoInfo.Price.ToString();
            countBox.Text = cargoInfo.Count.ToString();
        }
    }
}
