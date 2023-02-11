using RialtoDriver; //?
using RialtoLib.Model;
using System;
using System.Windows.Forms;

namespace RialtoDriver.View //?
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

            full_name.Text = driver.full_name; //form
            //? birth_date.Text = driver.birh_date;//form
            phone_number.Text = driver.phone_number;//form
            email.Text = driver.email;
            isEditing = true;
        }

        private async void registrate_btn_Click(object sender, EventArgs e)
        {
            try
            {
                driver.full_name = full_name.Text;
                //? driver.birh_date = birth_date.Text;//form
                driver.phone_number = phone_number.Text;//form
                driver.email = email.Text;
                if (!isEditing)
                {
                    //company_id - ?
                    try
                    {
                        rialtoEntities.Drivers.Add(driver);
                        await rialtoEntities.SaveChangesAsync();
                        Close();
                    }
                    catch (Exception ex)
                    {
                        rialtoEntities.Drivers.Remove(driver);
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

        private void RegistrationForm_Load(object sender, EventArgs e)
        {

        }
    }
}