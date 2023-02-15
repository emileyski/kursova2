using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET;
using RialtoDriver.View;
using RialtoLib.Model;
using RialtoLib.Service;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using System.Reflection.Emit;

namespace RialtoDriver
{
    public partial class MainDriverForm : Form
    {
        RialtoEntities rialtoEntities;
        Driver driver;
        public MainDriverForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
            ConfigMapControl();
        }
        //bool Authorizate = false;
        private async void isAuthorizated()
        {
            var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(path);
            var data = await GenericService
                .IsAuthorizated(rialtoEntities, LoginType.Driver, path);
            if (data.Item1)
            {
                //GetCompanyAdmin();
                driver = data.Item2 as Driver;
                name_lbl.Text = driver.full_name;
                number_lbl.Text = driver.phone_number;
                await LoadCurrentTask();
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
                    .IsAuthorizated(rialtoEntities, LoginType.Driver, path);
                    if (!data.Item1)
                    {
                        MessageBox.Show("Ви не пройшли авторизацію, спробуйте ще раз!");
                        Close();
                    }
                    else
                    {
                        driver = data.Item2 as Driver;
                        MessageBox.Show("Успішна авторизація!");
                        name_lbl.Text = driver.full_name;
                        number_lbl.Text = driver.phone_number;
                        await LoadCurrentTask();
                    }
                }
                else
                {
                    Close();
                }
            }
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
        async Task LoadCurrentTask()
        {
            //Task.Run(() =>
            //{

            //});
            var contract = driver.Contracts.FirstOrDefault(f => f.finish_date == null);
            if (contract != null)
            {
                customer_lbl.Text = contract.Order.Customer.name;
                label11.Text = contract.Order.Customer.phone_number;
                label10.Text = $"{contract.Order.weight} кг";
                label14.Text = $"{contract.Order.volume} м^3";
                label15.Text = contract.Car.car_number;
                label16.Text = contract.Car.Model.brand;
                label17.Text = contract.Car.Model.model_name;
                label19.Text = contract.Order.cargo_name;
                label21.Text = $"{Math.Round(contract.Order.price, 2)} UAH";

                var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");
                markers.Markers.Clear();
                routes.Routes.Clear();
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
                if (contract.Locations.Count > 0)
                {
                    PaintMap();
                }
                else
                {
                    var route = await MapService.GetRouteBeetwenTwoPoints(marker_from.Position, marker_to.Position);

                    routes.Routes.Add(route.Item2);
                    //distance_lbl.Text = $"Дистанція : {route.Item1} км";
                }
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
                RegistrationForm registrationForm = new RegistrationForm(driver);
                Hide();
                registrationForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            isAuthorizated();
        }

        private void add_location_btn_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Вкажіть місце на карті, де ви зупинилися");
                handlingType = mapHandlingType.AddLocation;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        mapHandlingType handlingType = mapHandlingType.None; 
        async void PaintMap()
        {

            var contract = driver.Contracts.FirstOrDefault(f => f.finish_date == null);
            var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
            var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");

            routes.Routes.Clear();
            markers.Markers.Clear();

            var point_from = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_from);
            var point_to = JsonConvert.DeserializeObject<PointLatLng>(contract.Order.point_to);

            var driver_waypoints = new List<PointLatLng>
            {
                point_from
            };

            GMapMarker marker_from = new GMarkerGoogle(point_from, GMarkerGoogleType.red_pushpin)
            {
                ToolTipText = "Звідки забрати"
            };
            markers.Markers.Add(marker_from);
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

            GMapMarker marker_to = new GMarkerGoogle(point_to, GMarkerGoogleType.green_pushpin)
            {
                ToolTipText = "Куди доставити"
            };
            markers.Markers.Add(marker_to);
            var route = await MapService.GetRouteBeetwenTwoPoints(driver_waypoints.Last(), point_to);
            routes.Routes.Add(route.Item2);
        }
        private async void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                if(handlingType == mapHandlingType.AddLocation)
                {
                    var contract = driver.Contracts.FirstOrDefault(f => f.finish_date == null);
                    var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                    var location = new RialtoLib.Model.Location
                    {
                        contract_id = contract.contract_id,
                        location1 = JsonConvert.SerializeObject(point),
                        location_date = DateTime.Now
                    };
                    contract.Locations.Add(location);
                    await rialtoEntities.SaveChangesAsync();
                    await LoadCurrentTask();
                    //var locati


                    //GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.purple_pushpin)
                    //{
                    //    ToolTipText = $"{DateTime.Now}"
                    //};
                    //var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                    //markers.Markers.Add(marker);
                    //var routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");
                    ////routes.Clear();
                    //routes.Routes.Clear();
                    //var completed_points = new List<PointLatLng>();
                    //completed_points.Add()
                    //var completed_route= await MapService.GetRouteBeetwenManyPoints(new List<PointLatLng>
                    //{

                    //})


                    handlingType = mapHandlingType.None;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    enum mapHandlingType
    {
        None = 0,
        AddLocation = 1,
    }
}