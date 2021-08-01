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
using System.IO;
using System.Linq;
using System.Text;

namespace StorybrewScripts
{
    public class Lyric3 : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 45120;
        const int One2Eight = (45167 - 45120) / 2;

        public override void Generate()
        {
            var layer = GetLayer("lyric");
            Text1(layer);
            Text2(layer);
        }
        private void Text2(StoryboardLayer layer)
        {
            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            bg.Fade(50370, 51120, 1, 1);
            bg.Color(50370, 0.5, 0, 0);

            for (int i = 0; i < 3; i++)
            {
                double x, y;
                if (i == 0)
                    x = 320;
                else if (i == 1)
                    x = 324;
                else
                    x = 316;

                var hito = layer.CreateSprite(@"SB\cg\waifu_red_h.png");
                hito.Move(50370, 51120 + 500, x, 240, 320, 240);
                hito.Fade(50370, 0.3);
                hito.Fade(51120, 0);
                hito.Additive(50370);
                hito.Scale(50370, 51120, 0.4, 0.38);
                if (i == 1)
                {
                    hito.Color(50370, 1 / 3d, 0, 1 / 5d);
                }
                else if (i == 2)
                {
                    hito.Color(50370, 1 / 3d, 1 / 5d, 0);
                }
            }

            var circle = layer.CreateSprite(@"SB\components\circle1.png");
            circle.Scale((OsbEasing)10, 48120, 48402, 0.5, 1);
            circle.Scale(48402, 48683, 1, 1.05);
            circle.Fade(48402, 48683, 1, 0);

            var unknownWords = new[] { "真実", "恐怖", "悲し", "境界", "約束", "地獄", "楽園", "悪霊" };
            var timings = new[] { 48120, 48683, 49245, 49808, 50370, 51120 };
            var scales = new[] { 0.9, 0.72, 0.54, 0.36, 0.18, 0 };

            var bg2 = layer.CreateSprite(@"SB\components\bg.jpg");
            bg2.Fade(49808, 50370, 1, 1);
            bg2.Scale(49808, 1.5);
            bg2.Color(49808, 0.2, 0, 0.3);

            var bg3 = layer.CreateSprite(@"SB\components\bg.jpg");
            bg3.Fade(49245, 49808, 1, 1);
            bg3.Scale(49245, 2);
            bg3.Color(49245, 0.2, 0.2, 0.2);

            var bgg = layer.CreateSprite(@"SB\components\snow.png");
            bgg.Fade(48120, 49245, 0.3, 0.3);
            bgg.Scale((OsbEasing)12, 48120, 48683, 8.5, 0);

            for (int i = 0; i < 160; i++)
            {
                var word = unknownWords[Random(unknownWords.Length)];
                var w = 90;

                var deg = Random(720d);
                var r = Random(400, 1800);
                var s = Random(0.5d, 1.5d);
                var color = Random(0.1d, 0.8d);
                for (int k = 0; k < word.Length; k++)
                {
                    var c = word[k];
                    var fn = ConvertToFileName(c.ToString(), "_2S");
                    var sprite = layer.CreateSprite(fn);
                    var sprite2 = layer.CreateSprite(fn);
                    var sprite3 = layer.CreateSprite(fn);

                    for (int j = 0; j < timings.Length - 1; j++)
                    {
                        var scale = scales[j];
                        var timing = timings[j];
                        // scale = scale / (s - 0.5);

                        double scaledR = r * scale;
                        var centerX = 320 + scaledR * 1.6 * Math.Cos(deg / 180d * Math.PI);
                        var centerY = 240 + scaledR * 0.9 * Math.Sin(deg / 180d * Math.PI) * (i % 2 == 0 ? 1 : -1);

                        var trueWidth = w * scale * s;
                        var x = trueWidth * (k / (word.Length - 1)) + centerX - trueWidth / 2d;
                        var y = centerY;
                        //--
                        var nextScale = scales[j + 1];
                        var nextTiming = timings[j + 1];
                        // nextScale = nextScale / (s - 0.5);

                        double scaledNextR = r * nextScale;
                        var nextCenterX = 320 + scaledNextR * 1.6 * Math.Cos(deg / 180d * Math.PI);
                        var nextCenterY = 240 + scaledNextR * 0.9 * Math.Sin(deg / 180d * Math.PI) * (i % 2 == 0 ? 1 : -1);

                        var nextTrueWidth = w * nextScale * s;
                        var nextX = nextTrueWidth * (k / (word.Length - 1)) + nextCenterX - nextTrueWidth / 2d;
                        var nextY = nextCenterY;

                        if (j == timings.Length - 2)
                        {
                            sprite.Scale(timing, scale * s);
                            sprite.Move(timing, x, y);
                            if (timing >= 49808)
                            {
                                sprite2.Scale(timing, scale * s);
                                sprite2.Move(timing, x + 3, y);
                                sprite3.Scale(timing, scale * s);
                                sprite3.Move(timing, x - 3, y);
                            }
                        }
                        else
                        {
                            sprite.Scale((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, scale * s, nextScale * s);
                            sprite.Move((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, x, y, nextX, nextY);
                            if (timing >= 49808)
                            {
                                sprite2.Scale((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, scale * s, nextScale * s);
                                sprite2.Move((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, x + 3, y, nextX + 3, nextY);
                                sprite3.Scale((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, scale * s, nextScale * s);
                                sprite3.Move((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, x - 3, y, nextX - 3, nextY);
                            }
                        }
                    }

                    var interval = Random(90, 110);
                    sprite.Color(48120, color, color, color);
                    sprite.Color(49808, 0, color, 0);
                    sprite.Color(50370, color / 3d, 0, 0);
                    sprite.Color(51120, 0, 0, 0);
                    sprite.Additive(48120);
                    sprite.StartLoopGroup(48120, 15);
                    sprite.Fade(0, interval, 1, 0.5);
                    sprite.Fade(0, interval, 2 * interval, 0.5, 1);
                    sprite.EndGroup();

                    sprite2.Color(48120, 0, 0, 0);
                    sprite2.Color(49808, color, 0, 0);
                    sprite2.Color(50370, color / 3d, color / 5d, 0);
                    sprite2.Color(51120, 0, 0, 0);
                    sprite2.Additive(49808);
                    sprite2.StartLoopGroup(48120, 15);
                    sprite2.Fade(0, interval, 0.5, 0.5);
                    sprite2.Fade(0, interval, 2 * interval, 0.5, 1);
                    sprite2.EndGroup();

                    sprite3.Color(48120, 0, 0, 0);
                    sprite3.Color(49808, 0, 0, color);
                    sprite3.Color(50370, color / 3d, 0, color / 5d);
                    sprite3.Color(51120, 0, 0, 0);
                    sprite3.Additive(49808);
                    sprite3.StartLoopGroup(48120, 15);
                    sprite3.Fade(0, interval, 1, 0.5);
                    sprite3.Fade(0, interval, 2 * interval, 0.5, 1);
                    sprite3.EndGroup();
                }
            }

            var sentence = " 憐れなる";
            // var width = 200;
            // timings = new[] { 48120, 49245, 49808, 50370, 51120 };
            var fixedWidth = 180;
            var widths = new[] { fixedWidth, fixedWidth * 2, fixedWidth * 4, fixedWidth * 6,
                fixedWidth * 8, fixedWidth * 10 };
            // scales = new[] { 0.9, 0.54, 0.36, 0.18, 0 };

            var c1 = sentence[1];
            var fn1 = ConvertToFileName(c1.ToString(), "_st_2L");
            var sp = layer.CreateSprite(fn1);
            sp.Scale((OsbEasing)12, timings[0], timings[0] + (timings[1] - timings[0]) / 2, scales[0], scales[0]);
            sp.Scale((OsbEasing)12, timings[0] + (timings[1] - timings[0]) / 2, timings[1], scales[0], scales[1]);
            var trueW = (1d / 854d * 165);
            var trueH = (1d / 480d * 165);
            for (int j = 0; j < 2; j++)
            {
                for (int i = 0; i < 2; i++)
                {
                    var x = 320 - 165 / 2d + i * 165;
                    var y = 240 - 165 / 2d + j * 165;
                    var sprite = layer.CreateSprite(@"SB\components\white.png");
                    sprite.ScaleVec(timings[0], trueW, trueH);
                    sprite.Move(timings[0], x, y);
                    // sprite.Color(timings[0], Random(1d), Random(1d), Random(1d));
                    var st = timings[0];
                    for (int k = 0; k < Random(3, 5); k++)
                    {
                        // var next = st + Random(22, 33);
                        sprite.Fade(st, 1);
                        st += Random(33, 66);
                        sprite.Fade(st, 0);
                        st += Random(33, 66);
                    }
                }
            }

            for (int j = 0; j < timings.Length - 1; j++)
            {
                var width = widths[j];
                var nextWidth = widths[j + 1];
                var scale = scales[j];
                var nextScale = scales[j + 1];
                var timing = timings[j];
                var nextTiming = timings[j + 1];

                var trueWidth = width * scale;
                var nextTrueWidth = nextWidth * nextScale;
                Log(nameof(nextTrueWidth) + ": " + nextTrueWidth);

                for (int i = 0; i <= j; i++)
                {
                    if (i == 0) continue;
                    var c = sentence[i];
                    string fn;
                    if (j == 1)
                        fn = ConvertToFileName(c.ToString(), "_2L");
                    else if (j == 2)
                        fn = ConvertToFileName(c.ToString(), "_st_1L");
                    else if (j == 3)
                        fn = ConvertToFileName(c.ToString(), "_3L");
                    else
                        fn = ConvertToFileName(c.ToString(), "_2L");
                    var x = j == 0 ? 320 : trueWidth * ((i - 0.5) / (double)(j)) + 320 - trueWidth / 2d;
                    var y = 240;

                    var jj = j + 1;
                    var nextX = nextTrueWidth * ((i - 0.5) / (double)(jj)) + 320 - nextTrueWidth / 2d;
                    var nextY = 240;
                    if (i == 0)
                        Log(j + ": " + nextX + " , " + nextY);
                    var sprite = layer.CreateSprite(fn);
                    if (j != timings.Length - 2)
                    {
                        sprite.Scale((OsbEasing)12, timing, timing + (nextTiming - timing) / 5d * 4, scale, scale);
                        sprite.Scale((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, scale, nextScale);
                        sprite.Move((OsbEasing)12, timing, timing + (nextTiming - timing) / 5d * 4, x, y, x, y);
                        sprite.Move((OsbEasing)12, timing + (nextTiming - timing) / 5d * 4, nextTiming, x, y, nextX, nextY);
                    }
                    else
                    {
                        sprite.Scale((OsbEasing)12, timing, nextTiming, scale, scale);
                        sprite.Move((OsbEasing)12, timing, nextTiming, x, y, x, y);
                        sprite.Fade(timing, 0.3);
                        sprite.Additive(timing);
                        sprite.Color((OsbEasing)12, timing, nextTiming, 0.9, 0.1, 0.1, 0.9, 0.1, 0.1);
                        var sprite2 = layer.CreateSprite(fn);
                        sprite2.Scale((OsbEasing)12, timing, nextTiming, scale, scale);
                        sprite2.Move(timing, nextTiming, x + 4, y, x + 1, y);
                        sprite2.Fade(timing, 0.5);
                        sprite2.Color(timing, 0.3, 0.2, 0.0);
                        sprite2.Additive(timing);
                        var sprite3 = layer.CreateSprite(fn);
                        sprite3.Scale((OsbEasing)12, timing, nextTiming, scale, scale);
                        sprite3.Move(timing, nextTiming, x - 4, y, x - 1, y);
                        sprite3.Fade(timing, 0.5);
                        sprite3.Color(timing, 0.3, 0.0, 0.2);
                        sprite3.Additive(timing);
                    }

                    if (timing == 49245)
                    {
                        sprite.Color(timing, 0.2, 0.4, 0.1);
                        sprite.Fade(timing, 0.7);
                    }
                    else if (timing == 49808)
                    {
                        sprite.Color(timing, 0.15, 0.13, 0.5);
                        sprite.Fade(timing, 0.7);
                    }
                }

            }
        }

        private void Text1(StoryboardLayer layer)
        {
            var newStart = StartTime + 45308 - 45120 - One2Eight * 0;
            var newEnd = newStart + 45683 - 45308;
            var ouTransStart = new[] { 45683, 45777, 45870, 45964 };
            var ouTransEnd = 46245/*46058*/- One2Eight;

            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            bg.Fade(StartTime, 0.3);
            bg.Fade(OsbEasing.Out, 45683, 45964, 0.3, 0.1);
            bg.Scale(OsbEasing.Out, StartTime, 47370, 0.9, 0.85);

            var pngName = Enumerable.Range(1, 3);
            var all = pngName.SelectMany(k => new[] { ConvertToFileName("衝", $"_st_{k}S"), ConvertToFileName("衝", $"_{k}S"), }).ToArray();
            var files = new DirectoryInfo(Path.Combine(MapsetPath, "SB", "output")).GetFiles("*S.png").Select(k => $"SB\\output\\{k.Name}").ToArray();
            var size = 40;
            for (int j = 0; j < 13; j++)
            {
                // var count = Random(1, 25);
                var count = 25;
                for (int i = 0; i < count; i++)
                {
                    var finalSize = Random(0.4, 0.8);
                    var preSize = finalSize * 0.5;

                    var finalRotate = Random(0, 0.6) - 0.3;
                    var preRotate = Random(0, 0.6) - 0.3;

                    var randomName = all[Random(all.Length)];
                    var sprite = layer.CreateSprite(randomName);
                    var trueStart = newStart + Random(200);

                    var color = Random(0.5, 0.7);
                    var showRed = Random(2d) >= 1.5;

                    var list = new List<OsbSprite>(){
                        sprite,
                        layer.CreateSprite(files[Random(files.Length)]),
                        // layer.CreateSprite(files[Random(files.Length)]),
                    };

                    var changeTime = ouTransStart[Random(ouTransStart.Length)];

                    for (int index = 0; index < list.Count; index++)
                    {

                        var fs = index == 0 ? finalSize : finalSize * 0.9;
                        OsbSprite item = list[index];
                        item.Move(trueStart, changeTime, -107 + i * size, j * size + Random(0, 20), -107 + i * size, j * size);
                        item.Scale(OsbEasing.OutExpo, trueStart, newEnd, preSize, fs);
                        item.Rotate(OsbEasing.OutExpo, trueStart, newEnd, preRotate, finalRotate);


                        if (index == 0)
                        {
                            item.Fade(trueStart, 0);
                            item.Fade(changeTime, ouTransEnd, 1, 1);

                            if (!showRed)
                                item.Color(trueStart, color, color, color);
                            else
                                item.Color(trueStart, 0.7, 0.1f, 0);

                            item.Move(ouTransEnd, ouTransEnd + One2Eight + Random(One2Eight * 3), -107 + i * size, j * size, -107 + i * size, j * size - 480);
                        }
                        else
                        {
                            item.Fade(OsbEasing.OutExpo, trueStart, newEnd, 0, 1);
                            item.Fade(changeTime, 1);
                        }
                    }
                }
            }

            // var word1 = layer.CreateSprite(ConvertToFileName("衝", "_st_1L"), OsbOrigin.Centre, new Vector2(170, 210));
            // word1.Scale(OsbEasing.OutCubic, StartTime, StartTime + One2Eight * 6, 2, 0.5);
            // word1.Fade(StartTime, StartTime + One2Eight * 2, 1, 1);
            // word1.Fade(StartTime + One2Eight * 2, 0);
            // word1.Fade(StartTime + One2Eight * 4, StartTime + One2Eight * 6, 1, 1);
            // var word1_s = layer.CreateSprite(ConvertToFileName("衝", "_1L"), OsbOrigin.Centre, new Vector2(170, 210));
            // word1_s.Scale(OsbEasing.OutCubic, StartTime, StartTime + One2Eight * 6, 2, 0.5);
            // word1_s.Fade(StartTime, 0);
            // word1_s.Fade(StartTime + One2Eight * 2, StartTime + One2Eight * 4, 1, 1);

            DrawLines(layer, StartTime);
            DrawLines(layer, 45683, 10, 300);

            var allPostFixes = new[] { "_1L", "_2L", "_3L", "_st_1L", "_st_2L", "_st_3L", };
            // 47558
            for (int i = 0; i < 30; i++)
            {
                var interval = 33 - i * 0.5;
                // var postFix = allPostFixes[Random(allPostFixes.Length)];
                // var file = ConvertToFileName(word, postFix);
                var file = files[Random(files.Length)];
                var sprite = layer.CreateSprite(file);
                var x = Random(-107 + 50, 747 - 50);
                var y = Random(0, 480);
                sprite.Move(0, 45214 + i * interval, 45214 + i * interval + 55, x, y, x, y);
                sprite.Scale(45214 + i * interval, 1 - i * 0.02);
                sprite.Rotate(45214 + i * interval, -0.3);
            }

            var chong = ConvertToFileName("衝", "_2L");
            var chongSprite = layer.CreateSprite(chong);
            chongSprite.Rotate(45214, 45495, -0.3, -0.3);
            chongSprite.Scale((OsbEasing)10, 45214, 45495, 0.9, 0.5);
            var interv = 22;
            int jj = 0;
            for (jj = 0; jj < 6; jj += 2)
            {
                chongSprite.Fade(45214 + jj * interv, 0);
                chongSprite.Fade(45214 + (jj + 1) * interv, 1);
            }

            chongSprite.Fade(45214 + jj * interv, 0);

            DrawLines(layer, StartTime + 46245 - 45120);
            DrawLines(layer, StartTime + 46808 - 45120, 5, 300);

            // int startTime = StartTime;
            // double targetSize = 0.5;
            // double originalSize = targetSize * 1.5;
            // SetAction("衝", "1", "3", layer, new Vector2(80, 110), startTime, targetSize, originalSize);

            // startTime = StartTime + One2Eight * 2;
            // targetSize = 0.6;
            // originalSize = targetSize * 1.5;
            // SetAction("衝", "2", "1", layer, new Vector2(310, 240), startTime, targetSize, originalSize);

            // startTime = StartTime + One2Eight * 4;
            // targetSize = 0.4;
            // originalSize = targetSize * 1.5;
            // SetAction("衝", "3", "2", layer, new Vector2(570, 280), startTime, targetSize, originalSize);

            // 47558
            for (int i = 0; i < 30; i++)
            {
                var interval = 33 - i * 0.5;
                // var postFix = allPostFixes[Random(allPostFixes.Length)];
                // var file = ConvertToFileName(word, postFix);
                var file = files[Random(files.Length)];
                var sprite = layer.CreateSprite(file);
                var x = Random(-107 + 50, 747 - 50);
                var y = Random(0, 480);
                sprite.Move(0, 46245 + i * interval, 46245 + i * interval + 55, x, y, x, y);
                sprite.Scale(46245 + i * interval, 1 - i * 0.02);
                sprite.Rotate(46245 + i * interval, 0.3);
            }

            var tuSt = ConvertToFileName("突", "_st_2L");
            var tuSpriteSt = layer.CreateSprite(tuSt);
            tuSpriteSt.Fade((OsbEasing)13, 46995, 47370, 0, 0.3);
            tuSpriteSt.Rotate(46995, 47370, 0.3, 0.3);
            tuSpriteSt.Scale(46995, 0.9);
            tuSpriteSt.Color(46995, 0.9, 0, 0);

            var tu = ConvertToFileName("突", "_2L");
            var tuSprite = layer.CreateSprite(tu);
            tuSprite.Rotate(46620, 47370, 0.3, 0.3);
            tuSprite.Scale((OsbEasing)10, 46620, 47370, 0.9, 0.5);
            var interv2 = 22;
            for (int i = 0; i < 10; i += 2)
            {
                tuSprite.Fade(46620 + i * interv2, 0);
                tuSprite.Fade(46620 + (i + 1) * interv2, 1);
            }

            {
                // var bg2 = layer.CreateSprite(@"SB\components\bg.jpg");
                // bg2.Fade(47370, 48120, 1, 1);
                var w2 = layer.CreateSprite(@"SB\components\white.png");
                w2.Fade(47370, 48120, 1, 1);
                w2.Color((OsbEasing)6, 47370, 48120, 0.95, 0.95, 0.95, 0.3, 0.05, 0.05);

                var hito = layer.CreateSprite(@"SB\cg\waifu_red_w.png");
                hito.MoveY((OsbEasing)7, 47370, 48320, 50, 490);
                hito.Color(47370, 48320, 0.7, 0.7, 0.7, 0.4, 0.05, 0.05);
                hito.Scale((OsbEasing)2, 47370, 48320, 0.7, 0.9);
                hito.MoveX(47370, 48320, 320, 270);
                hito.Fade((OsbEasing)2, 48120, 48320, 0.3, 0);

                var interval = 22;
                //衝突破滅
                var sentence = "衝突破滅";
                var height = 200;

                for (int i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var fn = ConvertToFileName(c.ToString(), "_st_1S");
                    var x = 320 + 5;
                    var y = height * (i / (double)(sentence.Length - 1)) + 235 - height / 2d;
                    var sprite = layer.CreateSprite(fn);
                    var start = 47370 + i * 99;
                    sprite.MoveX((OsbEasing)1, 47370, 48120, x, x - 10);
                    sprite.MoveY((OsbEasing)13, 47370, 48120, y, y + 10);
                    sprite.Scale(start, 0.7);
                    if (start != 47370)
                        sprite.Fade(47370, 0);
                    sprite.Fade(start, 0.25);
                    sprite.Color(start, 0.9, 0, 0);
                }

                for (int i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var fn = ConvertToFileName(c.ToString(), "_1S");
                    var y = height * (i / (double)(sentence.Length - 1)) + 240 - height / 2d;
                    var sprite = layer.CreateSprite(fn);
                    var start = 47370 + i * 99;
                    // sprite.Scale(start, 0.7);
                    // sprite.Color(start, 0.9, 0.9, 0.9);
                    sprite.Color((OsbEasing)7, 47370, 48120, 0.05, 0.05, 0.05, 0.5, 0.05, 0.05);
                    sprite.Fade(47370, 1);
                    sprite.Fade(48120, 0);
                    for (int j = 0; j < 40; j++)
                    {
                        sprite.MoveY(start + j * Random(16, 25), y + Random(-1, 1));
                        sprite.MoveX(start + j * Random(16, 25), 320 + Random(-1, 1));
                    }
                    sprite.Scale(48120, 0.7);
                }

                var w = layer.CreateSprite(@"sb\components\white.png", OsbOrigin.BottomCentre);
                w.ScaleVec((OsbEasing)9, 47370 + 200, 48120 - 100, 0.1, 0.2, 0.1, 0);
                w.MoveY((OsbEasing)13, 47370, 48120, 180, 390);
                w.Fade(47370, 1);
                w.Color((OsbEasing)7, 47370, 48120, 0.05, 0.05, 0.05, 0.5, 0.05, 0.05);
                for (int i = 0; i < 30; i++)
                {
                    w.MoveX(47370 + i * Random(16, 25), 320 + Random(-1, 1));
                }

                for (int i = 0; i < 12; i += 2)
                {
                    w.Fade(47370 + 100 + i * interval, 0);
                    w.Fade(47370 + 100 + (i + 1) * interval, 1);
                }

                DrawLines2(layer, StartTime + 47370 - 45120, 30, true);

                var waku = layer.CreateSprite(@"SB\components\waku.png");
                waku.Fade(StartTime + 47370 - 45120, StartTime + 48120 - 45120, 1, 1);
                waku.ScaleVec(StartTime, 2.652173913043478 * 1.02, 1.983471074380165 * 1.02);
                for (int i = 0; i < 30; i++)
                {
                    waku.Move(47370 + i * Random(16, 25), 320 + Random(-2, 2), 240 + Random(-2, 2));
                }
            }
        }

        private void DrawLines2(StoryboardLayer layer, int startTime, int count = 3, bool isBlack = false)
        {
            for (int i = 0; i < count; i++)
            {
                var line = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
                var Length = 200 + Random(200);
                var trueStart = startTime + i * Random(16, 66);
                line.ScaleVec(trueStart, trueStart + Random(16, 66), Length, 0.75, Length, 0.75);
                line.Move(trueStart, Random(640), Random(380) + 50);
                line.Rotate(trueStart, Random(Math.PI * 2));
                line.Fade(trueStart, Random(0.1, 0.4));
                if (isBlack) line.Color(trueStart, 0.1, 0.1, 0.1);
            }
        }

        private void DrawLines(StoryboardLayer layer, int startTime, int count = 3, int randomStart = 100)
        {
            for (int i = 0; i < count; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    Random(0);
                }

                var line = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
                var Length = 200 + Random(200);
                var trueStart = startTime + Random(randomStart);
                line.ScaleVec(trueStart, trueStart + 100, Length, 0.75, Length, 0.75);
                line.Move(trueStart, Random(640), Random(380) + 50);
                line.Rotate(trueStart, Random(Math.PI * 2));
                line.Fade(trueStart, 0.3);
            }
        }

        private void SetAction(string word, string font, string changeFont, StoryboardLayer layer, Vector2 position, int startTime, double targetSize, double? originalSize = null)
        {
            if (originalSize == null) originalSize = 2;

            var word2 = layer.CreateSprite(ConvertToFileName(word, "_st_" + font + "L"), OsbOrigin.Centre, position);
            word2.Scale(OsbEasing.Out, startTime, startTime + One2Eight * 3, originalSize.Value, targetSize);
            word2.Fade(startTime, startTime + One2Eight * 2, 1, 1);
            word2.Fade(startTime + One2Eight * 2, 0);
            word2.Fade(startTime + One2Eight * 4, startTime + One2Eight * 6, 1, 1);

            const int offset = 75;
            var position1 = new Vector2(position.X + Random(-offset, offset), position.Y + Random(-offset, offset));
            var word2_s = layer.CreateSprite(ConvertToFileName(word, "_" + changeFont + "L"), OsbOrigin.Centre, position1);
            word2_s.Scale(OsbEasing.None, startTime, startTime + One2Eight * 3, originalSize.Value, targetSize);
            word2_s.Fade(startTime, 0);
            word2_s.Fade(startTime + One2Eight * 2, startTime + One2Eight * 4, 1, 1);
            word2_s.Fade(startTime + One2Eight * 4, 0);
        }

        private static string ConvertToFileName(string name, string postFix)
        {
            var fileName =
                Convert.ToBase64String(Encoding.UTF8.GetBytes(name))
                    .Replace("\\", "$a$")
                    .Replace("/", "$b$")
                    .Replace(":", "$c$")
                    .Replace("*", "$d$")
                    .Replace("?", "$e$")
                    .Replace("\"", "$f$")
                    .Replace("<", "$g$")
                    .Replace(">", "$h$")
                    .Replace("|", "$i$")
                    .Replace(",", "$1$")
                    .Replace("'", "$2$")
                + postFix + ".png";
            return @"SB\output\" + fileName;
        }
    }
}
