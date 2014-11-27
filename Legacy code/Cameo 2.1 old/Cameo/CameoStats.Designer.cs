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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CameoStats));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buttonOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonClose = new System.Windows.Forms.ToolStripButton();
            this.labelSessionTitle = new System.Windows.Forms.Label();
            this.labelSessionDuration = new System.Windows.Forms.Label();
            this.labelSessionDate = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.displayHeatmap = new System.Windows.Forms.PictureBox();
            this.humanActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.labelAverageHuman = new System.Windows.Forms.Label();
            this.labelAverageActivity = new System.Windows.Forms.Label();
            this.labelAverageSoundLevel = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayHeatmap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.buttonOpen,
            this.toolStripSeparator1,
            this.buttonClose});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 1, 0);
            this.toolStrip1.Size = new System.Drawing.Size(802, 23);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // buttonClose
            // 
            this.buttonClose.Image = global::Cameo.Properties.Resources.x_7x7;
            this.buttonClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.buttonClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(113, 19);
            this.buttonClose.Text = "Close CameoStats";
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
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
            this.flowLayoutPanel1.Controls.Add(this.labelAverageHuman);
            this.flowLayoutPanel1.Controls.Add(this.labelAverageActivity);
            this.flowLayoutPanel1.Controls.Add(this.labelAverageSoundLevel);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 42);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(348, 229);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // displayHeatmap
            // 
            this.displayHeatmap.BackColor = System.Drawing.SystemColors.ControlDark;
            this.displayHeatmap.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.displayHeatmap.Location = new System.Drawing.Point(420, 12);
            this.displayHeatmap.Name = "displayHeatmap";
            this.displayHeatmap.Size = new System.Drawing.Size(360, 280);
            this.displayHeatmap.TabIndex = 9;
            this.displayHeatmap.TabStop = false;
            // 
            // humanActivityChart
            // 
            this.humanActivityChart.BackColor = System.Drawing.Color.Transparent;
            this.humanActivityChart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.humanActivityChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea1.Name = "ChartArea1";
            this.humanActivityChart.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.Color.Transparent;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.humanActivityChart.Legends.Add(legend1);
            this.humanActivityChart.Location = new System.Drawing.Point(0, 298);
            this.humanActivityChart.Name = "humanActivityChart";
            this.humanActivityChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Humans";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.IsXValueIndexed = true;
            series2.Legend = "Legend1";
            series2.Name = "Activity";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series2.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
            series3.Legend = "Legend1";
            series3.Name = "Sound";
            series3.YValuesPerPoint = 2;
            this.humanActivityChart.Series.Add(series1);
            this.humanActivityChart.Series.Add(series2);
            this.humanActivityChart.Series.Add(series3);
            this.humanActivityChart.Size = new System.Drawing.Size(802, 263);
            this.humanActivityChart.TabIndex = 10;
            this.humanActivityChart.Text = "chart1";
            // 
            // labelAverageHuman
            // 
            this.labelAverageHuman.AutoSize = true;
            this.labelAverageHuman.Location = new System.Drawing.Point(3, 78);
            this.labelAverageHuman.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.labelAverageHuman.Name = "labelAverageHuman";
            this.labelAverageHuman.Size = new System.Drawing.Size(87, 13);
            this.labelAverageHuman.TabIndex = 6;
            this.labelAverageHuman.Text = "Average human";
            // 
            // labelAverageActivity
            // 
            this.labelAverageActivity.AutoSize = true;
            this.labelAverageActivity.Location = new System.Drawing.Point(3, 111);
            this.labelAverageActivity.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.labelAverageActivity.Name = "labelAverageActivity";
            this.labelAverageActivity.Size = new System.Drawing.Size(86, 13);
            this.labelAverageActivity.TabIndex = 7;
            this.labelAverageActivity.Text = "Average activity";
            // 
            // labelAverageSoundLevel
            // 
            this.labelAverageSoundLevel.AutoSize = true;
            this.labelAverageSoundLevel.Location = new System.Drawing.Point(3, 144);
            this.labelAverageSoundLevel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 10);
            this.labelAverageSoundLevel.Name = "labelAverageSoundLevel";
            this.labelAverageSoundLevel.Size = new System.Drawing.Size(84, 13);
            this.labelAverageSoundLevel.TabIndex = 8;
            this.labelAverageSoundLevel.Text = "Average sound";
            // 
            // CameoStats
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 573);
            this.Controls.Add(this.humanActivityChart);
            this.Controls.Add(this.displayHeatmap);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(818, 612);
            this.MinimumSize = new System.Drawing.Size(818, 612);
            this.Name = "CameoStats";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "CameoStats";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayHeatmap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).EndInit();
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
        private System.Windows.Forms.PictureBox displayHeatmap;
        private System.Windows.Forms.DataVisualization.Charting.Chart humanActivityChart;
        private System.Windows.Forms.ToolStripButton buttonClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label labelAverageHuman;
        private System.Windows.Forms.Label labelAverageActivity;
        private System.Windows.Forms.Label labelAverageSoundLevel;

    }
}