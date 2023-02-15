using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using Microsoft.VisualBasic;
using RialtoCompanyAdmin.View;
using RialtoLib.Model;
using RialtoLib.Service;
using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.Drawing.Imaging;

namespace RialtoCompanyAdmin
{
    public partial class MainAdminForm : Form
    {
        RialtoEntities rialtoEntities;
        Company company;
        public MainAdminForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;
            dataGridView2.AutoGenerateColumns = true;
            dataGridView2.ForeColor = Color.Black;
            dataGridView3.AutoGenerateColumns = true;
            dataGridView3.ForeColor = Color.Black;

            ConfigMapControl();

            isAuthorizated();
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
        async Task LoadOrders()
        {
            var source = await rialtoEntities.Orders.Where(w => w.Contracts.Count == 0).ToListAsync();

            if (textBox1.Text.Length > 0)
                source = source.Where(w => w.Customer.name.Contains(textBox1.Text)).ToList();

            dataGridView1.DataSource = source.Select(s => new
            {
                id = s.order_id,
                ПІБ_замовника = s.Customer.name,
                Телефон_замовника = s.Customer.phone_number,
                Звідки = s.address_from,
                Куди = s.address_to,
                Ціна = s.price,
                Матеріал = s.cargo_name,
                Тип_кузова = s.Boby_type.boby_name
            }).ToList();
        }
        void LoadDrivers()
        {
            var source = company.Drivers
                .Where(w => w.Contracts.FirstOrDefault(f => f.finish_date == null) == null);
            dataGridView2.DataSource = source.Select(s => new
            {
                id = s.driver_id,
                ПІБ = s.full_name,
                Телефон = s.phone_number,
                Виконаних_контрактів = s.Contracts
                .Where(w => w.finish_date != null).Count()
            }).ToList();
        }
        void LoadCars()
        {
            var source = company.Cars
                .Where(w => w.Contracts
                .FirstOrDefault(f => f
                .finish_date == null) == null);
            dataGridView3.DataSource = source.Select(s => new
            {
                id = s.auto_id,
                Номер = s.car_number,
                Модель = s.Model.model_name,
                Тонаж = $"{s.carrying} кг"
            }).ToList();
        }

        private async void isAuthorizated()
        {
            var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(path);
            var data = await GenericService
                .IsAuthorizated(rialtoEntities, LoginType.Admin, path);
            if (data.Item1)
            {
                //GetCompanyAdmin();
                company = data.Item2 as Company;
                LoadDrivers();
                LoadCars();
                await LoadOrders();
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
                    .IsAuthorizated(rialtoEntities, LoginType.Admin, path);
                    if (!data.Item1)
                    {
                        MessageBox.Show("Ви не пройшли авторизацію, спробуйте ще раз!");
                        Close();
                    }
                    else
                    {
                        company = data.Item2 as Company;
                        MessageBox.Show("Успішна авторизація!");
                        LoadDrivers();
                        LoadCars();
                        await LoadOrders();
                    }
                }
                else
                {
                    Close();
                }
            }
        }

        private void змінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationForm registrationForm = new RegistrationForm(company);
                Hide();
                registrationForm.ShowDialog();
                Show();
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

        private void автівкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CarsHandlingForm carsHandlingForm = new CarsHandlingForm(company);
                Hide();
                carsHandlingForm.ShowDialog();
                Show();
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void queryEditToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void водіїToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                DriversHandlingForm driversHandlingForm = new DriversHandlingForm(company);
                Hide();
                driversHandlingForm.ShowDialog();
                Show();
                LoadDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Driver GetMyDriverById()
        {
            var driver = rialtoEntities.Drivers.ToList().FirstOrDefault(f => f.driver_id == Convert
            .ToInt32(dataGridView2[0, dataGridView2.CurrentCell.RowIndex].Value));
            return driver;
        }
        Car GetMyCarById()
        {
            var car = rialtoEntities.Cars.ToList().FirstOrDefault(f => f.auto_id == Convert
            .ToInt32(dataGridView3[0, dataGridView3.CurrentCell.RowIndex].Value));
            return car;
        }
        Order GetOrderById()
        {
            var order = rialtoEntities.Orders.ToList().FirstOrDefault(f => f.order_id == Convert
            .ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
            return order;
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = GetMyDriverById();
                var car = GetMyCarById();
                var order = GetOrderById();
                var contract = new Contract
                {
                    driver_id = driver.driver_id,
                    auto_id = car.auto_id,
                    order_id = order.order_id,
                    company_id = company.company_id,
                    start_date = DateTime.Now,
                };
                rialtoEntities.Contracts.Add(contract);
                await rialtoEntities.SaveChangesAsync();

                //var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                //var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");

                //routes.Routes.Clear();
                //markers.Markers.Clear();
                await LoadOrders();
                LoadDrivers();
                LoadCars();

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
                LoadCars();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                var order = GetOrderById();
                if (order != null)
                {
                    var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                    var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");

                    routes.Routes.Clear();
                    markers.Markers.Clear();

                    var point_from = JsonConvert.DeserializeObject<PointLatLng>(order.point_from);
                    var point_to = JsonConvert.DeserializeObject<PointLatLng>(order.point_to);

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

                    var route = await MapService.GetRouteBeetwenTwoPoints(marker_from.Position, marker_to.Position);

                    routes.Routes.Add(route.Item2);
                    distance_lbl.Text = $"Дистанція : {route.Item1} км";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                await LoadOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void статистикаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                StatisticForm statisticForm = new StatisticForm();
                Hide();
                statisticForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintInvisibleControl(gMapControl1, "C:\\Users\\hnure\\Downloads\\fgt.jpeg");
        }
        private void PrintInvisibleControl(Control myControl, string filename)
        {
            Bitmap bmp = new Bitmap(myControl.Width, myControl.Height);
            //Drawing control to the bitmap        
            myControl.DrawToBitmap(bmp, new Rectangle(0, 0, myControl.Width, myControl.Height));
            bmp.Save(filename, ImageFormat.Jpeg);
            bmp.Dispose();
        }

        private void виконаніToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CompletedContractsForm completedContracts = new CompletedContractsForm(company);
                Hide();
                completedContracts.ShowDialog();
                Show();
            }catch(Exception ex ) { MessageBox.Show(ex.Message);}
        }
    }
}