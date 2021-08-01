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
    public class DirtyFilterEffect : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 64246;
        [Configurable]
        public int EndTime = 69121;
        public override void Generate()
        {
            var layer = GetLayer("filter");
            var preEndTime = StartTime;
            var count = 10;
            var xCount = 3;
            var interval = 66;
            while (true)
            {
                var st = preEndTime;
                bool exit = false;
                if (preEndTime + interval > EndTime)
                {
                    preEndTime = EndTime;
                    exit = true;
                }
                else
                {
                    preEndTime = preEndTime + interval;
                }

                for (int i = 0; i < count; i++)
                {
                    double x = 0;
                    var total = 1d;
                    for (int j = 0; j < xCount; j++)
                    {
                        double rand;
                        if (j != xCount - 1)
                        {
                            rand = Random(total);
                            total -= rand;
                        }
                        else
                        {
                            rand = total;
                        }

                        var sprite = layer.CreateSprite(@"SB\components\bg" + (Random(4) + 1) + ".jpg", OsbOrigin.TopLeft);
                        sprite.Additive(st);
                        sprite.Move(st, -107 + x, 480 * (i / (double)count));
                        sprite.ScaleVec(st, rand, 1d / count);
                        sprite.Fade(st, preEndTime, 0.25, 0.25);

                        x += 854 * rand;
                    }
                }
                if (exit) break;
            }

        }
    }
}
