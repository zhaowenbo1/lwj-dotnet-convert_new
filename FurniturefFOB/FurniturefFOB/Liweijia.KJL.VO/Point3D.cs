namespace FurniturefFOB
{
    public class Point3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Point3D(double _x, double _y, double _z)
        {
            this.x = _x;
            this.y = _y;
            this.z = _z;
        }
        public Point3D()
        { }
    }
}
