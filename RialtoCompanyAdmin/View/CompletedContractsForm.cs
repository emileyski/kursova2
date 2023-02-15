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
    public partial class CompletedContractsForm : Form
    {
        Company company;
        public CompletedContractsForm(Company company)
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.ForeColor = Color.Black;
            this.company= company;
            LoadContracts();
        }
        void LoadContracts()
        {
            var source = company.Contracts
                .Where(w=>w.finish_date!=null).ToList();
            dataGridView1.DataSource = source.Select(s => new
            {
                Замовник = s.Order.Customer.name,
                Звідки = s.Order.address_from,
                Куди = s.Order.address_to,
                Вага = s.Order.weight,
                Ціна = s.Order.price,
                Вантаж = s.Order.cargo_name
            }).ToList();
        }
    }
}
