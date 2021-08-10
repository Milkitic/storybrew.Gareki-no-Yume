using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Animations;
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
    public class Solo : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            var bg = layer.CreateSprite(@"SB\components\bg_solo.jpg");
            bg.Fade(0, 147121, 174121, 1, 1);
            bg.Scale(147121, 0.4447916666666667);
            bg.Color(147121, 1, 0.5, 0.8);
            bg.Color(159121, 1, 1, 1);

            Preshow(layer);
            TextShow1(layer);
            TextShow2(layer);
            TextShow3(layer);
            TextShow4(layer);
            TextShow5(layer);
            TextShow6(layer);
            TextShow7(layer);
            TextShowCycle8(layer);
            TextShowEnter(layer, 164886, 166386, "Artist", 100, "電気式華憐音楽集団", 270);
            TextShowEnter(layer, 166386, 167886, "Title", 70, "瓦礫の夢", 100);
            TextShowEnter(layer, 167886, 169011, "MV Reference", 240, "幽閉サテライト-明日散る運命なら", 500, false);
            TextShowEnter(layer, 169011, 170886, "Source Game", 250, "サクラノモリ†ドリーマーズ", 330);
            TextShowEnter(layer, 170886, 171636, "Lyric", 80, "華憐", 35, true);
            TextShowEnter(layer, 171636, 172386, "Compose", 150, "電気", 35, true);
            //TextShowEnter(layer, 172386, 173136, "Beatmap", 150, "Dored", 80, true, "_1S");
            TextShowEnter(layer, 173136, 174121, "Storyboard", 200, "yf_bmp", 90, false, "_1S");
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
                { accOffset = 200; trueOffset = 1200; }
                else if (speed == false)
                { accOffset = 150; trueOffset = 800; }
                else if (speed == true)
                { accOffset = 130; trueOffset = 700; }

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
                { accOffset = 110 / 2; trueOffset = 600 / 2; }
                else if (speed == null)
                { accOffset = 150 / 2; trueOffset = 800 / 2; }
                else if (speed == false)
                { accOffset = 130 / 2; trueOffset = 700 / 2; }

                var ggOffset = EasingFunctions.QuartOut((i / (double)(str2.Length - 1) / 3d)) * trueOffset / 1.5d;
                sprite.Fade(start + ggOffset, 1);
                sprite.MoveY(start + ggOffset, start + accOffset + ggOffset, y1, y2);
                sprite.MoveY((OsbEasing)10, start + accOffset + ggOffset, start + trueOffset + ggOffset, y2, y3);
                sprite.MoveX(end, x);
                sprite.Scale(end, 0.4);
                sprite.Fade(end, 0);
            }
        }

        private void TextShowCycle8(StoryboardLayer layer)
        {
            for (int i = 0; i < 18; i++)
            {
                var pic = ConvertToFileName("界", "_1S");
                var sprite = layer.CreateSprite(pic);
                var scale = 1.8;
                var targetScale = 0.66;
                var start = 164183d;
                var end = 164746d;
                var deg = 360d / 18 * i;
                var endDeg = 360d / 18 * i + 240;

                var frames = 20d;
                for (int j = 0; j < frames; j++)
                {

                    var actualScale = scale + (targetScale - scale) * EasingFunctions.QuartOut((j / frames));
                    var actualScaleNext = scale + (targetScale - scale) * EasingFunctions.QuartOut(((j + 1) / frames));
                    var actualStart = start + (end - start) * (j / frames);
                    var actualEnd = start + (end - start) * ((j + 1) / frames);
                    var actualDeg = deg + (endDeg - deg) * (j / frames);
                    var actualDegNext = deg + (endDeg - deg) * ((j + 1) / frames);

                    Log(actualScale);
                    var r = 200 * actualScale;
                    var s = 0.75 * actualScale;
                    var r_single = (actualDeg + 90) / 180 * Math.PI;

                    var centerX = 320 + r * Math.Cos(actualDeg / 180d * Math.PI);
                    var centerY = 240 + r * Math.Sin(actualDeg / 180d * Math.PI);

                    var r2 = 200 * actualScaleNext;
                    var s2 = 0.75 * actualScaleNext;
                    var r_single2 = (actualDegNext + 90) / 180 * Math.PI;

                    var centerX2 = 320 + r2 * Math.Cos(actualDegNext / 180d * Math.PI);
                    var centerY2 = 240 + r2 * Math.Sin(actualDegNext / 180d * Math.PI);

                    sprite.Move(actualStart, actualEnd, centerX, centerY, centerX2, centerY2);
                    sprite.Scale(actualStart, actualEnd, s, s2);
                    sprite.Rotate(actualStart, actualEnd, r_single, r_single2);
                }
            }

            var jieL = ConvertToFileName("界", "_2L");
            var jie = layer.CreateSprite(jieL);
            jie.Move(164746, 164792, 320, 240, 320, 240);
            jie.Scale(164746, 0.3);

            var start1 = 164792;
            var end1 = 164816;
            var postFix = "_2S";
            var sentence = "何処に堕ちるの ";
            var width = 300;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start1, end1, x, x);
                sprite.MoveY((OsbEasing)0, start1, end1, y, y);
                sprite.Scale(start1, 0.5);
            }

            var tiao = layer.CreateSprite(@"SB\components\white.png");
            tiao.ScaleVec(164816, 164886, 0.5, 0.08, 0.5, 0.08);
            tiao.Move(164816, 330, 230);
            var tiao2 = layer.CreateSprite(@"SB\components\white.png");
            tiao2.ScaleVec(164839, 164886, 0.5, 0.085, 0.5, 0.085);
            tiao2.Move(164839, 140, 60);
            var tiao3 = layer.CreateSprite(@"SB\components\white.png");
            tiao3.ScaleVec(164839, 164886, 0.5, 0.08, 0.5, 0.08);
            tiao3.Move(164839, 730, 417);
            for (int i = 0; i < 12; i++)
            {
                Random(0);
            }
            for (int i = 0; i < 10; i++)
            {
                var x = Random(-107 + 100, 747 - 100);
                var y = Random(-30, 480 + 30);
                var vy = Random(0.015, 0.08);
                var vx = Random(0.1, 0.6);
                var tiaog = layer.CreateSprite(@"SB\components\white.png");
                tiaog.ScaleVec(164863, 164886, 0.5, vy, 0.5, vy);
                tiaog.Move(164863, x, y);
            }
        }

        private void TextShow7(StoryboardLayer layer)
        {
            var unknownWords = new[] { "真実", "恐怖", "悲し", "境界", "約束", "地獄", "楽園", "悪霊" };
            for (int j = 0; j < 11; j++)
            {
                Random(0);
                if (Random(1d) > 0.7) continue;
                var start = 163691 + j * (163714 - 163691);
                var end = 163714 + j * (163714 - 163691);
                var postFix = "_2L";
                var sentence = unknownWords[Random(unknownWords.Length)];
                var scale = Random(0.1, 0.7);
                var width = 58 / 0.15 * scale;
                var baseY = Random(+100, 480 - 100);
                var baseX = Random(-107 + 100, 747 - 100);
                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var x = width * (i / (double)(sentence.Length - 1)) + baseX - width / 2d;
                    var y = baseY;
                    var sprite = layer.CreateSprite(pic);
                    sprite.MoveX((OsbEasing)0, start, end, x, x);
                    sprite.MoveY((OsbEasing)0, start, end, y, y);
                    sprite.Scale(start, scale);
                }
            }
        }

        private void TextShow6(StoryboardLayer layer)
        {
            var start = 161206;
            var end = 161230;
            var postFix = "_2S";
            var sentence = "悪霊";
            var width = 33;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = width * (i / (double)(sentence.Length - 1)) + 240 - width / 2d;
                var x = 320;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.35);
            }

            start = 161253;
            end = 161277;
            postFix = "_2S";
            sentence = "悪霊";
            width = 80;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = width * (i / (double)(sentence.Length - 1)) + 240 - width / 2d;
                var x = 320;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.9);
            }

            Random(10);
            Random(10);
            for (int j = 0; j < 4; j++)
            {
                start = 161300;
                end = 161839;
                postFix = "_2S";
                sentence = "悪霊";
                width = 33;
                var x = Random(-107 + 100, 747 - 100);
                var yOff = Random(-15, 15);
                var tOff = Random(150);
                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var y = width * (i / (double)(sentence.Length - 1)) + 130 - width / 2d;
                    y = y + yOff;
                    var sprite = layer.CreateSprite(pic);
                    sprite.MoveX((OsbEasing)0, start, end, x, x);
                    sprite.MoveY((OsbEasing)7, start, start + 300 + tOff, y, y - 165);
                    sprite.Scale(start, 0.35);
                }
            }

            for (int j = 0; j < 5; j++)
            {
                start = 161324;
                end = 161839;
                postFix = "_2S";
                sentence = "悪霊";
                width = 33;
                var x = Random(-107 + 100, 747 - 100);
                var yOff = Random(-15, 15);
                var tOff = Random(150);
                var intv = 77;
                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var y = width * (i / (double)(sentence.Length - 1)) + 130 - width / 2d;
                    y = y + yOff;
                    var sprite = layer.CreateSprite(pic);
                    sprite.MoveX((OsbEasing)0, start + j * intv, end + j * intv, x, x);
                    sprite.MoveY((OsbEasing)7, start + j * intv, start + j * intv + 300 + tOff, y, y - 175);
                    sprite.Scale(start + j * intv, 0.35);
                }
            }

            var count = 40d;
            var intvst = 55d;
            for (int j = 0; j < count; j++)
            {
                start = 162027;
                end = 163621;
                postFix = "_2L";
                sentence = "悪霊";
                width = 40;
                var width0 = 180d;
                var y = Random(+30, 480 - 70);
                var x = Random(-107 + 30, 747 - 80);
                var tOff = Random(150);
                var intv = intvst - j * (intvst / count);
                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var actualX1 = width * (i / (double)(sentence.Length - 1)) + x - width / 2d;
                    var sprite3 = layer.CreateSprite(pic);
                    sprite3.Color(162964, 0.1, 0.1, 0.1);
                    sprite3.MoveX(162964, actualX1 + 4);
                    sprite3.MoveY(162964, y + 4);
                    sprite3.Scale(162964, 0.1);
                    sprite3.Fade(end, 0.7);
                }

                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var actualX1 = width * (i / (double)(sentence.Length - 1)) + x - width / 2d;
                    var sprite2 = layer.CreateSprite(pic);
                    sprite2.MoveX(162964, actualX1 + 2);
                    sprite2.MoveY(162964, y + 2);
                    sprite2.Scale(162964, 0.1);
                    sprite2.Fade(end, 0.2);
                }

                for (var i = 0; i < sentence.Length; i++)
                {
                    var c = sentence[i];
                    var pic = ConvertToFileName(c.ToString(), postFix);
                    var actualX0 = width0 * (i / (double)(sentence.Length - 1)) + x - width0 / 2d;
                    var actualX1 = width * (i / (double)(sentence.Length - 1)) + x - width / 2d;

                    var sprite = layer.CreateSprite(pic);
                    sprite.Color(start + j * intv, 1, 1, 1);
                    sprite.MoveX((OsbEasing)13, start + j * intv, start + j * intv + 300 + tOff, actualX0, actualX1);
                    sprite.MoveY((OsbEasing)13, start + j * intv, start + j * intv + 300 + tOff, y, y);
                    sprite.Scale((OsbEasing)13, start + j * intv, start + j * intv + 300 + tOff, 0.47, 0.1);
                    sprite.Fade(end, 1);
                    sprite.Color(162964, 1, 1, 0.8);
                }
            }

            start = 163621;
            end = 163644;
            postFix = "_2L";
            sentence = "悪霊";
            width = 340;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.85);
            }

            start = 163644;
            end = 163667;
            postFix = "_2S";
            sentence = "悪霊に魅入られた真実";
            width = 340;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.45);
            }
        }

        private void TextShow5(StoryboardLayer layer)
        {
            var start = 161042;
            var end = 161113;
            var postFix = "_2L";
            var sentence = "幻想";
            var width = 690;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 1.5);
            }

            start = 161136;
            end = 161183;
            postFix = "_2L";
            sentence = "幻想";
            width = 190;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 235;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.45);
            }
        }

        private void TextShow4(StoryboardLayer layer)
        {
            var start = 160714;
            var end = 160761;
            var postFix = "_2S";
            var sentence = "何を探すの···";
            var width = 270;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 350 - width / 2d;
                var y = 235;
                if (i >= 5)
                {
                    x = 325 + i * 15;
                }
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                if (i >= 5)
                {
                    sprite.Scale(start, 0.7);
                }
                else
                {
                    sprite.Scale(start, 0.45);
                }
            }

            start = 160761;
            end = 160808;
            postFix = "_2S";
            sentence = "何を";
            width = 40;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 235;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.45);
            }

            start = 160808;
            end = 160855;
            postFix = "_2S";
            sentence = "何を";
            width = 30;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.35);
            }

            start = 160855;
            end = 160902;
            postFix = "_2S";
            sentence = "何を";
            width = 80;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 235;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.95);
            }

            start = 160855;
            end = 160902;
            postFix = "_1S";
            sentence = "what";
            width = 70;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 325 - width / 2d;
                var y = 325;
                if (i == 0) x -= 4;
                else if (i == 3) x -= 4;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.65);
            }

            start = 160996;
            end = 161042;
            postFix = "_2S";
            sentence = "何を探すの···";
            width = 270;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 350 - width / 2d;
                var y = 235;
                if (i >= 5)
                {
                    x = 325 + i * 15;
                }
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                if (i >= 5)
                {
                    sprite.Scale(start, 0.7);
                }
                else
                {
                    sprite.Scale(start, 0.45);
                }
            }
        }

        private void TextShow3(StoryboardLayer layer)
        {
            var startTime = 160199;
            var points = new[] { new Vector2(312, 48), new Vector2(288, 60), new Vector2(300, 60), new Vector2(312, 60), new Vector2(324, 60), new Vector2(24, 72), new Vector2(36, 72), new Vector2(48, 72), new Vector2(60, 72), new Vector2(180, 72), new Vector2(192, 72), new Vector2(204, 72), new Vector2(216, 72), new Vector2(228, 72), new Vector2(240, 72), new Vector2(252, 72), new Vector2(264, 72), new Vector2(276, 72), new Vector2(288, 72), new Vector2(300, 72), new Vector2(312, 72), new Vector2(324, 72), new Vector2(72, 84), new Vector2(84, 84), new Vector2(96, 84), new Vector2(108, 84), new Vector2(120, 84), new Vector2(132, 84), new Vector2(144, 84), new Vector2(156, 84), new Vector2(180, 84), new Vector2(192, 84), new Vector2(204, 84), new Vector2(216, 84), new Vector2(84, 96), new Vector2(96, 96), new Vector2(108, 96), new Vector2(192, 96), new Vector2(204, 96), new Vector2(84, 108), new Vector2(96, 108), new Vector2(192, 108), new Vector2(204, 108), new Vector2(84, 120), new Vector2(96, 120), new Vector2(192, 120), new Vector2(204, 120), new Vector2(84, 132), new Vector2(96, 132), new Vector2(192, 132), new Vector2(204, 132), new Vector2(72, 144), new Vector2(84, 144), new Vector2(96, 144), new Vector2(132, 144), new Vector2(144, 144), new Vector2(156, 144), new Vector2(192, 144), new Vector2(204, 144), new Vector2(276, 144), new Vector2(288, 144), new Vector2(300, 144), new Vector2(72, 156), new Vector2(84, 156), new Vector2(96, 156), new Vector2(108, 156), new Vector2(120, 156), new Vector2(132, 156), new Vector2(144, 156), new Vector2(156, 156), new Vector2(168, 156), new Vector2(204, 156), new Vector2(264, 156), new Vector2(276, 156), new Vector2(288, 156), new Vector2(300, 156), new Vector2(312, 156), new Vector2(72, 168), new Vector2(84, 168), new Vector2(144, 168), new Vector2(156, 168), new Vector2(168, 168), new Vector2(204, 168), new Vector2(264, 168), new Vector2(276, 168), new Vector2(288, 168), new Vector2(72, 180), new Vector2(84, 180), new Vector2(144, 180), new Vector2(156, 180), new Vector2(168, 180), new Vector2(204, 180), new Vector2(216, 180), new Vector2(252, 180), new Vector2(264, 180), new Vector2(276, 180), new Vector2(60, 192), new Vector2(72, 192), new Vector2(144, 192), new Vector2(156, 192), new Vector2(168, 192), new Vector2(204, 192), new Vector2(216, 192), new Vector2(228, 192), new Vector2(240, 192), new Vector2(252, 192), new Vector2(264, 192), new Vector2(60, 204), new Vector2(72, 204), new Vector2(84, 204), new Vector2(144, 204), new Vector2(156, 204), new Vector2(168, 204), new Vector2(204, 204), new Vector2(216, 204), new Vector2(228, 204), new Vector2(240, 204), new Vector2(60, 216), new Vector2(72, 216), new Vector2(84, 216), new Vector2(96, 216), new Vector2(144, 216), new Vector2(156, 216), new Vector2(204, 216), new Vector2(216, 216), new Vector2(228, 216), new Vector2(48, 228), new Vector2(60, 228), new Vector2(96, 228), new Vector2(108, 228), new Vector2(120, 228), new Vector2(132, 228), new Vector2(144, 228), new Vector2(156, 228), new Vector2(216, 228), new Vector2(228, 228), new Vector2(48, 240), new Vector2(108, 240), new Vector2(120, 240), new Vector2(132, 240), new Vector2(144, 240), new Vector2(156, 240), new Vector2(216, 240), new Vector2(228, 240), new Vector2(36, 252), new Vector2(120, 252), new Vector2(132, 252), new Vector2(144, 252), new Vector2(216, 252), new Vector2(228, 252), new Vector2(132, 264), new Vector2(144, 264), new Vector2(216, 264), new Vector2(228, 264), new Vector2(324, 264), new Vector2(120, 276), new Vector2(132, 276), new Vector2(216, 276), new Vector2(228, 276), new Vector2(324, 276), new Vector2(120, 288), new Vector2(216, 288), new Vector2(228, 288), new Vector2(324, 288), new Vector2(96, 300), new Vector2(108, 300), new Vector2(120, 300), new Vector2(216, 300), new Vector2(228, 300), new Vector2(324, 300), new Vector2(84, 312), new Vector2(96, 312), new Vector2(108, 312), new Vector2(204, 312), new Vector2(216, 312), new Vector2(228, 312), new Vector2(312, 312), new Vector2(324, 312), new Vector2(60, 324), new Vector2(72, 324), new Vector2(84, 324), new Vector2(96, 324), new Vector2(204, 324), new Vector2(216, 324), new Vector2(228, 324), new Vector2(240, 324), new Vector2(252, 324), new Vector2(264, 324), new Vector2(276, 324), new Vector2(288, 324), new Vector2(300, 324), new Vector2(312, 324), new Vector2(324, 324), new Vector2(336, 324), new Vector2(48, 336), new Vector2(60, 336), new Vector2(72, 336), new Vector2(84, 336), new Vector2(216, 336), new Vector2(228, 336), new Vector2(240, 336), new Vector2(252, 336), new Vector2(264, 336), new Vector2(276, 336), new Vector2(288, 336), new Vector2(300, 336), new Vector2(312, 336), new Vector2(324, 336), new Vector2(336, 336), new Vector2(24, 348), new Vector2(36, 348), new Vector2(48, 348), new Vector2(60, 348), new Vector2(72, 348), new Vector2(36, 360) };

            var start = 160199;
            var end = 160456;
            foreach (var point in points)
            {
                // if (Random(1d) > 0.7) continue;
                var pic = ConvertToFileName("痛", "_1S");
                var x = point.X;
                var y = point.Y;

                var sprite = layer.CreateSprite(pic);
                var ox = Random(-47 - 50, 687 + 50);
                var oy = Random(50 - 100, 430 + 100);
                if (Random(1d) >= 0.5)
                {
                    sprite.MoveX(start, ox);
                    sprite.MoveX((OsbEasing)13, start + Random(0, 100), end, ox, x * 1.2 + 100);
                    sprite.MoveY(start, y * 1.2);
                }
                else
                {
                    sprite.MoveY(start, oy);
                    sprite.MoveY((OsbEasing)13, start + Random(0, 100), end, oy, y * 1.2);
                    sprite.MoveX(start, x * 1.2 + 100);
                }
                sprite.Scale(start, 0.3);
            }

            var shi = ConvertToFileName("死", "_1L");
            var sprite1 = layer.CreateSprite(shi);
            sprite1.Move(160480, 160503, 320, 240, 320, 240);
            sprite1.Scale(160480, 0.67);

            var start1 = 160527;
            var end1 = 160550;
            foreach (var point in points)
            {
                // if (Random(1d) > 0.7) continue;
                var pic = ConvertToFileName("痛", "_1S");
                var x = point.X;
                var y = point.Y;

                var sprite = layer.CreateSprite(pic);

                sprite.MoveX(start1, x * 1.2 * 0.37 + 240);
                sprite.MoveY(start1, end1, y * 1.2 * 0.37 + 150, y * 1.2 * 0.37 + 150);

                sprite.Scale(start1, 0.3 * 0.37);
            }

            var e = ConvertToFileName("悪", "_2L");
            var eSprite = layer.CreateSprite(e);
            eSprite.Move(160574, 160597, 320, 240, 320, 240);
            eSprite.Scale(160574, 0.8);
            eSprite.Scale(160597, 160621, 1.3, 1.3);
        }

        private void TextShow2(StoryboardLayer layer)
        {
            var start = 159777;
            var end = 159871;
            var postFix = "_2S";
            var sentence = "狂え染まれ目醒めよ";
            var width = 270;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 220;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.4);
            }

            start = 159871;
            end = 159917;
            postFix = "_2L";
            sentence = "救え";
            width = 200;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.55);
            }

            start = 159964;
            end = 160011;
            postFix = "_st_2L";
            sentence = "救え";
            width = 200;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.55);
            }

            start = 160011;
            end = 160058;
            postFix = "_2S";
            sentence = "死者の";
            width = 70;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.4);
            }

            start = 160058;
            end = 160105;
            postFix = "_2L";
            sentence = "死者の";
            width = 370;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 220;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.5);
            }

            start = 160105;
            end = 160152;
            postFix = "_2L";
            sentence = "救え死者の痛みを";
            width = 640;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 325 - width / 2d;
                var y = 240;

                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start, 0.27);
            }
        }

        private void TextShow1(StoryboardLayer layer)
        {
            for (int i = 0; i < 4; i++)
            {
                FuckingTextShow(layer, 159121 + i * (159167 - 159121), 159167 + i * (159167 - 159121), true);
            }

            FuckingTextShow(layer, 159308, 159449, false);
            var tiao = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.CentreLeft);
            tiao.ScaleVec(159402, 159449, 0.36, 0.075, 0.36, 0.075);
            tiao.Move(159402, -45, 240);

            var tiao2 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.CentreLeft);
            tiao2.ScaleVec(159496, 159542, 0.36, 0.075, 0.36, 0.075);
            tiao2.Move(159496, -45, 240);
            var tiao2_0 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.CentreLeft);
            tiao2_0.ScaleVec(159496, 159542, 0.425, 0.075, 0.425, 0.075);
            tiao2_0.Move(159496, -45 - 5, 240 - 60);
            var tiao2_2 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.CentreLeft);
            tiao2_2.ScaleVec(159496, 159542, 0.28, 0.075, 0.28, 0.075);
            tiao2_2.Move(159496, -45, 240 + 60);

            var tiao3 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.CentreLeft);
            tiao2_2.ScaleVec(159542, 159589, 0.843, 0.06, 0.843, 0.06);
            tiao2_2.Move(159542, -40, 240 + 15);
        }

        private void FuckingTextShow(StoryboardLayer layer, double start, double end, bool random)
        {
            var sentences = new[] { "秘めた約束叶えようか", "迷い込んだ楽園は", "地獄への道標" };
            var allChars = sentences.SelectMany(k => k).Select(k => k.ToString()).ToArray();
            var widths = new double[] { 320, 270, 200 };
            for (int i = 0; i < sentences.Length; i++)
            {
                var y = 240;
                if (i == 0) y -= 60;
                else if (i == 2) y += 60;
                string sentence = sentences[i];
                double width = widths[i];

                var postFix = "_2S";

                for (var j = 0; j < sentence.Length; j++)
                {
                    if (random)
                    {
                        if (Random(1.0d) > 0.77) continue;
                    }

                    var c = random ? allChars[Random(allChars.Length)] : sentence[j].ToString();
                    var pic = ConvertToFileName(c, postFix);
                    // var x = width * (j / (double)(sentence.Length - 1)) + 320 - width / 2d;
                    var x = width * (j / (double)(sentence.Length - 1)) - 25;
                    if (random)
                    {
                        if (Random(1.0d) > 0.8) x += Random(-50, 50);
                    }

                    var sprite = layer.CreateSprite(pic);
                    sprite.MoveX((OsbEasing)0, start, end, x, x);
                    sprite.MoveY((OsbEasing)0, start, end, y, y);
                    sprite.Scale(start, 0.4);
                }
            }
        }

        private static void Preshow(StoryboardLayer layer)
        {
            TextEnter(layer, 147121, 149746, "迷い込んだ", 220, "_2S");
            TextEnter(layer, 150121, 152746, "楽園は", 130, "_2S");
            TextEnter(layer, 153121, 155746, "地獄への", 180, "_2S");
            TextEnter(layer, 156121, 158746, "道標", 60, "_2S");
        }

        private static void TextEnter(StoryboardLayer layer, double start, double end, string sentence, double width,
            string postFix)
        {
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                const int interval = 88;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.Color(start, 0.2, 0.4, 0.6);
                sprite.Fade(start, 0.8);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start + i * interval, start + i * interval + 200, 0, 0.4);
                sprite.Scale((OsbEasing)13, start + i * interval + 200, start + i * interval + 1820, 0.4, 0.65);
                sprite.Rotate(start + i * interval, start + i * interval + 200, 0.65 * 1.3, 0.4 * 1.3);
                sprite.Rotate((OsbEasing)13, start + i * interval + 200, start + i * interval + 1820, 0.4 * 1.3, 0);

                sprite.Scale((OsbEasing)12, start + i * interval + 1820, start + i * interval / 3d + 2740, 0.65, 0.4);
                sprite.Scale(start + i * interval / 3d + 2740, start + i * interval / 3d + 2900, 0.4, 0);
                sprite.Rotate((OsbEasing)12, start + i * interval + 1820, start + i * interval / 3d + 2740, 0, -0.4);
                sprite.Rotate(start + i * interval / 3d + 2740, start + i * interval / 3d + 2900, -0.4, -0.65);
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
