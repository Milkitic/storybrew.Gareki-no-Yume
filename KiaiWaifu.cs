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
            Waifu58620_61620(layer);
            Waifu61620_64246(layer);
            Waifu64246_66871(layer);
            Waifu66871_69121(layer);
        }

        // RelativeTime by StartTime(58620 base)
        private double rt(double time)
        {
            return StartTime + (time - 58620);
        }
        private void Waifu58620_61620(StoryboardLayer layer)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg", OsbOrigin.CentreRight);
            // Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0803_n_1187.jpg", OsbOrigin.CentreRight);
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.CentreRight);
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var sp = arr[i]();
                var baseS = 1.5;
                var xo = i == 0 ? 100 : 0;
                var yo = xo / 16d * 9;
                var ratio = i == 0 ? 0.9 : 1;
                if (i == 0) baseS = 1.8;
                if (i == 1) sp.Color(StartTime, 0.9, 1, 1);
                sp.Scale(StartTime, baseS);
                sp.Rotate((OsbEasing)6, StartTime, rt(60074), 0.9, 0.2);
                sp.MoveX((OsbEasing)0, StartTime, rt(60074), xo + 600, xo + 1100);
                sp.MoveY((OsbEasing)1, StartTime, rt(59183), yo + 350, yo + 500);
                sp.MoveY((OsbEasing)6, rt(59183), rt(60074), yo + 500, yo + 520);

                sp.Scale(0, rt(60074), rt(60120), baseS, baseS / (1.5 * ratio));
                sp.Rotate(0, rt(60074), rt(60120), 0.2, 0.15);
                sp.MoveX(0, rt(60074), rt(60120), xo + 1100, xo + 850);
                sp.MoveY(0, rt(60074), rt(60120), yo + 520, yo + 400);

                sp.Scale((OsbEasing)1, rt(60120), rt(60870), baseS / (1.5 * ratio), baseS / (1.5 * ratio) * 0.85);
                sp.MoveX((OsbEasing)1, rt(60120), rt(60870), xo + 850, xo + 775);
                sp.MoveY((OsbEasing)1, rt(60120), rt(60870), yo + 400, yo + 300);
                sp.Rotate((OsbEasing)1, rt(60120), rt(60870), 0.15, 0.025);

                sp.Scale((OsbEasing)2, rt(60870), rt(61620), baseS / (1.5 * ratio) * 0.85, baseS / (1.5 * ratio) * 0.7);
                sp.MoveX((OsbEasing)2, rt(60870), rt(61620), xo + 775, xo + 700);
                sp.MoveY((OsbEasing)2, rt(60870), rt(61620), yo + 300, yo + 200);
                sp.Rotate((OsbEasing)2, rt(60870), rt(61620), 0.025, -0.1);

                var fixTime = rt(60870);
                sp.Fade(rt(60120), 1);
                sp.Fade(0, fixTime - 200, fixTime + 200, 0, 0);
                sp.Fade(fixTime + 200, 1);

                var easeFix = arr[i]();
                if (i == 1) easeFix.Color(fixTime - 200, 0.9, 1, 1);
                easeFix.Scale(0, fixTime - 200, fixTime + 200, baseS / (1.5 * ratio) * 0.863, baseS / (1.5 * ratio) * 0.841);
                easeFix.MoveX(0, fixTime - 200, fixTime + 200, xo + 781.5, xo + 771);
                easeFix.MoveY(0, fixTime - 200, fixTime + 200, yo + 308.5, yo + 292.5);
                easeFix.Rotate(0, fixTime - 200, fixTime + 200, 0.0355, 0.015);
            }
        }

        private void Waifu61620_64246(StoryboardLayer layer)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg");
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu.png");
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var baseS = 1d;
                if (i == 0) baseS = 2d;

                var sp = arr[i]();
                if (i == 1) sp.Color(rt(61620), 0.9, 1, 1);
                sp.Fade(rt(61620), 1);
                sp.Fade(rt(61620) + 600, 0);
                sp.Fade(rt(61620) + 1200, 1);
                sp.Move((OsbEasing)13, rt(61620), rt(61620) + 1000, -500, 300, i == 0 ? -170 : 160, 300);
                sp.Move((OsbEasing)14, rt(61620) + 900, rt(61620) + 2000, i == 0 ? -165 : 160, 300, i == 0 ? 55 : 600, 300);
                sp.Fade(rt(61620) + 1800, 0);
                sp.Scale(rt(61620), baseS * 0.9);

                var easeFix = arr[i]();
                if (i == 1) easeFix.Color(rt(61620) + 600, 0.9, 1, 1);
                easeFix.Fade(rt(61620) + 600, 1);
                easeFix.Move(0, rt(61620) + 600, rt(62845), i == 0 ? -173 : 153, 300, i == 0 ? -159.5 : 170, 300);
                easeFix.Fade(rt(61620) + 1200, 0);
                easeFix.Fade(rt(61620) + 1800, 1);
                easeFix.Scale(rt(61620) + 1800, baseS * 0.9);
                easeFix.Scale(rt(61620) + 1800, baseS * 0.9);
                easeFix.Move(0, rt(61620) + 1800, rt(64246), i == 0 ? 54 : 598, 300, i == 0 ? 60 : 610, 300);
            }
        }

        private void Waifu64246_66871(StoryboardLayer layer)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\components\bg.jpg");
            Func<OsbSprite> bg2Func = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg");
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu_red.png");
            var arr = new[] { bgFunc, bg2Func, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var baseS = 1d;
                if (i == 0) baseS = 2d;
                else if (i == 1) baseS = 2d;
                var sp = arr[i]();
                if (i == 0)
                {
                    sp.Fade(rt(64246), 0.6);
                    sp.Color(rt(64246), 0.9, 0.1, 0.1);
                }
                else if (i == 1)
                {
                    sp.Fade((OsbEasing)10, rt(64246), rt(66871) - 2000, 1, 0);
                }
                else if (i == 2)
                {
                    sp.Color(rt(64246), 0.9, 0.1, 0.1);
                }

                sp.MoveY((OsbEasing)10, rt(64246), rt(66871), 220, 280);
                sp.MoveX((OsbEasing)10, rt(64246), rt(66871), 330, 350);
                sp.Scale((OsbEasing)10, rt(64246), rt(66871), baseS * 0.5, baseS * 0.7);
            }
        }

        private void Waifu66871_69121(StoryboardLayer layer)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0803_n_1187.jpg");
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.Centre, new Vector2(380, 240));
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var baseS = 1d;
                var baseY = 140;
                if (i == 0)
                {
                    baseS = 1.5d;
                    // baseY = -100;
                }

                var sp = arr[i]();
                Func<double, double> gety = (double d) => baseY + (d - 140);
                Func<double, double> getdistance = (double d) => d / (baseS * baseS);
                if (i == 1) sp.Color(rt(66871), 0.9, 1, 1);
                sp.Scale((OsbEasing)10, rt(66871), rt(67621), baseS * 1, baseS * 1);
                sp.MoveY((OsbEasing)10, rt(66871), rt(67621), gety(140), gety(140) + getdistance(300));
                sp.MoveY((OsbEasing)9, rt(67821), rt(69133), gety(140) + getdistance(300),
                    gety(140) + getdistance(800));
                sp.Fade(rt(66871), i == 0 ? 0.6 : 1);
                sp.Fade(rt(67421), 0);
                sp.Fade(rt(67996) + 370, i == 0 ? 0.6 : 1);

                if (i == 1)
                {
                    var wfRed = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 240));
                    wfRed.Fade((OsbEasing)10, rt(66871), rt(67421), 1, 0);
                    wfRed.Scale((OsbEasing)10, rt(66871), rt(67621), baseS * 1, baseS * 1);
                    wfRed.MoveY((OsbEasing)10, rt(66871), rt(67621), gety(140), gety(440));
                }
                else
                {
                    var bgRed = layer.CreateSprite(@"SB\components\bg.jpg", OsbOrigin.Centre, new Vector2(380, 240));
                    bgRed.Color(rt(66871), 0.9, 0.1, 0.1);
                    bgRed.Fade((OsbEasing)10, rt(66871), rt(67421), 1, 0);
                    bgRed.Scale((OsbEasing)10, rt(66871), rt(67621), baseS * 1, baseS * 1);
                    bgRed.MoveY((OsbEasing)10, rt(66871), rt(67621), gety(140), gety(440));
                }
                // bgRed2.Fade((OsbEasing)10, 67621 - 300, 67621, 1, 0);

                var easeFix = arr[i]();
                if (i == 1) easeFix.Color(rt(67421), 0.9, 1, 1);
                easeFix.Scale((OsbEasing)0, rt(67421), rt(67996), baseS * 1, baseS * 1);
                easeFix.Fade(rt(67421), i == 0 ? 0.6 : 1);
                easeFix.MoveY((OsbEasing)0, rt(67421), rt(67996) + 370, gety(140) + getdistance(298),
                     gety(140) + getdistance(315));
                // bg.Scale((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 1, 0.7);
                // bg.MoveX((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 850, 700);
                // bg.MoveY((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), 200, 200);
                // bg.Rotate((OsbEasing)0, 60120 + (61620 - 60120) / 2, 60120 + (61620 - 60120), -0.3, -0.35);

                // bg.Fade(70009, 1);        
            }
        }
    }
}
