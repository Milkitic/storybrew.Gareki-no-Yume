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
    public class FullKiraBg : StoryboardObjectGenerator
    {

        [Configurable]
        public int StartTime = 69308;
        private double rt(double time)
        {
            return StartTime + (time - 69308);
        }

        public override void Generate()
        {
            var layer = GetLayer("effect");
            var bg = layer.CreateSprite(@"SB\cg\0816_n_1340_2x.jpg");
            // bg.Scale(69308, 1.0);
            bg.Fade(rt(69214), 0);
            bg.Fade(rt(69308), 0.8);
            bg.Fade(rt(69683), 0);
            bg.Move((OsbEasing)7, rt(69214), rt(69683) + 200, 120, 480, 260 + 100, 480);
            bg.Scale((OsbEasing)7, rt(69214), rt(69683) + 200, 1.0, 1);

            var bg_hp = layer.CreateSprite(@"SB\cg\0816_n_1340_2x_hp.png");
            // bg.Scale(69308, 1.0);
            bg_hp.Additive(rt(69214));
            bg_hp.Fade(rt(69214), 0);
            bg_hp.Fade(rt(69308), 0.8);
            bg_hp.Fade(rt(69683), 0);
            bg_hp.Move((OsbEasing)7, rt(69214), rt(69683) + 200, 120, 480, 260 + 100, 480);
            bg_hp.Scale((OsbEasing)7, rt(69214), rt(69683) + 200, 1.0, 1);
            var actualTime1 = rt(69214) + Random(-100, 100);
            var loop1 = bg_hp.StartLoopGroup(actualTime1, 6);
            var kiraVal1 = 0.4;
            var elapsed1 = 40;
            bg_hp.Color((OsbEasing)0, 0, elapsed1, 0, 0, 0, kiraVal1, kiraVal1, kiraVal1);
            bg_hp.Color((OsbEasing)0, elapsed1, elapsed1 * 2,
                kiraVal1, kiraVal1, kiraVal1, 0, 0, 0);
            loop1.EndGroup();
            for (int i = 0; i < 48; i++)
            {
                var bright = layer.CreateSprite(@"SB\components\Bright3.png");
                var offX = 140 + 100;
                var x = -90;
                var y = 190;
                var f = 1d;
                var sx = 0.4;
                var sy = 0.2;
                if (i < 8)
                {
                    x = x - i * 9;
                    y = y + i * 20;
                }
                else
                {
                    x = Random(-207, 27);
                    y = Random(380, 480);
                }

                if (i < 3)
                {
                    f = 0.8d;
                }
                else if (i < 8)
                {
                    f = 0.5d;
                }
                else
                {
                    f = Random(0.3, 0.6);
                    sx = Random(0.3, 0.4);
                    sy = Random(0.3, 0.4);
                }

                bright.Fade(rt(69214), 0);
                bright.Fade(rt(69308), f);
                bright.Fade(rt(69683), 0);
                bright.Rotate(rt(69683), 0.2);
                bright.Move((OsbEasing)7, rt(69214), rt(69683) + 200, x, y, x + offX, y);
                bright.ScaleVec(rt(69214), sx, sy);
                bright.Additive(rt(69214));
                var elapsed = 40;

                var actualTime = rt(69214) + Random(-100, 100);
                var loop = bright.StartLoopGroup(actualTime, 6);
                var kiraVal = 0.5;
                bright.Color((OsbEasing)0, 0, elapsed, 0.8, 0.8, 0.8, kiraVal, kiraVal, kiraVal);
                bright.Color((OsbEasing)0, elapsed, elapsed * 2,
                    kiraVal, kiraVal, kiraVal, 0.8, 0.8, 0.8);
                loop.EndGroup();
            }

            var bg1 = layer.CreateSprite(@"SB\cg\0816_n_1340_2x.jpg");
            bg1.MoveY((OsbEasing)0, rt(69308), rt(69308) + 200, -60, 140);
            bg1.MoveX((OsbEasing)0, rt(69308), rt(69308) + 200, 370, 320);
            bg1.Fade(0, rt(69308), rt(69308) + 200, 1, 1);
            bg1.Scale(rt(69308), 1.3);
            var cg1 = layer.CreateSprite(@"SB\cg\0800_n_1180.jpg");
            var cg2 = layer.CreateSprite(@"SB\cg\0803_n_1187.jpg");
            cg1.Additive(rt(69308) + 200);
            cg1.Fade(rt(69308), 0.7);
            cg1.Fade(0, rt(69308) + 200, rt(69683), 0.3, 0.3);
            cg1.Fade(rt(69683), 0);

            cg2.Fade(rt(69308), 1);
            cg2.Additive(rt(69308) + 200);
            cg2.Fade(0, rt(69308) + 200, rt(69683), 0.3, 0.3);
            cg2.Fade(rt(69683), 0);

            for (int i = 0; i < 12; i++)
            {
                var elapsed = 32;
                cg1.Color(rt(69308) + i * elapsed, 1, 1, 1);
                cg1.Color(rt(69308) + (i + 0.5) * elapsed, 0, 0, 0);
                cg2.Color(rt(69308) + i * elapsed, 0, 0, 0);
                cg2.Color(rt(69308) + (i + 0.5) * elapsed, 1, 1, 1);
                cg1.Move(rt(69308) + i * elapsed * 2, Random(320 - 40, 320 + 40), Random(240 - 40, 240 + 40));
                cg2.Move(rt(69308) + i * elapsed * 2, Random(320 - 40, 320 + 40), Random(240 - 40, 240 + 40));
            }

            var damnae = layer.CreateSprite(@"SB\components\damnae.png");
            damnae.Fade(0, rt(69308), rt(69683), 1, 1);
        }
    }
}
