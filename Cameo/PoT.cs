using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Microsoft.Kinect;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace Cameo
{
    

    class PoT
    {
        private int totalSkelCount = 0;
        private int curSec = 0;

        private int curSkelCount = 0;
        private float averageSkelCount = 0;
        private float humanActivity;
        private List<PointF> humanPositions;

        Dictionary<int, Point3> skelPoints = new Dictionary<int, Point3>();
        float deltaMovement, totalDeltaMovement, averageDeltaMovement = 0;
        //double deltaDistance =0.0D;

        bool intervalPassed = true;

       // Cameo cameo;

        public PoT()
        {
            //cameo = eo;
            humanPositions = new List<PointF>();
        }

        public void recordActivity(object sender, ElapsedEventArgs eea)
        {
            intervalPassed = true;
        }


        /// <summary>
        /// Methode die elke keer als de kinect een skeletonframe heeft word uitgevoerd, slaat simpelweg het aantal skeletons op.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void SensorSkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            
            //string skelposses = "";

            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                if (skeletonFrame != null)
                {

                    

                    Skeleton[] skeletons = new Skeleton[0];

                    int numSkel = 0;
                    
                    skeletons = new Skeleton[skeletonFrame.SkeletonArrayLength];
                    skeletonFrame.CopySkeletonDataTo(skeletons);

                    

                    totalDeltaMovement = 0;

                    //resetten van posities
                    if(intervalPassed)
                        humanPositions = new List<PointF>();


                    foreach (Skeleton sk in skeletons)
                    {

                        if (sk.TrackingId > 0)
                        {
                            //sla tracking posities op
                            if(intervalPassed)
                                humanPositions.Add(new PointF(sk.Position.X,sk.Position.Y, sk.TrackingId));
                            numSkel++;
                            sk.TrackingState = SkeletonTrackingState.PositionOnly;
                            // Console.WriteLine("ID: {0} | pos: {1},{2}",sk.TrackingId,sk.Position.X,sk.Position.Y);
                            //sk.Position.X

                            if (skelPoints.ContainsKey(sk.TrackingId))
                            {
                                //skelposses += sk.Position.X + "," + sk.Position.Y+ " " ;

                                //elke seconde verschil in movement meten
                                if (intervalPassed)
                                {
                                    
                                    deltaMovement = Math.Abs(skelPoints[sk.TrackingId].X - sk.Position.X) + Math.Abs(skelPoints[sk.TrackingId].Y - sk.Position.Y) + Math.Abs(skelPoints[sk.TrackingId].Z - sk.Position.Z);
                                    //deltaDistance = Math.Sqrt(Math.Pow(deltaMovementX,2)+Math.Pow(deltaMovementY,2));
                                    //Console.WriteLine("Verschil voor ID " + sk.TrackingId +": " +deltaMovement);
                                    totalDeltaMovement += deltaMovement;

                                    skelPoints[sk.TrackingId].X = sk.Position.X;
                                    skelPoints[sk.TrackingId].Y = sk.Position.Y;
                                    skelPoints[sk.TrackingId].Z = sk.Position.Z;
                                }
                            }
                            else
                            {
                                skelPoints.Add(sk.TrackingId, new Point3(sk.Position.X, sk.Position.Y, sk.Position.Z));
                            }
                        }
                    }
                    //Console.WriteLine(skelposses);
                    //skelposses = "";


                    curSkelCount = numSkel;

                    if (intervalPassed && curSkelCount > 0)
                    {
                        averageDeltaMovement = totalDeltaMovement / (float)curSkelCount;

                        this.humanActivity = averageDeltaMovement;
                    }

                    if (curSkelCount == 0)
                    {
                        this.humanActivity = 0;
                    }

                    intervalPassed = false;
                }
            }
        }

        public float getHumanActivity()
        {
            return this.humanActivity;
        }

        public int getCurrentSkeletonCount()
        {
            return this.curSkelCount;
        }

        public float getAverageSkeletonCount()
        {
            return this.averageSkelCount;
        }

        /// <summary>
        /// Schrijft het gemiddelde aantal skelletten naar een bestand.
        /// </summary>
        /// <param name="avgSkel"></param>
        private void WriteToFile(float avgSkel) 
        {
            using (System.IO.StreamWriter file = new System.IO.StreamWriter("Cameo.pot",true))
            {
                file.WriteLine("{0},{1}", System.DateTime.Now.ToString("dd/MM/yyyy HH:mm"), Math.Round(avgSkel, 2));
            }
        }

        /// <summary>
        /// Methode die elke seconde word uitgevoerd. Telt voor 60 seconden alles op, neemt daarna het gemiddelde en schrijft dit naar een file
        /// </summary>
        public void recordSkeletons(object sender, ElapsedEventArgs e)
        {
            //resetten en gemiddelde recorden
            if (curSec == 60)
            {
                float avgSkelCount = 0F;

                avgSkelCount = totalSkelCount / 60F;
                curSec = 0;
                totalSkelCount = 0;
                
                System.Console.WriteLine("Gemiddeld {0} skelet(ten) per minuut", avgSkelCount);
               // WriteToFile(avgSkelCount);
                //cameo.AverageSkeletonCount = avgSkelCount;
                this.averageSkelCount = avgSkelCount;
            }
            else
            { //tick opslaan
                curSec++;
                totalSkelCount += curSkelCount;
            }
            //cameo.UpdateHumans(curSkelCount);
     

        //System.Console.WriteLine("{0} sec: {1} skelet(ten)", curSec, curSkelCount);
        }

        /*
         * Geeft de benodigde gegevens voor een grafiek van de afgelopen x aantal minuten
         */
        //public void GetChart()
        //{
        //}

        public List<PointF> getHumanPositions()
        {
            return this.humanPositions;
        }
    }
}
