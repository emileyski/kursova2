namespace RialtoCustomer.View
{
    partial class RegistrationForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.customer_name = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.registrate_btn = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Назва замовника";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Електронна пошта";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(176, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Номер телефону";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // customer_name
            // 
            this.customer_name.ForeColor = System.Drawing.SystemColors.Highlight;
            this.customer_name.Location = new System.Drawing.Point(12, 39);
            this.customer_name.Name = "customer_name";
            this.customer_name.Size = new System.Drawing.Size(220, 30);
            this.customer_name.TabIndex = 4;
            this.customer_name.TextChanged += new System.EventHandler(this.company_name_TextChanged);
            // 
            // email
            // 
            this.email.ForeColor = System.Drawing.SystemColors.Highlight;
            this.email.Location = new System.Drawing.Point(12, 109);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(220, 30);
            this.email.TabIndex = 5;
            this.email.TextChanged += new System.EventHandler(this.email_TextChanged);
            // 
            // phone_number
            // 
            this.phone_number.ForeColor = System.Drawing.SystemColors.Highlight;
            this.phone_number.Location = new System.Drawing.Point(12, 170);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(220, 30);
            this.phone_number.TabIndex = 6;
            this.phone_number.TextChanged += new System.EventHandler(this.adress_TextChanged);
            // 
            // registrate_btn
            // 
            this.registrate_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.registrate_btn.Location = new System.Drawing.Point(12, 206);
            this.registrate_btn.Name = "registrate_btn";
            this.registrate_btn.Size = new System.Drawing.Size(220, 46);
            this.registrate_btn.TabIndex = 29;
            this.registrate_btn.Text = "ЗАРЕЄСТРУВАТИСЯ";
            this.registrate_btn.UseVisualStyleBackColor = false;
            this.registrate_btn.Click += new System.EventHandler(this.registrate_btn_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(294, 39);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(227, 236);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(994, 493);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.customer_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.email);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.registrate_btn);
            this.Controls.Add(this.phone_number);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox customer_name;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.Button registrate_btn;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}