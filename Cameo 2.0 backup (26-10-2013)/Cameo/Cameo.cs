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
using System.Timers;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cameo
{
    public partial class Cameo : Form
    {
        private Camera camera;
        //private int humanCounter;
        //private float activityCounter;
        //public float AverageSkeletonCount;
        Bitmap cameraBitmap;

        private System.Timers.Timer secondTimer = new System.Timers.Timer();

        public Cameo()
        {
            InitializeComponent();

            camera = new Camera(this);
            
            CameraSize.Text = "Camera size: "+camera.Width + " x " + camera.Height + " pixels";

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Console.WriteLine("why you non print");
            this.updateUI();
            
            base.OnPaint(e);

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

            
            //activityMeter.Paint += new PaintEventHandler(updateUI);
//            this.Paint += new PaintEventHandler(updateCameo);
        }


        public void updateUI()
        {

            Console.WriteLine("painting");
            int humans = camera.people.getCurrentSkeletonCount();
            float activity = camera.people.getHumanActivity();

            humanCount.Text = humans + " humans";
            Console.WriteLine(humanCount.Text);

            DataPointCollection s = humanActivityChart.Series["Humans"].Points;
            DataPointCollection ss = humanActivityChart.Series["Activity"].Points;

            s.Add(humans);
            ss.Add(activity * humans);

            //In de grafiek wel extreme waardes voor activiteit, maar zorgen dat het niet buiten de bar komt
            if (activity > 1)
                activity = 1;

            activityMeter.Value = (int)(activity * 100);
            activityLevelText.Text = Math.Round(activity,2) + " movements per coffee";
            averageHumanCount.Text =  Math.Round(camera.people.getAverageSkeletonCount(),2) + " humans per minute";

            heatmapDisplay.Image = camera.map.getHeatmap();
            heatmapDisplay.Invalidate();
        }
        /// <summary>
        /// Update the label that represents the of detected humans
        /// </summary>
        /// <param name="count">Amount of humans detected</param>
       // public void UpdateHumans(int count) {
       //     humanCounter = count;
      //      humanCount.Invalidate();
      //  }

    //    public void UpdateHumanActivity(float activity)
     //   {
    //        activityCounter = activity;
            //activityMeter.Invalidate();
   //     }

        /// <summary>
        /// Update the heatmap image with the newly computed heatmap
        /// </summary>
        /// <param name="heatmapBitmap"></param>
     //   public void UpdateHeatMap(Bitmap heatmapBitmap)
  //      {
   //         heatmapDisplay.Image = heatmapBitmap;
 //           heatmapDisplay.Invalidate();
   //     }

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
