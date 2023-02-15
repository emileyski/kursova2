using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using RialtoLib.Model;
using RialtoLib.Service;
using System;
using System.Linq;
using System.Windows.Forms;

namespace RialtoCustomer.View
{
    public partial class AddOrderForm : Form
    {
        Customer customer;
        RialtoEntities rialtoEntities;
        public AddOrderForm(Customer customer)
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
            this.customer = customer;
            ConfigMapControl();
        }
        public AddOrderForm(Order order) 
        {
            InitializeComponent();
            ConfigMapControl();
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

            body_types_cb.Items.Add("Не важливо");
            var bodyTypesSource = rialtoEntities.Boby_type.Select(s => s.boby_name).ToList();
            foreach(var body in bodyTypesSource)
            {
                body_types_cb.Items.Add(body);
            }
        }
        async void AddPinToMap(PointLatLng point)
        {
            switch (addPushPinsMode)
            {
                case AddPushPinsMode.From:
                    {
                        var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

                        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin)
                        {
                            ToolTipText = "Звідки"
                        };

                        var existedMarker = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Звідки");
                        if (existedMarker != null)
                        {
                            markers.Markers.Remove(existedMarker);
                            //existedMarker = marker;
                            markers.Markers.Add(marker);
                        }
                        else
                            markers.Markers.Add(marker);
                    }
                    break;
                case AddPushPinsMode.To:
                    {
                        var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

                        GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_pushpin)
                        {
                            ToolTipText = "Куди"
                        };

                        var existedMarker = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Куди");
                        if (existedMarker != null)
                        {
                            markers.Markers.Remove(existedMarker);
                            //existedMarker = marker;
                            markers.Markers.Add(marker);
                        }
                        else
                            markers.Markers.Add(marker);
                    }
                    break;
            }
            var markers_overlay = gMapControl1.Overlays.First(f => f.Id == "markers");

            if (markers_overlay.Markers.Count == 2)
            {
                GMapOverlay routes = gMapControl1.Overlays.FirstOrDefault(f => f.Id == "routes");

                var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

                var existedMarkerFrom = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Звідки");
                var existedMarkerTo = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Куди");

                var route = (await RialtoLib.Service.MapService.GetRouteBeetwenTwoPoints(existedMarkerFrom.Position, existedMarkerTo.Position));
                routes.Routes.Clear();
                routes.Routes.Add(route.Item2);

                distance_label.Text = $"Дистанція: {Math.Round(route.Item1, 2)} KM";
                distance = (float)Math.Round(route.Item1, 2);
            }
        }
        float distance = 0;
        private void gMapControl1_MouseDoubleClickAsync(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                AddPinToMap(point);

            }
        }
        AddPushPinsMode addPushPinsMode = AddPushPinsMode.None;
        private void select_from_Click(object sender, EventArgs e)
        {
            addPushPinsMode = addPushPinsMode != AddPushPinsMode.From
                ? AddPushPinsMode.From : AddPushPinsMode.None;
        }

        private void select_to_Click(object sender, EventArgs e)
        {
            addPushPinsMode = addPushPinsMode != AddPushPinsMode.To
                ? AddPushPinsMode.To : AddPushPinsMode.None;
        }

        private async void push_order_Click(object sender, EventArgs e)
        {
            try
            {
                var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                if (markers.Markers.Count != 2)
                    throw new Exception("Ви не вказали звідки забрати або куди доставити!");

                var existedMarkerFrom = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Звідки");
                var existedMarkerTo = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Куди");

                var pointFrom = existedMarkerFrom.Position;
                var pointTo = existedMarkerTo.Position;
                //var volume = double.Parse(volume_tb.Text);
                //var weight = double.Parse(weight_tb.Text);

                var volume = double.Parse(volume_tb.Text);
                var weight = double.Parse(weight_tb.Text);

                var price = (volume * 125 + weight) * distance / 100;

                Order order = new Order
                {
                    address_from = address_from_tb.Text,
                    address_to = address_to_tb.Text,
                    customer_id = customer.customer_id,
                    volume = double.Parse(volume_tb.Text),
                    weight = double.Parse(weight_tb.Text),
                    point_from = JsonConvert.SerializeObject(pointFrom),
                    point_to = JsonConvert.SerializeObject(pointTo),
                    price = price,
                    cargo_name = cargo_name_tb.Text,
                };
                if (body_types_cb.SelectedIndex > 0)
                    order.body_type_id = rialtoEntities.Boby_type.First(f => f.boby_name == body_types_cb.Text).boby_id;

                rialtoEntities.Orders.Add(order);
                await rialtoEntities.SaveChangesAsync();

                MessageBox.Show("Успішний успіх!");
                Close();
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
                if (distance == 0)
                    throw new Exception("Ви не розрахували дистанцію");
                var volume = double.Parse(volume_tb.Text);
                var weight = double.Parse(weight_tb.Text);

                var price = (volume * 125 + weight) * distance / 100;
                MessageBox.Show($"Орієнтовна ціна: {Math.Round(price, 2)} UAH");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void find_from_Click(object sender, EventArgs e)
        {
            try
            {
                addPushPinsMode = AddPushPinsMode.From;
                var point = await MapService.GetLocationByAdress(address_from_tb.Text);
                AddPinToMap(point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void find_to_Click(object sender, EventArgs e)
        {
            try
            {
                addPushPinsMode = AddPushPinsMode.To;
                var point = await MapService.GetLocationByAdress(address_to_tb.Text);
                AddPinToMap(point);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    enum AddPushPinsMode
    {
        None = 0,
        From = 1,
        To = 2,
    }
}