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

namespace RialtoCompanyAdmin.View.AddForms
{
    public partial class AddModelForm : Form
    {
        RialtoEntities rialtoEntities;
        Model model;
        bool isEditing = false;
        public AddModelForm()
        {
            InitializeComponent();

            rialtoEntities = Program.rialtoEntities;
            rialtoEntities = Program.rialtoEntities;
            model = new Model();
        }
        public AddModelForm(Model model)
        {
            InitializeComponent();

            rialtoEntities = Program.rialtoEntities;
            rialtoEntities = Program.rialtoEntities;
            this.model = model;

            isEditing = true;
        }

        private async void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                model.brand = brand_name_cb.Text;
                model.year_production = int.Parse(year_of_production.Text);
                model.model_name = model_name_tb.Text;
                if (!isEditing)
                {
                    try
                    {
                        rialtoEntities.Models.Add(model);
                        await rialtoEntities.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Models.Remove(model);
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                else
                {
                    await rialtoEntities.SaveChangesAsync();
                }
                Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        async Task LoadBrandsData(bool isFinding = false)
        {
            var source = rialtoEntities.Models.Select(s => s.brand)
                .Distinct().ToList();
            if (isFinding)
                source = source.Where(w => w.Contains(brand_name_cb.Text)).ToList();
            brand_name_cb.DataSource = source;
        }
        private async void find_brand_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadBrandsData(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AddModelForm_Load(object sender, EventArgs e)
        {
            await LoadBrandsData();
            if (isEditing)
            {
                model_name_tb.Text = model.model_name;
                brand_name_cb.Text = model.brand;
                year_of_production.Text = model.year_production.ToString();
            }
        }
    }
}