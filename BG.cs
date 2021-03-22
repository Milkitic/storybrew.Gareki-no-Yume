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
    public class BG : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var name = "Madoka";

            string bgPath = @"" + name + ".jpg";
            var endTime = 210121;

            var group = base.GetLayer("Back");
            var bg = group.CreateSprite(bgPath, OsbOrigin.Centre);
            bg.Move(0, 0, endTime, 320, 240, 320, 240);
            bg.Scale(0, 0, endTime, 0.4447916666666667, 0.4447916666666667);

            string barPath = @"SB\components\black.jpg";
            float opacity = 0.5f;

            var bar = group.CreateSprite(barPath, OsbOrigin.BottomCentre);
            bar.Move(0, 0, endTime, 320, 480, 320, 480);
            bar.ScaleVec(0, 0, endTime, 3, 0.3, 3, 0.3);
            bar.Fade(0, 0, endTime, opacity);
            // bg.
        }
    }
}
