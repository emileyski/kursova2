using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using RialtoLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using Microsoft.VisualBasic;
using Xceed.Words.NET;
using System.Diagnostics.Contracts;
using System.Diagnostics;
using RialtoLib.Service;

namespace RialtoCompanyAdmin.View
{
    public partial class DriversHandlingForm : Form
    {
        Company company;
        RialtoEntities rialtoEntities;
        public DriversHandlingForm(Company company)
        {
            InitializeComponent();

            ConfigMapControl();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.ForeColor = Color.Black;

            rialtoEntities = Program.rialtoEntities;
            this.company = company;

            FindAvailableDrivers();
            LoadMyDrivers();
        }
        private void ConfigMapControl()
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap;
            gMapControl1.RoutesEnabled = true;
            gMapControl1.MinZoom = 5;
            gMapControl1.MaxZoom = 100;
            gMapControl1.Zoom = 10;
            //gMapControl1.ShowCenter = false;
            gMapControl1.DragButton = MouseButtons.Left;
            gMapControl1.Position = new PointLatLng(48.5850, 36.1509);

            GMapOverlay markers = new GMapOverlay("markers");
            GMapOverlay routes = new GMapOverlay("routes");
            gMapControl1.Overlays.Add(routes);
            gMapControl1.Overlays.Add(markers);
        }
        private void FindAvailableDrivers()
        {
            try
            {
                var source = rialtoEntities.Drivers.Where(w => w.company_id == null).ToList();
                if (filter_by_age.Checked)
                {
                    var min_age = int.Parse(min_age_tb.Text);
                    var max_age = int.Parse(max_age_tb.Text);
                    if (min_age > max_age || min_age < 0 || max_age < 0)
                        throw new Exception("Ви ввели некоректні аргументи для пошуку за віком");

                    var min_birth_date = DateTime.Now.AddYears(-max_age);
                    var max_birth_date = DateTime.Now.AddYears(-min_age);
                    source = source.Where(w => w.birh_date > min_birth_date && w.birh_date < max_birth_date).ToList();
                }
                if (!string.IsNullOrEmpty(find_fullname_tb.Text))
                {
                    source = source.Where(w => w.full_name.Contains(find_fullname_tb.Text)).ToList();
                }
                if (order_available_cb.SelectedIndex > 0)
                {
                    switch (order_available_cb.SelectedIndex)
                    {
                        case 1:
                            source = source.OrderBy(o => o.birh_date).ToList();
                            break;
                        case 2:
                            source = source.OrderBy(o => o.full_name).ToList();
                            break;
                        case 3:
                            source = source.OrderBy(o => o.Contracts
                            .Where(w => w.finish_date != null).Count()).ToList();
                            break;
                    }
                }
                dataGridView1.DataSource = source.Select(s => new
                {
                    id = s.driver_id,
                    ПІБ = s.full_name,
                    Виконаних_контрактів = s.Contracts.Where(w => w.finish_date != null).Count(),
                    Дата_народження = s.birh_date,
                    Номер_телефона = s.phone_number,
                    Пошта = s.email
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetDriverStatus(Driver driver)
        {
            var last_contract = driver.Contracts.FirstOrDefault(f => f.finish_date == null);
            if (last_contract == null)
                return "Вільний";
            return $"Виконує контракт {last_contract.Order.Customer.name}";
        }
        private void LoadMyDrivers()
        {
            try
            {
                var source = company.Drivers.ToList();
                if (!string.IsNullOrEmpty(find_my_drivers_by_fullname_tb.Text))
                {
                    source = source.Where(w => w.full_name.Contains(find_my_drivers_by_fullname_tb.Text)).ToList();
                }
                dataGridView2.DataSource = source.Select(s => new
                {
                    id = s.driver_id,
                    ПІБ = s.full_name,
                    Статус = GetDriverStatus(s),
                    Номер_телефону = s.phone_number,
                    Пошта = s.email,
                    Досвід = $"Виконано {s.Contracts.Where(w => w.finish_date != null).Count()} контрактів",
                    Дата_народження = s.birh_date
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void add_body_type_Click(object sender, EventArgs e)
        {
            try
            {
                FindAvailableDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Driver GetAvailableDriverById()
        {
            var driver = rialtoEntities.Drivers.ToList().FirstOrDefault(f => f.driver_id == Convert
            .ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
            return driver;
        }
        Driver GetMyDriverById()
        {
            var driver = rialtoEntities.Drivers.ToList().FirstOrDefault(f => f.driver_id == Convert
            .ToInt32(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value));
            return driver;
        }

        private async void hire_selected_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = GetAvailableDriverById();
                if (driver == null)
                    throw new Exception("Ви не вибрали водія");
                driver.company_id = company.company_id;
                await rialtoEntities.SaveChangesAsync();
                FindAvailableDrivers();
                LoadMyDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //знайти мого водія (із можливістю пошуку за ПІБ)
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadMyDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var myDriver = GetMyDriverById();
                if (myDriver != null)
                {
                    //if(myDriver.)
                    var last_contract = myDriver.Contracts.FirstOrDefault(f => f.finish_date == null);
                    if (last_contract == null)
                    {
                        var point = JsonConvert.DeserializeObject<PointLatLng>(company.point_adress);
                        var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

                        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_pushpin)
                        {
                            ToolTipText = $"Поточне місцезнаходження {myDriver.full_name}"
                        };
                        markers.Markers.Add(marker);
                    }
                    else
                    {
                        var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                        var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");
                        markers.Markers.Clear();
                        routes.Routes.Clear();
                        var point_from = JsonConvert.DeserializeObject<PointLatLng>(last_contract.Order.point_from);
                        var point_to = JsonConvert.DeserializeObject<PointLatLng>(last_contract.Order.point_to);

                        GMapMarker marker_from = new GMarkerGoogle(point_from, GMarkerGoogleType.red_pushpin)
                        {
                            ToolTipText = "Звідки забрати"
                        };
                        GMapMarker marker_to = new GMarkerGoogle(point_to, GMarkerGoogleType.green_pushpin)
                        {
                            ToolTipText = "Пункт призначення"
                        };

                        markers.Markers.Add(marker_from);
                        markers.Markers.Add(marker_to); var driver_waypoints = new List<PointLatLng>
                    {
                        point_from
                    };
                        foreach (var loc in last_contract.Locations)
                        {
                            var point = JsonConvert.DeserializeObject<PointLatLng>(loc.location1);
                            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.purple_pushpin)
                            {
                                ToolTipText = $"{loc.location_date}"
                            };
                            markers.Markers.Add(marker);
                            driver_waypoints.Add(point);
                        }
                        if(last_contract.Locations.Count > 0)
                        {

                            var completed_path = await MapService.GetRouteBeetwenManyPoints(driver_waypoints);
                            routes.Routes.Add(completed_path.Item2);

                            var route = await MapService.GetRouteBeetwenTwoPoints(driver_waypoints.Last(), point_to);
                            routes.Routes.Add(route.Item2);
                        }
                        else
                        {
                            routes.Routes.Add((await MapService.GetRouteBeetwenTwoPoints(point_from, point_to)).Item2);
                        }
                        //throw new NotImplementedException();
                    }
                    var earned = Math.Round(myDriver.Contracts
                        .Where(w => w.finish_date != null && w.company_id == company.company_id).Select(s => s.Order.price).Sum(), 2);
                    earned_lbl.Text = $"{earned} UAH";

                    var earned_by_month = Math.Round(myDriver.Contracts
                        .Where(w => w.finish_date != null && DateTime.Now.AddDays(-30) < w.finish_date
                        && w.company_id == company.company_id)
                        .Select(s => s.Order.price).Sum(), 2);
                    earn_last_month.Text = $"{earned_by_month} UAH";

                    var biggest_cargo = myDriver.Contracts.OrderByDescending(s => s.Order.weight).FirstOrDefault();
                    if (biggest_cargo != null)
                    {
                        biggest_cargo_lbl.Text = $"{biggest_cargo.Order.cargo_name} : {biggest_cargo.Order.weight} кг";
                    }
                    //var favorite_auto = 
                    var cars = myDriver.Contracts.Select(s => s.Car).Distinct().ToList();
                    var favorite_car = cars.OrderByDescending(o => o.Contracts.Where(w => w.driver_id == myDriver.driver_id).Count()).FirstOrDefault();
                    if (favorite_car != null)
                    {
                        favorite_auto_lbl.Text = $"{favorite_car.Model.model_name}, " +
                            $"{favorite_car.car_number}, {favorite_car.Boby_type.boby_name}";
                    }
                    else
                    {
                        favorite_auto_lbl.Text = "Нема улюбленого авто";
                    }
                }
            }
            catch
            {

            }
        }

        private async void dismiss_the_selected_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = GetMyDriverById();
                if (driver == null)
                    throw new Exception("Ви не вибрали водія, якого хочете звільнити!");
                if (GetDriverStatus(driver) != "Вільний")
                    throw new Exception("Цей водій виконує замовлення");
                driver.company_id = null;
                await rialtoEntities.SaveChangesAsync();
                LoadMyDrivers();
                FindAvailableDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void make_receipt_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = GetMyDriverById();
                if (driver == null) throw new Exception("Ви не вибрали водія!");
                string path = "";
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

                var fb = folderBrowser.ShowDialog();

                if (fb == DialogResult.OK)
                {
                    path = folderBrowser.SelectedPath;



                    var fileName = Interaction.InputBox("Введіть назву файлу, у який ви хочете зберегти звіт");

                    if (string.IsNullOrEmpty(fileName))
                    {
                        fileName = "Report.docx";
                    }
                    else
                    {
                        fileName += ".docx";
                    }
                    DocX doc = DocX.Create($"{path}/{fileName}");
                    doc.SetDefaultFont(new Xceed.Document.NET.Font("Times New Roman"), 14);

                    doc.InsertParagraph($"Квитанція за роботи {driver.full_name}");

                    var contracts = driver.Contracts.ToList()
                        .Where(w => w.finish_date > DateTime.Now.AddDays(-30)).ToList();

                    if (contracts.Count > 0)
                    {

                        doc.InsertParagraph();

                        var table = doc.InsertTable(contracts.Count, 7);
                        table.Alignment = Xceed.Document.NET.Alignment.center;
                        table.Design = Xceed.Document.NET.TableDesign.TableGrid;

                        for (int i = 0; i < contracts.Count; i++)
                        {
                            table.Rows[i].Cells[0].Paragraphs[0].Append($"{contracts[i].Order.address_from}");
                            table.Rows[i].Cells[1].Paragraphs[0].Append($"{contracts[i].Order.address_to}");
                            table.Rows[i].Cells[2].Paragraphs[0].Append($"{Math.Round(contracts[i].Order.price, 2)} UAH");
                            table.Rows[i].Cells[3].Paragraphs[0].Append($"{contracts[i].Order.cargo_name} UAH");
                            table.Rows[i].Cells[4].Paragraphs[0].Append($"{contracts[i].Order.weight} kg");
                            table.Rows[i].Cells[5].Paragraphs[0].Append($"{contracts[i].Order.volume} m^3");
                            table.Rows[i].Cells[6].Paragraphs[0].Append($"{contracts[i].Order.Customer.name} {contracts[i].Order.Customer.phone_number}");
                        }
                        table.InsertRow(0);
                        table.Rows[0].Cells[0].Paragraphs[0].Append("Звідки");
                        table.Rows[0].Cells[1].Paragraphs[0].Append("Куди");
                        table.Rows[0].Cells[2].Paragraphs[0].Append("Ціна");
                        table.Rows[0].Cells[3].Paragraphs[0].Append("Вантаж");
                        table.Rows[0].Cells[4].Paragraphs[0].Append("Вага");
                        table.Rows[0].Cells[5].Paragraphs[0].Append("Об'єм");
                        table.Rows[0].Cells[6].Paragraphs[0].Append("Замовник");

                        doc.InsertParagraph("Таблиця 1 - Інформація про всі виконані за 30 днів контракти").Alignment = Xceed.Document.NET.Alignment.center;

                        doc.InsertParagraph();

                        doc.InsertParagraph($"Всього заробив за останні 30 днів : {Math.Round(contracts.Select(s => s.Order.price).Sum(), 2)} UAH");
                    }
                    else
                    {
                        doc.InsertParagraph("Цей водій не виконував замовлень за останні 30 місяців!(");
                    }
                    doc.Save();

                    Process.Start($"{path}/{fileName}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}