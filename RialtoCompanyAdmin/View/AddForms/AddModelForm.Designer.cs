namespace RialtoCompanyAdmin.View.AddForms
{
    partial class AddModelForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.brand_name_cb = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.year_of_production = new System.Windows.Forms.TextBox();
            this.save_btn = new System.Windows.Forms.Button();
            this.model_name_tb = new System.Windows.Forms.TextBox();
            this.find_brand = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Назва моделі";
            // 
            // brand_name_cb
            // 
            this.brand_name_cb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.brand_name_cb.FormattingEnabled = true;
            this.brand_name_cb.Location = new System.Drawing.Point(7, 101);
            this.brand_name_cb.Name = "brand_name_cb";
            this.brand_name_cb.Size = new System.Drawing.Size(142, 33);
            this.brand_name_cb.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Назва бренду";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(163, 25);
            this.label3.TabIndex = 11;
            this.label3.Text = "Рік виробництва";
            // 
            // year_of_production
            // 
            this.year_of_production.ForeColor = System.Drawing.SystemColors.Highlight;
            this.year_of_production.Location = new System.Drawing.Point(7, 165);
            this.year_of_production.Name = "year_of_production";
            this.year_of_production.Size = new System.Drawing.Size(188, 30);
            this.year_of_production.TabIndex = 12;
            // 
            // save_btn
            // 
            this.save_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.save_btn.Location = new System.Drawing.Point(7, 201);
            this.save_btn.Name = "save_btn";
            this.save_btn.Size = new System.Drawing.Size(188, 37);
            this.save_btn.TabIndex = 32;
            this.save_btn.Text = "ЗБЕРЕГТИ";
            this.save_btn.UseVisualStyleBackColor = false;
            this.save_btn.Click += new System.EventHandler(this.save_btn_Click);
            // 
            // model_name_tb
            // 
            this.model_name_tb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.model_name_tb.Location = new System.Drawing.Point(7, 40);
            this.model_name_tb.Name = "model_name_tb";
            this.model_name_tb.Size = new System.Drawing.Size(188, 30);
            this.model_name_tb.TabIndex = 33;
            // 
            // find_brand
            // 
            this.find_brand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.find_brand.Location = new System.Drawing.Point(155, 101);
            this.find_brand.Name = "find_brand";
            this.find_brand.Size = new System.Drawing.Size(40, 33);
            this.find_brand.TabIndex = 44;
            this.find_brand.Text = "🔍";
            this.find_brand.UseVisualStyleBackColor = false;
            this.find_brand.Click += new System.EventHandler(this.find_brand_Click);
            // 
            // AddModelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(198, 242);
            this.Controls.Add(this.find_brand);
            this.Controls.Add(this.model_name_tb);
            this.Controls.Add(this.save_btn);
            this.Controls.Add(this.year_of_production);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.brand_name_cb);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddModelForm";
            this.Text = "AddModelForm";
            this.Load += new System.EventHandler(this.AddModelForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox brand_name_cb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox year_of_production;
        private System.Windows.Forms.Button save_btn;
        private System.Windows.Forms.TextBox model_name_tb;
        private System.Windows.Forms.Button find_brand;
    }
}