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
    public class KiaiWaifu : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 58620;
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            var bg = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.CentreRight);
            bg.Scale(StartTime, 1.5);
            bg.Rotate((OsbEasing)6, StartTime, 60074, 0.9, 0.2);
            bg.MoveX((OsbEasing)0, StartTime, 60074, 600, 1100);
            bg.MoveY((OsbEasing)1, StartTime, 59183, 350, 500);
            bg.MoveY((OsbEasing)6, 59183, 60074, 500, 520);

            bg.Scale(0, 60074, 60120, 1.5, 1);
            bg.Rotate(0, 60074, 60120, 0.2, 0.15);
            bg.MoveX(0, 60074, 60120, 1100, 850);
            bg.MoveY(0, 60074, 60120, 520, 400);

            bg.Scale((OsbEasing)1, 60120, 60120 + (61620 - 60120) / 2, 1, 0.85);
            bg.MoveX((OsbEasing)1, 60120, 60120 + (61620 - 60120) / 2, 850, 775);
            bg.MoveY((OsbEasing)1, 60120, 60120 + (61620 - 60120) / 2, 400, 300);
            bg.Rotate((OsbEasing)1, 60120, 60120 + (61620 - 60120) / 2, 0.15, 0.025);

            bg.Scale((OsbEasing)2, 60120 + (61620 - 60120) / 2, 61620, 0.85, 0.7);
            bg.MoveX((OsbEasing)2, 60120 + (61620 - 60120) / 2, 61620, 775, 700);
            bg.MoveY((OsbEasing)2, 60120 + (61620 - 60120) / 2, 61620, 300, 200);
            bg.Rotate((OsbEasing)2, 60120 + (61620 - 60120) / 2, 61620, 0.025, -0.1);

            var fixTime = 60120 + (61620 - 60120) / 2;
            bg.Fade(60120, 1);
            bg.Fade(0, fixTime - 200, fixTime + 200, 0, 0);
            bg.Fade(fixTime + 200, 1);

            var bgEasingFix = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.CentreRight);
            bgEasingFix.Scale(0, fixTime - 200, fixTime + 200, 0.863, 0.841);
            bgEasingFix.MoveX(0, fixTime - 200, fixTime + 200, 781.5, 771);
            bgEasingFix.MoveY(0, fixTime - 200, fixTime + 200, 308.5, 292.5);
            bgEasingFix.Rotate(0, fixTime - 200, fixTime + 200, 0.0355, 0.015);

            var bg2 = layer.CreateSprite(@"SB\cg\waifu.png");
            bg2.Fade(61620, 1);
            bg2.Fade(61620 + 600, 0);
            bg2.Fade(61620 + 1200, 1);
            bg2.Move((OsbEasing)13, 61620, 61620 + 1000, -500, 300, 160, 300);
            bg2.Move((OsbEasing)14, 61620 + 900, 61620 + 2000, 160, 300, 600, 300);
            bg2.Fade(61620 + 1800, 0);
            bg2.Scale(61620, 0.9);

            var bgEasingFix2 = layer.CreateSprite(@"SB\cg\waifu.png");
            bgEasingFix2.Fade(61620 + 600, 1);
            bgEasingFix2.Move(0, 61620 + 600, 62845, 153, 300, 170, 300);
            bgEasingFix2.Fade(61620 + 1200, 0);
            bgEasingFix2.Fade(61620 + 1800, 1);
            bgEasingFix2.Scale(61620 + 1800, 0.9);
            bgEasingFix2.Scale(61620 + 1800, 0.9);
            bgEasingFix2.Move(0, 61620 + 1800, 64246, 598, 300, 610, 300);

            var bgRed = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(330, 240));
            bgRed.MoveY((OsbEasing)10, 64246, 66871, 220, 280);
            bgRed.MoveX((OsbEasing)10, 64246, 66871, 330, 350);
            bgRed.Scale((OsbEasing)10, 64246, 66871, 0.5, 0.7);

            var bg22 = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.Centre, new Vector2(380, 240));
            bg22.Scale((OsbEasing)10, 66871, 67621, 1, 1);
            bg22.MoveY((OsbEasing)10, 66871, 67621, 140, 440);
            bg22.MoveY((OsbEasing)9, 67821, 69133, 440, 940);

            var bgRed2 = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 240));
            bgRed2.Fade((OsbEasing)10, 66871, 67421, 1, 0);
            bgRed2.Scale((OsbEasing)10, 66871, 67621, 1, 1);
            bgRed2.MoveY((OsbEasing)10, 66871, 67621, 140, 440);
            // bgRed2.Fade((OsbEasing)10, 67621 - 300, 67621, 1, 0);

            var bg22_fixEase = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.Centre, new Vector2(380, 240));
            bg22.Fade(66871, 1);
            bg22.Fade(67421, 0);
            bg22.Fade(67996 + 370, 1);

            bg22_fixEase.Scale((OsbEasing)0, 67421, 67996, 1, 1);
            bg22_fixEase.Fade(67421, 1);
            bg22_fixEase.MoveY((OsbEasing)0, 67421, 67996 + 370, 438, 455);
            // bg.Scale((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 1, 0.7);
            // bg.MoveX((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 850, 700);
            // bg.MoveY((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 200, 200);
            // bg.Rotate((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), -0.3, -0.35);

            // bg.Fade(70009, 1);

        }
    }
}
