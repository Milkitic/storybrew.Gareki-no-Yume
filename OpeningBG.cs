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
    public class OpeningBG : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("main");

            var bg = layer.CreateSprite(@"SB/components/bg.jpg");
            bg.Fade(0, 6120, 18121, 0.5, 0.5);
            bg.Color(0, 1, 0, 0);
            bg.ScaleVec(6120, 0.9, 0.6);

        }
    }
}
