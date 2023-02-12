namespace RialtoCustomer.View
{
    partial class AddOrderForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.select_to = new System.Windows.Forms.Button();
            this.select_from = new System.Windows.Forms.Button();
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.distance_label = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.weight_tb = new System.Windows.Forms.TextBox();
            this.volume_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.push_order = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.address_to_tb = new System.Windows.Forms.TextBox();
            this.address_from_tb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label5);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.address_to_tb);
            this.splitContainer1.Panel1.Controls.Add(this.address_from_tb);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.push_order);
            this.splitContainer1.Panel1.Controls.Add(this.button1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.volume_tb);
            this.splitContainer1.Panel1.Controls.Add(this.weight_tb);
            this.splitContainer1.Panel1.Controls.Add(this.distance_label);
            this.splitContainer1.Panel1.Controls.Add(this.select_to);
            this.splitContainer1.Panel1.Controls.Add(this.select_from);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.gMapControl1);
            this.splitContainer1.Size = new System.Drawing.Size(707, 523);
            this.splitContainer1.SplitterDistance = 235;
            this.splitContainer1.TabIndex = 0;
            // 
            // select_to
            // 
            this.select_to.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.select_to.Location = new System.Drawing.Point(3, 170);
            this.select_to.Name = "select_to";
            this.select_to.Size = new System.Drawing.Size(230, 37);
            this.select_to.TabIndex = 31;
            this.select_to.Text = "ВИБЕРІТЬ КУДИ";
            this.select_to.UseVisualStyleBackColor = false;
            this.select_to.Click += new System.EventHandler(this.select_to_Click);
            // 
            // select_from
            // 
            this.select_from.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.select_from.Location = new System.Drawing.Point(3, 67);
            this.select_from.Name = "select_from";
            this.select_from.Size = new System.Drawing.Size(230, 37);
            this.select_from.TabIndex = 30;
            this.select_from.Text = "ВИБЕРІТЬ ЗВІДКИ";
            this.select_from.UseVisualStyleBackColor = false;
            this.select_from.Click += new System.EventHandler(this.select_from_Click);
            // 
            // gMapControl1
            // 
            this.gMapControl1.Bearing = 0F;
            this.gMapControl1.CanDragMap = true;
            this.gMapControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl1.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl1.GrayScaleMode = false;
            this.gMapControl1.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl1.LevelsKeepInMemmory = 5;
            this.gMapControl1.Location = new System.Drawing.Point(0, 0);
            this.gMapControl1.MarkersEnabled = true;
            this.gMapControl1.MaxZoom = 2;
            this.gMapControl1.MinZoom = 2;
            this.gMapControl1.MouseWheelZoomEnabled = true;
            this.gMapControl1.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl1.Name = "gMapControl1";
            this.gMapControl1.NegativeMode = false;
            this.gMapControl1.PolygonsEnabled = true;
            this.gMapControl1.RetryLoadTile = 0;
            this.gMapControl1.RoutesEnabled = true;
            this.gMapControl1.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl1.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl1.ShowTileGridLines = false;
            this.gMapControl1.Size = new System.Drawing.Size(468, 523);
            this.gMapControl1.TabIndex = 12;
            this.gMapControl1.Zoom = 0D;
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClickAsync);
            // 
            // distance_label
            // 
            this.distance_label.AutoSize = true;
            this.distance_label.Location = new System.Drawing.Point(5, 209);
            this.distance_label.Name = "distance_label";
            this.distance_label.Size = new System.Drawing.Size(110, 25);
            this.distance_label.TabIndex = 32;
            this.distance_label.Text = "Дистанція";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 259);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 25);
            this.label1.TabIndex = 33;
            this.label1.Text = "Вага";
            // 
            // weight_tb
            // 
            this.weight_tb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.weight_tb.Location = new System.Drawing.Point(2, 287);
            this.weight_tb.Name = "weight_tb";
            this.weight_tb.Size = new System.Drawing.Size(230, 30);
            this.weight_tb.TabIndex = 34;
            // 
            // volume_tb
            // 
            this.volume_tb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.volume_tb.Location = new System.Drawing.Point(2, 350);
            this.volume_tb.Name = "volume_tb";
            this.volume_tb.Size = new System.Drawing.Size(230, 30);
            this.volume_tb.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 33;
            this.label2.Text = "Об\'єм";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.button1.Location = new System.Drawing.Point(2, 386);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 37);
            this.button1.TabIndex = 35;
            this.button1.Text = "ПІДРАХУВАТИ ЦІНУ";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // push_order
            // 
            this.push_order.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.push_order.Location = new System.Drawing.Point(3, 483);
            this.push_order.Name = "push_order";
            this.push_order.Size = new System.Drawing.Size(230, 37);
            this.push_order.TabIndex = 36;
            this.push_order.Text = "ОПУБЛІКУВАТИ";
            this.push_order.UseVisualStyleBackColor = false;
            this.push_order.Click += new System.EventHandler(this.push_order_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(2, 426);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(199, 25);
            this.label3.TabIndex = 37;
            this.label3.Text = "Бажаний тип кузова";
            // 
            // address_to_tb
            // 
            this.address_to_tb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.address_to_tb.Location = new System.Drawing.Point(3, 134);
            this.address_to_tb.Name = "address_to_tb";
            this.address_to_tb.Size = new System.Drawing.Size(230, 30);
            this.address_to_tb.TabIndex = 38;
            // 
            // address_from_tb
            // 
            this.address_from_tb.ForeColor = System.Drawing.SystemColors.Highlight;
            this.address_from_tb.Location = new System.Drawing.Point(3, 31);
            this.address_from_tb.Name = "address_from_tb";
            this.address_from_tb.Size = new System.Drawing.Size(230, 30);
            this.address_from_tb.TabIndex = 39;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(2, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(171, 25);
            this.label4.TabIndex = 40;
            this.label4.Text = "Куди доставити?";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 25);
            this.label5.TabIndex = 41;
            this.label5.Text = "Звідки забрати?";
            // 
            // AddOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(707, 523);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.ForeColor = System.Drawing.Color.White;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AddOrderForm";
            this.Text = "AddOrderForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private GMap.NET.WindowsForms.GMapControl gMapControl1;
        private System.Windows.Forms.Button select_to;
        private System.Windows.Forms.Button select_from;
        private System.Windows.Forms.Label distance_label;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button push_order;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox volume_tb;
        private System.Windows.Forms.TextBox weight_tb;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox address_to_tb;
        private System.Windows.Forms.TextBox address_from_tb;
    }
}