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

namespace RialtoCompanyAdmin.View
{
    public partial class RegistrationForm : Form
    {
        RialtoEntities rialtoEntities;
        Company company;
        bool isEditing = false;
        public RegistrationForm()
        {
            InitializeComponent();
            company = new Company();
            ConfigMapControl();
            rialtoEntities = Program.rialtoEntities;
        }
        public RegistrationForm(Company company)
        {
            InitializeComponent();
            this.company = company;
            ConfigMapControl();
            rialtoEntities = Program.rialtoEntities;

            company_name.Text = company.company_name;
            email.Text = company.email;
            adress.Text = company.address;

            var point = JsonConvert.DeserializeObject<PointLatLng>(company.point_adress);
            var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

            GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_pushpin)
            {
                ToolTipText = "Місцезнаходження офісу"
            };
            markers.Markers.Add(marker);

            isEditing = true;

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
            //GMapOverlay routes = new GMapOverlay("routes");
            //gMapControl1.Overlays.Add(routes);
            gMapControl1.Overlays.Add(markers);
        }
        private async void registrate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                company.company_name = company_name.Text;
                company.email = email.Text;
                company.address = adress.Text;
                if (!isEditing)
                {
                    company.date_of_foundation = DateTime.Now;
                    company.rating = 0;
                    try
                    {
                        rialtoEntities.Companies.Add(company);
                        await rialtoEntities.SaveChangesAsync();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Companies.Remove(company);
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                {
                    try
                    {
                        await rialtoEntities.SaveChangesAsync();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gMapControl1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                var point = gMapControl1.FromLocalToLatLng(e.X, e.Y);
                var markers = gMapControl1.Overlays.First(f => f.Id == "markers");

                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.green_pushpin)
                {
                    ToolTipText = "Місцезнаходження офісу"
                };

                //var existedMarker = markers.Markers.FirstOrDefault(f => f.ToolTipText == "Місцезнаходження офісу)");
                markers.Markers.Clear();
                markers.Markers.Add(marker);
                company.point_adress = JsonConvert.SerializeObject(marker.Position);
            }
        }
    }
}