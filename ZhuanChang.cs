using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.CommandValues;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class ZhuanChang : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            Kira(layer, 26558);
            Kira(layer, 82058, true);
            Kira(layer, 91058);
            Kira(layer, 140558, true);
            Kira(layer, 173558);
            Kira(layer, 197558, true);

            RedFadeIn(layer, 56370);
            RedFadeIn(layer, 81871);
            RedFadeIn(layer, 114871);
            RedFadeIn(layer, 140371);
            RedFadeIn(layer, 183871);
            RedFadeIn(layer, 197371);

            QuickChange(layer, 35745, 8, new CommandColor(0.06, 0.1, 0.2));
            QuickChange(layer, 41745, 8, new CommandColor(0.06, 0.1, 0.2));
            QuickChange(layer, 158933, 4, new CommandColor(0.06, 0.1, 0.2));
            QuickChange(layer, 203746, 4, new CommandColor(0.02, 0.08, 0.10));
            QuickChange(layer, 209933, 4, new CommandColor(0.02, 0.08, 0.10));
        }

        private void QuickChange(StoryboardLayer layer, int startTime, int loop, CommandColor color)
        {
            for (int i = 0; i < 30; i++)
            {
                var tiao = layer.CreateSprite(@"SB\components\white.png");
                tiao.Fade(startTime, startTime + 159121 - 158933, 1, 1);
                tiao.ScaleVec(startTime, Random(200 / 480d, 500 / 480d), Random(1 / 480d, 3 / 480d));
                var x = Random(-107, 747);
                var y = Random(0, 480);
                for (int j = 0; j < loop; j++)
                {
                    tiao.Move(startTime + (j) * 47, startTime + (j + 1) * 47, x, y, x + Random(-5, 5), y + Random(0, 2));
                }

                tiao.Color(startTime, color);
            }
        }

        private static void RedFadeIn(StoryboardLayer layer, int startTime)
        {
            var bg2 = layer.CreateSprite(@"SB\components\white.png");
            bg2.Fade((OsbEasing)6, startTime, startTime + 57120 - 56370, 0, 1);
            bg2.Color(startTime, 0.4, 0, 0);
        }

        private static void Kira(StoryboardLayer layer, int startTime, bool faster = false)
        {
            OsbSprite filter, bg;
            filter = layer.CreateSprite(@"SB\components\filter.jpg");
            filter.MoveX(startTime, startTime + 27121 - 26558, 320 + 200, 220 - 100);
            filter.MoveY((OsbEasing)1, startTime, startTime + 27121 - 26558, 110, 240 + 200);
            filter.Scale(startTime, startTime + 27121 - 26558, 1.2, 2);
            filter.Additive(startTime);
            filter.Fade(startTime, startTime + 27121 - 26558, 0, 1);

            bg = layer.CreateSprite(@"SB\components\white.png");
            bg.Fade(0, startTime + 26993 - 26558, startTime + 27121 - 26558, 0, 1);
            bg.Fade((OsbEasing)(faster ? 13 : 1), startTime + 27121 - 26558, startTime + 28621 - 26558, 1, 0);
        }
    }
}
