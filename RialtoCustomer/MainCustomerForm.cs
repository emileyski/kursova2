using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using RialtoCustomer.View;
using RialtoLib.Model;
using RialtoLib.Service;
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
using System.Diagnostics.Contracts;
using Microsoft.VisualBasic;
using Xceed.Words.NET;
using System.Diagnostics;
using System.Drawing.Imaging;
using Xceed.Document.NET;

namespace RialtoCustomer
{
    public partial class MainCustomerForm : Form
    {
        RialtoEntities rialtoEntities;
        Customer customer;
        public MainCustomerForm()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;
            ConfigMapControl();

            rialtoEntities = Program.rialtoEntities;
        }
        RialtoLib.Model.Contract GetSelectedContractById()
        {
            try
            {

                var contract = rialtoEntities.Contracts.ToList().FirstOrDefault(f => f.contract_id == Convert
                .ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
                return contract;
            }
            catch
            {
                return null;
            }
        }
        async void LoadSelectedContract()
        {
            var contract = GetSelectedContractById();
            var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
            var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");
            markers.Markers.Clear();
            routes.Routes.Clear();
            if (contract != null)
            {
                var point_from = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_from);
                var point_to = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_to);

                GMapMarker marker_from = new GMarkerGoogle(point_from, GMarkerGoogleType.red_pushpin)
                {
                    ToolTipText = "Звідки забрати"
                };
                GMapMarker marker_to = new GMarkerGoogle(point_to, GMarkerGoogleType.green_pushpin)
                {
                    ToolTipText = "Пункт призначення"
                };

                markers.Markers.Add(marker_from);
                markers.Markers.Add(marker_to);
                if (contract.Locations.Count == 0)
                {
                    var route = await MapService.GetRouteBeetwenTwoPoints(marker_from.Position, marker_to.Position);

                    routes.Routes.Add(route.Item2);
                }
                else
                {
                    var driver_waypoints = new List<PointLatLng>
                    {
                        point_from
                    };
                    foreach (var loc in contract.Locations)
                    {
                        var point = JsonConvert.DeserializeObject<PointLatLng>(loc.location1);
                        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.purple_pushpin)
                        {
                            ToolTipText = $"{loc.location_date}"
                        };
                        markers.Markers.Add(marker);
                        driver_waypoints.Add(point);
                    }
                    var completed_path = await MapService.GetRouteBeetwenManyPoints(driver_waypoints);
                    routes.Routes.Add(completed_path.Item2);

                    var route = await MapService.GetRouteBeetwenTwoPoints(driver_waypoints.Last(), point_to);
                    routes.Routes.Add(route.Item2);
                }
            }
        }
        //async void PaintMap(RialtoLib.Model.Contract contract)
        //{

        //    //var contract = driver.Contracts.FirstOrDefault(f => f.finish_date == null);
        //    var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
        //    var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");

        //    routes.Routes.Clear();
        //    markers.Markers.Clear();

        //    var point_from = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_from);
        //    var point_to = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_to);

        //    var driver_waypoints = new List<PointLatLng>
        //    {
        //        point_from
        //    };

        //    GMapMarker marker_from = new GMarkerGoogle(point_from, GMarkerGoogleType.red_pushpin)
        //    {
        //        ToolTipText = "Звідки забрати"
        //    };
        //    markers.Markers.Add(marker_from);
        //    foreach (var loc in contract.Locations)
        //    {
        //        var point = JsonConvert.DeserializeObject<PointLatLng>(loc.location1);
        //        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.purple_pushpin)
        //        {
        //            ToolTipText = $"{loc.location_date}"
        //        };
        //        markers.Markers.Add(marker);
        //        driver_waypoints.Add(point);
        //    }
        //    var completed_path = await MapService.GetRouteBeetwenManyPoints(driver_waypoints);
        //    routes.Routes.Add(completed_path.Item2);

        //    GMapMarker marker_to = new GMarkerGoogle(point_to, GMarkerGoogleType.green_pushpin)
        //    {
        //        ToolTipText = "Куди доставити"
        //    };
        //    markers.Markers.Add(marker_to);
        //    var route = await MapService.GetRouteBeetwenTwoPoints(driver_waypoints.Last(), point_to);
        //    routes.Routes.Add(route.Item2);
        //}
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
        private void LoadProceseedContracts()
        {
            var data = customer.Orders.ToList().Where(w=>w.Contracts.Count==1)
                .Select(s => s.Contracts.Where(w => w.finish_date == null).ToList()).ToList();
            var source = new List<RialtoLib.Model.Contract>();
            foreach (var contracts in data)
            {
                foreach (var contract in contracts)
                {
                    source.Add(contract);
                }
            }

            dataGridView1.DataSource = source.Select(s => new
            {
                id = s.contract_id,
                Звідки = s.Order.address_from,
                Куди = s.Order.address_to,
                Вага = s.Order.weight,
                Що_везе = s.Order.cargo_name,
                Водій = $"{s.Driver.full_name} {s.Driver.phone_number}",
                Авто = $"{s.Car.Model.brand} {s.Car.Model.model_name}",
                Номер_авто = s.Car.car_number,
                В_дорозі = DateTime.Now - s.start_date
            }).ToList();
        }
        private async void isAuthorizated()
        {
            var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(path);
            var data = await GenericService
                .IsAuthorizated(rialtoEntities, LoginType.Customer, path);
            if (data.Item1)
            {
                //GetCompanyAdmin();
                customer = data.Item2 as Customer;
                LoadProceseedContracts();
            }
            else
            {
                var dlg = MessageBox.Show("Вам треба авторизуватися. Продовжити?",
                    "Ви не авторизувалися", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dlg)
                {
                    AuthorizationForm authorizationForm = new AuthorizationForm();
                    Hide();
                    authorizationForm.ShowDialog();
                    Show();
                    data = await GenericService
                    .IsAuthorizated(rialtoEntities, LoginType.Customer, path);
                    if (!data.Item1)
                    {
                        MessageBox.Show("Ви не пройшли авторизацію, спробуйте ще раз!");
                        Close();
                    }
                    else
                    {
                        customer = data.Item2 as Customer;
                        LoadProceseedContracts();
                        MessageBox.Show("Успішна авторизація!");
                    }
                }
                else
                {
                    Close();
                }
            }
        }

        private void MainCustomerForm_Load(object sender, EventArgs e)
        {
            isAuthorizated();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void вийтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                GenericService.LogOut(path);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void змінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationForm registrationForm = new RegistrationForm(customer);
                Hide();
                registrationForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void додатиЗамовленняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderForm addOrderForm = new AddOrderForm(customer);
                Hide();
                addOrderForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedContract();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void MakeReceipt(RialtoLib.Model.Contract contract)
        {
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

                doc.InsertParagraph($"Квитанція за послуги Rialto № {contract.contract_id}");

                doc.InsertParagraph();
                doc.InsertParagraph();

                var table = doc.InsertTable(12, 2);
                table.Alignment = Xceed.Document.NET.Alignment.center;
                table.Design = Xceed.Document.NET.TableDesign.TableGrid;


                table.Rows[0].Cells[0].Paragraphs[0].Append("Замовник");
                table.Rows[0].Cells[1].Paragraphs[0].Append($"{contract.Order.Customer.name}");
                table.Rows[1].Cells[0].Paragraphs[0].Append("Перевізник");
                table.Rows[1].Cells[1].Paragraphs[0].Append($"{contract.Company.company_name}");
                table.Rows[2].Cells[0].Paragraphs[0].Append("Водій");
                table.Rows[2].Cells[1].Paragraphs[0].Append($"{contract.Driver.full_name} {contract.Driver.phone_number}");
                table.Rows[3].Cells[0].Paragraphs[0].Append("Авто");
                table.Rows[3].Cells[1].Paragraphs[0].Append($"{contract.Car.Model.brand} {contract.Car.Model.model_name} {contract.Car.car_number}");
                table.Rows[4].Cells[0].Paragraphs[0].Append("Звідки");
                table.Rows[4].Cells[1].Paragraphs[0].Append($"{contract.Order.address_from}");
                table.Rows[5].Cells[0].Paragraphs[0].Append("Куди");
                table.Rows[5].Cells[1].Paragraphs[0].Append($"{contract.Order.address_to}");
                table.Rows[6].Cells[0].Paragraphs[0].Append("Сума");
                table.Rows[6].Cells[1].Paragraphs[0].Append($"{Math.Round(contract.Order.price, 2)} UAH");
                table.Rows[7].Cells[0].Paragraphs[0].Append("Вага");
                table.Rows[7].Cells[1].Paragraphs[0].Append($"{contract.Order.weight} кг");
                table.Rows[8].Cells[0].Paragraphs[0].Append("Об'єм");
                table.Rows[8].Cells[1].Paragraphs[0].Append($"{contract.Order.volume} m^3");
                table.Rows[9].Cells[0].Paragraphs[0].Append("Вантаж");
                table.Rows[9].Cells[1].Paragraphs[0].Append($"{contract.Order.cargo_name}");
                table.Rows[10].Cells[0].Paragraphs[0].Append("Дата початку");
                table.Rows[10].Cells[1].Paragraphs[0].Append($"{contract.start_date}");
                table.Rows[11].Cells[0].Paragraphs[0].Append("Дата завершення");
                table.Rows[11].Cells[1].Paragraphs[0].Append($"{contract.finish_date}");


                doc.InsertParagraph();
                doc.InsertParagraph();



                PrintInvisibleControl(gMapControl1, $"route{contract.contract_id}.jpeg");
                Xceed.Document.NET.Image image = doc.AddImage($"route{contract.contract_id}.jpeg");

                // Create a picture (A custom view of an Image).
                Picture picture = image.CreatePicture();

                doc.InsertParagraph().AppendPicture(picture).Alignment = Alignment.center;

                doc.InsertParagraph("Рисунок 1 - Маршрут").Alignment = Alignment.center;
                doc.InsertParagraph();
                doc.InsertParagraph();

                doc.InsertParagraph($"Квитанцію сформовано: {DateTime.Now}");
                //p1.AppendLine();

                //doc.inser

                doc.Save();
                Process.Start($"{path}/{fileName}");

                GenericService.SendMessage(contract.Driver.full_name, contract.Driver.email, $"Квитанція № {contract.contract_id}",
                    "Ви успішно виконали доставку вантажу, квитанція буде у прикріпленому файлі.\n\nЗ повагою, команда Rialto",
                    attachment: new System.Net.Mail.Attachment($"{path}/{fileName}"));

                GenericService.SendMessage(contract.Order.Customer.name, contract.Order.Customer.email, $"Квитанція № {contract.contract_id}",
                    $"Ви отримали свій вантаж {contract.finish_date}. Квитанція буде у прикріпленому файлі\n\nЗ повагою, команда Rialto",
                    attachment: new System.Net.Mail.Attachment($"{path}/{fileName}"));
            }
        }
        private void PrintInvisibleControl(Control myControl, string filename)
        {
            Bitmap bmp = new Bitmap(myControl.Width, myControl.Height);
            //Drawing control to the bitmap        
            myControl.DrawToBitmap(bmp, new Rectangle(0, 0, myControl.Width, myControl.Height));
            bmp.Save(filename, ImageFormat.Jpeg);
            bmp.Dispose();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var contract = GetSelectedContractById();
                if (contract == null)
                    throw new Exception("Ви не вибрали контракт!");
                contract.finish_date = DateTime.Now;
                await rialtoEntities.SaveChangesAsync();
                MakeReceipt(contract);
                var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");
                markers.Markers.Clear();
                routes.Routes.Clear();
                LoadProceseedContracts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSelectedContract();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}