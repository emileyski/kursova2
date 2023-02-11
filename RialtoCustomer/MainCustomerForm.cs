using RialtoCustomer.View;
using RialtoLib.Model;
using RialtoLib.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RialtoCustomer
{
    public partial class MainCustomerForm : Form
    {
        RialtoEntities rialtoEntities;
        Customer customer;
        public MainCustomerForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
        }
        private async void isAuthorizated()
        {
            var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(path);
            var data = await GenericService
                .IsAuthorizated(rialtoEntities, LoginType.Customer, path);
            if (data.Item1)
            {
                //GetCompanyAdmin();
                customer = data.Item2 as Customer;
            }
            else
            {
                var dlg = MessageBox.Show("Вам треба авторизуватися. Продовжити?",
                    "Ви не авторизувалися", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dlg)
                {
                    AuthorizationForm authorizationForm = new AuthorizationForm();
                    Hide();
                    authorizationForm.ShowDialog();
                    Show();
                    data = await GenericService
                    .IsAuthorizated(rialtoEntities, LoginType.Customer, path);
                    if (!data.Item1)
                    {
                        MessageBox.Show("Ви не пройшли авторизацію, спробуйте ще раз!");
                        Close();
                    }
                    else
                    {
                        customer = data.Item2 as Customer;
                        MessageBox.Show("Успішна авторизація!");
                    }
                }
                else
                {
                    Close();
                }
            }
        }

        private void MainCustomerForm_Load(object sender, EventArgs e)
        {
            isAuthorizated();
        }

        private void вийтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void вийтиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                GenericService.LogOut(path);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void змінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationForm registrationForm = new RegistrationForm(customer);
                Hide();
                registrationForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void додатиЗамовленняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AddOrderForm addOrderForm = new AddOrderForm(customer);
                Hide();
                addOrderForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}