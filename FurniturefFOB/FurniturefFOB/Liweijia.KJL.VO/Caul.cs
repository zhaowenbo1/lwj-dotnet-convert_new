namespace FurniturefFOB
{
    public class Caul
    {
        public double minX { get; set; }
        public double maxX { get; set; }
        public double minY { get; set; }
        public double maxY { get; set; }
        public double minZ { get; set; }
        public double maxZ { get; set; }


        //获取空间极限坐标
        public static Caul newCaul(Position abs, double d, double w, double h)
        {

            Caul caulModel = new Caul();

            Cuboid cb = Cuboid.newCuboid(abs, h, w, d);
            caulModel.minX = cb.points[0].x;
            caulModel.minY = cb.points[0].y;
            caulModel.minZ = cb.points[0].z;
            caulModel.maxX = cb.points[0].x;
            caulModel.maxY = cb.points[0].y;
            caulModel.maxZ = cb.points[0].z;

            foreach (Point3D point in cb.points)
            {
                if (point.x <= caulModel.minX)
                {
                    caulModel.minX = point.x;
                }
                if (point.x >= caulModel.maxX)
                {
                    caulModel.maxX = point.x;
                }

                if (point.y <= caulModel.minY)
                {
                    caulModel.minY = point.y;
                }
                if (point.y >= caulModel.maxY)
                {
                    caulModel.maxY = point.y;
                }

                if (point.z <= caulModel.minZ)
                {
                    caulModel.minZ = point.z;
                }
                if (point.z >= caulModel.maxZ)
                {
                    caulModel.maxZ = point.z;
                }
            }
            return caulModel;
        }
    }
}
