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
        private string defaultSessionName = "Session-" + DateTime.Now.Day + "-" + DateTime.Now.Month + "-" + DateTime.Now.Year;
        public string sessionName = "-";

        public bool sessionStarted = false; 
        public bool sessionPaused = false;


        private int prevTime = -1;
        public static int runTime = 0;
        private Camera camera;
        private KinectSensor kinect;
        private CameoStats cameoStats;
        private Graphics trackerGraphics;
        //private int humanCounter;
        //private float activityCounter;
        //public float AverageSkeletonCount;
        Bitmap cameraBitmap;

        //private System.Timers.Timer secondTimer = new System.Timers.Timer();

        public Cameo()
        {

            this.FormClosing += new FormClosingEventHandler(Cameo_FormClosing);

            InitializeComponent();
            trackerGraphics = trackerDisplay.CreateGraphics();

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
                camera = new Camera(this, kinect);
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

        void Cameo_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sessionStarted)
                stopCurrentSession();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //Console.WriteLine("why you non print");
            if (prevTime < runTime && kinect!=null)
            {
                this.updateUI();
                prevTime = runTime;
            }
            
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
            int humans = camera.people.getCurrentSkeletonCount();
            float activity = camera.people.getHumanActivity();
            List<PointF> positions = camera.people.getHumanPositions();
            //labelSession.Text = camera.people.getHumanPositions().Count.ToString();
            
                
            
            //Point p = camera.people.getHumanPosition();
            /*string res = "";
            for (int i = 0; i < positions.Count; i++)
			{
			    res+=positions[i].X+","+positions[i].Y+" ";
			}
            Console.WriteLine(res);*/
            //Console.WriteLine(humanCount.Text);

            DataPointCollection s = humanActivityChart.Series["Humans"].Points;
            DataPointCollection ss = humanActivityChart.Series["Activity"].Points;

            s.AddXY(runTime,humans);
            ss.AddXY(runTime ,activity * humans);


            //In de grafiek wel extreme waardes voor activiteit, maar zorgen dat het niet buiten de bar komt
            if (activity > 1)
                activity = 1;

            activityMeter.Value = (int)(activity * 100);
            activityLevelText.Text = Math.Round(activity,2) + "% movement levels";
            averageHumanCount.Text =  Math.Round(camera.people.getAverageSkeletonCount(),2) + " humans per minute";
            humanCount.Text = camera.people.getCurrentSkeletonCount() + " humans";

            heatmapDisplay.Image = camera.map.getHeatmap();
            
            
            //if(positions.Count>0)
            //{
            //   // e.Graphics.DrawRectangle(Pens.Black, positions[0].X, positions[0].Y, 20, 20);
            //    Console.WriteLine(" yo" );
            //}
            //if (positions.Count > 0)
                //trackerDisplay.BackColor = Color.Beige;

            
            trackerGraphics.FillRectangle(Brushes.Black, 0, 0, trackerDisplay.Width, trackerDisplay.Height);

            if (positions.Count > 0)
            {
                //Console.WriteLine(positions[0].X + "," + positions[0].Y);

                

                for (int i = 0; i < positions.Count; i++)
                {
                    float pX = ((positions[i].X) * (trackerDisplay.Width / 2)) + (trackerDisplay.Width / 2);
                    float pY = (-positions[i].Y * (trackerDisplay.Height / 2)) + (trackerDisplay.Height / 2);
                    //Console.WriteLine(((positions[i].X) * (trackerDisplay.Width / 2)) + (trackerDisplay.Width / 2) + "," + (positions[i].Y * (trackerDisplay.Height / 2)) + (trackerDisplay.Height / 2));
                    trackerGraphics.FillEllipse(getPositionBrush(i), pX,pY , 32, 32);
                    trackerGraphics.DrawString("ID:" + positions[i].id, new Font("Arial", 11), Brushes.White, pX+25,pY+25);
                    trackerGraphics.DrawString("[" + Math.Round(pX,1)+","+Math.Round(pY,1)+"]", new Font("Arial", 8), Brushes.White, pX + 25, pY + 45);
                }
                
            }
                //position1.Text = positions[0].X.ToString();
            //else
              //  trackerDisplay.BackColor = Color.Pink;

            int seconds, minutes, hours;

            seconds = runTime % 60;
            minutes = (runTime % 3600) /60;
            hours = runTime / 3600;

            string secondS, minuteS;

            if (seconds < 10)
                secondS = "0" + seconds;
            else
                secondS = seconds.ToString();

            if (minutes < 10)
                minuteS = "0" + minutes;
            else
                minuteS = minutes.ToString();


            labelRuntime.Text = hours + ":" + minuteS + ":" + secondS; 
            labelRuntime1.Text = hours + ":" + minuteS + ":" + secondS;
       }


        public Brush getPositionBrush(int i)
        {
            switch (i)
            {
                case 0: return Brushes.Red;
                case 1: return Brushes.Blue;
                case 2: return Brushes.Yellow;
                case 3: return Brushes.Orange;
                case 4: return Brushes.Pink;
                case 5: return Brushes.Green;
                case 6: return Brushes.Gold;
                case 7: return Brushes.Teal;
                case 8: return Brushes.Cyan;
                case 9: return Brushes.Magenta;
                case 10: return Brushes.Purple;
                default: return Brushes.Red;
            }
        }
// public void UpdateHumans(int count) {
//     humanCounter = count;
//      humanCount.Invalidate();
//  }

//    public void UpdateHumanActivity(float activity)
//   {
//        activityCounter = activity;
//activityMeter.Invalidate();
//     }

       
/// <param name="heatmapBitmap"></param>
//   public void UpdateHeatMap(Bitmap heatmapBitmap)
//      {
//         heatmapDisplay.Image = heatmapBitmap;
//           heatmapDisplay.Invalidate();
//     }
        private void emptyCharts()
        {
            humanActivityChart.Series["Humans"].Points.Clear();
            humanActivityChart.Series["Activity"].Points.Clear();
        }


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
                if (InputBox("New session", "Type a new descriptive session name:", ref value) == DialogResult.OK)
                    sessionName = value;

                MessageBox.Show("Make sure that the room is as empty as possible to ensure proper default readings and heatmap generation. As soon as the heatmap is displayed in the interface you can use the room.", "Preparations", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Text = "Cameo [" + sessionName + "]";

            labelSession.Text = sessionName + " (running..)";
            labelSessionInfo.Text = sessionName + " is running.";

            sessionStarted = true;
            sessionPaused = false;

            buttonStop.Enabled = true;
            buttonSave.Enabled = true;
            buttonReset.Enabled = true;

            buttonStart.Text = "Pause";
            buttonStart.Image = global::Cameo.Properties.Resources.pause_6x8;

            flowDisplays.Enabled = true;
            humanActivityChart.Visible = true;

            camera.StartSession();
            
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
                cameraDisplay.Image = global::Cameo.Properties.Resources.icon128;
                cameraDisplay.Invalidate();

                camera.RemoveSession();
                camera = new Camera(this, kinect);

                emptyCharts();

                this.Text = "Cameo [No session]";
                buttonStart.Text = "Start";
                buttonStart.Image = global::Cameo.Properties.Resources.play_6x8;

                sessionStarted = false;
                sessionPaused = false;
                labelSession.Text = "No session";
                labelSessionInfo.Text = "No session running.";

                buttonStop.Enabled = false;
                buttonReset.Enabled = false;

                flowDisplays.Enabled = false;
                humanActivityChart.Visible = false;

                buttonStartBig.Enabled = true;

                runTime = 0;
                prevTime = -1;
                this.Invalidate();
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

                //metadata
                writer.WriteLine(sessionName); 
                writer.WriteLine(DateTime.Now.ToLongDateString() + " " + DateTime.Now.ToLongTimeString());
                writer.WriteLine(runTime);

                //heatmap
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

                //whitespace
                writer.WriteLine();
                
                //HumansOverTime - data
                foreach (DataPoint point in humanActivityChart.Series["Humans"].Points)
                {
                    writer.WriteLine(point.XValue + ":" + point.YValues[0]);
                }

                //ActivityOverTime - data

                foreach (DataPoint point in humanActivityChart.Series["Activity"].Points)
                {
                    writer.WriteLine(point.XValue + ":" + point.YValues[0]);

                }

                writer.Dispose();
                writer.Close();


            }
        }
        #endregion

        #region UI events
        private void cameoTrayClickItem(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "Quit Cameo":
                    if(sessionStarted)
                        stopCurrentSession();
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
        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Images|*.jpg";
            ImageFormat format = ImageFormat.Jpeg;
            sfd.FileName = sessionName + "-chart";
            if (sfd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName);
                switch (ext)
                {
                    case ".jpg":
                        format = ImageFormat.Jpeg;
                        break;
                }
                humanActivityChart.BackColor = Color.White;
                humanActivityChart.SaveImage(sfd.FileName, format);
                humanActivityChart.BackColor = Color.Transparent;
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
                labelSessionInfo.Text = sessionName + " is running..";
                camera.ResumeSession();

                sessionPaused = false;

                buttonStart.Text = "Pause";
                buttonStart.Image = global::Cameo.Properties.Resources.pause_6x8;
                //todo: timers en sensor stoppen
            }
            else //Pause session
            {
                camera.PauzeSession();
                

                sessionPaused = true;
                labelSession.Text = sessionName + " (paused)";
                labelSessionInfo.Text = sessionName + "  is paused.";
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

        private void buttonStartBig_Click(object sender, EventArgs e)
        {
            buttonStartBig.Enabled = false;
            buttonStart_Click(sender, e);
        }
        
        #endregion
    }
}
