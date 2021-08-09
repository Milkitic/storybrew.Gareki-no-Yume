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
        private const string SongFolder = @"E:\Games\osu!\Songs";
        private const string BaseFolder = SongFolder + "\\" + @"1037741 Denkishiki Karen Ongaku Shuudan - Gareki no Yume\SB";

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
            var allText = "0123456789:.,./_-qwertyuiopasdfghjklzxcvbnm·" +
                          "qwertyuiopasdfghjklzxcvbnm".ToUpper() +
                          "幽閉サテライト - 明日散る運命なら" +
                          "サクラノモリ†ドリーマーズ" +
                          "電気式華憐音楽集団" +
                          "瓦礫の夢" +
                          "華憐" +
                          "電気";
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
            SaveVisualTreeImages(itemChar_1l, "_1L");
            SaveVisualTreeImages(itemStroke_1l, "_st_1L");
            SaveVisualTreeImages(itemChar_2l, "_2L");
            SaveVisualTreeImages(itemStroke_2l, "_st_2L");
            SaveVisualTreeImages(itemChar_3l, "_3L");
            SaveVisualTreeImages(itemStroke_3l, "_st_3L");

            SaveVisualTreeImages(itemChar_1S, "_1S");
            SaveVisualTreeImages(itemStroke_1S, "_st_1S");
            SaveVisualTreeImages(itemChar_2S, "_2S");
            SaveVisualTreeImages(itemStroke_2S, "_st_2S");
            SaveVisualTreeImages(itemChar_3S, "_3S");
            SaveVisualTreeImages(itemStroke_3S, "_st_3S");
        }

        private void SaveVisualTreeImages(ItemsControl itemsControl, string postFix = "")
        {
            var grids = FindVisualChildren<Grid>(itemsControl).ToArray();
            var targetFolder = Path.Combine(BaseFolder, "output");
            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);
            foreach (var grid in grids)
            {
                var name = grid.Tag.ToString() ?? "";
                var fileName = ConvertToFileName(name, postFix);
                var image = GetImageByVisual(grid, new Size(grid.ActualWidth, grid.ActualHeight));
                image.Save(Path.Combine(targetFolder, fileName));
                image.Dispose();
            }
        }
        private static string StringToUnicode(string srcText)
        {
            string dst = "";
            char[] src = srcText.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(src[i].ToString());
                string str = @"" + bytes[1].ToString("X2") + bytes[0].ToString("X2");
                dst += str;
            }
            return dst;
        }

        private static string ConvertToFileName(string name, string postFix)
        {
            var fileName = StringToUnicode(name) + postFix + ".png";
            return fileName;
        }

        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child is T o)
                    {
                        yield return o;
                    }

                    foreach (var childOfChild in FindVisualChildren<T>(child))
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
