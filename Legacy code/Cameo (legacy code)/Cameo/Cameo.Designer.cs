namespace Cameo
{
    partial class Cameo
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cameo));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cameoTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cameoTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cameraDisplay = new System.Windows.Forms.PictureBox();
            this.CameraSize = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.heatmapDisplay = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.humanCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.averageHumanCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.activityMeter = new System.Windows.Forms.ProgressBar();
            this.activityLevelText = new System.Windows.Forms.Label();
            this.humanActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cameoStatusbar = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRuntime = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.cameoTrayMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatmapDisplay)).BeginInit();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).BeginInit();
            this.cameoStatusbar.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cameoTray
            // 
            this.cameoTray.ContextMenuStrip = this.cameoTrayMenu;
            resources.ApplyResources(this.cameoTray, "cameoTray");
            // 
            // cameoTrayMenu
            // 
            this.cameoTrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuLabel,
            this.trayMenuQuit});
            this.cameoTrayMenu.Name = "cameoTrayMenu";
            resources.ApplyResources(this.cameoTrayMenu, "cameoTrayMenu");
            this.cameoTrayMenu.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cameoTrayClickItem);
            // 
            // trayMenuLabel
            // 
            resources.ApplyResources(this.trayMenuLabel, "trayMenuLabel");
            this.trayMenuLabel.Name = "trayMenuLabel";
            // 
            // trayMenuQuit
            // 
            this.trayMenuQuit.Name = "trayMenuQuit";
            resources.ApplyResources(this.trayMenuQuit, "trayMenuQuit");
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.label1);
            this.flowLayoutPanel1.Controls.Add(this.cameraDisplay);
            this.flowLayoutPanel1.Controls.Add(this.CameraSize);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // cameraDisplay
            // 
            this.cameraDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.cameraDisplay, "cameraDisplay");
            this.cameraDisplay.Name = "cameraDisplay";
            this.cameraDisplay.TabStop = false;
            // 
            // CameraSize
            // 
            resources.ApplyResources(this.CameraSize, "CameraSize");
            this.CameraSize.Name = "CameraSize";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // heatmapDisplay
            // 
            this.heatmapDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.heatmapDisplay, "heatmapDisplay");
            this.heatmapDisplay.Name = "heatmapDisplay";
            this.heatmapDisplay.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.heatmapDisplay);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.pictureBox1);
            this.flowLayoutPanel3.Controls.Add(this.label4);
            this.flowLayoutPanel3.Controls.Add(this.humanCount);
            this.flowLayoutPanel3.Controls.Add(this.label6);
            this.flowLayoutPanel3.Controls.Add(this.averageHumanCount);
            this.flowLayoutPanel3.Controls.Add(this.label5);
            this.flowLayoutPanel3.Controls.Add(this.activityMeter);
            this.flowLayoutPanel3.Controls.Add(this.activityLevelText);
            this.flowLayoutPanel3.Controls.Add(this.humanActivityChart);
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // humanCount
            // 
            resources.ApplyResources(this.humanCount, "humanCount");
            this.humanCount.Name = "humanCount";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // averageHumanCount
            // 
            resources.ApplyResources(this.averageHumanCount, "averageHumanCount");
            this.averageHumanCount.Name = "averageHumanCount";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // activityMeter
            // 
            resources.ApplyResources(this.activityMeter, "activityMeter");
            this.activityMeter.Maximum = 101;
            this.activityMeter.Name = "activityMeter";
            this.activityMeter.UseWaitCursor = true;
            // 
            // activityLevelText
            // 
            resources.ApplyResources(this.activityLevelText, "activityLevelText");
            this.activityLevelText.Name = "activityLevelText";
            // 
            // humanActivityChart
            // 
            this.humanActivityChart.BackGradientStyle = System.Windows.Forms.DataVisualization.Charting.GradientStyle.LeftRight;
            chartArea1.Name = "ChartArea1";
            this.humanActivityChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.humanActivityChart.Legends.Add(legend1);
            resources.ApplyResources(this.humanActivityChart, "humanActivityChart");
            this.humanActivityChart.Name = "humanActivityChart";
            this.humanActivityChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
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
            this.humanActivityChart.Series.Add(series1);
            this.humanActivityChart.Series.Add(series2);
            // 
            // cameoStatusbar
            // 
            this.cameoStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.labelRuntime});
            resources.ApplyResources(this.cameoStatusbar, "cameoStatusbar");
            this.cameoStatusbar.Name = "cameoStatusbar";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // labelRuntime
            // 
            this.labelRuntime.Name = "labelRuntime";
            resources.ApplyResources(this.labelRuntime, "labelRuntime");
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel1);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel2);
            this.flowLayoutPanel4.Controls.Add(this.flowLayoutPanel3);
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // Cameo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.cameoStatusbar);
            this.DoubleBuffered = true;
            this.HelpButton = true;
            this.Name = "Cameo";
            this.cameoTrayMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatmapDisplay)).EndInit();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).EndInit();
            this.cameoStatusbar.ResumeLayout(false);
            this.cameoStatusbar.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon cameoTray;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ContextMenuStrip cameoTrayMenu;
        private System.Windows.Forms.ToolStripMenuItem trayMenuQuit;
        private System.Windows.Forms.ToolStripMenuItem trayMenuLabel;
        private System.Windows.Forms.PictureBox cameraDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox heatmapDisplay;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label CameraSize;
        private System.Windows.Forms.StatusStrip cameoStatusbar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel labelRuntime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label humanCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label averageHumanCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar activityMeter;
        private System.Windows.Forms.Label activityLevelText;
        private System.Windows.Forms.DataVisualization.Charting.Chart humanActivityChart;

    }
}

