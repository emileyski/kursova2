using Microsoft.VisualBasic;
using RialtoLib.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RialtoCompanyAdmin.View.AddForms
{
    public partial class AddCarForm : Form
    {
        RialtoEntities rialtoEntities;
        Company company;
        Car car;
        bool isEditing = false;
        public AddCarForm(Company company)
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
            car = new Car();
            this.company = company;
        }
        public AddCarForm(Car car, Company company)
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
            this.car = car;
            isEditing = true;
            this.company = company;
        }
        private async Task LoadModels(bool isFinding = false)
        {
            var source = await rialtoEntities.Models.ToListAsync();
            if (isFinding)
            {
                source = source.Where(w => w.model_name.Contains(model_name_cb.Text)).ToList();
            }
            model_name_cb.DataSource = source.Select(s => s.model_name).ToList();
        }
        private async Task LoadBodyTypes(bool isFinding = false)
        {
            var source = await rialtoEntities.Boby_type.ToListAsync();
            if (isFinding)
            {
                source = source.Where(w => w.boby_name.Contains(body_type_cb.Text)).ToList();
            }
            body_type_cb.DataSource = source.Select(s => s.boby_name).ToList();
        }
        private async void save_btn_Click(object sender, EventArgs e)
        {
            try
            {
                car.Boby_type = rialtoEntities.Boby_type.First(f => f.boby_name == body_type_cb.Text);
                car.car_number = textBox1.Text;
                car.carrying = double.Parse(carying_tb.Text);
                car.company_id = company.company_id;
                var model = rialtoEntities.Models.FirstOrDefault(f => f.model_name == model_name_cb.Text);
                car.model_id = model.model_id;
                //car.company_id = compa
                if (isEditing)
                {
                    await rialtoEntities.SaveChangesAsync();
                }
                else
                {
                    try
                    {
                        rialtoEntities.Cars.Add(car);
                        await rialtoEntities.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Cars.Remove(car);
                        MessageBox.Show(ex.Message);
                        return;
                    }
                }
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void AddCarForm_Load(object sender, EventArgs e)
        {
            await LoadBodyTypes();
            await LoadModels();

            if (isEditing)
            {
                model_name_cb.Text = car.Model.model_name;
                body_type_cb.Text = car.Boby_type.boby_name;
                carying_tb.Text = car.carrying.ToString();
                textBox1.Text = car.car_number;
            }
        }

        private async void find_model_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadModels(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void add_body_type_Click(object sender, EventArgs e)
        {
            try
            {
                var body_type_name = Interaction.InputBox("Введіть назву типу кузова");
                if (!string.IsNullOrEmpty(body_type_name))
                {
                    var body_type = new Boby_type
                    {
                        boby_name = body_type_name,
                    };
                    try
                    {
                        rialtoEntities.Boby_type.Add(body_type);
                        await rialtoEntities.SaveChangesAsync();
                        await LoadBodyTypes();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Boby_type.Remove(body_type);
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    throw new Exception("Ви не ввели назву типу кузову");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        //редактировать тип кузова
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var body_type = rialtoEntities.Boby_type.FirstOrDefault(f => f.boby_name == body_type_cb.Text);
                var body_type_name = Interaction.InputBox("Введіть назву типу кузова");
                if (!string.IsNullOrEmpty(body_type_name))
                {
                    body_type.boby_name = body_type_name;
                    await rialtoEntities.SaveChangesAsync();
                    await LoadBodyTypes();
                }
                else
                    throw new Exception("Ви не ввели назву типу кузову");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //удалить тип кузова
        private async void button3_Click(object sender, EventArgs e)
        {
            try
            {
                var body_type = rialtoEntities.Boby_type.FirstOrDefault(f => f.boby_name == body_type_cb.Text);
                if (body_type != null)
                {
                    rialtoEntities.Boby_type.Remove(body_type);
                    await rialtoEntities.SaveChangesAsync();
                    await LoadBodyTypes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //поиск кузова
        private async void button4_Click(object sender, EventArgs e)
        {
            try
            {
                await LoadBodyTypes(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void add_model_Click(object sender, EventArgs e)
        {
            try
            {
                AddModelForm addModelForm = new AddModelForm();
                Hide();
                addModelForm.ShowDialog();
                Show();
                await LoadModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void edit_city_Click(object sender, EventArgs e)
        {
            try
            {
                var model = rialtoEntities.Models.FirstOrDefault(f => f.model_name == model_name_cb.Text);
                if (model == null)
                    throw new Exception("Ви не вибрали модель для редагування");
                AddModelForm addModelForm = new AddModelForm(model);
                Hide();
                addModelForm.ShowDialog();
                Show();
                await LoadModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void delete_city_Click(object sender, EventArgs e)
        {
            try
            {
                var model = rialtoEntities.Models.FirstOrDefault(f => f.model_name == model_name_cb.Text);
                if (model == null)
                    throw new Exception("Ви не вибрали модель для редагування");
                rialtoEntities.Models.Remove(model);
                await rialtoEntities.SaveChangesAsync();
                await LoadModels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}