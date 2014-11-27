using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cameo
{
    struct PointF
    {
        public float X, Y, id;
        public PointF(float x, float y, int id)
        {
            this.X = x;
            this.Y = y;
            this.id = id;
        }
    }
}
