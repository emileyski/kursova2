using Microsoft.VisualBasic;
using RialtoCompanyAdmin.View;
using RialtoLib.Model;
using RialtoLib.Service;
using System;
using System.Windows.Forms;

namespace RialtoCompanyAdmin
{
    public partial class MainAdminForm : Form
    {
        RialtoEntities rialtoEntities;
        Company company;
        public MainAdminForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;

            isAuthorizated();
        }
        private async void isAuthorizated()
        {
            var path = System.IO.Path
                .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //MessageBox.Show(path);
            var data = await GenericService
                .IsAuthorizated(rialtoEntities, LoginType.Admin, path);
            if (data.Item1)
            {
                //GetCompanyAdmin();
                company = data.Item2 as Company;
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
                    .IsAuthorizated(rialtoEntities, LoginType.Admin, path);
                    if (!data.Item1)
                    {
                        MessageBox.Show("Ви не пройшли авторизацію, спробуйте ще раз!");
                        Close();
                    }
                    else
                    {
                        company = data.Item2 as Company;
                        MessageBox.Show("Успішна авторизація!");
                    }
                }
                else
                {
                    Close();
                }
            }
        }

        private void змінитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                RegistrationForm registrationForm = new RegistrationForm();
                Hide();
                registrationForm.ShowDialog();
                Show();
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

        private void автівкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                CarsHandlingForm carsHandlingForm = new CarsHandlingForm();
                Hide();
                carsHandlingForm.ShowDialog();
                Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}