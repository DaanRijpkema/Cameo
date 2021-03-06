﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using System.Timers;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace Cameo
{
    class Heatmap
    {
        private bool defaultDepthGenerated = false;
        private bool secondPassed = false;
        private int avgFrameCount = 10;
        private int currentFrameCount = 0;

        private DepthImagePixel[] defaultDepth, currentDepth = null;

        private int[] heat;
        private int maxheat;

        private Bitmap bitmapFrame;

        private int width, height;

        public Heatmap(int w, int h)
        {
            width = w;
            height = h;

            bitmapFrame = new Bitmap(width, height);
        }

        public void heatTimeTick(object sender, ElapsedEventArgs e)
        {
            secondPassed = true;
        }

        public void depthFrameReady(object sender, DepthImageFrameReadyEventArgs e)
        {
            if (secondPassed)
            {
                using (DepthImageFrame depthFrame = e.OpenDepthImageFrame())
                {
                    if (depthFrame != null)
                    {
                        //First pass
                        if (defaultDepth == null)
                        {
                            defaultDepth = currentDepth = new DepthImagePixel[depthFrame.PixelDataLength];
                            heat = new int[depthFrame.Width * depthFrame.Height];
                        }

                        if (currentFrameCount == avgFrameCount)
                        {


                            if (defaultDepthGenerated)
                            {
                                //vergelijk
                                for (int i = 0; i < defaultDepth.Length; i++)
                                {
                                    //Vanaf 100 milimeter dichter bij heat genereren.
                                    if (defaultDepth[i].IsKnownDepth && 
                                        currentDepth[i].IsKnownDepth && 
                                        currentDepth[i].Depth > 1000 &&
                                        currentDepth[i].Depth < (defaultDepth[i].Depth - 100))
                                    {
                                        heat[i] += 10;
                                        if (heat[i] > maxheat)
                                            maxheat = heat[i];
                                    }
                                }

                                resetcurrentframe(depthFrame.PixelDataLength);
                                secondPassed = false;

                                drawHeatmap();
                            }
                            else
                            {
                                defaultDepth = (DepthImagePixel[])currentDepth.Clone();
                                resetcurrentframe(depthFrame.PixelDataLength);
                                
                                defaultDepthGenerated = true;
                                //Console.WriteLine(" Default klaar" );
                                secondPassed = false;
                            }

                            currentFrameCount = 0;
                        }
                        else
                        {
                            DepthImagePixel[] tempDepth = new DepthImagePixel[depthFrame.PixelDataLength];

                            depthFrame.CopyDepthImagePixelDataTo(tempDepth);

                            for (int i = 0; i < tempDepth.Length; i++)
                            {
                                if (tempDepth[i].IsKnownDepth)
                                {
                                    currentDepth[i].Depth += (short)(tempDepth[i].Depth / avgFrameCount);
                             
                                }
                            }      

                            currentFrameCount++;
                        }
                    }
                }
            }
        }

        private void resetcurrentframe(int pixelarraylength)
        {
            currentDepth = new DepthImagePixel[pixelarraylength];
        }

        private void drawHeatmap()
        {
            float factor = 255F / (float)maxheat;
            //Console.WriteLine(factor);

            for (int x = 0; x < bitmapFrame.Width; x++)
            {
                for (int y = 0; y < bitmapFrame.Height; y++)
                {
                    int pixelValue = (int)(heat[x + y * width] * factor);
                    bitmapFrame.SetPixel(x, y, System.Drawing.Color.FromArgb(pixelValue,pixelValue, pixelValue));
                }

            }

           // cameo.UpdateHeatMap(bitmapFrame);
        }

        public Bitmap getHeatmap()
        {
            return this.bitmapFrame;
        }

        //Bitmap DepthToBitmap(DepthImageFrame imageFrame)
        //{
        //    short[] pixelData = new short[imageFrame.PixelDataLength];
        //    imageFrame.CopyPixelDataTo(pixelData);

        //    Bitmap bmap = new Bitmap(
        //    imageFrame.Width,
        //    imageFrame.Height,
        //    PixelFormat.Format16bppRgb555);

        //    BitmapData bmapdata = bmap.LockBits(
        //     new Rectangle(0, 0, imageFrame.Width,
        //                            imageFrame.Height),
        //     ImageLockMode.WriteOnly,
        //     bmap.PixelFormat);
        //    IntPtr ptr = bmapdata.Scan0;
        //    Marshal.Copy(pixelData,
        //     0,
        //     ptr,
        //     imageFrame.Width *
        //       imageFrame.Height);
        //    bmap.UnlockBits(bmapdata);
        //    return bmap;
        //}
    }
}
