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
    public class KiaiWaifu2 : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 70621 - 100;
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            var bg = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 240));
            var nextTime = StartTime + (1031);

            // bg.Scale(StartTime, 1);
            bg.MoveY((OsbEasing)0, StartTime, StartTime + 100, -600, 0);
            bg.MoveY((OsbEasing)1, StartTime + 100, StartTime + 400, 0, 340);

            bg.MoveY((OsbEasing)6, nextTime, nextTime + 300, 390, 600);
            bg.MoveY((OsbEasing)0, nextTime + 300, nextTime + 800, 600, 2000);

            var bgEasingFix = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 240));
            // bgEasingFix.Scale(StartTime, 1);

            var nextStartTime = StartTime + (72121 - 70621) - 100;
            var gTime = StartTime + (71773 - 70621);
            bg.Fade(StartTime, 1);
            bg.Fade(StartTime + 400 - 50, 0);
            bg.Fade(gTime, 1);
            bg.Fade(nextStartTime, 0);
            bgEasingFix.Fade(StartTime + 400 - 50, 1);
            bgEasingFix.Fade(gTime, 0);
            bgEasingFix.MoveY((OsbEasing)0, StartTime + 400 - 50, StartTime + 400 + 1031 + 50, 330, 435);

            var bg2 = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(270, 240));
            bg2.Scale((OsbEasing)13, nextStartTime, nextStartTime + 1000, 1.2, 1);
            bg2.MoveY((OsbEasing)13, nextStartTime, nextStartTime + 800, 320, 320);
            bg2.Rotate((OsbEasing)13, nextStartTime, nextStartTime + 1000, Math.PI / 4 * 6, -0.2);
            bg2.MoveX((OsbEasing)0, nextStartTime + 800, nextStartTime + 1500, 270, 290);
            bg2.MoveX((OsbEasing)13, nextStartTime + 1500, nextStartTime + 3000, 290, 460);
            bg2.MoveX((OsbEasing)9, nextStartTime + 3000, nextStartTime + 4030, 490, 800);
            bg2.MoveX((OsbEasing)0, nextStartTime + 4030, nextStartTime + 4100, 800, 1100);

            var bg2EasingFix = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 320));
            bg2.Fade(nextStartTime, 1);
            bg2.Fade(nextStartTime + 2300, 0);
            bg2.Fade(nextStartTime + 3420, 1);
            bg2EasingFix.Fade(nextStartTime, 0);
            bg2EasingFix.Fade(nextStartTime + 2300, 1);
            bg2EasingFix.Fade(nextStartTime + 3420, 0);

            bg2EasingFix.MoveX((OsbEasing)0, nextStartTime + 2300, nextStartTime + 3420, 456, 498);
            bg2EasingFix.Rotate(nextStartTime + 2900, -0.2);

            var nextbStartTime = StartTime + (76246 - 70621) - 100;
            var bg3 = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 320));
            bg3.Scale((OsbEasing)13, nextbStartTime, nextbStartTime + 800, 0.5, 0.8);
            bg3.Move((OsbEasing)13, nextbStartTime, nextbStartTime + 800, 360, 320, 380, 350);

            var bg3EasingFix = layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(380, 350));
            var bg3EasingFix2 = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.Centre, new Vector2(380, 350));
            bg3.Fade(nextbStartTime, 1);
            bg3.Fade(nextbStartTime + 500, 0);

            bg3EasingFix.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, 0.798, 0.85);
            bg3EasingFix.Fade((OsbEasing)9, nextbStartTime + 2500, nextbStartTime + 4900, 1, 0);
            bg3EasingFix2.Fade((OsbEasing)10, nextbStartTime + 2500, nextbStartTime + 4900, 0, 1);
            bg3EasingFix2.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, 0.798, 0.85);

            var bg3EasingFix_r = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 350));
            bg3EasingFix_r.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, 0.798, 0.85);
            bg3EasingFix_r.Fade((OsbEasing)9, nextbStartTime + 2500, nextbStartTime + 4900, 0, 1);
            var bg4 = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 280));
            bg4.Scale(nextbStartTime + 4900, 0.6);
            bg4.Color(nextbStartTime + 4900, 0.2, 0.2, 0.2);
            bg4.Fade((OsbEasing)0, nextbStartTime + 4900, nextbStartTime + 6300, 1, 1);
        }
    }
}
