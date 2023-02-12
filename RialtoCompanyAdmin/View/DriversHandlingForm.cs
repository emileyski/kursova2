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
    public partial class DriversHandlingForm : Form
    {
        Company company;
        RialtoEntities rialtoEntities;
        public DriversHandlingForm(Company company)
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;

            rialtoEntities = Program.rialtoEntities;
            this.company = company;

            FindAvailableDrivers();
        }
        private void FindAvailableDrivers()
        {
            try
            {
                var source = rialtoEntities.Drivers.Where(w => w.company_id == null).ToList();
                if (filter_by_age.Checked)
                {
                    var min_age = int.Parse(min_age_tb.Text);
                    var max_age = int.Parse(max_age_tb.Text);
                    if (min_age > max_age || min_age < 0 || max_age < 0)
                        throw new Exception("Ви ввели некоректні аргументи для пошуку за віком");

                    var min_birth_date = DateTime.Now.AddYears(-max_age);
                    var max_birth_date = DateTime.Now.AddYears(-min_age);
                    source = source.Where(w => w.birh_date > min_birth_date && w.birh_date < max_birth_date).ToList();
                }
                if (!string.IsNullOrEmpty(find_fullname_tb.Text))
                {
                    source = source.Where(w => w.full_name.Contains(find_fullname_tb.Text)).ToList();
                }
                if (order_available_cb.SelectedIndex > 0)
                {
                    switch (order_available_cb.SelectedIndex)
                    {
                        case 1:
                            source = source.OrderBy(o => o.birh_date).ToList();
                            break;
                        case 2:
                            source = source.OrderBy(o => o.full_name).ToList();
                            break;
                        case 3:
                            source = source.OrderBy(o => o.Contracts
                            .Where(w => w.finish_date != null).Count()).ToList();
                            break;
                    }
                }
                dataGridView1.DataSource = source.Select(s => new
                {
                    id = s.driver_id,
                    ПІБ = s.full_name,
                    Виконаних_контрактів = s.Contracts.Where(w => w.finish_date != null).Count(),
                    Дата_народження = s.birh_date,
                    Номер_телефона = s.phone_number,
                    Пошта = s.email
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void add_body_type_Click(object sender, EventArgs e)
        {
            try
            {
                FindAvailableDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        Driver GetAvailableDriverById()
        {
            var driver = rialtoEntities.Drivers.ToList().FirstOrDefault(f => f.driver_id == Convert
            .ToInt32(dataGridView1[0, dataGridView1.CurrentCell.RowIndex].Value));
            return driver;
        }

        private async void hire_selected_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = GetAvailableDriverById();
                if (driver == null)
                    throw new Exception("Ви не вибрали водія");
                driver.company_id = company.company_id;
                await rialtoEntities.SaveChangesAsync();
                FindAvailableDrivers();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}