namespace Cameo
{
    partial class CameoStats
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameoStats));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonOpen = new System.Windows.Forms.ToolStripButton();
            this.labelSessionTitle = new System.Windows.Forms.Label();
            this.labelSessionDuration = new System.Windows.Forms.Label();
            this.labelSessionDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.heatmap = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.heatmap)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpen});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(692, 22);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Image = global::Cameo.Properties.Resources.folder_fill_8x8;
            this.buttonOpen.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(108, 19);
            this.buttonOpen.Text = "Open Cameo file";
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // labelSessionTitle
            // 
            this.labelSessionTitle.AutoSize = true;
            this.labelSessionTitle.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.labelSessionTitle.Location = new System.Drawing.Point(3, 0);
            this.labelSessionTitle.Name = "labelSessionTitle";
            this.labelSessionTitle.Size = new System.Drawing.Size(123, 30);
            this.labelSessionTitle.TabIndex = 3;
            this.labelSessionTitle.Text = "sessionTitle";
            // 
            // labelSessionDuration
            // 
            this.labelSessionDuration.AutoSize = true;
            this.labelSessionDuration.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSessionDuration.Location = new System.Drawing.Point(3, 49);
            this.labelSessionDuration.Name = "labelSessionDuration";
            this.labelSessionDuration.Size = new System.Drawing.Size(107, 19);
            this.labelSessionDuration.TabIndex = 4;
            this.labelSessionDuration.Text = "sessionDuration";
            // 
            // labelSessionDate
            // 
            this.labelSessionDate.AutoSize = true;
            this.labelSessionDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.labelSessionDate.Location = new System.Drawing.Point(3, 30);
            this.labelSessionDate.Name = "labelSessionDate";
            this.labelSessionDate.Size = new System.Drawing.Size(82, 19);
            this.labelSessionDate.TabIndex = 5;
            this.labelSessionDate.Text = "sessionDate";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.labelSessionTitle);
            this.flowLayoutPanel1.Controls.Add(this.labelSessionDate);
            this.flowLayoutPanel1.Controls.Add(this.labelSessionDuration);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 25);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(200, 260);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.heatmap);
            this.groupBox1.Location = new System.Drawing.Point(231, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(440, 342);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "heatmap";
            // 
            // heatmap
            // 
            this.heatmap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.heatmap.Location = new System.Drawing.Point(31, 22);
            this.heatmap.Name = "heatmap";
            this.heatmap.Size = new System.Drawing.Size(360, 260);
            this.heatmap.TabIndex = 8;
            this.heatmap.TabStop = false;
            // 
            // CameoStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 381);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CameoStats";
            this.Text = "CameoStats";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.heatmap)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton buttonOpen;
        private System.Windows.Forms.Label labelSessionTitle;
        private System.Windows.Forms.Label labelSessionDuration;
        private System.Windows.Forms.Label labelSessionDate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox heatmap;

    }
}