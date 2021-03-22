using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using FontGenerator.Annotations;
using Image = System.Drawing.Image;
using Point = System.Windows.Point;
using Size = System.Windows.Size;

namespace FontGenerator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private char[] _allCharacters;
        const string BaseFolder = @"D:\Games\osu!\Songs\1037741 Denkishiki Karen Ongaku Shuudan - Gareki no Yume\SB";

        public MainWindow()
        {
            InitializeComponent();
        }

        public char[] AllCharacters
        {
            get => _allCharacters;
            set
            {
                if (value == _allCharacters) return;
                _allCharacters = value;
                OnPropertyChanged();
            }
        }

        private void MainWindow_OnInitialized(object? sender, EventArgs e)
        {
            //var ffPath = BaseFolder + @"\font.ttc";
            //var pfc = new PrivateFontCollection();
            //pfc.AddFontFile(ffPath);
            //var font = new Font(pfc.Families.First(k => k.Name.EndsWith("NK-R")), 32);
            //var name = font.Name;
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            var allText = File.ReadAllText(BaseFolder + @"\lyric.txt");
            var distinct = allText
                .Where(k => k != '\r' && k != '\n' && k != ' ')
                .Distinct()
                .OrderBy(k => k)
                .ToArray();
            AllCharacters = distinct;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            SaveVisualTreeImages(itemChar);
            SaveVisualTreeImages(itemBlur, "_b");
        }

        private void SaveVisualTreeImages(ItemsControl itemsControl, string postFix = "")
        {
            var grids = FindVisualChildren<Grid>(itemsControl).ToArray();
            var targetFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output");
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);
            foreach (var grid in grids)
            {
                var name = grid.Tag.ToString() ?? "";
                var fileName =
                    Convert.ToBase64String(Encoding.UTF8.GetBytes(name))
                        .Replace("\\", "nmsl")
                        .Replace("/", "slnm")
                    + postFix + ".png";
                var image = GetImageByVisual(grid, new Size(grid.ActualWidth, grid.ActualHeight));
                image.Save(Path.Combine(targetFolder, fileName));
                image.Dispose();
            }
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        protected Image GetImageByVisual(Visual visual, Size size)
        {
            var dpi = this.GetDpi();
            var bmp = new RenderTargetBitmap(
                (int)(size.Width * dpi.X / 96), (int)(size.Height * dpi.Y / 96),
                dpi.X, dpi.Y, PixelFormats.Pbgra32
            );

            bmp.Render(visual);

            using var stream = new MemoryStream();
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(bmp));
            encoder.Save(stream);
            var bitmap = new Bitmap(stream);
            return bitmap;
        }

        private Point GetDpi()
        {
            var source = PresentationSource.FromVisual(this);

            double dpiX = 0, dpiY = 0;
            if (source != null)
            {
                dpiX = 96.0 * source.CompositionTarget.TransformToDevice.M11;
                dpiY = 96.0 * source.CompositionTarget.TransformToDevice.M22;
            }

            return new Point(dpiX, dpiY);
        }
    }
}
