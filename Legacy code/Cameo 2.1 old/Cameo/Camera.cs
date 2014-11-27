using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Timers;
using System.IO;

namespace Cameo
{
    class Camera
    {
        private KinectSensor sensor;
        private Timer secondTimer = new Timer();
        private Timer halfSecondTimer = new Timer();

        public PoT people;
        public Heatmap map;

        private Cameo cameo;

        public int Height = 480;
        public int Width = 640;

        public Camera(Cameo eo, KinectSensor s)
        {
            cameo = eo;

            sensor = s;

            map = new Heatmap(Width, Height);
            people = new PoT();

            if (null != this.sensor)
            {
                // Turn on the skeleton and depth stream to receive skeleton frames
                this.sensor.SkeletonStream.Enable();
                this.sensor.DepthStream.Enable(DepthImageFormat.Resolution640x480Fps30);
                this.sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            }
        }

        public void StartSession()
        {
            // Add an event handler to be called whenever there is new color frame data
            this.sensor.SkeletonFrameReady += people.SensorSkeletonFrameReady;
            this.sensor.DepthFrameReady += map.depthFrameReady;
            this.sensor.ColorFrameReady += cameo.colorFrameReady;

            // Start the sensor!
            try
            {
                this.sensor.Start();
                secondTimer.Interval = 2000D;
                halfSecondTimer.Interval = 500D;
                secondTimer.Elapsed += new ElapsedEventHandler(people.recordSkeletons);
                secondTimer.Elapsed += new ElapsedEventHandler(map.heatTimeTick);
                secondTimer.Elapsed += this.inval;
                halfSecondTimer.Elapsed += new ElapsedEventHandler(people.recordActivity);
                secondTimer.Start();
                halfSecondTimer.Start();
            }
            catch (IOException)
            {
                //Kinect in use by something else.
                Console.WriteLine("No Kinect Found");
                this.sensor = null;
            }
        }

        public void PauzeSession()
        {
            this.sensor.SkeletonFrameReady -= people.SensorSkeletonFrameReady;
            this.sensor.DepthFrameReady -= map.depthFrameReady;
            this.sensor.ColorFrameReady -= cameo.colorFrameReady;

            secondTimer.Elapsed -= new ElapsedEventHandler(people.recordSkeletons);
            secondTimer.Elapsed -= new ElapsedEventHandler(map.heatTimeTick);
            secondTimer.Elapsed -= this.inval;
            halfSecondTimer.Elapsed -= new ElapsedEventHandler(people.recordActivity);

        }

        public void ResumeSession()
        {
            this.sensor.SkeletonFrameReady += people.SensorSkeletonFrameReady;
            this.sensor.DepthFrameReady += map.depthFrameReady;
            this.sensor.ColorFrameReady += cameo.colorFrameReady;

            secondTimer.Elapsed += new ElapsedEventHandler(people.recordSkeletons);
            secondTimer.Elapsed += new ElapsedEventHandler(map.heatTimeTick);
            secondTimer.Elapsed += this.inval;
            halfSecondTimer.Elapsed += new ElapsedEventHandler(people.recordActivity);
        }

        public void RemoveSession()
        {
            PauzeSession();
        }

        private void inval(Object o, EventArgs e)
        {
            Cameo.runTime++;
            cameo.Invalidate();
        }

        public Stream GetAudioStream()
        {
            return this.sensor.AudioSource.Start();
        }


        internal void updateKinect(KinectSensor kinectSensor)
        {
            this.sensor = kinectSensor;
        }
    }
}
