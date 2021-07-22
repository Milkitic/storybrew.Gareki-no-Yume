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
    public class FullKira : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 57683;
        public override void Generate()
        {
            var elapsed = (58058 - 57870) * 1;
            var layer = GetLayer("waifu");
            RenderPreKira(layer);

            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            bg.Fade(StartTime, StartTime + (57870 - 57683), 0.1, 0);
            bg.Scale(StartTime, StartTime + (57870 - 57683), 1, 0.8);
            bg.Fade((OsbEasing)1, StartTime + (57870 - 57683), StartTime + (57870 - 57683) * 2, 0, 0.3);
            bg.Scale((OsbEasing)1, StartTime + (57870 - 57683), StartTime + (57870 - 57683) * 2, 0.8, 1);
            bg.Color(StartTime + (57870 - 57683), 1, 0, 0);
            bg.Fade((OsbEasing)2, StartTime + (57870 - 57683) * 2, StartTime + (58527 - 57683), 0.3, 0.5);
            // bg.MoveX((OsbEasing)1, StartTime, StartTime + (57870 - 57683), 320, 340);

            var dot_s = layer.CreateSprite(@"SB\components\Bright.png");
            dot_s.Scale((OsbEasing)2, StartTime, StartTime + elapsed, 4, 2);
            dot_s.Fade((OsbEasing)2, StartTime, StartTime + elapsed, 0.7, 0);
            dot_s.Additive(StartTime);

            var line1 = layer.CreateSprite(@"SB\components\Line_3.png");
            line1.ScaleVec(0, StartTime, StartTime + elapsed, 1.5, 0.75, 0, 0);
            line1.Additive(StartTime);
            var dot = layer.CreateSprite(@"SB\components\White Effect_1.png");
            dot.Scale(0, StartTime, StartTime + elapsed, 0.1, 0);
            dot.Rotate((OsbEasing)1, StartTime, StartTime + elapsed, 0, Math.PI);
            dot.Additive(StartTime);

            var newStart = StartTime + elapsed;
            elapsed = (58058 - 57870) * 1;
            var dot_s1 = layer.CreateSprite(@"SB\components\Bright.png");
            dot_s1.Scale(0, newStart, newStart + elapsed, 1.1, 1.1);
            dot_s1.Scale(0, newStart + elapsed, newStart + 100 + elapsed * 3, 1.1, 1.1);
            dot_s1.Additive(newStart);
            dot_s1.Color(newStart, 1, 0.1, 0.2);

            var particleCount = 30;
            for (int i = 0; i < particleCount; i++)
            {
                var start = newStart + Random(0, 100) + i * Random(10, 30);
                var end = newStart + i * Random(10, 30) + Random(200, 300);
                if (start >= StartTime + (58433 - 57683))
                {
                    continue;
                }

                var particle = layer.CreateSprite(@"SB\components\particle.png");
                particle.Color(start, 1, 0, 0.2);
                particle.Additive(start);
                particle.Fade(start, 1);
                particle.Scale(start, 0.4);
                particle.Move(0, start, end,
                 320, 240, 320 + Random(-10, 10), 240 + Random(-10, 10));
                particle.Fade(end, 0);
                particle.Fade(StartTime + (58433 - 57683), 0);
            }

            for (int i = 0; i < 3; i++)
            {
                double init;
                if (i == 0)
                {
                    init = Random(0, 0.3) - 0.15 + Math.PI * 0.5;
                }
                else if (i == 1)
                {
                    init = Random(0, 0.3) - 0.15 + Math.PI * 1.05;
                }
                else
                {
                    init = Random(0, 0.3) - 0.15 + Math.PI * 1.6;
                }

                var tri = layer.CreateSprite(@"SB\components\triangle.png", OsbOrigin.CentreLeft);
                tri.Additive(newStart);
                tri.Color(newStart, 1, 0, 0.2);
                tri.ScaleVec(newStart, 1, 0);
                tri.Fade((OsbEasing)2, newStart + elapsed + 100, newStart + 100 + elapsed + 130, 0, 1);
                tri.Rotate((OsbEasing)9, newStart + elapsed + 100, newStart + 100 + elapsed * 3, init + 0.6, init + 0.6 + 3.1);
                tri.ScaleVec((OsbEasing)9, newStart + elapsed + 100, newStart + 100 + elapsed * 3, 1, 0, 1, Random(0.2, 0.8));
                tri.Fade(newStart + 100 + elapsed * 3, 0);

                var w = Random(1, 1.5);
                var line = layer.CreateSprite(@"SB\components\Line_1.png", OsbOrigin.CentreLeft);
                line.Color(newStart, 1, 0, 0.2);
                line.ScaleVec((OsbEasing)7, newStart, newStart + elapsed, 0, w, 1, w);
                var s = Random(0.0, 200);
                var radio = Random(0.8, 1.2);
                if (Random(0, 1.0) > 0.0)
                {
                    Log("sb");
                    for (int k = 0; k < 4; k++)
                    {
                        line.ScaleVec((OsbEasing)0, s + newStart + elapsed, s + newStart + elapsed + 20 * radio, 1, w, 1, w * 0.2);
                        line.ScaleVec((OsbEasing)0, s + newStart + elapsed + 20 * radio, s + newStart + elapsed + 40 * radio, 1, w * 0.2, 1, w);
                        s += 40 * radio;
                    }
                }

                line.Rotate((OsbEasing)7, newStart, newStart + elapsed, init - 1, init + 0.5);
                line.Additive(newStart);
                line.Rotate((OsbEasing)0, newStart + elapsed, newStart + elapsed + 100, init + 0.5, init + 0.6);
                line.Rotate((OsbEasing)9, newStart + elapsed + 100, newStart + 100 + elapsed * 3, init + 0.6, init + 0.6 + 3.1);


                // var offStart = newStart;
                // var line2 = layer.CreateSprite(@"SB\components\Line_1.png", OsbOrigin.CentreLeft);
                // line2.ScaleVec(offStart, 1, 1);
                // // line2.Rotate((OsbEasing)0, offStart + elapsed, offStart + elapsed + 100, init + 0.5, init + 0.6);
                // line2.Fade((OsbEasing)2, offStart + elapsed + 100, offStart + 100 + elapsed + 130, 0, 1);
                // line2.Rotate((OsbEasing)9, offStart + elapsed + 100 + Random(0, 0),
                //     offStart + 100 + elapsed * 3 + Random(0, 30),
                //     init + 0.6, init + 0.6 + 3.1);
                // line2.Additive(offStart);
                // line2.Fade(newStart + 100 + elapsed * 3, 0);
                if (i < 2)
                {
                    double init2;
                    if (i == 0)
                    {
                        init2 = Random(0, 0.3) - 0.15 + Math.PI * 1.3;
                    }
                    else
                    {
                        init2 = Random(0, 0.3) - 0.15 + Math.PI * 0.15;
                    }

                    var nStart = newStart + 550;
                    var line233 = layer.CreateSprite(@"SB\components\Line_1.png", OsbOrigin.CentreLeft);
                    line233.Color(nStart, 1, 0, 0.2);
                    line233.Additive(nStart);
                    line233.Fade((OsbEasing)1, nStart, nStart + 100, 0, 1);
                    line233.ScaleVec((OsbEasing)7, newStart, newStart + elapsed, 0, 1, 1, 1);
                    line233.Rotate((OsbEasing)9, newStart + elapsed + 100, newStart + 100 + elapsed * 3,
                        init2 + 0.6, init2 + 0.6 + 3.1);
                }

            }
        }

        private void RenderPreKira(StoryboardLayer layer)
        {
            var trueStart = StartTime - (57683 - 57120);
            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            bg.Fade(trueStart, trueStart + (57402 - 57120), 0.4, 0.4);
            bg.MoveX((OsbEasing)1, trueStart, trueStart + (57402 - 57120), 320, 340);
            bg.Color(trueStart, 1, 0, 0);
            var sb = (57402 - 57120) / 3;
            var circleStart = trueStart + (57402 - 57120) / 3;
            var elapsed = (57402 - 57120) / 3 * 2;
            for (int i = 0; i < 50; i++)
            {
                var circle = i <= 3
                    ? layer.CreateSprite(@"SB\components\circle_s.png")
                    : layer.CreateSprite(@"SB\components\circle1.png");
                circle.Move((OsbEasing)7, circleStart, circleStart + elapsed, 320 - i * 0.4, 230 + i * 0.4, 330, 290);
                circle.Scale((OsbEasing)7, circleStart, circleStart + elapsed, 0.3 - i * 0.0015, 0.9 - i * 0.001);
                if (i != 0)
                    circle.Fade((OsbEasing)2, circleStart, circleStart + elapsed - (i) * 2, 1, 0);
                else
                    circle.Fade((OsbEasing)0, trueStart + elapsed, circleStart + elapsed, 1, 0);
                circle.Color(circleStart, 243 / 255d, 244 / 255d, 152 / 255d);
                circle.Additive(circleStart);
                // circle.Additive(trueStart + elapsed, circleStart + elapsed);
            }

            var round = layer.CreateSprite(@"SB\components\round.png");
            round.Move((OsbEasing)0, trueStart, trueStart + sb, 280, 220, 320, 260);
            round.Scale((OsbEasing)2, trueStart, trueStart + sb, 0.1, 0);
            round.Color(trueStart, 243 / 255d, 244 / 255d, 152 / 255d);
            round.Additive(trueStart);
            // round.Additive(trueStart + elapsed, circleStart + elapsed);

            var elapsed2 = (57402 - 57120) / 3 * 3;
            for (int i = 0; i < 2; i++)
            {
                var kira1 = layer.CreateSprite(@"SB\components\kira.png");
                kira1.Rotate((OsbEasing)7, trueStart, trueStart + elapsed2, -1.7 + i * Math.PI / 2, -0.2 + i * Math.PI / 2);
                if (i == 0)
                {
                    kira1.ScaleVec((OsbEasing)0, trueStart, trueStart + sb / 2, 0.03, 2, 0, 2.5);
                    kira1.ScaleVec((OsbEasing)2, trueStart + sb / 2, trueStart + sb, 0, 2.5, 0.1, 1);
                    kira1.ScaleVec((OsbEasing)1, trueStart + sb, trueStart + elapsed2, 0.2, 1, 0.00, 3);
                }
                else
                {
                    kira1.ScaleVec((OsbEasing)0, trueStart, trueStart + sb / 2, 0, 0, 0, 0);
                    kira1.ScaleVec((OsbEasing)1, trueStart + sb, trueStart + elapsed2, 0.1, 1, 0.00, 3);
                }

                kira1.Move((OsbEasing)7, trueStart, trueStart + elapsed2, 300, 210, 330, 290);
                kira1.Fade((OsbEasing)0, trueStart + elapsed, circleStart + elapsed, 1, 0);
                kira1.Color(trueStart, 243 / 255d, 244 / 255d, 152 / 255d);
                kira1.Additive(trueStart);
                // kira1.Additive(trueStart + elapsed, circleStart + elapsed);
            }
        }
    }
}
