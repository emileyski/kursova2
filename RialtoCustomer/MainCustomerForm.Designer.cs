﻿namespace RialtoCustomer
{
    partial class MainCustomerForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.вийтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обліковийЗаписToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вийтиToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.змінитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.замовленняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.додатиЗамовленняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вийтиToolStripMenuItem,
            this.обліковийЗаписToolStripMenuItem,
            this.замовленняToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // вийтиToolStripMenuItem
            // 
            this.вийтиToolStripMenuItem.Name = "вийтиToolStripMenuItem";
            this.вийтиToolStripMenuItem.Size = new System.Drawing.Size(65, 24);
            this.вийтиToolStripMenuItem.Text = "Вийти";
            this.вийтиToolStripMenuItem.Click += new System.EventHandler(this.вийтиToolStripMenuItem_Click);
            // 
            // обліковийЗаписToolStripMenuItem
            // 
            this.обліковийЗаписToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.вийтиToolStripMenuItem1,
            this.змінитиToolStripMenuItem});
            this.обліковийЗаписToolStripMenuItem.Name = "обліковийЗаписToolStripMenuItem";
            this.обліковийЗаписToolStripMenuItem.Size = new System.Drawing.Size(141, 24);
            this.обліковийЗаписToolStripMenuItem.Text = "Обліковий запис";
            // 
            // вийтиToolStripMenuItem1
            // 
            this.вийтиToolStripMenuItem1.Name = "вийтиToolStripMenuItem1";
            this.вийтиToolStripMenuItem1.Size = new System.Drawing.Size(148, 26);
            this.вийтиToolStripMenuItem1.Text = "Вийти";
            this.вийтиToolStripMenuItem1.Click += new System.EventHandler(this.вийтиToolStripMenuItem1_Click);
            // 
            // змінитиToolStripMenuItem
            // 
            this.змінитиToolStripMenuItem.Name = "змінитиToolStripMenuItem";
            this.змінитиToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this.змінитиToolStripMenuItem.Text = "Змінити";
            this.змінитиToolStripMenuItem.Click += new System.EventHandler(this.змінитиToolStripMenuItem_Click);
            // 
            // замовленняToolStripMenuItem
            // 
            this.замовленняToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.додатиЗамовленняToolStripMenuItem});
            this.замовленняToolStripMenuItem.Name = "замовленняToolStripMenuItem";
            this.замовленняToolStripMenuItem.Size = new System.Drawing.Size(109, 24);
            this.замовленняToolStripMenuItem.Text = "Замовлення";
            // 
            // додатиЗамовленняToolStripMenuItem
            // 
            this.додатиЗамовленняToolStripMenuItem.Name = "додатиЗамовленняToolStripMenuItem";
            this.додатиЗамовленняToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.додатиЗамовленняToolStripMenuItem.Text = "Додати замовлення";
            this.додатиЗамовленняToolStripMenuItem.Click += new System.EventHandler(this.додатиЗамовленняToolStripMenuItem_Click);
            // 
            // MainCustomerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Name = "MainCustomerForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainCustomerForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обліковийЗаписToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem вийтиToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem змінитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem замовленняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem додатиЗамовленняToolStripMenuItem;
    }
}

