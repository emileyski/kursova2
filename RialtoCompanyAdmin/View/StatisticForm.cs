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
    public partial class StatisticForm : Form
    {
        RialtoEntities rialtoEntities;
        public StatisticForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;
        }

        private void найдорожчіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Contracts
                    .Where(w => w.finish_date != null)
                    .OrderByDescending(o => o.Order.price).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Замовник = s.Order.Customer.name,
                    Водій = s.Driver.full_name,
                    Перевізник = s.Company.company_name,
                    Ціна = $"{Math.Round(s.Order.price, 2)} UAH",
                    Звідки = s.Order.address_from,
                    Куди = s.Order.address_to,
                    Авто = $"{s.Car.Model.brand} {s.Car.Model.model_name} {s.Car.car_number}"
                }).ToList();
                //var company = new Company();
                //company.Drivers.Add()
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найважчіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Contracts
                    .Where(w => w.finish_date != null)
                    .OrderByDescending(o => o.Order.weight).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Замовник = s.Order.Customer.name,
                    Водій = s.Driver.full_name,
                    Перевізник = s.Company.company_name,
                    Ціна = $"{Math.Round(s.Order.price, 2)} UAH",
                    Вага = s.Order.weight,
                    Звідки = s.Order.address_from,
                    Куди = s.Order.address_to,
                    Авто = $"{s.Car.Model.brand} {s.Car.Model.model_name} {s.Car.car_number}",
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найшвидшіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Contracts
                    .Where(w => w.finish_date != null).ToList()
                    .OrderBy(o => o.finish_date - o.start_date).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Замовник = s.Order.Customer.name,
                    Водій = s.Driver.full_name,
                    Перевізник = s.Company.company_name,
                    Ціна = $"{Math.Round(s.Order.price, 2)} UAH",
                    Час = (s.finish_date - s.start_date).Value,
                    Вага = s.Order.weight,
                    Звідки = s.Order.address_from,
                    Куди = s.Order.address_to,
                    Авто = $"{s.Car.Model.brand} {s.Car.Model.model_name} {s.Car.car_number}",
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найдосвідченішіToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Drivers.ToList()
                    .OrderByDescending(s => s.Contracts
                    .Where(w => w.finish_date != null).Count()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    ПІБ = s.full_name,
                    Перевезено = s.Contracts.Where(w => w.finish_date != null).Count(),
                    Заробив = s.Contracts.Where(w => w.finish_date != null).Select(ss => ss.Order.price).Sum()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшЗаробилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Drivers.ToList()
                    .OrderByDescending(s => s.Contracts
                    .Where(w => w.finish_date != null).Select(ss => ss.Order.price).Sum()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    ПІБ = s.full_name,
                    Перевезено = s.Contracts.Where(w => w.finish_date != null).Count(),
                    Заробив = s.Contracts.Where(w => w.finish_date != null).Select(ss => ss.Order.price).Sum()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшеВиконаноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Cars.ToList().OrderByDescending(s => s.Contracts
                    .Where(w => w.finish_date != null).Count()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Модель_авто = $"{s.Model.brand} {s.Model.model_name}",
                    Номер = s.car_number,
                    Зароблено = $"{Math.Round(s.Contracts.Select(ss => ss.Order.price).Sum(), 2)} UAH",
                    Компанія = s.Company != null ? s.Company.company_name : "На ринку",
                    Перевезено = $"{s.Contracts.Select(ss => ss.Order.weight).Sum()} кг",
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null).Count()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшеПеревезеноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Cars.ToList().OrderByDescending(s => s.Contracts
                    .Where(w => w.finish_date != null).Select(ss => ss.Order.weight).Sum()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Модель_авто = $"{s.Model.brand} {s.Model.model_name}",
                    Номер = s.car_number,
                    Зароблено = $"{Math.Round(s.Contracts.Select(ss => ss.Order.price).Sum(), 2)} UAH",
                    Компанія = s.Company != null ? s.Company.company_name : "На ринку",
                    Перевезено = $"{s.Contracts.Select(ss => ss.Order.weight).Sum()} кг",
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null)
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшеЗаробленоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Cars.ToList().OrderByDescending(s => s.Contracts
                    .Where(w => w.finish_date != null).Select(ss => ss.Order.price).Sum()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Модель_авто = $"{s.Model.brand} {s.Model.model_name}",
                    Номер = s.car_number,
                    Зароблено = $"{Math.Round(s.Contracts.Select(ss => ss.Order.price).Sum(), 2)} UAH",
                    Компанія = s.Company != null ? s.Company.company_name : "На ринку",
                    Перевезено = $"{s.Contracts.Select(ss => ss.Order.weight).Sum()} кг",
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null)
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшеЗамовленьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Companies.ToList()
                    .OrderByDescending(o => o.Contracts.Where(w => w.finish_date != null).Count()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Назва = s.company_name,
                    Адреса = s.address,
                    Заснована = s.date_of_foundation,
                    Автопарк = $"{s.Cars.Count} автівок",
                    Кількість_водіїв = s.Drivers.Count,
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null).Count()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшеЗаробилиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Companies.ToList()
                    .OrderByDescending(o => o.Contracts
                    .Where(w => w.finish_date != null).Select(s=>s.Order.price).Sum()).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Назва = s.company_name,
                    Адреса = s.address,
                    Заснована = s.date_of_foundation,
                    Заробила = s.Contracts
                    .Where(w => w.finish_date != null).Select(ss => ss.Order.price).Sum(),
                    Автопарк = $"{s.Cars.Count} автівок",
                    Кількість_водіїв = s.Drivers.Count,
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null).Count()
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void найбільшийАвтопаркToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var source = rialtoEntities.Companies.ToList()
                    .OrderByDescending(o => o.Cars.Count).ToList();

                dataGridView1.DataSource = source.Select(s => new
                {
                    Назва = s.company_name,
                    Адреса = s.address,
                    Заснована = s.date_of_foundation,
                    Автопарк = $"{s.Cars.Count} автівок",
                    Кількість_водіїв = s.Drivers.Count,
                    Виконано_контрактів = s.Contracts.Where(w => w.finish_date != null).Count()
                }).ToList();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}