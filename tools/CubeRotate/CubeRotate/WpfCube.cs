using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace CubeRotate
{
    public class WpfCube
    {
        private Point3D origin;
        private double width;
        private double height;
        private double depth;

        public Point3D centerBottom()
        {
            Point3D c = new Point3D(
                origin.X + (width / 2),
                origin.Y + height,
                origin.Z + (depth / 2)
                );

            return c;
        }

        public Point3D center()
        {
            Point3D c = new Point3D(
                origin.X + (width / 2),
                origin.Y - height / 2,
                origin.Z + (depth / 2)
                );

            return c;
        }

        public Point3D centerTop()
        {
            Point3D c = new Point3D(
                origin.X + (width / 2),
                origin.Y,
                origin.Z + (depth / 2)
                );

            return c;
        }

        public WpfCube(Point3D P0, double w, double h, double d)
        {
            width = w;
            height = h;
            depth = d;

            origin = P0;
        }

        public WpfCube(WpfCube cube)
        {
            width = cube.width;
            height = cube.height;
            depth = cube.depth;

            origin = new Point3D(cube.origin.X, cube.origin.Y, cube.origin.Z);
        }

        public WpfRectangle Front()
        {
            WpfRectangle r = new WpfRectangle(origin, width, height, 0);

            return r;
        }

        public WpfRectangle Back()
        {
            WpfRectangle r = new WpfRectangle(new Point3D(origin.X + width, origin.Y, origin.Z + depth), -width, height, 0);

            return r;
        }

        public WpfRectangle Left()
        {
            WpfRectangle r = new WpfRectangle(new Point3D(origin.X, origin.Y, origin.Z + depth),
                0, height, -depth);

            return r;
        }

        public WpfRectangle Right()
        {
            WpfRectangle r = new WpfRectangle(new Point3D(origin.X + width, origin.Y, origin.Z),
                0, height, depth);

            return r;
        }

        public WpfRectangle Top()
        {
            WpfRectangle r = new WpfRectangle(origin, width, 0, depth);

            return r;
        }

        public WpfRectangle Bottom()
        {
            WpfRectangle r = new WpfRectangle(new Point3D(origin.X + width, origin.Y - height, origin.Z),
                -width, 0, depth);

            return r;
        }

        public static void addCubeToMesh(Point3D p0, double w, double h, double d,
            MeshGeometry3D mesh)
        {
            WpfCube cube = new WpfCube(p0, w, h, d);

            double maxDimension = Math.Max(d, Math.Max(w, h));

            WpfRectangle front = cube.Front();
            WpfRectangle back = cube.Back();
            WpfRectangle right = cube.Right();
            WpfRectangle left = cube.Left();
            WpfRectangle top = cube.Top();
            WpfRectangle bottom = cube.Bottom();

            front.addToMesh(mesh);
            back.addToMesh(mesh);
            right.addToMesh(mesh);
            left.addToMesh(mesh);
            top.addToMesh(mesh);
            bottom.addToMesh(mesh);
        }

        public GeometryModel3D CreateModel(Color color)
        {
            return CreateCubeModel(origin, width, height, depth, color);
        }

        public static GeometryModel3D CreateCubeModel(Point3D p0, double w, double h, double d, Color color)
        {
            MeshGeometry3D mesh = new MeshGeometry3D();

            addCubeToMesh(p0, w, h, d, mesh);

            Material material = new DiffuseMaterial(new SolidColorBrush(color));
            //var material = new SpecularMaterial()
            //{
            //    Brush = new ImageBrush(new BitmapImage(new Uri(@"Z:\游戏资料\osu thing\sb\00_noiz.png")))
            //    {
            //        TileMode = TileMode.Tile
            //    }
            //};
            GeometryModel3D model = new GeometryModel3D(mesh, material);

            return model;
        }
    }
}
