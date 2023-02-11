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
    public partial class RegistrationForm : Form
    {
        RialtoEntities rialtoEntities;
        Company company;
        bool isEditing = false;
        public RegistrationForm()
        {
            InitializeComponent();
            company = new Company();

            rialtoEntities = Program.rialtoEntities;
        }
        public RegistrationForm(Company company)
        {
            InitializeComponent();
            this.company = company;

            rialtoEntities = Program.rialtoEntities;

            company_name.Text = company.company_name;
            email.Text = company.email;
            adress.Text = company.address;
            isEditing = true;
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
    }
}