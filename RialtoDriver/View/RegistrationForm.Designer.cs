namespace RialtoDriver.View
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
            this.full_name = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.birth_date = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.phone_number = new System.Windows.Forms.TextBox();
            this.registrate_btn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "ПІБ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Електронна пошта";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата народження";
            // 
            // full_name
            // 
            this.full_name.ForeColor = System.Drawing.SystemColors.Highlight;
            this.full_name.Location = new System.Drawing.Point(41, 51);
            this.full_name.Name = "full_name";
            this.full_name.Size = new System.Drawing.Size(220, 30);
            this.full_name.TabIndex = 4;
            // 
            // email
            // 
            this.email.ForeColor = System.Drawing.SystemColors.Highlight;
            this.email.Location = new System.Drawing.Point(41, 176);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(220, 30);
            this.email.TabIndex = 5;
            // 
            // birth_date
            // 
            this.birth_date.ForeColor = System.Drawing.SystemColors.Highlight;
            this.birth_date.Location = new System.Drawing.Point(41, 112);
            this.birth_date.Name = "birth_date";
            this.birth_date.Size = new System.Drawing.Size(220, 30);
            this.birth_date.TabIndex = 6;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(328, 23);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(250, 341);
            this.flowLayoutPanel1.TabIndex = 7;
            // 
            // phone_number
            // 
            this.phone_number.ForeColor = System.Drawing.SystemColors.Highlight;
            this.phone_number.Location = new System.Drawing.Point(41, 237);
            this.phone_number.Name = "phone_number";
            this.phone_number.Size = new System.Drawing.Size(220, 30);
            this.phone_number.TabIndex = 30;
            // 
            // registrate_btn
            // 
            this.registrate_btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.registrate_btn.Location = new System.Drawing.Point(41, 273);
            this.registrate_btn.Name = "registrate_btn";
            this.registrate_btn.Size = new System.Drawing.Size(220, 46);
            this.registrate_btn.TabIndex = 29;
            this.registrate_btn.Text = "ЗАРЕЄСТРУВАТИСЯ";
            this.registrate_btn.UseVisualStyleBackColor = false;
            this.registrate_btn.Click += new System.EventHandler(this.registrate_btn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(36, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 25);
            this.label4.TabIndex = 31;
            this.label4.Text = "Номер телефону";
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(792, 397);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.full_name);
            this.Controls.Add(this.email);
            this.Controls.Add(this.registrate_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.birth_date);
            this.Controls.Add(this.phone_number);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox full_name;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.TextBox birth_date;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button registrate_btn;
        private System.Windows.Forms.TextBox phone_number;
        private System.Windows.Forms.Label label4;
    }
}