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
    public class TitleFinshBreak : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 27121;

        bool aaaa => StartTime == 141121;
        private double rt(double time)
        {
            return StartTime + (time - 27121);
        }

        public override void Generate()
        {

            var layer = GetLayer("main");

            var files = new[]
            {
                "Hatsune.jpg", "End.jpg", "Kureha.jpg",
                "Madoka.jpg", "Mahoro.jpg", "Mifuyu.jpg",
                "Hatsune.jpg", "End.jpg",
            };

            var startTime = StartTime;
            var endTime = aaaa ? (145808) : rt(33120);
            if (!aaaa)
            {
                for (int i = 0; i < files.Length; i++)
                {
                    var sp = files[i];
                    var sprite = layer.CreateSprite(sp);
                    sprite.Scale(startTime + i * 750, startTime + (i + 1) * 750, 0.4447916666666667 * 1.1, 0.4447916666666667);
                    sprite.Fade(startTime + i * 750, startTime + (i + 1) * 750, 1, 0);
                    sprite.Move(startTime + i * 750, startTime + (i + 1) * 750,
                            320 + Random(-15, 15), 240 + Random(-15, 15), 320, 240);
                    sprite.Color(startTime + i * 750, 0.6, 0.6, 0.95);
                }
            }
            else
            {
                var sp = files[1];
                var sprite = layer.CreateSprite(sp);
                sprite.Scale(startTime, 145714, 0.4447916666666667 * 1.1, 0.4447916666666667);
                sprite.Fade(startTime, 145714, 1, 0);
                sprite.Move(startTime, 145714, 320 + Random(-15, 15), 240 + Random(-15, 15), 320, 240);
                sprite.Color(startTime, 0.85, 0.6, 0.6);

                sprite.Fade(145808, 146746, 1, 1);
                sprite.Color(145808, 0.7, 0.7, 0.7);

                sprite.Scale(145808, 0.7);
                sprite.Move(145808, 320, 305);

                sprite.Scale(146277, 0.4447916666666667);
                sprite.Move(146277, 320, 240);

                sprite.Scale(146558, 1);
                sprite.Move(146558, 850, -70);
            }

            var w = layer.CreateSprite(@"SB\components\white.png");
            w.Color(startTime, 0.05, 0, 0);
            var st = startTime;
            var fade = 0.3;
            while (st < endTime)
            {
                w.Fade(st, fade);
                st += Random(22, 44);
                if (st >= endTime) break;
                w.Fade(st, fade * 0.9);
                st += Random(22, 44);
                fade += 0.01;
                if (fade > 0.8) fade = 0.8;
            }
            if (aaaa)
            {
                w.Fade(145714, 1);
                w.Fade((OsbEasing)7, 145808, 146089, 0, 1);
                w.Fade((OsbEasing)7, 146277, 146464, 0, 1);
                w.Fade((OsbEasing)7, 146558, 146746, 0, 1);
            }

            var waku = layer.CreateSprite(@"SB\components\waku.png");
            waku.Fade(startTime, rt(33120), 1, 1);
            waku.ScaleVec(startTime, 2.652173913043478 * 1.02, 1.983471074380165 * 1.02);

        }
    }
}
