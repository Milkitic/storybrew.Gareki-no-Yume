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
using StorybrewCommon.Animations;

namespace StorybrewScripts
{
    public class DiffOnlyTitle : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("Foreground");
            var h = 45;
            var baseY = 230;
            string mapper = "Dored";
            int width = 70;
            if (Beatmap.Name.Contains("LMT"))
            {
                mapper = "LMT";
                width = 45;
            }
            else if (Beatmap.Name.Contains("Lunala"))
            {
                mapper = "Lunala";
                width = 81;
            }
            else if (Beatmap.Name.Contains("Otosaka"))
            {
                mapper = "Otosaka-Yu";
                width = 121;
            }
            else if (Beatmap.Name.Contains("Misure"))
            {
                mapper = "Misure";
                width = 71;
            }
            else if (Beatmap.Name.Contains("Normal") ||
                     Beatmap.Name.Contains("Separation"))
            {
                mapper = "Dored";
                width = 70;
            }

            RenderTexts(layer, mapper, width, 640 - 5, baseY + h / 2 + h - 5);
            TextShowEnter(layer, 172386, 173136, "Beatmap", 150, mapper, width / 7d * 8, true, "_1S");
        }

        private void RenderTexts(StoryboardLayer layer, string sentence, int width, int centerX, int centerY,
            double sRatio = 1)
        {
            var start = 15121;
            var end = 18121;
            var postFix = "_2S";
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

        private void TextShowEnter(StoryboardLayer layer, double start, double end,
            string str1, double w1,
            string str2, double w2,
            bool? speed = null, string type2 = "_2S")
        {
            var postFix = "_1L";
            for (var i = 0; i < str1.Length; i++)
            {
                var c = str1[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                if (c == ' ') continue;

                var s1 = 1.5 / 1.25;
                var s2 = 0.25 / 1.25;
                var s3 = 0.15 / 1.25;
                var w1_2 = w1 / s3 * s2;
                var w1_3 = w1 / s3 * s1;

                var x1 = w1_3 * (i / (double)(str1.Length - 1)) + 320 - w1_3 / 2d;
                var x2 = w1_2 * (i / (double)(str1.Length - 1)) + 320 - w1_2 / 2d;

                var x3 = w1 * (i / (double)(str1.Length - 1)) + 320 - w1 / 2d;

                var y = 230;
                var sprite = layer.CreateSprite(pic);

                double accOffset = 0, trueOffset = 0;
                if (speed == null)
                {
                    accOffset = 200;
                    trueOffset = 1200;
                }
                else if (speed == false)
                {
                    accOffset = 150;
                    trueOffset = 800;
                }
                else if (speed == true)
                {
                    accOffset = 130;
                    trueOffset = 700;
                }

                sprite.MoveX(start, start + accOffset, x1, x2);
                sprite.MoveX((OsbEasing)10, start + accOffset, start + trueOffset, x2, x3);
                sprite.MoveY(end, y);
                sprite.Scale(start, start + accOffset, s1, s2);
                sprite.Scale((OsbEasing)10, start + accOffset, start + trueOffset, s2, s3);
            }

            postFix = type2;
            start += 200;
            for (var i = 0; i < str2.Length; i++)
            {
                var c = str2[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                if (c == ' ') continue;

                var x = w2 * (i / (double)(str2.Length - 1)) + 320 - w2 / 2d;

                var y1 = 450;
                var y2 = 350;
                var y3 = 290;
                var sprite = layer.CreateSprite(pic);

                double accOffset = 0, trueOffset = 0;
                if (speed == true)
                {
                    accOffset = 110 / 2;
                    trueOffset = 600 / 2;
                }
                else if (speed == null)
                {
                    accOffset = 150 / 2;
                    trueOffset = 800 / 2;
                }
                else if (speed == false)
                {
                    accOffset = 130 / 2;
                    trueOffset = 700 / 2;
                }

                var ggOffset = EasingFunctions.QuartOut((i / (double)(str2.Length - 1) / 3d)) * trueOffset / 1.5d;
                sprite.Fade(start + ggOffset, 1);
                sprite.MoveY(start + ggOffset, start + accOffset + ggOffset, y1, y2);
                sprite.MoveY((OsbEasing)10, start + accOffset + ggOffset, start + trueOffset + ggOffset, y2, y3);
                sprite.MoveX(end, x);
                sprite.Scale(end, 0.4);
                sprite.Fade(end, 0);
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