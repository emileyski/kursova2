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
            this.gMapControl1 = new GMap.NET.WindowsForms.GMapControl();
            this.select_from = new System.Windows.Forms.Button();
            this.select_to = new System.Windows.Forms.Button();
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
            this.gMapControl1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl1_MouseDoubleClick);
            // 
            // select_from
            // 
            this.select_from.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.select_from.Location = new System.Drawing.Point(3, 3);
            this.select_from.Name = "select_from";
            this.select_from.Size = new System.Drawing.Size(230, 37);
            this.select_from.TabIndex = 30;
            this.select_from.Text = "ВИБЕРІТЬ ЗВІДКИ";
            this.select_from.UseVisualStyleBackColor = false;
            this.select_from.Click += new System.EventHandler(this.select_from_Click);
            // 
            // select_to
            // 
            this.select_to.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(85)))), ((int)(((byte)(174)))), ((int)(((byte)(217)))));
            this.select_to.Location = new System.Drawing.Point(2, 46);
            this.select_to.Name = "select_to";
            this.select_to.Size = new System.Drawing.Size(230, 37);
            this.select_to.TabIndex = 31;
            this.select_to.Text = "ВИБЕРІТЬ КУДИ";
            this.select_to.UseVisualStyleBackColor = false;
            this.select_to.Click += new System.EventHandler(this.select_to_Click);
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
    }
}