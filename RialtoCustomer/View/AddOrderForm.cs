using GMap.NET.MapProviders;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RialtoLib.Model;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms;

namespace RialtoCustomer.View
{
    public partial class AddOrderForm : Form
    {
        Customer customer;
        RialtoEntities rialtoEntities;
        public AddOrderForm(Customer customer)
        {
            InitializeComponent();
            ConfigMapControl();
            rialtoEntities = Program.rialtoEntities;
            this.customer = customer;
            GMapOverlay markers = new GMapOverlay("markers");
            gMapControl1.Overlays.Add(markers);
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
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                switch (addPushPinsMode)
                {
                    case AddPushPinsMode.From:
                        {
                            //var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                            //GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin)
                            //{
                            //    ToolTipText = "Звідки"
                            //};

                            //var markers = gMapControl1.Overlays.First(f => f.Id == "markers");
                            //markers.Markers.Add(marker);
                            var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
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
                            var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
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
    }
    enum AddPushPinsMode
    {
        None = 0,
        From = 1,
        To = 2,
    }
}