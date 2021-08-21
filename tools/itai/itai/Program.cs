using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FastBitmapLib;

namespace itai
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Point>();
            var bitmap = (Bitmap)Bitmap.FromFile("5q27_1L.png");
            using var fastBitmap = bitmap.FastLock();
            var step = 12;
            for (int j = 0; j < fastBitmap.Height; j += step)
            {
                for (int i = 0; i < fastBitmap.Width; i += step)
                {
                    var pixel = fastBitmap.GetPixel(i, j);
                    if (pixel.A > 128)
                    {
                        list.Add(new Point(i, j));
                        //fastBitmap
                    }
                }
            }

            Console.WriteLine("new []{" + 
                              string.Join(',', list.Select(k => $"new Vector2({k.X},{k.Y})")) +
                              "};");
            Console.ReadKey();
        }
    }
}
