using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorybrewScripts
{
    public class Opening : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("main");

            var waifu = layer.CreateSprite(@"SB\cg\waifu_red_h2.png");
            waifu.Move(0, 12121, 18121, 320, 240, 320, 240);
            waifu.Fade(12121, 0);
            for (int i = 0; i < 20; i += 2)
            {
                waifu.Fade(14371 + i * 33, 0.4);
                waifu.Fade(14371 + (i + 1) * 33, 0);
            }
            waifu.Fade(15121, 1);
            waifu.Color(12121, 0.7, 0.7, 0.7);
            waifu.Scale((OsbEasing)7, 12121, 12121 + 500, 1, 0.8);
            waifu.Scale(0, 12121 + 500, 18121, 0.8, 0.7);
            var startKiraTime = 17746;
            for (int i = 0; i < 4; i++)
            {
                waifu.Fade(startKiraTime, 0);
                waifu.Fade(startKiraTime + (17792 - 17746), 1);
                startKiraTime += (17839 - 17746);
            }

            var count = 250;
            var list = new double[count];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = Random(0.1, 0.5);
            }

            Array.Sort(list);
            for (int i = 0; i < list.Count(); i++)
            {
                var aniInterval = Random(15, 25);
                var elapsed = 1500d;
                var start = Random(0, 18121);

                var x = Random(-107 - 100, 747 + 100);
                var fadeT = Random(-2000, 0);
                var scale = list[i];
                elapsed = elapsed / (scale * 1);
                var shouldFadeTime = 6120;
                if (scale > 0.2) shouldFadeTime = 12121;
                if (start + elapsed <= shouldFadeTime) continue;

                var black = scale / 0.5 * 1;

                var cube = layer.CreateAnimation(@"SB\components\cube\blur\cube.png", 97, aniInterval, OsbLoopType.LoopForever);
                // var cube2 = layer.CreateAnimation(@"SB\components\cube\ani.png", 97, interval, OsbLoopType.LoopForever);


                cube.Fade(fadeT, 0);
                if (start > shouldFadeTime)
                    cube.Fade(start, 1);
                else
                {
                    cube.Fade(shouldFadeTime, 1);
                }
                cube.Move(0, start, start + elapsed, x, 480 + 100, x, 0 - 100);
                cube.Fade(start + elapsed, 0);
                cube.Scale(shouldFadeTime, scale);
                cube.Fade(18121, 0);
                cube.Color(0, 6120, 12121, 1, 1, 1, 1, 1, 1);
                cube.Color(12121, black, black, black);

                // cube2.Additive(0);
                // cube2.Fade(fadeT, 0);
                // cube2.Fade(6120, 1);
                // cube2.Move(0, start, start + speed, x, 480 + 50, x, 0 - 50);
                // cube2.Scale(6120, scale);
            }

            var h = 45;
            var baseY = 230;
            RenderTexts(layer, "Artist:", 80, 0 - 40, baseY - h / 2 - h);
            RenderTexts(layer, "電気式華憐音楽集団", 235, 181 - 40, baseY - h / 2 - h, 0.9);

            RenderTexts(layer, "Title:", 60, 0 - 50, baseY - h / 2);
            RenderTexts(layer, "瓦礫の夢", 100, 100 - 50, baseY - h / 2, 0.9);

            RenderTexts(layer, "Lyric:", 60, 0 - 50, baseY + h / 2);
            RenderTexts(layer, "華憐", 34, 70 - 50, baseY + h / 2, 0.9);

            RenderTexts(layer, "Compose:", 110, 0 - 26, baseY + h / 2 + h);
            RenderTexts(layer, "電気", 34, 95 - 26, baseY + h / 2 + h, 0.9);

            RenderTexts(layer, "Beatmap", 95, 640 - 5, baseY + h / 2 + 5);
            //RenderTexts(layer, "Dored", 70, 640 - 5, baseY + h / 2 + h - 5);

            RenderTexts(layer, "Storyboard", 120, 640 - 5, baseY - h / 2 - h + 5);
            RenderTexts(layer, "yf_bmp", 75, 640 - 5, baseY - h / 2 - 5);

            RenderTexts(layer, "MV", 23, 320 - 65, 480 - 65);
            RenderTexts(layer, "Reference", 115, 320 + 35, 480 - 65);
            RenderTexts(layer, "幽閉サテライト-明日散る運命なら", 450, 320, 480 - 30, 0.9);

            var title = layer.CreateSprite(@"SB\cg\top_mainvisual_logo.png", OsbOrigin.Centre);
            title.Move(0, 12121, 18121, 320, 240, 320, 240);
            title.Color(18121, 1, 0.75, 0.75);
            title.Scale((OsbEasing)0, 12121, 12121 + 100, 1.3, 1.0);
            title.Scale((OsbEasing)7, 12121 + 100, 12121 + 700, 1.0, 0.8);

            var fLayer = GetLayer("Foreground");
            for (int i = 0; i < 20; i++)
            {
                var fog = fLayer.CreateSprite(@"SB\components\fog.png");
                var x = Random(-107, 747);
                var y = Random(0, 480);
                var start = 17558 + Random(18121 - 17558);
                fog.Color(start, 0, 0, 0);
                fog.ScaleVec(start, Random(1, 2), Random(2, 4));
                fog.Move(0, start, 18121, x, y, x, y);
            }

            for (int i = 0; i < 25; i++)
            {
                var fog = layer.CreateSprite(@"SB\components\fog.png");
                var x = Random(-207, 847);
                var y = Random(-100, 580);
                var start = 11746 + Random(12121 - 11746);
                fog.Color(start, 0.5, 0, 0);
                fog.ScaleVec(start, Random(1, 2), Random(2, 6));
                fog.Move(0, start, 12121, x, y, x, y);
            }
        }

        private void RenderTexts(StoryboardLayer layer, string sentence, int width, int centerX, int centerY, double sRatio = 1)
        {
            var start = 15121;
            var end = 18121;
            var postFix = "_2S";
            // var sentence = "Artist: 電気式華憐音楽集団";
            // var width = 240;
            for (var j = 0; j < sentence.Length; j++)
            {
                var c = sentence[j];
                if (c == ' ') continue;
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (j / (double)(sentence.Length - 1)) + centerX - width / 2d;
                var y = centerY;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.4 * sRatio);
                sprite.Fade(start, 1);

                var interval = Random(33, 66);
                var st = 14371;
                var g = 15;
                while (st < start)
                {
                    if (g > 0)
                    {
                        sprite.MoveX(st, x + Random(-g, g));
                        sprite.MoveY(st, y + Random(-g, g));
                    }
                    
                    sprite.Fade(st, 0.1);
                    st += interval;
                    if (st >= start) break;
                    sprite.Fade(st, 0);
                    st += interval;
                    g--;
                }
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
            var fileName = @"SB\output\" + StringToUnicode(name) + postFix + ".png";
            return fileName;
        }
    }
}
