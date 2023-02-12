using RialtoCompanyAdmin.View.AddForms;
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

namespace RialtoCompanyAdmin.View
{
    public partial class CarsHandlingForm : Form
    {
        //RialtoEntities rialtoEntities;
        Company company;
        RialtoEntities rialtoEntities;
        public CarsHandlingForm(Company company)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            rialtoEntities = Program.rialtoEntities;
            this.company = company;

            LoadCarsData();
        }
        void LoadCarsData(SortType sortType = SortType.None)
        {
            var source = company.Cars.ToList();
            switch (sortType)
            {
                case SortType.Alphabetic:
                    source = source.OrderBy(o => o.Model.model_name).ToList();
                    break;
                case SortType.Carrying:
                    source = source.OrderByDescending(o => o.carrying).ToList();
                    break;
            }
            dataGridView1.DataSource = source.Select(s => new
            {
                id = s.auto_id,
                Модель = s.Model.model_name,
                Вантажопідйомність = s.carrying,
                Номер = s.car_number,
                Кількість_виконаних_контрактів = s.Contracts
                .ToList().Where(w => w.finish_date != null).Count(),
                Кузов = s.Boby_type.boby_name
            }).ToList();
        }

        private void додатиАвтівкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddCarForm addCarForm = new AddCarForm(company);
                Hide();
                addCarForm.ShowDialog();
                Show();
                LoadCarsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Car GetCarById()
        {
            var car = rialtoEntities.Cars.ToList().FirstOrDefault(f => f.auto_id == Convert
            .ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));

            return car;
        }
        private void редагуватиВибрануToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var car = GetCarById();
                if (car == null)
                    throw new Exception("Ви не вибрали автівку");
                AddCarForm addCarForm = new AddCarForm(car, company);
                Hide();
                addCarForm.ShowDialog();
                Show();
                LoadCarsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void видалитиВибрануToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var car = GetCarById();
                if (car == null)
                    throw new Exception("Ви не вибрали автівку");
                rialtoEntities.Cars.Remove(car);
                await rialtoEntities.SaveChangesAsync();
                LoadCarsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void заНавоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try 
            {
                LoadCarsData(SortType.Alphabetic);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void заВантажопідйомністюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCarsData(SortType.Carrying);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void неСортуватиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                LoadCarsData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

    enum SortType
    {
        None = 0,
        Alphabetic = 1,
        Carrying = 2

    }
}