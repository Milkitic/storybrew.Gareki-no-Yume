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
    public class JingwuEffect : StoryboardObjectGenerator
    {
        [Configurable]
        public string WtfTheBg = @"SB\cg\1105_n_8500.jpg";
        [Configurable]
        public int StartTime = 19621;
        [Configurable]
        public int R = 255;
        [Configurable]
        public int G = 255;
        [Configurable]
        public int B = 255;
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            What(layer, StartTime, (21121 - 19621) + StartTime);
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var x = -107 + 140 + 854 / 3f * i;
                    var y = 0 + 70 + 480 / 3f * j;
                    What(layer, (21121 - 19621) + StartTime, (22246 - 19621) + StartTime, 1 / 4.5f, x, y);
                }
            }

            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    var x = -107 + 50 + 854 / 9f * i;
                    var y = 0 + 15 + 480 / 9f * j;
                    What(layer, (22246 - 19621) + StartTime, (22621 - 19621) + StartTime, 1 / 13f, x, y);
                }
            }

            var st = (21121 - 19621) + StartTime;
            var fire = layer.CreateAnimation(@"SB\components\fire\fire.png", 33, 30, OsbLoopType.LoopForever);
            fire.Color(StartTime, R / 255d, G / 255d, B / 255d);
            fire.Fade(StartTime, 0.2);
            fire.Move(0, st, (22621 - 19621) + StartTime, 380, 240, 380, 240);
            fire.Fade(st, 0.5);
            fire.Scale(st, 2);
            fire.Additive(st);
        }

        private void What(StoryboardLayer layer, double startTime, double endTime2, double scale = 1, double x = 320, double y = 240)
        {
            var count = 8;
            var endTime = startTime + (21121 - 19621);
            for (int i = 0; i < count; i++)
            {
                if (i == 0) continue;
                var bg = layer.CreateSprite(WtfTheBg);
                var r = count / Math.PI * 2 * i;
                var o = 50;
                bg.Color(startTime, R / 255d, G / 255d, B / 255d);
                bg.Move(startTime, x, y);
                bg.Fade(startTime, 1d / count * 3);
                bg.Rotate(0, startTime, endTime, r, r + Math.PI * i * (i % 2 == 0 ? -1 : 1));
                bg.Scale(0, startTime + i * o, startTime + (endTime - startTime) / 2 + i * o, 1.2 * scale, 1.3 * scale);
                bg.Scale(0, startTime + (endTime - startTime) / 2 + i * o, startTime + (endTime - startTime) + i * o, 1.3 * scale, 1.2 * scale);
                bg.Additive(startTime);
                bg.Fade(endTime2, 0);
            }
        }
    }
}
