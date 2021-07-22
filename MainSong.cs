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

namespace StorybrewScripts
{
    public class MainSong : StoryboardObjectGenerator
    {
        public int StartTime = 33120;
        public override void Generate()
        {
            var layer = GetLayer("main");

            var white = layer.CreateSprite(@"SB\components\white.png");
            white.Fade(0, StartTime, StartTime + 45120 - 33120, 1, 1);

            var saku = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y = 240;
            var x = 160;
            saku.Move(StartTime, StartTime + 36120 - 33120, x, y, x, y - 150);
            saku.Move(StartTime + 39120 - 33120, StartTime + 42120 - 33120, x, y - 400, x, y - 550);

            var saku2 = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y2 = 640;
            var x2 = 460;
            saku2.Move(StartTime, StartTime + 36120 - 33120, x2, y2, x2, y2 - 150);
            saku2.Move(StartTime + 39120 - 33120, StartTime + 42120 - 33120, x2, y2 - 400, x2, y2 - 550);

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

                item.Move(0, StartTime, StartTime + 36120 - 33120, startX, startY, startX, startY - 150);
                item.Scale(StartTime, 0.4);

                item.Move(0, StartTime + 39120 - 33120, StartTime + 42120 - 33120, startX, startY - 400, startX, startY - 550);
            }

            var waifu2 = layer.CreateSprite(@"SB\cg\0769_n_1046_re.jpg");
            MoveWaifu(waifu2, 37620, 39120, true);
            var waifu = layer.CreateSprite(@"SB\cg\0769_n_1046.jpg");
            MoveWaifu(waifu, 36120, 37808);

            for (int i = 0; i < 12; i++)
            {
                var start = StartTime + 37245 - 33120 + _interval / 2 * i;
                var mosaic = layer.CreateSprite($@"SB\cg\0769_n_1046_mosaic{Random(0, 5)}.png");
                mosaic.Fade(start, start + _interval / 2, 1, 1);
                mosaic.Scale(start, 2.5);
                mosaic.Move(start, 360, 220);
                var c = Random(0.6, 0.7);
                mosaic.Color(start, c, c, c);
            }


            var waku = layer.CreateSprite(@"SB\components\waku.png");
            waku.Fade(StartTime + 45120 - 33120, 1);
            waku.ScaleVec(StartTime, 2.652173913043478, 1.983471074380165);
        }

        int _interval = 36402 - 36308;
        private void MoveWaifu(OsbSprite waifu, int startTime, int endTime, bool twinkle = false)
        {
            MoveAndScale(waifu, startTime, 140, 140, 1.8, twinkle);

            var st = startTime + (36308 - 36120);
            MoveAndScale(waifu, st, 260, 240, 1, twinkle);
            MoveAndScale(waifu, st + _interval, 260, 240, 0.86, twinkle);
            MoveAndScale(waifu, st + _interval * 2, 260, 240, 0.93, twinkle);
            MoveAndScale(waifu, st + _interval * 3, 260, 240, 0.78, twinkle);

            st = startTime + (36777 - 36120);
            MoveAndScale(waifu, st, 90, 440, 1.5, twinkle);
            MoveAndScale(waifu, st + _interval, 30, 540, 2, twinkle);

            st = startTime + (37058 - 36120);
            MoveAndScale(waifu, st, 570, 180, 2, twinkle);
            MoveAndScale(waifu, st + _interval, 620, 180, 2.5, twinkle);
            waifu.Fade(endTime, 1);

        }

        private void MoveAndScale(OsbSprite waifu, int startTime, int x, int y, double r, bool twinkle)
        {
            waifu.Move(startTime, x, y);
            waifu.Scale(startTime, r);
            if (twinkle)
                waifu.Color((OsbEasing)2, startTime, startTime + _interval, 1, 0.4, 0.5, 1, 0.7, 0.8);
            else
                waifu.Color((OsbEasing)2, startTime, startTime + _interval, 0.7, 0.7, 0.7, 0.9, 0.9, 0.9);
            // var layer = GetLayer("above");
            // var waku = layer.CreateSprite(@"SB\components\waku.png");
            // waku.ScaleVec(startTime, 2.652173913043478, 1.983471074380165);
            // waku.Fade(startTime, startTime + interval, 1, 0);
        }
    }
}
