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
            var group = base.GetLayer("Back");
            var g = group.CreateSprite("Madoka.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);
            g = group.CreateSprite("End.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);
            g = group.CreateSprite("Hatsune.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);
            g = group.CreateSprite("Kureha.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);
            g = group.CreateSprite("Mahoro.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);
            g = group.CreateSprite("Mifuyu.jpg", OsbOrigin.Centre);
            g.Fade(0, 0);

        }
    }
}
