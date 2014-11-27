using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Cameo
{
    class QuietPlease
    {
        Cameo cameo;
        Camera camera;

        private Stream audio;

        public QuietPlease(Cameo ca, Camera c)
        {
            this.cameo = ca;
            this.camera = c;

            audio = camera.GetAudioStream();
        }

        public void GetSoundLevel()
        {
           
        }


    }
}
