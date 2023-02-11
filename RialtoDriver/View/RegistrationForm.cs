using RialtoDriver;
using RialtoLib.Model;
using System;
using System.Windows.Forms;

namespace RialtoCompanyDriver.View
{
    public partial class RegistrationForm : Form
    {
        RialtoEntities rialtoEntities;
        Driver driver;
        bool isEditing = false;
        public RegistrationForm()
        {
            InitializeComponent();
            driver = new Driver();

            rialtoEntities = Program.rialtoEntities;
        }
        public RegistrationForm(Driver driver)
        {
            InitializeComponent();
            this.driver = driver;

            rialtoEntities = Program.rialtoEntities;

            company_name.Text = driver.full_name;
            email.Text = driver.email;
            //adress.Text = company.address;
            isEditing = true;
        }

        private async void registrate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                driver.company_name = company_name.Text;
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