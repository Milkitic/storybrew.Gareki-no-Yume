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
using System.Text;

namespace StorybrewScripts
{
    public class Lyric3 : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 45120;
        const int One2Eight = (45167 - 45120) / 2;

        public override void Generate()
        {
            var layer = GetLayer("lyric");
            var bg = layer.CreateSprite(@"SB\components\bg.jpg");
            bg.Fade(StartTime, 0.3);
            bg.Scale(StartTime - 1000, StartTime + 3000, 0.85, 0.85);
            // var word1 = layer.CreateSprite(ConvertToFileName("衝", "_st_1L"), OsbOrigin.Centre, new Vector2(170, 210));
            // word1.Scale(OsbEasing.OutCubic, StartTime, StartTime + One2Eight * 6, 2, 0.5);
            // word1.Fade(StartTime, StartTime + One2Eight * 2, 1, 1);
            // word1.Fade(StartTime + One2Eight * 2, 0);
            // word1.Fade(StartTime + One2Eight * 4, StartTime + One2Eight * 6, 1, 1);
            // var word1_s = layer.CreateSprite(ConvertToFileName("衝", "_1L"), OsbOrigin.Centre, new Vector2(170, 210));
            // word1_s.Scale(OsbEasing.OutCubic, StartTime, StartTime + One2Eight * 6, 2, 0.5);
            // word1_s.Fade(StartTime, 0);
            // word1_s.Fade(StartTime + One2Eight * 2, StartTime + One2Eight * 4, 1, 1);

            int startTime = StartTime;
            double targetSize = 0.5;
            double originalSize = targetSize * 1.5;
            SetAction("衝", "1", "3", layer, new Vector2(80, 110), startTime, targetSize, originalSize);

            startTime = StartTime + One2Eight * 2;
            targetSize = 0.6;
            originalSize = targetSize * 1.5;
            SetAction("衝", "2", "1", layer, new Vector2(310, 240), startTime, targetSize, originalSize);

            startTime = StartTime + One2Eight * 4;
            targetSize = 0.4;
            originalSize = targetSize * 1.5;
            SetAction("衝", "3", "2", layer, new Vector2(570, 280), startTime, targetSize, originalSize);

            var newStart = StartTime + 45308 - 45120;
            var newEnd = newStart + 45683 - 45308;
            var pngName = Enumerable.Range(1, 3);
            var all = pngName.SelectMany(k => new[] { ConvertToFileName("衝", $"_st_{k}S"), ConvertToFileName("衝", $"_{k}S"), }).ToArray();

            var size = 40;
            for (int j = 0; j < 13; j++)
            {
                // var count = Random(1, 25);
                var count = 25;
                for (int i = 0; i < count; i++)
                {
                    var finalSize = Random(0.4, 0.8);
                    var preSize = finalSize * 0.5;

                    var finalRotate = Random(0, 0.6) - 0.3;
                    var preRotate = Random(0, 0.6) - 0.3;

                    var randomName = all[Random(all.Length)];
                    var sprite = layer.CreateSprite(randomName);
                    var trueStart = newStart + Random(200);

                    var color = Random(0.5, 1);
                    var showRed = Random(2d) >= 1.5;

                    sprite.Move(trueStart, newEnd, -107 + i * size, j * size, -107 + i * size, j * size);
                    sprite.Fade(OsbEasing.OutExpo, trueStart, newEnd, 0, 1);
                    sprite.Scale(OsbEasing.OutExpo, trueStart, newEnd, preSize, finalSize);
                    sprite.Rotate(OsbEasing.OutExpo, trueStart, newEnd, preRotate, finalRotate);
                    if (!showRed)
                        sprite.Color(trueStart, color, color, color);
                    else
                    {
                        Log("sb");
                        sprite.Color(trueStart, 0.7, 0.1f, 0);
                    }
                }
            }
        }

        private static void SetAction(string word, string font, string changeFont, StoryboardLayer layer, Vector2 position, int startTime, double targetSize, double? originalSize = null)
        {
            if (originalSize == null) originalSize = 2;
            var word2 = layer.CreateSprite(ConvertToFileName(word, "_st_" + font + "L"), OsbOrigin.Centre, position);
            word2.Scale(OsbEasing.Out, startTime, startTime + One2Eight * 3, originalSize.Value, targetSize);
            word2.Fade(startTime, startTime + One2Eight * 2, 1, 1);
            word2.Fade(startTime + One2Eight * 2, 0);
            word2.Fade(startTime + One2Eight * 4, startTime + One2Eight * 6, 1, 1);
            var word2_s = layer.CreateSprite(ConvertToFileName(word, "_" + changeFont + "L"), OsbOrigin.Centre, position);
            word2_s.Scale(OsbEasing.None, startTime, startTime + One2Eight * 3, originalSize.Value, targetSize);
            word2_s.Fade(startTime, 0);
            word2_s.Fade(startTime + One2Eight * 2, startTime + One2Eight * 4, 1, 1);
            word2_s.Fade(startTime + One2Eight * 4, 0);
        }

        private static string ConvertToFileName(string name, string postFix)
        {
            var fileName =
                Convert.ToBase64String(Encoding.UTF8.GetBytes(name))
                    .Replace("\\", "$a$")
                    .Replace("/", "$b$")
                    .Replace(":", "$c$")
                    .Replace("*", "$d$")
                    .Replace("?", "$e$")
                    .Replace("\"", "$f$")
                    .Replace("<", "$g$")
                    .Replace(">", "$h$")
                    .Replace("|", "$i$")
                    .Replace(",", "$1$")
                    .Replace("'", "$2$")
                + postFix + ".png";
            return @"SB\output\" + fileName;
        }
    }
}
