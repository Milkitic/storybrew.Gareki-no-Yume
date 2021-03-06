using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorybrewScripts
{
    public class KiaiTexts : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 58620;
        [Configurable]
        public bool Short = false;

        bool IsMid => StartTime == 117121;

        private double rt(double time)
        {
            return StartTime + (time - 58620);
        }

        public override void Generate()
        {
            var layer = GetLayer("text");
            if (!Short)
            {
                Generate1(layer);
                Generate2(layer);
                Generate3(layer);
                Generate5(layer);
                Generate4(layer);
            }

            Generate6(layer);
            Generate7(layer);
            Generate8(layer);
            Generate9(layer);
            Generate10(layer);
            Generate11(layer);
            Kira(layer);
            GenerateBlood(layer);
        }

        private void GenerateBlood(StoryboardLayer layer)
        {
            var count = 130;
            for (int i = 0; i < count; i++)
            {
                double g = 30;
                var deg = Math.Sin(i % g / g) * 360;
                var r = 300 * i / (count - 1);

                var x = 320 + r * 2 * Math.Cos(deg / 180d * Math.PI) + Random(-20, 20);
                var y = 240 + r * Math.Sin(deg / 180 * Math.PI) * (i % 2 == 0 ? 1 : -1) + Random(-30, 30);

                var ratio = i / (double)count;
                var o = layer.CreateAnimation(@"SB\components\ink\ink.png", 18, Random(16, 32), OsbLoopType.LoopOnce);
                var interval = 18;
                var start = rt(79621) + 1700 + (count - 1 * interval) - i * interval;
                o.Move(start, rt(80933), x, y, x, y);
                o.Scale(start, 0.2 * ((r / 250d) + 1));
                o.Color(start, 0.5, 0, 0.1);
                // o.Fade(start, 0.2);
            }

            for (int i = 0; i < count; i++)
            {
                double g = 30;
                var deg = Math.Sin(i % g / g) * 360;
                var r = 300 * i / (count - 1);

                var x = 320 + r * 2 * Math.Cos(deg / 180d * Math.PI) + Random(-20, 20);
                var y = 240 + r * Math.Sin(deg / 180 * Math.PI) * (i % 2 == 0 ? 1 : -1) + Random(-30, 30);
                var x2 = 320 + (r + 30 + i) * 2 * Math.Cos(deg / 180d * Math.PI) + Random(-20, 20);
                var y2 = 240 + (r + 30 + i) * Math.Sin(deg / 180 * Math.PI) * (i % 2 == 0 ? 1 : -1) + Random(-30, 30);

                var ratio = i / (double)count;
                var o = layer.CreateSprite(@"SB\components\ink\ink17.png");
                var interval = 3 + i / 20;
                var start = rt(80933) + i * interval;
                // o.Move(80933, 82339, x, y, x, y);
                var less = 10;
                var s = 0.2 * ((r / 250d) + 1);
                o.Scale((OsbEasing)2, start, start + 200 + i * less, s, 0);
                o.Color((OsbEasing)2, start, start + 200 + i * less, 0.3, 0, 0.02, 0, 0, 0);
                o.Rotate((OsbEasing)2, start, start + 200 + i * less, Random(Math.PI * 2), Random(Math.PI * 2));
                o.Move((OsbEasing)2, start, start + 200 + i * less, x, y, x2, y2);
                // o.Color(80933, 82339, 0.3, 0, 0.02, 0.3, 0, 0.02);
                o.Fade(rt(80933), 1);
                o.Fade(rt(82621), 0);
                // o.Fade(start, 0.2);
            }

            var w = layer.CreateSprite(@"SB\components\white.png");
            w.Fade(rt(80746), rt(80933), 0, 1);
            w.Color(rt(80746), 1, 0.5, 0.6);
        }

        private void Generate11(StoryboardLayer layer)
        {
            var start = StartTime + (80933 - 58620);
            var end = StartTime + (82621 - 58620);
            var postFix = "_1L";
            var sentence = IsMid ? "???????????????" : "???????????????";
            var width = 340;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.27);
            }
        }

        private void Generate10(StoryboardLayer layer)
        {
            var start = StartTime + (79058 - 58620);
            var end = StartTime + (80933 - 58620);
            var postFix = "_1S";
            var sentence = IsMid ? "??????" : "?????????";
            var height = IsMid ? 60 : 120;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 240 - height / 2d;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX(start, 320);
                sprite.Fade(start, 0);
                sprite.Fade(end, 0);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveY(start, y);
                sprite.Scale((OsbEasing)13, start + i * 50, start + i * 50 + 700, 1.1, 0.7);
                sprite.Fade(start + 1 + i * 50, 1);


                for (int j = 0; j < 135; j++)
                {
                    sprite.MoveX(StartTime + (79058 - 58620) + j * 16.6667, 320 + Random(j) / 30);
                    sprite.MoveY(StartTime + (79058 - 58620) + j * 16.6667, y + Random(j) / 30);
                }
                sprite.Color((OsbEasing)2, start, end, 0.5, 0, 0, 1, 1, 1);
            }
        }

        private void Generate9(StoryboardLayer layer)
        {
            var start = StartTime + (76058 - 58620);
            var postFix = "_2S";
            var sentence = IsMid ? "???????????????????????????" : "????????????????????????";
            var width = IsMid ? 320 : 300;
            var targetWidthPre = IsMid ? 415 : 450;
            var targetWidth = IsMid ? 520 : 500;
            for (var i = 0; i < sentence.Length; i++)
            {
                var deg = ((i / (sentence.Length - 1d)) - 0.5) * 2 * 45 - 90;
                var r = 250;

                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;

                var xp = x + r * Math.Cos(deg / 180d * Math.PI);
                var yp = y + r * Math.Sin(deg / 180 * Math.PI) * (i % 2 == 0 ? 1 : -1);
                var xpp = x + 40 * Math.Cos(deg / 180d * Math.PI);
                var ypp = y + 40 * Math.Sin(deg / 180 * Math.PI) * (i % 2 == 0 ? 1 : -1);


                var x2 = targetWidthPre * (i / (double)(sentence.Length - 1)) + 320 - targetWidthPre / 2d;
                var x3 = targetWidth * (i / (double)(sentence.Length - 1)) + 320 - targetWidth / 2d;
                var enterTime = start + i * (66 - i * 4);

                var sprite = layer.CreateSprite(pic);
                var s = 150;
                sprite.MoveX((OsbEasing)0, enterTime, enterTime + s, xp, xpp);
                sprite.MoveY((OsbEasing)0, enterTime, enterTime + s, yp, ypp);
                sprite.MoveX((OsbEasing)13, enterTime + s, enterTime + 1100, xpp, x);
                sprite.MoveY((OsbEasing)13, enterTime + s, enterTime + 1100, ypp, y);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveX(0, StartTime + (78121 - 58620), StartTime + (78214 - 58620), x, x2);
                sprite.MoveX((OsbEasing)7, StartTime + (78214 - 58620), StartTime + (79058 - 58620), x2, x3);
                // sprite.Fade(start, 1);
                sprite.Scale(StartTime + (79058 - 58620), 0.5);
            }
        }

        private void Generate8(StoryboardLayer layer)
        {
            var start = StartTime + (73621 - 58620);
            // var end = StartTime + (71839 - 58620);
            var sentence = IsMid ? "?????????????????????" : "??????????????????";
            var postFix = "_3S";
            var width = IsMid ? 290 : 280;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x0 = width * (i / (float)sentence.Length) + 320 - width / 2 - 180;
                var y0 = 243;
                var shadows = 50;
                var shadowInterval = 1;
                for (int j = 0; j < shadows; j++)
                {
                    var enterTime = start + j * shadowInterval;
                    var sprite = layer.CreateSprite(pic, OsbOrigin.Centre, new Vector2(x0, y0));
                    var offset = (j / (shadows - 1d) - 0.5) * 100;
                    var f = Math.Abs(shadows / 2d - Math.Abs(j - shadows / 2d)) / (shadows / 2d);
                    f = f * f * f;

                    sprite.Scale(enterTime, 0.6);
                    sprite.MoveX((OsbEasing)0, start, StartTime + (73902 - 58620) - 200, 320 + offset, x0);
                    sprite.MoveX((OsbEasing)10, StartTime + (73902 - 58620) - 200, StartTime + (76058 - 58620), x0, x0 - 50);
                    sprite.Fade((OsbEasing)0, start, StartTime + (73902 - 58620), 0, f);
                    sprite.Fade(StartTime + (76058 - 58620), 1);
                }
            }
        }

        private void Generate7(StoryboardLayer layer)
        {
            var start = StartTime + (72308 - 58620);
            // var end = StartTime + (71839 - 58620);
            var sentence = IsMid ? "?????????????????????" : "???????????????";
            var postFix = "_3S";
            var width = IsMid ? 260 : 210;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d + 200;
                var enterTime = start + i * (66 - i * 2);

                var sprite = layer.CreateSprite(pic);
                // sprite.MoveY((OsbEasing)13, enterTime, enterTime + 700, 240 + (i % 2 == 0 ? -50 : 50), 240);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveX(0, enterTime, enterTime + 2000, x, x);
                sprite.MoveY(enterTime, 240);
                sprite.Scale((OsbEasing)13, enterTime, enterTime + 700, 1.1, 0.7);
                sprite.Fade(enterTime, 1);
                sprite.Fade(StartTime + (73433 - 58620), 0);
                // sprite.Fade(start, 1);
                // sprite.Scale(start, 0.7);
            }

            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                double x0 = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d + 200;
                var y0 = 240;
                var shadows = 50;
                var shadowInterval = 1;
                for (int j = 0; j < shadows; j++)
                {
                    var enterTime = StartTime + (73433 - 58620) + j * shadowInterval;
                    var sprite = layer.CreateSprite(pic, OsbOrigin.Centre, new Vector2((float)x0, y0));
                    var offset = (j / (shadows - 1d) - 0.5) * 100;
                    var f = Math.Abs(shadows / 2d - Math.Abs(j - shadows / 2d)) / (shadows / 2d);
                    f = f * f * f;

                    sprite.Scale(enterTime, 0.7);
                    sprite.MoveX((OsbEasing)2, StartTime + (73433 - 58620), StartTime + (73621 - 58620), x0, 320 + offset);
                    sprite.Fade((OsbEasing)0, StartTime + (73433 - 58620), StartTime + (73621 - 58620), f * 0.5, 0);
                }
            }
        }

        private void Generate6(StoryboardLayer layer)
        {
            var start = StartTime + (70621 - 58620);
            var end = StartTime + (71839 - 58620);
            if (IsMid)
            {
                for (int i = 0; i < 5; i++)
                {
                    Random(0);
                }
            }

            var sentence = IsMid ? "?????????" : "????????????";
            var postFix = "_2S";
            var width = IsMid ? 180 : 260;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d - 55;
                var y = 240 + Random(-50, 50) - 50;
                var enterTime = start;
                var r = 100;
                var xp = Random(0, 100d) > 50 ? Random(0, 100) : Random(540, 647);
                var yp = Random(0, 100d) > 50 ? Random(280, 380) : Random(100, 200);
                var sprite = layer.CreateSprite(pic, OsbOrigin.TopLeft);
                sprite.Rotate((OsbEasing)13, enterTime, enterTime + 600, Math.PI + Random(Math.PI), 0);
                sprite.MoveX((OsbEasing)13, enterTime, enterTime + 600, xp, x);
                sprite.MoveY((OsbEasing)13, enterTime, enterTime + 600, yp, y);
                if (i == 0) sprite.Scale(end, 1.2);
                else sprite.Scale(end, 1);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                // sprite.Fade(start, 1);
                // sprite.Scale(enterTime, 0.5);
            }
        }

        private void Generate5(StoryboardLayer layer)
        {
            var start = StartTime + (66871 - 58620);
            var end = StartTime + (69121 - 58620);
            var sentence = IsMid ? "?????????????????????" : "??????";
            var postFix = "_1S";
            var height = IsMid ? 230 : 60;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 240 - height / 2d;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX(start, 320);
                sprite.Fade(start, 1);
                sprite.Fade(end, 0);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveY(start, y);
                sprite.Scale(start, IsMid ? 0.5 : 0.7);
                for (int j = 0; j < 135; j++)
                {
                    sprite.MoveX(StartTime + (66871 - 58620) + j * 16.6667, 320 + Random(j) / 30);
                    sprite.MoveY(StartTime + (66871 - 58620) + j * 16.6667, y + Random(j) / 30);
                }
                sprite.Color((OsbEasing)2, start, end, 1, 1, 1, 0.5, 0, 0);
            }
        }

        private void Generate4(StoryboardLayer layer)
        {
            var start = StartTime + (64621 - 58620);
            var sentence = IsMid ? "??????????????????" : "????????????????????????";
            var postFix = "_2S";
            var height = IsMid ? 220 : 300;
            var targetHeightPre = IsMid ? 170 : 240;
            var targetHeight = IsMid ? 150 : 210;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 240 - height / 2d;
                var y2 = targetHeightPre * (i / (double)(sentence.Length - 1)) + 240 - targetHeightPre / 2d;
                var y3 = targetHeight * (i / (double)(sentence.Length - 1)) + 240 - targetHeight / 2d;
                var enterTime = start + i * (66 - i * 2);

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, enterTime, enterTime + 100, 320 + (i % 2 == 0 ? -160 : 160), 320 + (i % 2 == 0 ? -70 : 70));
                sprite.MoveX((OsbEasing)13, enterTime + 100, enterTime + 1200, 320 + (i % 2 == 0 ? -70 : 70), 320);
                // sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveY(0, StartTime + (66121 - 58620), StartTime + (66167 - 58620), y, y2);
                sprite.Scale(0, StartTime + (66121 - 58620), StartTime + (66167 - 58620), 0.5, 0.4);
                sprite.MoveY((OsbEasing)7, StartTime + (66167 - 58620), StartTime + (66683 - 58620), y2, y3);
                sprite.Scale((OsbEasing)7, StartTime + (66167 - 58620), StartTime + (66683 - 58620), 0.4, 0.35);
                // sprite.Fade(start, 1);
                sprite.Scale(StartTime + (66871 - 58620), 0.5);
            }

            var wTargetHeight = (targetHeight + 140);
            var white = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.TopCentre);
            white.MoveY(StartTime + (66589 - 58620), 240 - wTargetHeight / 2);
            white.ScaleVec(0, StartTime + (66589 - 58620), StartTime + (66871 - 58620) - 270,
                0.06, 0, 0.06, (wTargetHeight - 200) / 480d);
            white.ScaleVec((OsbEasing)7, StartTime + (66871 - 58620) - 270, StartTime + (66871 - 58620),
                0.06, (wTargetHeight - 200) / 480d, 0.06, wTargetHeight / 480d);

            var white2 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.BottomCentre);
            white2.MoveY(StartTime + (66871 - 58620), 240 + wTargetHeight / 2);
            white2.ScaleVec(0, StartTime + (66871 - 58620), StartTime + (67152 - 58620) - 270,
                0.06, wTargetHeight / 480d, 0.06, 200 / 480d);
            white2.ScaleVec((OsbEasing)7, StartTime + (67152 - 58620) - 270, StartTime + (67152 - 58620),
                0.06, 200 / 480d, 0.06, 0);

        }

        private void Generate3(StoryboardLayer layer)
        {
            //63402
            var start = StartTime + (63074 - 58620);
            var sentence = IsMid ? "??????" : "?????????";
            var postFix = "_3S";
            var width = IsMid ? 130 : 170;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x0 = width * (i / (float)sentence.Length) + 320 - width / 2 - 200;
                var y0 = 240;
                var shadows = 50;
                var shadowInterval = 1;
                for (int j = 0; j < shadows; j++)
                {
                    var enterTime = start + j * shadowInterval;
                    var sprite = layer.CreateSprite(pic, OsbOrigin.Centre, new Vector2(x0, y0));
                    var offset = (j / (shadows - 1d) - 0.5) * 100;
                    var f = Math.Abs(shadows / 2d - Math.Abs(j - shadows / 2d)) / (shadows / 2d);
                    f = f * f * f;

                    sprite.Scale(enterTime, 0.9);
                    sprite.MoveX((OsbEasing)10, start, StartTime + (63402 - 58620), 320 + offset, x0);
                    sprite.Fade((OsbEasing)0, start, StartTime + (63402 - 58620), 0, f);
                    sprite.Fade(StartTime + (64246 - 58620), 1);
                }
            }
        }

        private void Generate2(StoryboardLayer layer)
        {
            var start = StartTime + (61620 - 58620);
            var sentence = IsMid ? "????????????" : "???????????????";
            var postFix = "_3S";
            var width = IsMid ? 250 : 300;

            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x0 = width * (i / (float)sentence.Length) + 320 - width / 2 + 200;
                var y0 = 240;
                var shadows = 50;
                var shadowInterval = 1;
                for (int j = 1; j < shadows; j++)
                {
                    var enterTime = start + (61808 - 61620) + i * 30 + j * shadowInterval;
                    var sprite = layer.CreateSprite(pic, OsbOrigin.Centre, new Vector2(x0, y0));
                    sprite.Scale(enterTime, 0.9);
                    Action<OsbEasing, double, double, CommandDecimal, CommandDecimal> moveImpl;
                    double @base;
                    int offset;
                    if (i % 4 == 0)
                    {
                        moveImpl = sprite.MoveX;
                        offset = -100;
                        @base = x0;
                    }
                    else if (i % 4 == 1)
                    {
                        moveImpl = sprite.MoveY;
                        offset = -100;
                        @base = y0;
                    }
                    else if (i % 4 == 2)
                    {
                        moveImpl = sprite.MoveX;
                        offset = 100;
                        @base = x0;
                    }
                    else
                    {
                        moveImpl = sprite.MoveY;
                        offset = 100;
                        @base = y0;
                    }

                    moveImpl((OsbEasing)13, enterTime + j * shadowInterval, enterTime + j * shadowInterval + 900, @base + offset, @base);
                    var f = Math.Abs(shadows / 2d - Math.Abs(j - shadows / 2d)) / (shadows / 2d);
                    f = f * f;
                    sprite.Color(enterTime + j * shadowInterval, 1, 1, 1);
                    sprite.Color(StartTime + (62745 - 58620), 0, 0, 0);
                    sprite.Fade((OsbEasing)13, enterTime + j * shadowInterval, enterTime + 900, 0, f);
                }
            }

            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x0 = width * (i / (float)sentence.Length) + 320 - width / 2 + 200;
                var y0 = 240;
                var shadows = 50;
                var shadowInterval = 1;
                for (int j = 0; j < shadows; j++)
                {
                    var enterTime = StartTime + (62745 - 58620) + j * shadowInterval;
                    var sprite = layer.CreateSprite(pic, OsbOrigin.Centre, new Vector2(x0, y0));
                    var offset = (j / (shadows - 1d) - 0.5) * 100;
                    var f = Math.Abs(shadows / 2d - Math.Abs(j - shadows / 2d)) / (shadows / 2d);
                    f = f * f * f;

                    sprite.Scale(enterTime, 0.9);
                    sprite.MoveX((OsbEasing)2, StartTime + (62745 - 58620), StartTime + (63074 - 58620), x0, 320 + offset);
                    sprite.Fade((OsbEasing)0, StartTime + (62745 - 58620), StartTime + (63074 - 58620), f, 0);
                }
            }
        }

        private void Generate1(StoryboardLayer layer)
        {
            var start = StartTime + (58808 - 58620);
            var postFix = "_2S";
            var sentence = IsMid ? "???????????????????????????" : "??????????????????????????????";
            var width = IsMid ? 300 : 350;
            var targetWidthPre = 500;
            var targetWidth = 550;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var x2 = targetWidthPre * (i / (double)(sentence.Length - 1)) + 320 - targetWidthPre / 2d;
                var x3 = targetWidth * (i / (double)(sentence.Length - 1)) + 320 - targetWidth / 2d;
                var enterTime = start + i * (66 - i * 2);

                var sprite = layer.CreateSprite(pic);
                sprite.MoveY((OsbEasing)13, enterTime, enterTime + 700, 240 + (i % 2 == 0 ? -50 : 50), 240);
                sprite.Fade((OsbEasing)7, enterTime, enterTime + 700, 0, 1);
                sprite.MoveX(0, StartTime + (60074 - 58620), StartTime + (60120 - 58620), x, x2);
                sprite.MoveX((OsbEasing)7, StartTime + (60120 - 58620), StartTime + (61058 - 58620), x2, x3);
                // sprite.Fade(start, 1);
                sprite.Scale(StartTime + (61620 - 58620), 0.5);
            }
        }

        private void Kira(StoryboardLayer layer)
        {
            if(Short) return;
            var filterG = layer.CreateSprite(@"SB\components\filter.jpg");
            filterG.Additive(rt(60120));
            filterG.Scale(rt(60120), 2);
            filterG.Fade((OsbEasing)1, rt(60120), rt(60120) + 500, 0, 0.3);
            filterG.Fade((OsbEasing)2, rt(60120) + 500, rt(60120) + 1000, 0.3, 0);
            filterG.MoveY(rt(60120), rt(60120) + 1000, 240, 240 - 100);
            filterG.Rotate(rt(60120), rt(60120) + 1000, 0, -3);

            var filter = layer.CreateSprite(@"SB\components\filter.jpg");
            filter.MoveX(rt(61620), rt(62745), 320 + 200, 320);
            filter.MoveX((OsbEasing)2, rt(62745), rt(63027), 320, 220 - 100);
            filter.MoveX((OsbEasing)1, rt(63027), rt(63308), 220 - 100, -100);
            filter.MoveY(rt(61620), rt(63027), 110, 240 + 200);
            filter.Scale(rt(61620), rt(63027), 1.2, 1.5);
            filter.MoveY(rt(63027), rt(63308), 240 + 200, 110);
            filter.Scale(rt(63027), rt(63308), 1.5, 1.7);
            filter.Additive(rt(61620));
            filter.Fade(rt(61620), rt(61620) + 1000, 0, 0.15);
            filter.Fade((OsbEasing)2, rt(63308), rt(64058), 0.15, 0);

            // var bg = layer.CreateSprite(@"SB\components\white.png");
            // bg.Fade(0, startTime + 26993 - 26558, startTime + 27121 - 26558, 0, 1);
            // bg.Fade((OsbEasing)(faster ? 13 : 1), startTime + 27121 - 26558, startTime + 28621 - 26558, 1, 0);
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
