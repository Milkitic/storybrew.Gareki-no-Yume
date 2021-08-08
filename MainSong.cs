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
    public class MainSong : StoryboardObjectGenerator
    {
        public int StartTime = 33120;
        public override void Generate()
        {
            var layer = GetLayer("main");

            var white = layer.CreateSprite(@"SB\components\white.png");
            // white.Fade(0, StartTime, StartTime + 45120 - 33120, 1, 1);
            HideItem(white);

            var saku = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y = 240;
            var x = 160;
            saku.Move(StartTime, StartTime + 35745 - 33120, x, y, x, y - 150);
            saku.Move(StartTime + 39120 - 33120, StartTime + 41745 - 33120, x, y - 400, x, y - 550);
            HideItem(saku);
            var saku2 = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y2 = 640;
            var x2 = 460;
            saku2.Move(StartTime, StartTime + 35745 - 33120, x2, y2, x2, y2 - 150);
            saku2.Move(StartTime + 39120 - 33120, StartTime + 41745 - 33120, x2, y2 - 400, x2, y2 - 550);
            HideItem(saku2);
            var note1 = layer.CreateSprite(@"SB\cg\0778_n_10601.jpg");
            var note2 = layer.CreateSprite(@"SB\cg\0779_n_10602.jpg");
            var note3 = layer.CreateSprite(@"SB\cg\0780_n_10603.jpg");
            var note4 = layer.CreateSprite(@"SB\cg\0781_n_10604.jpg");

            // var arr = new[] { note1, note2, note3, note4 };
            var arr = new[] { note1, note2, };
            for (int i = 0; i < arr.Length; i++)
            {
                OsbSprite item = arr[i];
                double startX;
                if (i % 2 == 0)
                {
                    startX = 320 + 300;
                }
                else
                {
                    startX = 320 - 300;
                    item.FlipH(StartTime);
                }

                var startY = 240 + 120 + i * 400;

                item.Move(0, StartTime, StartTime + 35745 - 33120, startX, startY, startX, startY - 150);
                item.Scale(StartTime, 0.4);

                item.Move(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, startX, startY - 400, startX, startY - 550);
                HideItem(item);
            }

            var line = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
            var lineY = 155;
            line.Move(0, StartTime, StartTime + 35745 - 33120, 100, lineY, 100, lineY - 150);
            line.Move(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, 100, lineY - 400, 100, lineY - 550);
            line.Color(33870, 0.1, 0.1, 0.1);
            line.Rotate(33870, Math.PI / 2);
            line.ScaleVec((OsbEasing)10, 33870, 34620, 0, 1, 400, 1);
            line.Fade(StartTime + 42120 - 33120, 1);

            var line2 = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
            var line2Y = 555;
            line2.Move(0, StartTime, StartTime + 35745 - 33120, 540, line2Y, 540, line2Y - 150);
            line2.Move(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, 540, line2Y - 400, 540, line2Y - 550);
            line2.Color(33870, 0.1, 0.1, 0.1);
            line2.Rotate(33870, Math.PI / 2);
            line2.ScaleVec((OsbEasing)10, 39870, 40620, 0, 1, 400, 1);
            line2.Fade(StartTime + 42120 - 33120, 1);

            Lyric1(layer);
            Lyric2(layer);
            DrawNmslEffect(layer);

            var waku = layer.CreateSprite(@"SB\components\waku.png");
            waku.Fade(StartTime + 45120 - 33120, 1);
            waku.ScaleVec(StartTime, 2.652173913043478, 1.983471074380165);
        }

        private void Lyric1(StoryboardLayer layer)
        {
            var start = StartTime + (33870 - 33120);
            var end = StartTime + (34620 - 33120);
            // var postFix = "_st_2S";
            var postFix = "_2S";
            var sentence = "傷ついた目で";
            var height = 250;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 360 - height / 2d;
                var x = 135;
                var t = start + i * (130 - i * 5);
                var sprite = layer.CreateSprite(pic);
                sprite.Fade(StartTime, 0);
                sprite.Fade(t, 1);
                sprite.MoveX(0, t, t + 100, x + 90, x + 50);
                sprite.MoveX((OsbEasing)13, t + 100, t + 1200, x + 50, x);
                sprite.Scale(start, 0.45);
                sprite.Color(StartTime, 0.1, 0.1, 0.1);
                sprite.MoveY(0, StartTime, StartTime + 35745 - 33120, y, y - 150);
                sprite.MoveY(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, y - 400, y - 550);
            }
        }

        private void Lyric2(StoryboardLayer layer)
        {
            var start = StartTime + (39870 - 33120);
            var end = StartTime + (40620 - 33120);
            // var postFix = "_st_2S";
            var postFix = "_2S";
            var sentence = "何を探すの";
            var height = 200;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 760 - height / 2d;
                var x = 505;
                var t = start + i * (130 - i * 5);
                var sprite = layer.CreateSprite(pic);
                sprite.Fade(StartTime, 0);
                sprite.Fade(t, 1);
                sprite.MoveX(0, t, t + 100, x - 90, x - 50);
                sprite.MoveX((OsbEasing)13, t + 100, t + 1200, x - 50, x);
                sprite.Scale(start, 0.45);
                sprite.Color(StartTime, 0.1, 0.1, 0.1);
                sprite.MoveY(0, StartTime, StartTime + 36120 - 33120, y, y - 150);
                sprite.MoveY(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, y - 400, y - 550);
                sprite.Fade(StartTime + 42120 - 33120, 1);
            }
        }

        private void DrawNmslEffect(StoryboardLayer layer)
        {
            var waifu2 = layer.CreateSprite(@"SB\cg\0769_n_1046.jpg");
            MoveWaifuAdv(waifu2, 37620, 39120, true);
            var waifu2_1 = layer.CreateSprite(@"SB\cg\0769_n_1046.jpg");
            MoveWaifuAdv(waifu2_1, 37620, 39120, true, true);

            var waifu = layer.CreateSprite(@"SB\cg\0769_n_1046.jpg");
            MoveWaifuAdv(waifu, 36120, 37808);
            var waifu_1 = layer.CreateSprite(@"SB\cg\0769_n_1046.jpg");
            MoveWaifuAdv(waifu_1, 36120, 37808, false, true);

            var waifu4 = layer.CreateSprite(@"Madoka.jpg");
            MoveWaifuAdv2(waifu4, 43620, 45120, true);
            var waifu4_1 = layer.CreateSprite(@"Madoka.jpg");
            MoveWaifuAdv2(waifu4_1, 43620, 45120, true, true);

            var waifu3 = layer.CreateSprite(@"Madoka.jpg");
            MoveWaifuAdv2(waifu3, 42120, 43808);
            var waifu3_1 = layer.CreateSprite(@"Madoka.jpg");
            MoveWaifuAdv2(waifu3_1, 42120, 43808, false, true);

            for (int i = 0; i < 12; i++)
            {
                var start = StartTime + 37245 - 33120 + _interval / 2 * i;
                var serial = Random(0, 5);
                var mosaic = layer.CreateSprite($@"SB\cg\0769_n_1046_mosaic{serial}.png");
                mosaic.Fade(start, start + _interval / 2, 1, 1);
                mosaic.Scale(start, 2.5);
                mosaic.Move(start, 360, 220);
                var c = Random(0.6, 0.7);
                mosaic.Color(start, c, c, c);

                var mosaic2 = layer.CreateSprite($@"SB\cg\0769_n_1046_mosaic{serial}.png");
                mosaic2.Fade(start, start + _interval / 2, 0.2, 0.2);
                mosaic2.Additive(start);
                mosaic2.Scale(start, 2.5);
                mosaic2.Move(start, 360 + 4, 220);
                mosaic2.Color(start, 1, 0, 0);

                var mosaic4 = layer.CreateSprite($@"SB\cg\0769_n_1046_mosaic{serial}.png");
                mosaic4.Fade(start, start + _interval / 2, 0.2, 0.2);
                mosaic4.Additive(start);
                mosaic4.Scale(start, 2.5);
                mosaic4.Move(start, 360 - 4, 220);
                mosaic4.Color(start, 0, 0, 0.3);
            }

            var w = layer.CreateSprite($@"SB\components\white.png");
            w.Color(37245, 0, 0, 0);
            var stt = 37245;
            for (int i = 0; i < 10; i++)
            {
                w.Fade(stt, 0.2);
                stt = stt + Random(30, 60);
                w.Fade(stt, 0);
                stt = stt + Random(30, 60);
            }

            w.Color(38839, 0.1, 0, 0);
            w.Fade(38839, 39120, 1, 1);

            for (int i = 0; i < 12; i++)
            {
                var start = StartTime + 43245 - 33120 + _interval / 2 * i;
                var serial = Random(0, 5);
                var mosaic = layer.CreateSprite($@"SB\cg\Madoka_mosaic{serial}.jpg");
                mosaic.Fade(start, start + _interval / 2, 1, 1);
                mosaic.Scale(start, 2);
                mosaic.Move(start, 310, 185);
                var c = Random(0.6, 0.7);
                mosaic.Color(start, c, c, c);

                var mosaic2 = layer.CreateSprite($@"SB\cg\Madoka_mosaic{serial}.jpg");
                mosaic2.Fade(start, start + _interval / 2, 0.2, 0.2);
                mosaic2.Additive(start);
                mosaic2.Scale(start, 2);
                mosaic2.Move(start, 310 + 4, 185);
                mosaic2.Color(start, 1, 0, 0);

                var mosaic4 = layer.CreateSprite($@"SB\cg\Madoka_mosaic{serial}.jpg");
                mosaic4.Fade(start, start + _interval / 2, 0.2, 0.2);
                mosaic4.Additive(start);
                mosaic4.Scale(start, 2);
                mosaic4.Move(start, 310 - 4, 185);
                mosaic4.Color(start, 0, 0, 0.3);
            }

            var w2 = layer.CreateSprite($@"SB\components\white.png");
            w2.Color(43245, 0, 0, 0);
            var stt2 = 43245;
            for (int i = 0; i < 10; i++)
            {
                w2.Fade(stt2, 0.2);
                stt2 = stt2 + Random(30, 60);
                w2.Fade(stt2, 0);
                stt2 = stt2 + Random(30, 60);
            }

            w2.Color(44839, 0.1, 0, 0);
            w2.Fade(44839, 45120, 1, 1);
        }

        private void HideItem(OsbSprite item)
        {
            item.Fade(StartTime, 1);
            item.Fade(36120, 0);
            item.Fade(39120, 1);
            item.Fade(42120, 0);
        }

        int _interval = 36402 - 36308;
        private void MoveWaifu(OsbSprite waifu, int startTime, int endTime, bool twinkle = false, bool isDouyin = false)
        {
            if (isDouyin)
            {
                waifu.Additive(startTime);
                waifu.Fade(startTime, 0.4);
                if (twinkle)
                    waifu.Color(startTime, 0, 0, 1);
                else
                    waifu.Color(startTime, 1, 0, 0);
            }

            if (twinkle)
            {
                waifu.Additive(startTime);
            }

            MoveAndScale(waifu, startTime, 140, 140, 1.8, twinkle, isDouyin);

            var st = startTime + (36308 - 36120);
            MoveAndScale(waifu, st, 260, 240, 1, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval, 260, 240, 0.86, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval * 2, 260, 240, 0.93, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval * 3, 260, 240, 0.78, twinkle, isDouyin);

            st = startTime + (36777 - 36120);
            MoveAndScale(waifu, st, 90, 440, 1.5, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval, 30, 540, 2, twinkle, isDouyin);

            st = startTime + (37058 - 36120);
            MoveAndScale(waifu, st, 570, 180, 2, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval, 620, 180, 2.5, twinkle, isDouyin);
            waifu.Fade(endTime, 1);

        }

        private void MoveWaifuAdv(OsbSprite waifu, int startTime, int endTime, bool twinkle = false, bool isDouyin = false)
        {
            var layer = GetLayer("asdf");
            var w = layer.CreateSprite($@"SB\components\white.png");
            if (isDouyin)
            {
                waifu.Additive(startTime);
                waifu.Fade(startTime, 0.4);
                if (twinkle)
                    waifu.Color(startTime, 0, 0, 1);
                else
                    waifu.Color(startTime, 1, 0, 0);
            }

            // if (twinkle)
            // {
            //     waifu.Additive(startTime);
            // }

            if (!twinkle)
            {
                MoveAndScale(waifu, startTime, 140, 140, 1.8, twinkle, isDouyin);
                w.Fade((OsbEasing)2, startTime, startTime + _interval * 2, 0.2, 1);
            }

            w.Color(startTime, 0.1, 0, 0);
            var st = startTime + (36308 - 36120);
            MoveAndScale(waifu, st, 260, 240, 1, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 2, 0.2, 1);
            // MoveAndScale(waifu, st + _interval, 260, 240, 0.86, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval * 2, 260, 240, 0.93, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st + _interval * 2, st + _interval * 4, 0.2, 1);
            // MoveAndScale(waifu, st + _interval * 3, 260, 240, 0.78, twinkle, isDouyin);

            st = startTime + (36777 - 36120);
            // MoveAndScale(waifu, st, 90, 440, 1.5, twinkle, isDouyin);
            MoveAndScale(waifu, st, 30, 540, 2, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 2, 0.2, 1);

            st = startTime + (37058 - 36120);
            // MoveAndScale(waifu, st, 570, 180, 2, twinkle, isDouyin);
            MoveAndScale(waifu, st, 620, 180, 2.5, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 3, 0.2, 1);
            waifu.Fade(endTime, 1);

        }

        private void MoveWaifuAdv2(OsbSprite waifu, int startTime, int endTime, bool twinkle = false, bool isDouyin = false)
        {
            var layer = GetLayer("asdf");
            var w = layer.CreateSprite($@"SB\components\white.png");
            if (isDouyin)
            {
                waifu.Additive(startTime);
                waifu.Fade(startTime, 0.4);
                if (twinkle)
                    waifu.Color(startTime, 0, 0, 1);
                else
                    waifu.Color(startTime, 1, 0, 0);
            }

            if (twinkle)
            {
                waifu.Additive(startTime);
            }

            if (!twinkle)
            {
                MoveAndScale(waifu, startTime, 1040, 340, 1.8, twinkle, isDouyin);
                w.Fade((OsbEasing)2, startTime, startTime + _interval * 2, 0.2, 1);
            }

            w.Color(startTime, 0.1, 0, 0);
            var st = startTime + (36308 - 36120);
            MoveAndScale(waifu, st, 760, 280, 1, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 2, 0.2, 1);
            // MoveAndScale(waifu, st + _interval, 260, 240, 0.86, twinkle, isDouyin);
            MoveAndScale(waifu, st + _interval * 2, 560, 300, 0.7, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st + _interval * 2, st + _interval * 4, 0.2, 1);
            // MoveAndScale(waifu, st + _interval * 3, 260, 240, 0.78, twinkle, isDouyin);

            st = startTime + (36777 - 36120);
            // MoveAndScale(waifu, st, 90, 440, 1.5, twinkle, isDouyin);
            MoveAndScale(waifu, st, 1330, 680, 1.7, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 2, 0.2, 1);

            st = startTime + (37058 - 36120);
            // MoveAndScale(waifu, st, 570, 180, 2, twinkle, isDouyin);
            MoveAndScale(waifu, st, 400, 740, 1.9, twinkle, isDouyin);
            w.Fade((OsbEasing)2, st, st + _interval * 3, 0.2, 1);
            waifu.Fade(endTime, 1);

        }

        private void MoveAndScale(OsbSprite waifu, int startTime, int x, int y, double r, bool twinkle, bool isDouyin)
        {
            if (isDouyin) x += 7;
            waifu.Move((OsbEasing)1, startTime, startTime + 33, x + Random(-7, 7), y + Random(-7, 7), x, y);
            // waifu.Move(startTime, x, y);
            waifu.Scale(startTime, r);
            if (twinkle)
            {
                if (!isDouyin)
                    waifu.Color((OsbEasing)2, startTime, startTime + _interval, 1, 0.4, 0.5, 1, 0.4, 0.5);
                // else
                //     waifu.Color((OsbEasing)2, startTime, startTime + _interval, 0, 0, 0.6, 0, 0, 0.8);
            }
            else
            {
                if (!isDouyin)
                    waifu.Color((OsbEasing)2, startTime, startTime + _interval, 0.7, 0.7, 0.7, 0.9, 0.9, 0.9);
                // else
                //     waifu.Color((OsbEasing)2, startTime, startTime + _interval, 0.6, 0, 0, 0.8, 0, 0);
            }
        }
        // var layer = GetLayer("above");
        // var waku = layer.CreateSprite(@"SB\components\waku.png");
        // waku.ScaleVec(startTime, 2.652173913043478, 1.983471074380165);
        // waku.Fade(startTime, startTime + interval, 1, 0);


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
