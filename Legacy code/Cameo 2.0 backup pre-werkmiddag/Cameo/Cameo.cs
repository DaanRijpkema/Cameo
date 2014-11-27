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
using System.IO;

namespace Cameo
{
    public partial class Cameo : Form
    {
        private string defaultSessionName = "NewSession-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        public string sessionName = "-";

        public bool sessionStarted = false; 
        public bool sessionPaused = false;
        

        public static int runTime = 0;
        private Camera camera;
        private KinectSensor kinect;
        private CameoStats cameoStats;

        //private int humanCounter;
        //private float activityCounter;
        //public float AverageSkeletonCount;
        Bitmap cameraBitmap;

        //private System.Timers.Timer secondTimer = new System.Timers.Timer();

        public Cameo()
        {
            
            camera = new Camera(this, kinect);

            InitializeComponent();
            //vind een kinect
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.kinect = potentialSensor;
                    break;
                }
            }

            //is er een kinect?
            if (null != this.kinect)
            {
                CameraSize.Text = "Camera size: " + camera.Width + " x " + camera.Height + " pixels";
            }
            else //geen kinect
            {
                CameraSize.Text = "No camera attached";
                MessageBox.Show("No Kinect attached, please connect a Kinect and check again via the menu.", "Error: no Kinect found", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
               

                /*foreach (ToolStripItem item in cameoToolstrip.Items)
                {
                    item.Enabled = false;
                }
                buttonStart.Enabled = true;
                buttonSave.Enabled = true;
                buttonDocumentation.Enabled = true;*/

                buttonKinectStatus.DisplayStyle = ToolStripItemDisplayStyle.ImageAndText;
                buttonKinectStatus.Enabled = true;

                flowDisplays.Enabled = false;
                humanActivityChart.Visible = false;

            }


            

        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Console.WriteLine("why you non print");
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
            //Console.WriteLine(runTime + " updateUI");
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
            
            runTime++;

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


        #region Session Handling 
        private void startNewSession(bool isReset = false)
        {

            
            if (!isReset)
            {
                string value = defaultSessionName;
                if (InputBox("New session", "New session name:", ref value) == DialogResult.OK)
                {
                    sessionName = value;
                }
            }
            this.Text = "Cameo [" + sessionName + "]";

            labelSession.Text = sessionName + " (running..)";

            sessionStarted = true;
            sessionPaused = false;

            buttonStop.Enabled = true;
            buttonSave.Enabled = true;
            buttonReset.Enabled = true;

            buttonStart.Text = "Pause";
            buttonStart.Image = global::Cameo.Properties.Resources.pause_6x8;

            flowDisplays.Enabled = true;
            humanActivityChart.Visible = true;

        }
        private void stopCurrentSession()
        {
            //Prompten om te saven
            DialogResult promptToSave;
            promptToSave = MessageBox.Show(this, "Do you want to save this session?", "Save session?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (promptToSave == DialogResult.Yes)
            {
                saveCurrentSession();
            }
            else if (promptToSave == DialogResult.No)
            {
                //todo:  sessie afsluiten en data weggooien
                //this.Close(); //gewoon afsluiten
            }
            if (promptToSave != DialogResult.Cancel)
            {
                this.Text = "Cameo [No session]";
                buttonStart.Text = "Start";
                buttonStart.Image = global::Cameo.Properties.Resources.play_6x8;

                sessionStarted = false;
                sessionPaused = false;
                labelSession.Text = "No session";

                buttonStop.Enabled = false;
                buttonReset.Enabled = false;

                flowDisplays.Enabled = false;
                humanActivityChart.Visible = false;
            }


        }
        private void saveCurrentSession()
        {

            SaveFileDialog save = new SaveFileDialog();
            save.FileName = sessionName + ".cameo";
            save.Filter = "Cameo File | *.cameo";
            if (save.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(save.OpenFile());

                writer.WriteLine(sessionName + ":" + DateTime.Now.ToLongDateString() + ":" + DateTime.Now.ToLongTimeString());


                writer.WriteLine("Heatmap:");
                string line = "";
                using (Bitmap bmp = new Bitmap(heatmapDisplay.Image))
                {
                    for (int y = 0; y < heatmapDisplay.Height; y++)
                    {

                        for (int x = 0; x < heatmapDisplay.Width; x++)
                        {
                            line += bmp.GetPixel(x, y).R + ",";
                        }
                        writer.WriteLine(line);
                        line = "";
                    }
                }

                writer.WriteLine("PeopleOverTime:");

                //DataPointCollection ss = humanActivityChart.Series["Activity"].Points;
                foreach (DataPoint point in humanActivityChart.Series["Humans"].Points)
                {
                    writer.WriteLine(point.XValue + ":" + point.YValues[0]);

                    //DateTime time = point.Key;
                    //float value = point.Value;
                }

                //for (int i = 0; i < listBox1.Items.Count; i++)
                //{
                //  writer.WriteLine(listBox1.Items[i].ToString());
                //}
                writer.Dispose();
                writer.Close();


            }
            //MessageBox.Show("Succesfully saved your statistics!", "Save successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //using (System.IO.StreamWriter file = new System.IO.StreamWriter("Cameo.pot", true))
            //{
            //    file.WriteLine("{0},{1}", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Math.Round(avgSkel, 2));
            //}
        }
        #endregion

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

        private void checkKinectStatus_Click(object sender, EventArgs e)
        {
            bool foundKinect = false;
            //vind een kinect
            foreach (var potentialSensor in KinectSensor.KinectSensors)
            {
                if (potentialSensor.Status == KinectStatus.Connected)
                {
                    this.kinect = potentialSensor;
                    foundKinect =true;
                    break;
                }
            }
            if(foundKinect)
            {
                camera.updateKinect(this.kinect);
                CameraSize.Text = "Camera size: " + camera.Width + " x " + camera.Height + " pixels";
                
                flowDisplays.Enabled = true;

                foreach (ToolStripItem item in cameoToolstrip.Items)
                {
                    item.Enabled = true;
                }

                buttonKinectStatus.DisplayStyle = ToolStripItemDisplayStyle.None;
                buttonKinectStatus.Enabled = false;

                humanActivityChart.Visible = true;
            } 
            else 
            {
                MessageBox.Show("There is still no Kinect attached, please (re)connect a Kinect and check again.", "Error: still no Kinect", MessageBoxButtons.OK, MessageBoxIcon.Error); 
            }

        }

        private void buttonDocumentation_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.daanrijpkema.com/cameo");
        }

        private void buttonSaveHeatmap_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.jpg";
            ImageFormat format = ImageFormat.Jpeg;
            sfd.FileName = sessionName + "-heatmap";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                }
                heatmapDisplay.Image.Save(sfd.FileName, format);
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            saveCurrentSession();
        }
       
        private void buttonStart_Click(object sender, EventArgs e)
        {
            //Start new session
            if (!sessionStarted)
            {
                startNewSession();
            }
            else if (sessionPaused) //Resume session
            {
                labelSession.Text = sessionName + " (running..)";

                sessionPaused = false;

                buttonStart.Text = "Pause";
                buttonStart.Image = global::Cameo.Properties.Resources.pause_6x8;
                //todo: timers en sensor stoppen
            }
            else //Pause session
            {
                sessionPaused = true;
                labelSession.Text = sessionName + " (paused)";
                buttonStart.Text = "Resume";
                buttonStart.Image = global::Cameo.Properties.Resources.play_6x8;
                //todo: timers en sensor stoppen
            }
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            stopCurrentSession();
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            stopCurrentSession();
            startNewSession(true);
        }

        private void buttonStats_Click(object sender, EventArgs e)
        {
            //todo: prompt om te saven

            if (cameoStats == null)
            {
                cameoStats = new CameoStats();
                cameoStats.Show();
            }
            else
            {
                cameoStats.Activate();
            }

        }

        #region Text InputBox
        //http://www.csharp-examples.net/inputbox/
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
          Form form = new Form();
          Label label = new Label();
          TextBox textBox = new TextBox();
          Button buttonOk = new Button();
          Button buttonCancel = new Button();

          form.Text = title;
          label.Text = promptText;
          textBox.Text = value;

          buttonOk.Text = "OK";
          buttonCancel.Text = "Cancel";
          buttonOk.DialogResult = DialogResult.OK;
          buttonCancel.DialogResult = DialogResult.Cancel;

          label.SetBounds(9, 20, 372, 13);
          textBox.SetBounds(12, 36, 372, 20);
          buttonOk.SetBounds(228, 72, 75, 23);
          buttonCancel.SetBounds(309, 72, 75, 23);

          label.AutoSize = true;
          textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
          buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
          buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

          form.ClientSize = new Size(396, 107);
          form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
          form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
          form.FormBorderStyle = FormBorderStyle.FixedDialog;
          form.StartPosition = FormStartPosition.CenterScreen;
          form.MinimizeBox = false;
          form.MaximizeBox = false;
          form.AcceptButton = buttonOk;
          form.CancelButton = buttonCancel;

          DialogResult dialogResult = form.ShowDialog();
          value = textBox.Text;
          return dialogResult;
        }
        #endregion
        
        #endregion
    }
}
