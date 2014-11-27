using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using System.Threading;

namespace Cameo
{
    class QuietPlease
    {
        private float volume = 0;

        Thread readingThread;
        Stream audioStream;
        volatile bool reading = true;

        private byte[] audioBuffer = new byte[50 * 16 * 2];

        public QuietPlease(Stream s)
        {
            audioStream = s;
            this.readingThread = new Thread(AudioReadingThread);
            this.readingThread.Start();
        }


        private void AudioReadingThread()
        {

            while (this.reading)
            {

                int readCount = audioStream.Read(audioBuffer, 0, audioBuffer.Length);

                long totalSquare = 0;
                for (int i = 0; i < audioBuffer.Length; i += 2)
                {
                    if (reading == false)
                        break;

                    short sample = (short)(audioBuffer[i] | (audioBuffer[i + 1] << 8));
                    totalSquare += sample * sample;
                }
                long meanSquare = 2 * totalSquare / audioBuffer.Length;
                double rms = Math.Sqrt(meanSquare);
                volume = (float)(rms / 32768.0);

            }

        }

        public float getVolume()
        {
            return volume;
        }

        public void stopSound()
        {
            reading = false;
            try
            {
                readingThread.Abort();
            }
            catch (Exception e)
            {
                ;//do nothing, nodig omdat hij wacht tot hij de buffer gevuld heeft (nooit als de stream stopt)
            }
        }

        public void Pause()
        {
            readingThread.Suspend();
        }

        public void Resume()
        {
            readingThread.Resume();
        }
    }



}
