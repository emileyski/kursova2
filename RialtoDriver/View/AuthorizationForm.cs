using Microsoft.VisualBasic;
using RialtoLib.Model;
using RialtoLib.Service;
using System;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;

namespace RialtoDriver.View//?
{
    public partial class AuthorizationForm : Form
    {
        RialtoEntities rialtoEntities;
        public AuthorizationForm()
        {
            InitializeComponent();
            rialtoEntities = Program.rialtoEntities;
        }

        private void registrate_btn_Click(object sender, EventArgs e)
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

        private async void authorizate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                var driver = await rialtoEntities.Drivers
                    .FirstOrDefaultAsync(f => f.email == email.Text);
                if (driver != null)
                {
                    var code = GenericService.RandomString(16);

                    GenericService.SendMessage(driver.full_name, driver.email,
                        "Ваш код авторизації", $"Введіть цей код\n\n{code}\n\n" +
                        $" у вікно, що з'явилося");

                    var conf = Interaction.InputBox("Введіть код, що ви отримали на пошту");
                    if (conf == code)
                    {
                        var path = System.IO.Path
                        .GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                        GenericService.SaveData(driver.email, path);
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Облікового запису із такою поштою не існує");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}