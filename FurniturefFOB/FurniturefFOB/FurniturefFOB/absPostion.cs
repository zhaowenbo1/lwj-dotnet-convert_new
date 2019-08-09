using System;
using System.Collections.Generic;
using System.Text;

namespace FurniturefFOB
{
    [Serializable]
    public class absPostion
    {
        public double x { get; set; }
         public double y { get; set; }
         public double z { get; set; }
        public absPostion(double x1,double y1,double z1)
        {
            this.x = x1;
            this.y = y1;
            this.z = z1;
        }
        public absPostion()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }

    }
}
