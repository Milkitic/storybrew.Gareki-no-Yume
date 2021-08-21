using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Path = System.IO.Path;

namespace CubeRotate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        public int sceneSize = 30;
        private async void Viewport3D_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Viewport3D viewport)
            {
                WpfCube cube = new WpfCube(new Point3D(0, 0, 0), sceneSize / 6, sceneSize / 6, sceneSize / 6);
                GeometryModel3D cubeModel = cube.CreateModel(Color.FromRgb(240, 10, 20));
                //cubeModel.Material = new SpecularMaterial()
                //{
                //    Brush = new ImageBrush(new BitmapImage(new Uri(@"Z:\游戏资料\osu thing\sb\素材\00_noiz.png")))
                //};
                //GeometryModel3D cubeModel = cube.CreateModel(Color.FromRgb(230, 42, 49))
                Model3DGroup groupScene = new Model3DGroup();
                groupScene.Children.Add(cubeModel);
                Point3D position = new Point3D(-sceneSize, sceneSize / 2, 0.0);
                groupScene.Children.Add(positionLight(position));
                groupScene.Children.Add(new DirectionalLight()
                {
                    Color = Colors.White,
                    Direction = new Point3D(0, 0, 0) - position
                });
                //groupScene.Children.Add(new AmbientLight(Colors.Gray));

                viewport.Camera = camera();

                var visual = new ModelVisual3D();
                visual.Content = groupScene;
                viewport.Children.Add(visual);
                var sec = 30;
                turnModel(cube.center(), cubeModel, 0, 360, sec, true);
                //return;
                await SaveByFrames(sec, "blurplus", "cube");
            }

        }

        private async Task SaveByFrames(int sec, string dir, string prefix)
        {
            var count = 100;
            var listByte = new List<byte[]>();
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine(i);
                var ts = Stopwatch.StartNew();
                double sleep = (double)(sec * 1000) / count;
                //var t = sleep * i;
                listByte.Add(SaveToMemory(grid));
                long elapsed = ts.ElapsedMilliseconds;
                var delay = sleep - elapsed;
                if (delay > 0)
                    await Task.Delay(TimeSpan.FromMilliseconds(delay));
            }

            for (int i = 0; i < listByte.Count; i++)
            {
                byte[] item = listByte[i];
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir);
                var path = Path.Combine(dir, $"{prefix}{i}.png");
                await File.WriteAllBytesAsync(path, item);
            }
        }

        byte[] SaveToMemory(FrameworkElement visual)
        {
            var encoder = new PngBitmapEncoder();
            using var stream = new MemoryStream();
            SaveUsingEncoder(visual, stream, encoder);
            return stream.ToArray();
        }

        void SaveUsingEncoder(FrameworkElement visual, MemoryStream stream, BitmapEncoder encoder)
        {
            Size sz = new Size(visual.ActualWidth, visual.ActualHeight);
            visual.Measure(sz);
            visual.Arrange(new Rect(sz));

            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)sz.Width, (int)sz.Height, 96,
                96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            encoder.Save(stream);
        }

        void SaveToPng(FrameworkElement visual, string fileName)
        {
            var encoder = new PngBitmapEncoder();
            SaveUsingEncoder(visual, fileName, encoder);
        }

        void SaveUsingEncoder(FrameworkElement visual, string fileName, BitmapEncoder encoder)
        {
            Size sz = new Size(visual.ActualWidth, visual.ActualHeight);
            visual.Measure(sz);
            visual.Arrange(new Rect(sz));

            RenderTargetBitmap bitmap = new RenderTargetBitmap((int)sz.Width, (int)sz.Height, 96,
                96, PixelFormats.Pbgra32);
            bitmap.Render(visual);
            BitmapFrame frame = BitmapFrame.Create(bitmap);
            encoder.Frames.Add(frame);

            using (var stream = File.Create(fileName))
            {
                encoder.Save(stream);
            }
        }

        public Light positionLight(Point3D position)
        {
            Light l = new DirectionalLight();

            var light = (DirectionalLight)l;
            light.Color = Colors.Gray;
            light.Direction = new Point3D(0, 0, 0) - position;
            return light;
        }

        /// <summary>
        /// 得到一个透视投影摄像机
        /// </summary>
        /// <returns></returns>
        Point3D lookat = new Point3D(0, 0, 0);
        public PerspectiveCamera camera()
        {
            PerspectiveCamera perspectiveCamera = new PerspectiveCamera();
            perspectiveCamera.Position = new Point3D(-sceneSize, sceneSize / 2, sceneSize);//设置观察点
            perspectiveCamera.LookDirection = new Vector3D(lookat.X - perspectiveCamera.Position.X,
                                                           lookat.Y - perspectiveCamera.Position.Y,
                                                           lookat.Z - perspectiveCamera.Position.Z);//设置观察方向 空间向量的表示方式
            perspectiveCamera.FieldOfView = 60;//水平视角
            return perspectiveCamera;
        }

        /// <summary>
        /// 模型动起来
        /// </summary>
        /// <param name="center"></param>
        /// <param name="model"></param>
        /// <param name="beginAngle">开始角度</param>
        /// <param name="endAngle">结束角度</param>
        /// <param name="seconds"></param>
        /// <param name="forever"></param>
        public void turnModel(Point3D center, GeometryModel3D model, double beginAngle, double endAngle, double seconds, bool forever)
        {
            //向量作为两个旋转轴
            Vector3D vector = new Vector3D(0, 1, 0);
            Vector3D vector2 = new Vector3D(1, 0, 0);

            // 创建AxisAngleRotation3D（三维旋转）。我们可以设置一个0度的旋转，因为我们要给他们做动画
            AxisAngleRotation3D rotation = new AxisAngleRotation3D(vector, 0.0);
            AxisAngleRotation3D rotation2 = new AxisAngleRotation3D(vector2, 0.0);

            // 创建双动画来动画我们的每一个旋转
            DoubleAnimation doubleAnimation = new DoubleAnimation(beginAngle, endAngle, durationTS(seconds));
            DoubleAnimation doubleAnimation2 = new DoubleAnimation(beginAngle, endAngle, durationTS(seconds));

            // 为我们的动画设置重复的行为和持续时间
            if (forever)
            {
                doubleAnimation.RepeatBehavior = RepeatBehavior.Forever;
                doubleAnimation2.RepeatBehavior = RepeatBehavior.Forever;
            }

            doubleAnimation.BeginTime = durationTS(0.0);
            doubleAnimation2.BeginTime = durationTS(0.0);

            // 创建2个旋转变换应用到我们的模型。每个需要一个旋转和一个中心点
            RotateTransform3D rotateTransform = new RotateTransform3D(rotation, center);
            RotateTransform3D rotateTransform2 = new RotateTransform3D(rotation2, center);

            // 创建一个转换组来保持我们的2个转换
            Transform3DGroup transformGroup = new Transform3DGroup();
            transformGroup.Children.Add(rotateTransform);
            transformGroup.Children.Add(rotateTransform2);

            // 将旋转组添加到模型上
            model.Transform = transformGroup;


            //var sb = new Storyboard();
            //sb.Children.Add(doubleAnimation);
            //sb.Children.Add(doubleAnimation2);
            //Storyboard.SetTargetProperty(doubleAnimation, new PropertyPath(AxisAngleRotation3D.AngleProperty));
            //Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(AxisAngleRotation3D.AngleProperty));
            //Storyboard.SetTarget(doubleAnimation, rotation);
            //Storyboard.SetTarget(doubleAnimation2, rotation2);
            //sb.Begin();
            //sb.Seek(TimeSpan.FromMilliseconds(3240));

            // 开始动画 -- specify a target object and property for each animation -- in this case,
            //目标是我们创造的两个AxisAngleRotation3D对象 并且 我们改变每个的角度属性
            rotation.BeginAnimation(AxisAngleRotation3D.AngleProperty, doubleAnimation);
            rotation2.BeginAnimation(AxisAngleRotation3D.AngleProperty, doubleAnimation2);
        }

        private int durationM(double seconds)
        {
            int milliseconds = (int)(seconds * 1000);
            return milliseconds;
        }

        public TimeSpan durationTS(double seconds)
        {
            TimeSpan ts = new TimeSpan(0, 0, 0, 0, durationM(seconds));
            return ts;
        }
    }
}
