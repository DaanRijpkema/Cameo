using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cameo
{
    public partial class CameoStats : Form
    {

        private string sessionTitle = "";
        private string sessionDate = "";
        private int sessionDuration = 0;

        private int[] heatmap;
        private Bitmap bitmapHeatmap;


        public CameoStats()
        {
            InitializeComponent();
            buttonOpen_Click(this, new EventArgs());
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Cameo files|*.cameo";
            ofd.Title = "Select a Cameo file";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                heatmap = new int[200000];
                bitmapHeatmap = new Bitmap(360, 280);

                humanActivityChart.Series["Humans"].Points.Clear();
                humanActivityChart.Series["Activity"].Points.Clear();

                StreamReader sr = new StreamReader(ofd.FileName);

                sessionTitle = sr.ReadLine();
                sessionDate = sr.ReadLine();
                sessionDuration = int.Parse(sr.ReadLine());

                labelSessionDate.Text = sessionDate;
                labelSessionTitle.Text = sessionTitle;
                
                //duur goed neerzetten
                int seconds, minutes, hours;

                seconds = sessionDuration % 60;
                minutes = (sessionDuration % 3600) / 60;
                hours = sessionDuration / 3600;

                string secondS, minuteS;

                if (seconds < 10)
                    secondS = "0" + seconds;
                else
                    secondS = seconds.ToString();

                if (minutes < 10)
                    minuteS = "0" + minutes;
                else
                    minuteS = minutes.ToString();
                labelSessionDuration.Text = hours + ":" + minuteS + ":" + secondS;

                //uitlezen heatmap
                int i=0;
                string inputline;
                while ((inputline = sr.ReadLine()) != "")
                {
                    foreach(string x in inputline.Split(',')) 
                    {
                        if (x != "")
                        {
                            heatmap[i] = int.Parse(x);
                            i++;
                        }
                    }
                }

                int sumHumans = 0;
                float sumActivity = 0F;
                float sumSound = 0F;


                //sr.ReadLine();
                DataPointCollection humanPlot = humanActivityChart.Series["Humans"].Points;
                DataPointCollection activityPlot = humanActivityChart.Series["Activity"].Points;
                DataPointCollection soundPlot = humanActivityChart.Series["Sound"].Points;

                string[] point;
                //uitlezen human counts
                while ((inputline = sr.ReadLine()) != "" && inputline != null)
                {
                    point = inputline.Split(':');
                    humanPlot.AddXY(int.Parse(point[0]), int.Parse(point[1]));
                    sumHumans += int.Parse(point[1]);
                }

                //uitlezen activity counts
                while ((inputline = sr.ReadLine()) != "" && inputline != null)
                {
                    point = inputline.Split(':');
                    activityPlot.AddXY(int.Parse(point[0]), float.Parse(point[1]));
                    sumActivity += float.Parse(point[1]);
                }

                //uitlezen sound levels
                while ((inputline = sr.ReadLine()) != "" && inputline != null)
                {
                    point = inputline.Split(':');
                    soundPlot.AddXY(int.Parse(point[0]), float.Parse(point[1]));
                    sumSound += float.Parse(point[1]);
                }
            
                drawHeatmap();

                sr.Close();

                //stats berekenen
                labelAverageHuman.Text = Math.Round(((float)sumHumans / (float)sessionDuration),2) + " humans on average";
                labelAverageActivity.Text = Math.Round((sumActivity / sessionDuration),2) + " activity level on average";
                labelAverageSoundLevel.Text = Math.Round((sumSound / sessionDuration),2) + " sound level on average";
            }
        }

        private void drawHeatmap()
        {
            Console.WriteLine("bitmap van "+bitmapHeatmap.Width+" x "+bitmapHeatmap.Height);
            for (int x = 0; x < bitmapHeatmap.Width; x++)
            {
                for (int y = 0; y < bitmapHeatmap.Height; y++)
                {
                    int pixelValue = (int)(heatmap[x + y * bitmapHeatmap.Width]);
                    bitmapHeatmap.SetPixel(x, y, System.Drawing.Color.FromArgb(pixelValue, pixelValue, pixelValue));
                }
            }
            displayHeatmap.Image = bitmapHeatmap;
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
