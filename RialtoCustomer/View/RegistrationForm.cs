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

namespace RialtoCustomer.View
{
    public partial class RegistrationForm : Form
    {
        RialtoEntities rialtoEntities;
        Customer customer;
        bool isEditing = false;
        public RegistrationForm()
        {
            InitializeComponent();
            customer = new Customer();

            rialtoEntities = Program.rialtoEntities;
        }
        public RegistrationForm(Customer customer)
        {
            InitializeComponent();
            this.customer = customer;

            rialtoEntities = Program.rialtoEntities;

            customer_name.Text = customer.name;
            email.Text = customer.email;
            phone_number.Text = customer.phone_number;
            isEditing = true;
        }

        private async void registrate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                customer.name = customer_name.Text;
                customer.email = email.Text;
                customer.phone_number = phone_number.Text;
                if (!isEditing)
                {
                    customer.registration_date = DateTime.Now;
                    try
                    {
                        rialtoEntities.Customers.Add(customer);
                        await rialtoEntities.SaveChangesAsync();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Customers.Remove(customer);
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void email_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void company_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void adress_TextChanged(object sender, EventArgs e)
        {

        }
    }
}