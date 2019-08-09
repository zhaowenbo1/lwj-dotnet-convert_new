using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace FurniturefFOB
{
   public class BoardModel
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public BoardModel(double _Height, double _Width, double _Depth)
        {
            Height = _Height;
            Width = _Width;
            Depth = _Depth;
        }
        //通过厚 宽 深，和插入点坐标 获取初始8个点的位置坐标
        public BoardModel()
        { }
        public Cuboid getBoardPoint(absPostion abs,double H,double W,double D,absRotation abr )
        {
            double x = abs.x;
            double y = abs.y;
            double z = abs.z;
            Cuboid cuboid = new Cuboid();
            List<Point3D> points = new List<Point3D>();
            if (abr.z == 0|| abr.z == 180)
            {
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y - D, z));
                points.Add(new Point3D(x + W, y - D, z));
                points.Add(new Point3D(x + W, y, z));
                points.Add(new Point3D(x, y, z + H));
                points.Add(new Point3D(x, y - D, z + H));
                points.Add(new Point3D(x + W, y - D, z + H));
                points.Add(new Point3D(x + W, y, z + H));
            }
            else if ( abr.z == 180)
            {
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y - D, z));
                points.Add(new Point3D(x + W, y - D, z));
                points.Add(new Point3D(x + W, y, z));
                points.Add(new Point3D(x, y, z + H));
                points.Add(new Point3D(x, y - D, z + H));
                points.Add(new Point3D(x + W, y - D, z + H));
                points.Add(new Point3D(x + W, y, z + H));
            }
            else if(abr.z==90 )
            {
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y +W, z));
                points.Add(new Point3D(x + D, y, z));
                points.Add(new Point3D(x + D, y+W, z));
                points.Add(new Point3D(x, y, z + H));
                points.Add(new Point3D(x, y+W, z + H));
                points.Add(new Point3D(x + D, y, z + H));
                points.Add(new Point3D(x + D, y+W, z + H));
            }
            else if (abr.z == -90 || abr.z == 270)
            {
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y - W, z));
                points.Add(new Point3D(x - D, y, z));
                points.Add(new Point3D(x - D, y - W, z));
                points.Add(new Point3D(x, y, z + H));
                points.Add(new Point3D(x, y - W, z + H));
                points.Add(new Point3D(x - D, y, z + H));
                points.Add(new Point3D(x - D, y - W, z + H));
            }
            else if (abr.z == -180)
            {
                points.Add(new Point3D(x, y, z));
                points.Add(new Point3D(x, y + D, z));
                points.Add(new Point3D(x - W, y + D, z));
                points.Add(new Point3D(x - W, y, z));
                points.Add(new Point3D(x, y, z + H));
                points.Add(new Point3D(x, y + D, z + H));
                points.Add(new Point3D(x - W, y + D, z + H));
                points.Add(new Point3D(x - W, y, z + H));
            }
            cuboid.points = points;
            return cuboid;
        }                   
    }
   public class Point3D
    {
        public double x { get; set; }
        public double y { get; set; }
        public double z { get; set; }
        public Point3D(double _x, double _y, double _z)
        {
            x = _x;
            y = _y;
            z = _z;
        }
        public Point3D()
        { }
    }
   public class Cuboid
    {
        public List<Point3D> points { get; set; }    

    }
   public  class CaulModel
    {
         public double minX { get; set; }
         public double maxX { get; set; }
         public double minY { get; set; }
         public double maxY { get; set; }
         public double minZ { get; set; }
         public double maxZ { get; set; }
        //获取空间极限坐标
        public CaulModel getCaulModel(absPostion abs, absRotation abr, double D, double W, double H)
        {
            
            CaulModel caulModel = new CaulModel();
            Cuboid cb = new Cuboid();
            BoardModel board = new BoardModel();
            cb = board.getBoardPoint(abs, H, W, D,abr);
            caulModel.minX = cb.points[0].x;
            caulModel.minY = cb.points[0].y;
            caulModel.minZ = cb.points[0].z;
            caulModel.maxX = cb.points[0].x;
            caulModel.maxY = cb.points[0].y;
            caulModel.maxZ = cb.points[0].z;

            foreach (Point3D point in cb.points)
            {
                if(point.x<=caulModel.minX)
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
