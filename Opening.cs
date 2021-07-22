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
    public class Opening : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("main");

            var waifu = layer.CreateSprite(@"SB\cg\waifu_red_h2.png");
            waifu.Move(0, 12121, 18121, 320, 240, 320, 240);
            waifu.Fade(12121, 1);
            waifu.Scale((OsbEasing)7, 12121, 12121 + 500, 1, 0.8);
            waifu.Scale(0, 12121 + 500, 18121, 0.8, 0.7);
            var startKiraTime = 17746;
            for (int i = 0; i < 4; i++)
            {
                waifu.Fade(startKiraTime, 0);
                waifu.Fade(startKiraTime + (17792 - 17746), 1);
                startKiraTime += (17839 - 17746);
            }

            var count = 250;
            var list = new double[count];
            for (int i = 0; i < list.Length; i++)
            {
                list[i] = Random(0.1, 0.5);
            }

            Array.Sort(list);
            for (int i = 0; i < list.Count(); i++)
            {
                var aniInterval = Random(15, 25);
                var elapsed = 1500d;
                var start = Random(0, 18121);

                var x = Random(-107 - 100, 747 + 100);
                var fadeT = Random(-2000, 0);
                var scale = list[i];
                elapsed = elapsed / (scale * 1);
                var shouldFadeTime = 6120;
                if (scale > 0.2) shouldFadeTime = 12121;
                if (start + elapsed <= shouldFadeTime) continue;

                var black = scale / 0.5 * 1;

                var cube = layer.CreateAnimation(@"SB\components\cube\blur\cube.png", 97, aniInterval, OsbLoopType.LoopForever);
                // var cube2 = layer.CreateAnimation(@"SB\components\cube\ani.png", 97, interval, OsbLoopType.LoopForever);


                cube.Fade(fadeT, 0);
                if (start > shouldFadeTime)
                    cube.Fade(start, 1);
                else
                {
                    cube.Fade(shouldFadeTime, 1);
                }
                cube.Move(0, start, start + elapsed, x, 480 + 100, x, 0 - 100);
                cube.Fade(start + elapsed, 0);
                cube.Scale(shouldFadeTime, scale);
                cube.Fade(18121, 0);
                cube.Color(0, 6120, 12121, 1, 1, 1, 1, 1, 1);
                cube.Color(12121, black, black, black);

                // cube2.Additive(0);
                // cube2.Fade(fadeT, 0);
                // cube2.Fade(6120, 1);
                // cube2.Move(0, start, start + speed, x, 480 + 50, x, 0 - 50);
                // cube2.Scale(6120, scale);
            }

            for (int i = 0; i < 20; i++)
            {
                var fog = layer.CreateSprite(@"SB\components\fog.png");
                var x = Random(-107, 747);
                var y = Random(0, 480);
                var start = 17558 + Random(18121 - 17558);
                fog.Color(start, 0, 0, 0);
                fog.ScaleVec(start, Random(1,2),Random(2,4));
                fog.Move(0, start, 18121, x, y, x, y);
            }    
            
              for (int i = 0; i < 25; i++)
            {
                var fog = layer.CreateSprite(@"SB\components\fog.png");
                var x = Random(-207, 847);
                var y = Random(-100, 580);
                var start = 11746 + Random(12121 - 11746);
                fog.Color(start, 0.5, 0, 0);
                fog.ScaleVec(start, Random(1,2),Random(2,6));
                fog.Move(0, start, 12121, x, y, x, y);
            }
        }
    }
}
