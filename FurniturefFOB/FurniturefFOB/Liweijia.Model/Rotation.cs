using System;

namespace FurniturefFOB
{
    [Serializable]
    public class Rotation
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Rotation(double x1, double y1, double z1)
        {
            this.x = x1;
            this.y = y1;
            this.z = z1;
        }
        public Rotation()
        {
            this.x = 0;
            this.y = 0;
            this.z = 0;
        }
    }
}
