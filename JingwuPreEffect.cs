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
    public class JingwuPreEffect : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 18121;
        public override void Generate()
        {
            int startX = -107, endX = 854;
            int startY = 200, endY = 300;
            var count = 20;

            var endTime = StartTime + (19246 - 18121);
            var trueEndTime = StartTime + (19621 - 18121);
            var layer = GetLayer("waifu");

            var newSt = StartTime + 22621 - 18121;
            var newTe = StartTime + 24121 - 18121;
            var newEt = StartTime + 23746 - 18121;
            Scene(layer, StartTime, trueEndTime, endTime, count, startX, endX, startY, endY);
            Scene(layer, newSt, newTe, newEt, count, endX - 150, startX - 150, startY, endY, true);
        }

        private void Scene(StoryboardLayer layer, int startTime, int trueEndTime, int endTime, int count, int startX, int endX,
            int startY, int endY, bool red = false)
        {
            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            if (red) bg.Color(startTime, 1, 0, 0);
            bg.Rotate(startTime, 0.2);
            bg.ScaleVec(startTime, 1.3, 1);
            if (red)
                bg.Fade(startTime, 1);
            else
                bg.Fade(startTime, 0.2);
            bg.MoveX(startTime, trueEndTime, 340, 340 + (red ? 400 : -400));
            // bg.MoveY(startTime, trueEndTime, 240, 240 - 50);
            MoveRandomly(bg, startTime, trueEndTime, 240, 240 - 50);

            for (int i = 0; i < 600; i++)
            {
                var particle = layer.CreateSprite(@"SB\components\particle.png");
                var x = Random(-107, 1154);
                var y = Random(0, 520);
                particle.Move(startTime, trueEndTime, x, y, x + Random(-50, 50) + (red ? 400 : -400), y - 50 + Random(-50, 50));
                particle.Scale(startTime, 0.3);
                particle.Additive(startTime);
                if (red)
                    particle.Color(startTime, 0.7, 0.24, 0.2);
                else
                    particle.Color(startTime, 0.24, 0.7, 0.2);
                particle.Color(trueEndTime, 0, 0, 0);
                var elapsed = 300;
                var showTime = Random(startTime, endTime + elapsed);
                particle.Fade(showTime, showTime + elapsed / 2, 0, 1);
                particle.Fade(showTime + elapsed / 2, showTime + elapsed, 1, 0);
                // particle.Color(trueEndTime, 0.7, 0.24, 0.2);
            }

            for (int i = 0; i < count; i++)
            {
                var ratio = i / (double)count;
                var o = layer.CreateAnimation(@"SB\components\ink\ink.png", 18, Random(16, 32), OsbLoopType.LoopOnce);
                var x = startX + (endX - startX) * ratio;
                var y = startY + (endY - startY) * ratio;
                o.Fade((OsbEasing)0, startTime + (endTime - startTime) * ratio, trueEndTime, 1, 1);
                var st0 = startTime + (endTime - startTime) * ratio;
                o.MoveX((OsbEasing)0, st0, st0 + 1500, x, x + (red ? 400 : -400));
                MoveRandomly(o, st0, st0 + 1500, y, y - 50);
                // o.MoveY((OsbEasing)0, st0, st0 + 1500, y, y - 50);
                o.Scale(startTime + (endTime - startTime) * ratio, Random(0.3, 0.6));
                o.Rotate(trueEndTime, Random(Math.PI * 2));
                o.Fade(trueEndTime, 0);
                if (red)
                    o.Color(trueEndTime, 0.5, 0.14, 0.1);
                else o.Color(trueEndTime, 0.14, 0.35, 0.1);
            }
        }

        private void MoveRandomly(OsbSprite sprite, double st, double et, double y0, double y1)
        {
            var count = 50;
            var v = (y1 - y0) / (et - st);
            for (int i = 0; i < count; i++)
            {
                var t = (et - st) / (double)count * i;
                var y = y0 + v * t;
                sprite.MoveY(st + t, y + Random(-3, 3));
            }
        }
    }
}