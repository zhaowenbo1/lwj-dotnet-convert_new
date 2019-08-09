using System.Collections.Generic;

namespace FurniturefFOB
{
    class Cuboid
    {
        public List<Point3D> points { get; set; }

        public static Cuboid newCuboid(Position abs, double h, double w, double d)
        {
            double x = abs.x;
            double y = abs.y;
            double z = abs.z;
            Cuboid cuboid = new Cuboid();
            List<Point3D> points = new List<Point3D>();
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y - d, z));
                points.Add(new Point3D(x + w, y - d, z));
                points.Add(new Point3D(x + w, y, z));
                points.Add(new Point3D(x, y, z + h));
                points.Add(new Point3D(x, y - d, z + h));
                points.Add(new Point3D(x + w, y - d, z + h));
                points.Add(new Point3D(x + w, y, z + h));          
            cuboid.points = points;
            return cuboid;
        }
    }
}
