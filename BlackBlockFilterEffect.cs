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
    public class BlackBlockFilterEffect : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            // var startTime = 49245;
            // var endTime = 49808;

            // var layer = GetLayer("filter");
            // var count = 50;
            // for (int i = 0; i < count; i++)
            // {
            //     var targetW = Random(100, 300);
            //     var targetH = Random(0.5d, 2d);
            //     var x = Random(-207, 847 - targetW);
            //     var y = Random(0, 480 - targetH);
            //     var w2 = layer.CreateSprite(@"SB\components\white.png", OsbOrigin.TopLeft);
            //     var baseX = 1 / 854d;
            //     var baseY = 1 / 480d;
            //     w2.Color(startTime, 0, 0, 0);
            //     w2.Move(startTime, x, y);
            //     w2.ScaleVec(startTime, endTime, baseX * targetW, baseY * targetH, baseX * targetW, baseY * targetH);
            // }
        }
    }
}
