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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series7 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series8 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.cameoTray = new System.Windows.Forms.NotifyIcon(this.components);
            this.cameoTrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuLabel = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonSaveHeatmap = new System.Windows.Forms.Button();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.humanCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.averageHumanCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.activityMeter = new System.Windows.Forms.ProgressBar();
            this.activityLevelText = new System.Windows.Forms.Label();
            this.humanActivityChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cameoStatusbar = new System.Windows.Forms.StatusStrip();
            this.CameraSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.flowDisplays = new System.Windows.Forms.FlowLayoutPanel();
            this.cameoToolstrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.buttonStart = new System.Windows.Forms.ToolStripButton();
            this.buttonSave = new System.Windows.Forms.ToolStripButton();
            this.buttonStop = new System.Windows.Forms.ToolStripButton();
            this.buttonReset = new System.Windows.Forms.ToolStripButton();
            this.buttonStats = new System.Windows.Forms.ToolStripButton();
            this.buttonSettings = new System.Windows.Forms.ToolStripButton();
            this.buttonDocumentation = new System.Windows.Forms.ToolStripButton();
            this.buttonKinectStatus = new System.Windows.Forms.ToolStripButton();
            this.cameraDisplay = new System.Windows.Forms.PictureBox();
            this.heatmapDisplay = new System.Windows.Forms.PictureBox();
            this.trackerDisplay = new System.Windows.Forms.PictureBox();
            this.labelSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelRuntime = new System.Windows.Forms.ToolStripStatusLabel();
            this.cameoTrayMenu.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).BeginInit();
            this.cameoStatusbar.SuspendLayout();
            this.flowDisplays.SuspendLayout();
            this.cameoToolstrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatmapDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackerDisplay)).BeginInit();
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
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.label2);
            this.flowLayoutPanel2.Controls.Add(this.heatmapDisplay);
            this.flowLayoutPanel2.Controls.Add(this.buttonSaveHeatmap);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // buttonSaveHeatmap
            // 
            resources.ApplyResources(this.buttonSaveHeatmap, "buttonSaveHeatmap");
            this.buttonSaveHeatmap.Name = "buttonSaveHeatmap";
            this.buttonSaveHeatmap.UseVisualStyleBackColor = true;
            this.buttonSaveHeatmap.Click += new System.EventHandler(this.buttonSaveHeatmap_Click);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.label3);
            this.flowLayoutPanel3.Controls.Add(this.trackerDisplay);
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
            this.humanActivityChart.BackColor = System.Drawing.Color.Transparent;
            this.humanActivityChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea4.Name = "ChartArea1";
            this.humanActivityChart.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.humanActivityChart.Legends.Add(legend4);
            resources.ApplyResources(this.humanActivityChart, "humanActivityChart");
            this.humanActivityChart.Name = "humanActivityChart";
            this.humanActivityChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series7.ChartArea = "ChartArea1";
            series7.IsXValueIndexed = true;
            series7.Legend = "Legend1";
            series7.Name = "Humans";
            series7.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series8.ChartArea = "ChartArea1";
            series8.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series8.IsXValueIndexed = true;
            series8.Legend = "Legend1";
            series8.Name = "Activity";
            series8.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            series8.YValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Int32;
            this.humanActivityChart.Series.Add(series7);
            this.humanActivityChart.Series.Add(series8);
            // 
            // cameoStatusbar
            // 
            this.cameoStatusbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelSession,
            this.labelRuntime,
            this.CameraSize});
            resources.ApplyResources(this.cameoStatusbar, "cameoStatusbar");
            this.cameoStatusbar.Name = "cameoStatusbar";
            // 
            // CameraSize
            // 
            this.CameraSize.Name = "CameraSize";
            resources.ApplyResources(this.CameraSize, "CameraSize");
            // 
            // flowDisplays
            // 
            this.flowDisplays.Controls.Add(this.flowLayoutPanel1);
            this.flowDisplays.Controls.Add(this.flowLayoutPanel2);
            this.flowDisplays.Controls.Add(this.flowLayoutPanel3);
            resources.ApplyResources(this.flowDisplays, "flowDisplays");
            this.flowDisplays.Name = "flowDisplays";
            // 
            // cameoToolstrip
            // 
            this.cameoToolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.buttonStart,
            this.buttonSave,
            this.buttonStop,
            this.buttonReset,
            this.toolStripSeparator1,
            this.buttonStats,
            this.toolStripSeparator2,
            this.buttonSettings,
            this.buttonDocumentation,
            this.buttonKinectStatus});
            this.cameoToolstrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            resources.ApplyResources(this.cameoToolstrip, "cameoToolstrip");
            this.cameoToolstrip.Name = "cameoToolstrip";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            resources.ApplyResources(this.toolStripLabel1, "toolStripLabel1");
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // buttonStart
            // 
            resources.ApplyResources(this.buttonStart, "buttonStart");
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSave
            // 
            resources.ApplyResources(this.buttonSave, "buttonSave");
            this.buttonSave.Image = global::Cameo.Properties.Resources.folder_fill_8x8;
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonStop
            // 
            resources.ApplyResources(this.buttonStop, "buttonStop");
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonStats
            // 
            this.buttonStats.Image = global::Cameo.Properties.Resources.bars_8x8;
            resources.ApplyResources(this.buttonStats, "buttonStats");
            this.buttonStats.Name = "buttonStats";
            this.buttonStats.Click += new System.EventHandler(this.buttonStats_Click);
            // 
            // buttonSettings
            // 
            resources.ApplyResources(this.buttonSettings, "buttonSettings");
            this.buttonSettings.Name = "buttonSettings";
            // 
            // buttonDocumentation
            // 
            this.buttonDocumentation.Image = global::Cameo.Properties.Resources.info_4x8;
            resources.ApplyResources(this.buttonDocumentation, "buttonDocumentation");
            this.buttonDocumentation.Name = "buttonDocumentation";
            this.buttonDocumentation.Click += new System.EventHandler(this.buttonDocumentation_Click);
            // 
            // buttonKinectStatus
            // 
            this.buttonKinectStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.None;
            resources.ApplyResources(this.buttonKinectStatus, "buttonKinectStatus");
            this.buttonKinectStatus.Name = "buttonKinectStatus";
            this.buttonKinectStatus.Click += new System.EventHandler(this.checkKinectStatus_Click);
            // 
            // cameraDisplay
            // 
            this.cameraDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.cameraDisplay, "cameraDisplay");
            this.cameraDisplay.Name = "cameraDisplay";
            this.cameraDisplay.TabStop = false;
            // 
            // heatmapDisplay
            // 
            this.heatmapDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.heatmapDisplay, "heatmapDisplay");
            this.heatmapDisplay.Name = "heatmapDisplay";
            this.heatmapDisplay.TabStop = false;
            // 
            // trackerDisplay
            // 
            this.trackerDisplay.BackColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.trackerDisplay, "trackerDisplay");
            this.trackerDisplay.Name = "trackerDisplay";
            this.trackerDisplay.TabStop = false;
            // 
            // labelSession
            // 
            this.labelSession.Image = global::Cameo.Properties.Resources.tag_fill_8x8;
            resources.ApplyResources(this.labelSession, "labelSession");
            this.labelSession.Margin = new System.Windows.Forms.Padding(5, 3, 0, 2);
            this.labelSession.Name = "labelSession";
            // 
            // labelRuntime
            // 
            resources.ApplyResources(this.labelRuntime, "labelRuntime");
            this.labelRuntime.Margin = new System.Windows.Forms.Padding(5, 3, 7, 2);
            this.labelRuntime.Name = "labelRuntime";
            // 
            // Cameo
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cameoToolstrip);
            this.Controls.Add(this.flowDisplays);
            this.Controls.Add(this.cameoStatusbar);
            this.HelpButton = true;
            this.Name = "Cameo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.cameoTrayMenu.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.humanActivityChart)).EndInit();
            this.cameoStatusbar.ResumeLayout(false);
            this.cameoStatusbar.PerformLayout();
            this.flowDisplays.ResumeLayout(false);
            this.cameoToolstrip.ResumeLayout(false);
            this.cameoToolstrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cameraDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heatmapDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackerDisplay)).EndInit();
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
        private System.Windows.Forms.PictureBox trackerDisplay;
        private System.Windows.Forms.StatusStrip cameoStatusbar;
        private System.Windows.Forms.FlowLayoutPanel flowDisplays;
        private System.Windows.Forms.ToolStripStatusLabel labelRuntime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label humanCount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label averageHumanCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ProgressBar activityMeter;
        private System.Windows.Forms.Label activityLevelText;
        private System.Windows.Forms.DataVisualization.Charting.Chart humanActivityChart;
        private System.Windows.Forms.ToolStrip cameoToolstrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton buttonStart;
        private System.Windows.Forms.ToolStripButton buttonStop;
        private System.Windows.Forms.ToolStripButton buttonReset;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton buttonStats;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton buttonSettings;
        private System.Windows.Forms.ToolStripButton buttonKinectStatus;
        private System.Windows.Forms.ToolStripStatusLabel CameraSize;
        private System.Windows.Forms.ToolStripButton buttonDocumentation;
        private System.Windows.Forms.ToolStripStatusLabel labelSession;
        private System.Windows.Forms.Button buttonSaveHeatmap;
        private System.Windows.Forms.ToolStripButton buttonSave;

    }
}

