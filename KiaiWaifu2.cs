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
        private double rt(double time)
        {
            return StartTime + (time - 70621 - 100);
        }

        public override void Generate()
        {
            var layer = GetLayer("waifu");
            var nextStartTime = StartTime + (72121 - 70621) - 100;

            Waifu70621_71933(layer, nextStartTime);
            Waifu71933_76058(layer, nextStartTime);

            var nextbStartTime = StartTime + (76246 - 70621) - 100;
            Waifu76058_80933(layer, nextbStartTime);

            var bg = layer.CreateSprite(@"SB\cg\0803_n_1187.jpg", OsbOrigin.Centre, new Vector2(380, 280));
            bg.Scale(nextbStartTime + 4900, 0.6);
            bg.Color(nextbStartTime + 4900, 0.2, 0.2, 0.2);
            bg.Fade((OsbEasing)0, nextbStartTime + 4900, rt(82808), 1, 1);


            var wf = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 280));
            wf.Scale(nextbStartTime + 4900, 0.6);
            wf.Color(nextbStartTime + 4900, 0.3, 0.2, 0.2);
            wf.Fade((OsbEasing)0, nextbStartTime + 4900, rt(82808), 1, 1);
        }

        private void Waifu70621_71933(StoryboardLayer layer, int nextStartTime)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg", OsbOrigin.Centre, new Vector2(360, 240));
            // Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0803_n_1187.jpg", OsbOrigin.CentreRight);
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 240));
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var sp = arr[i]();
                var baseS = 1;
                if (i == 0) baseS = 2;
                var nextTime = StartTime + (1031);
                sp.Scale(StartTime, baseS);
                if (i == 1) sp.Color(StartTime, 0.9, 1, 1);
                sp.MoveY((OsbEasing)0, StartTime, StartTime + 100, -600, 0);
                sp.MoveY((OsbEasing)1, StartTime + 100, StartTime + 400, 0, 340);

                sp.MoveY((OsbEasing)6, nextTime, nextTime + 300, 390, 600);
                sp.MoveY((OsbEasing)0, nextTime + 300, nextTime + 800, 600, 2000);

                var easeFix = arr[i]();

                var gTime = StartTime + (71773 - 70621);
                sp.Fade(StartTime, 1);
                sp.Fade(StartTime + 400 - 50, 0);
                sp.Fade(gTime, 1);
                sp.Fade(nextStartTime, 0);

                if (i == 1) easeFix.Color(gTime, 0.9, 1, 1);
                easeFix.Fade(StartTime + 400 - 50, 1);
                easeFix.Scale(gTime, baseS);
                easeFix.Fade(gTime, 0);
                easeFix.MoveY((OsbEasing)0, StartTime + 400 - 50, StartTime + 400 + 1031 + 50, 330, 435);
            }
        }

        private static void Waifu71933_76058(StoryboardLayer layer, int nextStartTime)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg", OsbOrigin.Centre, new Vector2(360, 320));
            // Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0803_n_1187.jpg", OsbOrigin.CentreRight);
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(360, 320));
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var sp = arr[i]();
                var baseS = 1;
                var baseR0 = Math.PI / 4 * 6;
                var baseR1 = -0.2;
                if (i == 0)
                {
                    baseS = 2;
                    baseR0 += 0.2;
                    baseR1 += 0.2;
                }

                if (i == 1) sp.Color(nextStartTime, 0.9, 1, 1);
                sp.Scale((OsbEasing)13, nextStartTime, nextStartTime + 1000, baseS * 1.2, baseS);
                sp.MoveY((OsbEasing)13, nextStartTime, nextStartTime + 800, 320, 320);
                sp.Rotate((OsbEasing)13, nextStartTime, nextStartTime + 1000, baseR0, baseR1);
                sp.MoveX((OsbEasing)0, nextStartTime + 800, nextStartTime + 1500, 270, 290);
                sp.MoveX((OsbEasing)13, nextStartTime + 1500, nextStartTime + 3000, 290, 460);
                sp.MoveX((OsbEasing)9, nextStartTime + 3000, nextStartTime + 4030, 490, 800);
                sp.MoveX((OsbEasing)0, nextStartTime + 4030, nextStartTime + 4100, 800, 1100);
                sp.Fade(nextStartTime, 1);
                sp.Fade(nextStartTime + 2300, 0);
                sp.Fade(nextStartTime + 3420, 1);

                var easeFix = arr[i]();
                if (i == 1) easeFix.Color(nextStartTime, 0.9, 1, 1);
                easeFix.Scale(nextStartTime, baseS);
                easeFix.Fade(nextStartTime, 0);
                easeFix.Fade(nextStartTime + 2300, 1);
                easeFix.Fade(nextStartTime + 3420, 0);

                easeFix.MoveX((OsbEasing)0, nextStartTime + 2300, nextStartTime + 3420, 456, 498);
                easeFix.Rotate(nextStartTime + 2900, baseR1);
            }
        }

        private static void Waifu76058_80933(StoryboardLayer layer, int nextbStartTime)
        {
            Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0800_n_1180.jpg", OsbOrigin.Centre, new Vector2(380, 350));
            // Func<OsbSprite> bgFunc = () => layer.CreateSprite(@"SB\cg\0803_n_1187.jpg", OsbOrigin.CentreRight);
            Func<OsbSprite> wfFunc = () => layer.CreateSprite(@"SB\cg\waifu.png", OsbOrigin.Centre, new Vector2(380, 350));
            var arr = new[] { bgFunc, wfFunc };
            for (int i = 0; i < arr.Length; i++)
            {
                var sp = arr[i]();
                var baseS = 1;
                if (i == 0) baseS = 2;

                if (i == 1) sp.Color(nextbStartTime, 0.9, 1, 1);
                sp.Scale((OsbEasing)13, nextbStartTime, nextbStartTime + 800, baseS * 0.5, baseS * 0.8);
                sp.Move((OsbEasing)13, nextbStartTime, nextbStartTime + 800, 360, 320, 380, 350);
                sp.Fade(nextbStartTime, 1);
                sp.Fade(nextbStartTime + 500, 0);

                var easeFix = arr[i]();
                if (i == 1) easeFix.Color(nextbStartTime + 500, 0.9, 1, 1);
                easeFix.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, baseS * 0.798, baseS * 0.85);
                easeFix.Fade((OsbEasing)9, nextbStartTime + 2500, nextbStartTime + 4900, 1, 0);

                if (i == 1)
                {
                    var bg3EasingFix2 = layer.CreateSprite(@"SB\cg\waifu2.png", OsbOrigin.Centre, new Vector2(380, 350));
                    bg3EasingFix2.Fade((OsbEasing)10, nextbStartTime + 2500, nextbStartTime + 4900, 0, 1);
                    bg3EasingFix2.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, baseS * 0.798, baseS * 0.85);
                    bg3EasingFix2.Color(nextbStartTime + 500, 0.9, 1, 1);

                    var easeFix_red = layer.CreateSprite(@"SB\cg\waifu_red.png", OsbOrigin.Centre, new Vector2(380, 350));
                    easeFix_red.Scale((OsbEasing)0, nextbStartTime + 500, nextbStartTime + 4900, baseS * 0.798, baseS * 0.85);
                    easeFix_red.Fade((OsbEasing)9, nextbStartTime + 2500, nextbStartTime + 4900, 0, 1);
                }

            }
        }
    }
}
