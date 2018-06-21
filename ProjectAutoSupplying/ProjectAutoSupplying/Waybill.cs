using System;
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

            cargosView.DataSource = from cargoInfo in db.Information_about_the_cargoes
                                    where cargoInfo.Waybill_ID == index
                                    select new
                                    {
                                        ID = cargoInfo.Cargo_ID,
                                        Груз = cargoInfo.Cargo.Name,
                                        Ед = cargoInfo.Cargo.Units,
                                        Количество = cargoInfo.Count,
                                        Масса = cargoInfo.Mass
                                    };
        }

        private void LoadBill(Models.WayBill wayBill)
        {
            autoEnterpriseBox.Text = wayBill.AutoEnterprise;
            cargoSupplierBox.Text = wayBill.Shipper;
            cargoReceiverBox.Text = wayBill.Redirect;

            billNameBox.Text = wayBill.WayNumber;

            try
            {
                LoadLoadingUnloadingInfo(wayBill.Loading_and_unloading_operations.First());
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно отобразить данные о накладной");
            }

        }

        private void LoadLoadingUnloadingInfo(Models.Loading_and_unloading_operation luInfo)
        {
            loadExecBox.Text = luInfo.Executor;
            loadingCase.Text = luInfo.Method.First().ToString();


            loadingArrivalTime.Text = luInfo.Additional_operation__load_unload_.First()
                .Additional_Operation.Time.ToString();
            
        }

        private void OnSubmitWayBill(object sender, EventArgs e)
        {
            var bill = LoadHeaderInfo();
            var cargoInfo = LoadCargoInfo();

            bill.Information_about_the_cargo.Add(cargoInfo);
        }

        private Models.WayBill LoadHeaderInfo()
        {
            Models.WayBill bill = new Models.WayBill()
            {
                AutoEnterprise = autoEnterpriseBox.Text,
                Shipper = cargoSupplierBox.Text,


            };

            return bill;
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

            };

            db.SaveChanges();
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
