using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cameo
{
    public partial class Cameo : Form
    {
        private Camera camera;
        private int humanCounter;
        private float activityCounter;
        public float AverageSkeletonCount;
        Bitmap cameraBitmap;


        public Cameo()
        {
            InitializeComponent();

            camera = new Camera(this);
            
            CameraSize.Text = "Camera size: "+camera.Width + " x " + camera.Height + " pixels";


        }




        public void colorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            ColorImageFrame colorFrame = e.OpenColorImageFrame();
            
            if (colorFrame == null)
            {
                return;
            }

            cameraBitmap = ColorImageFrameToBitmap(colorFrame);

            cameraDisplay.Image = cameraBitmap;
            cameraDisplay.Invalidate();
            humanCount.Paint += new PaintEventHandler(updateUI);
            
            //activityMeter.Paint += new PaintEventHandler(updateUI);
//            this.Paint += new PaintEventHandler(updateCameo);
        }


        void updateUI(object sender, PaintEventArgs e)
        {
            humanCount.Text = humanCounter + " humans";

            DataPointCollection s = humanActivityChart.Series["Humans"].Points;
            DataPointCollection ss = humanActivityChart.Series["Activity"].Points;

            s.Add(humanCounter);
            ss.Add(activityCounter * humanCounter);

          //  if (s.Count > 5)
          //  {
           //     s.Remove(s.First());
           //     ss.Remove(ss.First());
            //}

          
            
            if (activityCounter > 1)
                activityCounter = 1;

            activityMeter.Value = (int)(activityCounter * 100);
            activityLevelText.Text = Math.Round(activityCounter,2) + " movements per coffee";
            averageHumanCount.Text =  Math.Round(AverageSkeletonCount,2) + " humans per minute";
            
        }
        /// <summary>
        /// Update the label that represents the of detected humans
        /// </summary>
        /// <param name="count">Amount of humans detected</param>
        public void UpdateHumans(int count) {
            humanCounter = count;
            humanCount.Invalidate();
        }

        public void UpdateHumanActivity(float activity)
        {
            activityCounter = activity;
            //activityMeter.Invalidate();
        }

        /// <summary>
        /// Update the heatmap image with the newly computed heatmap
        /// </summary>
        /// <param name="heatmapBitmap"></param>
        public void UpdateHeatMap(Bitmap heatmapBitmap)
        {
            heatmapDisplay.Image = heatmapBitmap;
            heatmapDisplay.Invalidate();
        }

        /// <summary>
        /// Transform a ColorImageFrame to a Bitmap
        /// </summary>
        /// <param name="colorFrame">ColorImageFrame to convert</param>
        /// <returns></returns>
        private static Bitmap ColorImageFrameToBitmap(ColorImageFrame colorFrame)
        {
            byte[] pixelBuffer = new byte[colorFrame.PixelDataLength];
            colorFrame.CopyPixelDataTo(pixelBuffer);


            Bitmap bitmapFrame = new Bitmap(colorFrame.Width, colorFrame.Height,
                PixelFormat.Format32bppRgb);


            BitmapData bitmapData = bitmapFrame.LockBits(new Rectangle(0, 0,
                                             colorFrame.Width, colorFrame.Height),
            ImageLockMode.WriteOnly, bitmapFrame.PixelFormat);


            IntPtr intPointer = bitmapData.Scan0;
            Marshal.Copy(pixelBuffer, 0, intPointer, colorFrame.PixelDataLength);


            bitmapFrame.UnlockBits(bitmapData);


            return bitmapFrame;
        }

        #region UI events
        private void cameoTrayClickItem(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Quit Cameo":
                    this.Close();
                    break;
                default:
                    break;
            }

        }

        #endregion

    }
}
