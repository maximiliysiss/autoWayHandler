using Newtonsoft.Json.Linq;
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

        private void ReloadContractData()
        {
            dataGridView1.DataSource = db.Contracts.Select(x => new
            {
                x.Id,
                x.Company,
                Счет = x.Legal_Entity.Account,
                Банк = x.Legal_Entity.Bank_Name,
                Адрес = x.Legal_Entity.Legal_Adress,
                ИНН = x.Legal_Entity.INN,
                ОКПО = x.Legal_Entity.OKPO,
                ОКОНХ = x.Legal_Entity.OKONX
            }).ToList();
        }

        private void ReloadWayBillData()
        {
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
        }

        private void ReloadWayListData()
        {
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
        }

        private void ReloadWaysAndShipping()
        {
            dataGridView6.DataSource = db.WaysAndShippings.Select(x => new
            {
                x.Id,
                Наименование = x.Name,
                Перевозка = x.ShippingKind.Name,
                Круг = x.Time_Loop,
                Дистанция = x.Distance,
                Конечная = x.EndStation
            }).ToList();
        }

        private void ReloadShippingKind()
        {
            dataGridView7.DataSource = db.ShippingKinds.Select(x => new { x.Id, x.Name }).ToList();
        }

        enum TypeClear
        {
            Car, Driver, Fuel, Downtime, Contract
        }

        private void ClearForm(TypeClear type)
        {
            switch (type)
            {
                case TypeClear.Car:
                    carTrailerNameTextBox.Text = "";
                    carTrailerModelTextBox.Text = "";
                    carTrailerNumberTextBox.Text = "";
                    carTrailerTypeComboBox.SelectedIndex = 0;
                    selectedCar = null;
                    break;
                case TypeClear.Downtime:
                    nameTextBoxDownTime.Text = "";
                    beginDateTimePickerDownTime.Value = DateTime.Now;
                    endDateTimePickerDownTime.Value = DateTime.Now;
                    codeTextBoxDownTime.Text = "";
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
                    nameTextBoxFuel.Text = numberTextBoxFuel.Text = priceTextBoxFuel.Text = "";
                    break;
                case TypeClear.Contract:
                    contractAccountTextBox.Text = contractAddressTextBox.Text = contractBankNameTextBox.Text
                        = contractINNTextBox.Text = contractOKONXTextBox.Text = contractOKPOTextBox.Text = "";
                    break;
            }
        }

        private Dictionary<string, string> bankCount = new Dictionary<string, string>();
        private Dictionary<string, List<string>> bankInfo = new Dictionary<string, List<string>>();

        public void GetAndSetJSonInfo()
        {
            FileStream fileStream = new FileStream("Settings.settings", FileMode.Open);
            StreamReader streamReader = new StreamReader(fileStream);
            String json = streamReader.ReadToEnd();
            JObject jObject = JObject.Parse(json);
            streamReader.Close();
            fileStream.Close();
            var settings = jObject["settings"];
            var bankNames = settings["bankName"].ToList();
            var accounts = settings["account"].ToList();
            var aboutBank = settings["about bank"].ToList();
            var infos = new List<List<string>>();
            foreach (var obj in aboutBank)
            {
                List<string> info = new List<string>();
                foreach (var elem in obj)
                    info.Add(elem.ToString());
                infos.Add(info);
            }
            for (int i = 0; i < bankNames.Count; i++)
            {
                bankCount[bankNames[i].ToString()] = accounts[i].ToString();
                bankInfo[bankNames[i].ToString()] = infos[i];
            }
            mainFrameNameTextBox.Text = bankNameRichTextBox.Text = settings["name"].ToString();
            mainFrameINNTextBox.Text = settings["inn"].ToString();
            mainFrameOKONXTextBox.Text = settings["okonx"].ToString();
            mainFrameOKPOTextBox.Text = settings["okpo"].ToString();
            mainFrameAddressTextBox.Text = settings["adress"].ToString();
            mainFramePhoneTextBox.Text = settings["phone"].ToString();
            mainFrameRegisterNumTextBox.Text = settings["register number"].ToString();
            mainFrameSerialTextBox.Text = settings["serial"].ToString();
            mainFrameBankNameComboBox.DataSource = bankCount.Select(x => x.Key).ToList();
            string selectedItem = mainFrameBankNameComboBox.SelectedItem.ToString();
            mainFrameAccountTextBox.Text = bankCount[selectedItem];
            bankCodeTextBox.Text = bankInfo[selectedItem][0];
            bankAddressRichTextBox.Text = bankInfo[selectedItem][1];
            bankAccountTextBox.Text = bankInfo[selectedItem][2];
            bankBIKTextBox.Text = bankInfo[selectedItem][3];
            bankINNTextBox.Text = bankInfo[selectedItem][4];
        }

        public MainFrame()
        {
            InitializeComponent();
            //GetAndSetJSonInfo();
            if (File.Exists("favicon.bmp"))
                faviconPicture.Image = (Bitmap)Image.FromFile("favicon.bmp");
            comboBox16.DataSource = (from role in db.Roles select role.Name).ToList();
            carTrailerTypeComboBox.DataSource = (from type in db.Transport_Types select type.Name).ToList();
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
                carTrailerNameTextBox.Text = car.Name;
                carTrailerModelTextBox.Text = car.Model;
                carTrailerNumberTextBox.Text = car.State_number;
                carTrailerTypeComboBox.Text = car.Transport_Type.Name;
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
            car.Name = carTrailerNameTextBox.Text;
            car.Model = carTrailerModelTextBox.Text;
            car.State_number = carTrailerNumberTextBox.Text;
            car.Type_ID = db.Transport_Types.Where(x => x.Name == carTrailerTypeComboBox.SelectedItem.ToString()).ToList()[0].Id;
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

        private void dataGridView9_DoubleClick(object sender, EventArgs e)
        {
            CreateDowntime createDowntime = new CreateDowntime();
            createDowntime.ShowDialog();
            ReloadDownTimesData();
        }

        private void changeButtonDownTime_Click(object sender, EventArgs e)
        {
            if (nameTextBoxDownTime.Text.Trim().Length == 0 || codeTextBoxDownTime.Text.Trim().Length == 0 ||
                wayListComboBoxDownTime.SelectedIndex == -1)
                return;
            var id = int.Parse(dataGridView9.SelectedCells[0].Value.ToString());
            var elem = db.DownTime_on_Lines.Where(x => x.Id == id).First();
            elem.Name = nameTextBoxDownTime.Text;
            elem.Start_time = beginDateTimePickerDownTime.Value;
            elem.End_time = endDateTimePickerDownTime.Value;
            elem.Code = codeTextBoxDownTime.Text;
            elem.WayList_ID = int.Parse(wayListComboBoxDownTime.SelectedItem.ToString());
            db.Entry(elem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ReloadDownTimesData();
            ClearForm(TypeClear.Downtime);
        }

        private void dataGridView9_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dataGridView9.SelectedCells[0].Value.ToString());
            var elem = db.DownTime_on_Lines.Where(x => x.Id == id).First();
            nameTextBoxDownTime.Text = elem.Name;
            beginDateTimePickerDownTime.Value = elem.Start_time;
            endDateTimePickerDownTime.Value = elem.End_time;
            wayListComboBoxDownTime.DataSource = db.WayLists.Select(x => x.Id).ToList();
            wayListComboBoxDownTime.SelectedItem = elem.Id.ToString();
            codeTextBoxDownTime.Text = elem.Code;
        }

        private void dataGridView10_DoubleClick(object sender, EventArgs e)
        {
            CreateFuel createFuel = new CreateFuel();
            createFuel.ShowDialog();
            ReloadFuelData();
        }

        private void dataGridView10_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dataGridView10.SelectedCells[0].Value.ToString());
            var elem = db.Fuels.Where(x => x.Id == id).First();
            nameTextBoxFuel.Text = elem.Name;
            numberTextBoxFuel.Text = elem.Number;
            priceTextBoxFuel.Text = elem.Price.ToString();
        }

        private void changeButtonFuel_Click(object sender, EventArgs e)
        {
            if (nameTextBoxFuel.Text.Trim().Length == 0 || numberTextBoxFuel.Text.Trim().Length == 0 || priceTextBoxFuel.Text.Trim().Length == 0)
                return;
            var id = int.Parse(dataGridView10.SelectedCells[0].Value.ToString());
            var elem = db.Fuels.Where(x => x.Id == id).First();
            elem.Name = nameTextBoxFuel.Text;
            elem.Price = double.Parse(priceTextBoxFuel.Text);
            elem.Number = numberTextBoxFuel.Text;
            db.Entry(elem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ReloadFuelData();
            ClearForm(TypeClear.Fuel);
        }

        private void mainFrameBankNameComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedItem = mainFrameBankNameComboBox.SelectedItem.ToString();
            mainFrameAccountTextBox.Text = bankCount[selectedItem];
            bankNameRichTextBox.Text = selectedItem;
            bankCodeTextBox.Text = bankInfo[selectedItem][0];
            bankAddressRichTextBox.Text = bankInfo[selectedItem][1];
            bankAccountTextBox.Text = bankInfo[selectedItem][2];
            bankBIKTextBox.Text = bankInfo[selectedItem][3];
            bankINNTextBox.Text = bankInfo[selectedItem][4];
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            CreateLegal createLegal = new CreateLegal();
            createLegal.ShowDialog();
            CreateContract createContract = new CreateContract();
            createContract.ShowDialog();
            ReloadContractData();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = int.Parse(dataGridView1.SelectedCells[0].Value.ToString());
            var elem = db.Contracts.Find(id);
            contractAccountTextBox.Text = elem.Legal_Entity.Account;
            contractAddressTextBox.Text = elem.Legal_Entity.Legal_Adress;
            contractBankNameTextBox.Text = elem.Legal_Entity.Bank_Name;
            contractINNTextBox.Text = elem.Legal_Entity.INN;
            contractOKONXTextBox.Text = elem.Legal_Entity.OKONX;
            contractOKPOTextBox.Text = elem.Legal_Entity.OKPO;
        }

        private void contractChangeButton_Click(object sender, EventArgs e)
        {
            if (contractOKPOTextBox.Text.Trim().Length == 0 || contractOKONXTextBox.Text.Trim().Length == 0
                || contractINNTextBox.Text.Trim().Length == 0 || contractBankNameTextBox.Text.Trim().Length == 0
                || contractAddressTextBox.Text.Trim().Length == 0 || contractAccountTextBox.Text.Trim().Length == 0)
                return;
            var elem = db.Contracts.Find(int.Parse(dataGridView1.SelectedCells[0].Value.ToString()));
            elem.Legal_Entity.OKPO = contractOKPOTextBox.Text.Trim();
            elem.Legal_Entity.OKONX = contractOKONXTextBox.Text.Trim();
            elem.Legal_Entity.INN = contractINNTextBox.Text.Trim();
            elem.Legal_Entity.Bank_Name = contractBankNameTextBox.Text.Trim();
            elem.Legal_Entity.Legal_Adress = contractAddressTextBox.Text.Trim();
            elem.Legal_Entity.Account = contractAccountTextBox.Text.Trim();
            db.Entry(elem).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            ClearForm(TypeClear.Contract);
            ReloadContractData();
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    ReloadCarsData();
                    break;
                case 1:
                    ReloadDriversData();
                    break;
                case 2:
                    ReloadDownTimesData();
                    break;
                case 3:
                    ReloadFuelData();
                    break;
            }
        }

        private void tabControlCatalogueInherit_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlCatalogueInherit.SelectedIndex)
            {
                case 1:
                    ReloadContractData();
                    break;
                case 3:
                    ReloadCarsData();
                    break;
            }
        }

        private void tabControlUpper_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControlUpper.SelectedIndex)
            {
                case 4:
                    ReloadWayBillData();
                    break;
                case 5:
                    ReloadWayListData();
                    break;
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (nameTextBoxDownTime.Text.Trim().Length == 0 || codeTextBoxDownTime.Text.Trim().Length == 0 ||
               wayListComboBoxDownTime.SelectedIndex == -1)
                return;
            var id = int.Parse(dataGridView9.SelectedCells[0].Value.ToString());
            var elem = db.DownTime_on_Lines.Where(x => x.Id == id).First();
            db.DownTime_on_Lines.Remove(elem);
            db.SaveChanges();
            ReloadDownTimesData();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (nameTextBoxFuel.Text.Trim().Length == 0 || numberTextBoxFuel.Text.Trim().Length == 0 || priceTextBoxFuel.Text.Trim().Length == 0)
                return;
            var id = int.Parse(dataGridView10.SelectedCells[0].Value.ToString());
            var elem = db.Fuels.Where(x => x.Id == id).First();
            db.Fuels.Remove(elem);
            db.SaveChanges();
            ReloadFuelData();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (contractOKPOTextBox.Text.Trim().Length == 0 || contractOKONXTextBox.Text.Trim().Length == 0
               || contractINNTextBox.Text.Trim().Length == 0 || contractBankNameTextBox.Text.Trim().Length == 0
               || contractAddressTextBox.Text.Trim().Length == 0 || contractAccountTextBox.Text.Trim().Length == 0)
                return;
            var elem = db.Contracts.Find(int.Parse(dataGridView1.SelectedCells[0].Value.ToString()));
            var waybillsInContract = db.WayBills_In_Contracts.Where(x => x.Contract_ID == elem.Id);
            foreach (var obj in waybillsInContract)
                db.WayBills_In_Contracts.Remove(obj);
            db.Contracts.Remove(elem);
            db.SaveChanges();
            ReloadContractData();
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl2.SelectedIndex)
            {
                case 2:
                    ReloadWaysAndShipping();
                    break;
                case 3:
                    ReloadShippingKind();
                    break;
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (carTrailerModelTextBox.Text.Trim().Length == 0 || carTrailerNameTextBox.Text.Trim().Length == 0
                || carTrailerNumberTextBox.Text.Trim().Length == 0)
                return;
            db.Car_Trailer.Add(new Models.Car_Trailer()
            {
                Name = carTrailerNameTextBox.Text.Trim(),
                Model = carTrailerModelTextBox.Text.Trim(),
                State_number = carTrailerNumberTextBox.Text.Trim(),
                Type_ID = db.Transport_Types.Where(x => x.Name == carTrailerTypeComboBox.SelectedItem.ToString()).First().Id
            });
            db.SaveChanges();
            ReloadCarsData();
            ClearForm(TypeClear.Car);
        }
    }
}
