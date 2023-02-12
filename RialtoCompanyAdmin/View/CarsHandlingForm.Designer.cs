namespace RialtoCompanyAdmin.View
{
    partial class CarsHandlingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.додатиАвтівкуToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.редагуватиВибрануToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиВибрануToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сортуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заНавоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заВантажопідйомністюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.неСортуватиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 48);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(685, 441);
            this.dataGridView1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиАвтівкуToolStripMenuItem,
            this.редагуватиВибрануToolStripMenuItem,
            this.видалитиВибрануToolStripMenuItem,
            this.сортуватиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(685, 38);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // додатиАвтівкуToolStripMenuItem
            // 
            this.додатиАвтівкуToolStripMenuItem.Name = "додатиАвтівкуToolStripMenuItem";
            this.додатиАвтівкуToolStripMenuItem.Size = new System.Drawing.Size(125, 34);
            this.додатиАвтівкуToolStripMenuItem.Text = "Додати автівку";
            this.додатиАвтівкуToolStripMenuItem.Click += new System.EventHandler(this.додатиАвтівкуToolStripMenuItem_Click);
            // 
            // редагуватиВибрануToolStripMenuItem
            // 
            this.редагуватиВибрануToolStripMenuItem.Name = "редагуватиВибрануToolStripMenuItem";
            this.редагуватиВибрануToolStripMenuItem.Size = new System.Drawing.Size(162, 34);
            this.редагуватиВибрануToolStripMenuItem.Text = "Редагувати вибрану";
            this.редагуватиВибрануToolStripMenuItem.Click += new System.EventHandler(this.редагуватиВибрануToolStripMenuItem_Click);
            // 
            // видалитиВибрануToolStripMenuItem
            // 
            this.видалитиВибрануToolStripMenuItem.Name = "видалитиВибрануToolStripMenuItem";
            this.видалитиВибрануToolStripMenuItem.Size = new System.Drawing.Size(152, 34);
            this.видалитиВибрануToolStripMenuItem.Text = "Видалити вибрану";
            this.видалитиВибрануToolStripMenuItem.Click += new System.EventHandler(this.видалитиВибрануToolStripMenuItem_Click);
            // 
            // сортуватиToolStripMenuItem
            // 
            this.сортуватиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.заНавоToolStripMenuItem,
            this.заВантажопідйомністюToolStripMenuItem,
            this.неСортуватиToolStripMenuItem});
            this.сортуватиToolStripMenuItem.Name = "сортуватиToolStripMenuItem";
            this.сортуватиToolStripMenuItem.Size = new System.Drawing.Size(94, 34);
            this.сортуватиToolStripMenuItem.Text = "Сортувати";
            // 
            // заНавоToolStripMenuItem
            // 
            this.заНавоToolStripMenuItem.Name = "заНавоToolStripMenuItem";
            this.заНавоToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.заНавоToolStripMenuItem.Text = "За назвою моделі";
            this.заНавоToolStripMenuItem.Click += new System.EventHandler(this.заНавоToolStripMenuItem_Click);
            // 
            // заВантажопідйомністюToolStripMenuItem
            // 
            this.заВантажопідйомністюToolStripMenuItem.Name = "заВантажопідйомністюToolStripMenuItem";
            this.заВантажопідйомністюToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.заВантажопідйомністюToolStripMenuItem.Text = "За вантажопідйомністю";
            this.заВантажопідйомністюToolStripMenuItem.Click += new System.EventHandler(this.заВантажопідйомністюToolStripMenuItem_Click);
            // 
            // неСортуватиToolStripMenuItem
            // 
            this.неСортуватиToolStripMenuItem.Name = "неСортуватиToolStripMenuItem";
            this.неСортуватиToolStripMenuItem.Size = new System.Drawing.Size(259, 26);
            this.неСортуватиToolStripMenuItem.Text = "Не сортувати";
            this.неСортуватиToolStripMenuItem.Click += new System.EventHandler(this.неСортуватиToolStripMenuItem_Click);
            // 
            // CarsHandlingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(548, 391);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CarsHandlingForm";
            this.Text = "CarsHandlingForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem додатиАвтівкуToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem редагуватиВибрануToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиВибрануToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сортуватиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заНавоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заВантажопідйомністюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem неСортуватиToolStripMenuItem;
    }
}