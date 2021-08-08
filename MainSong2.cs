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
    public class MainSong2 : StoryboardObjectGenerator
    {
        public int StartTime = 91621;

        private double rt(double time)
        {
            return StartTime + (time - 91621);
        }

        public override void Generate()
        {
            var layer = GetLayer("main");

            var white = layer.CreateSprite(@"SB\components\white.png");
            white.Fade(0, StartTime, StartTime + 45120 - 33120, 1, 1);

            var saku = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y = 240;
            var x = 160;
            saku.Move(StartTime, rt(103621), x, y, x, y - 550);
            var saku2 = layer.CreateSprite(@"SB\cg\saku.jpg");
            var y2 = 640;
            var x2 = 460;
            saku2.Move(StartTime, rt(103621), x2, y2, x2, y2 - 550);
            var note1 = layer.CreateSprite(@"SB\cg\0778_n_10601.jpg");
            var note2 = layer.CreateSprite(@"SB\cg\0779_n_10602.jpg");
            var note3 = layer.CreateSprite(@"SB\cg\0780_n_10603.jpg");
            var note4 = layer.CreateSprite(@"SB\cg\0781_n_10604.jpg");

            // var arr = new[] { note1, note2, note3, note4 };
            var arr = new[] { note3, note4 };
            for (int i = 0; i < arr.Length; i++)
            {
                OsbSprite item = arr[i];
                double startX;
                if (i % 2 == 0)
                {
                    startX = 320 + 300;
                }
                else
                {
                    startX = 320 - 300;
                    item.FlipH(StartTime);
                }

                var startY = 240 + 120 + i * 400;

                item.Move(0, StartTime, rt(103621), startX, startY, startX, startY - 650);
                item.Scale(StartTime, 0.4);
            }

            var st = StartTime;

            for (int i = 0; i < 4; i++)
            {
                var sakuG = layer.CreateSprite(@"SB\components\saku1.png");
                var xg = Random(-107, 747);
                if (i == 3) xg = 580;
                sakuG.Move(st, st + Random(2500, 3000), xg, 480 + 150, xg, -200);
                sakuG.Scale(st, Random(0.5, 1));
                sakuG.Rotate(st, Random(-0.5, 0.5));
                sakuG.Color(st, 0.9, 0.8, 0.8);
                sakuG.Fade(st, 0.75);
                st += (Random(2000, 4000));

            }

            var line = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
            var lineY = 155;
            line.Move(StartTime, rt(103621), 100, lineY, 100, lineY - 650);
            line.Color(rt(33870), 0.1, 0.1, 0.1);
            line.Rotate(rt(33870), Math.PI / 2);
            line.ScaleVec((OsbEasing)10, rt(92371), rt(93121), 0, 1, 400, 1);
            line.Fade(StartTime + 42120 - 33120, 1);

            var line2 = layer.CreateSprite(@"SB\components\line_source.png", OsbOrigin.CentreLeft);
            var line2Y = 555;
            line2.Move(StartTime, rt(103621), 540, line2Y, 540, line2Y - 650);
            line2.Color(rt(33870), 0.1, 0.1, 0.1);
            line2.Rotate(rt(33870), Math.PI / 2);
            line2.ScaleVec((OsbEasing)10, rt(98371), rt(99121), 0, 1, 400, 1);
            line2.Fade(StartTime + 42120 - 33120, 1);

            Lyric1(layer);
            Lyric2(layer);

            var waku = layer.CreateSprite(@"SB\components\waku.png");
            waku.Fade(StartTime + 45120 - 33120, 1);
            waku.ScaleVec(StartTime, 2.652173913043478, 1.983471074380165);

        }

        private void Lyric1(StoryboardLayer layer)
        {
            var start = StartTime + (33870 - 33120);
            var end = StartTime + (34620 - 33120);
            // var postFix = "_st_2S";
            var postFix = "_2S";
            var sentence = "嘆く心で";
            var height = 150;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 360 - height / 2d;
                var x = 135;
                var t = start + i * (130 - i * 5);
                var sprite = layer.CreateSprite(pic);
                sprite.Fade(StartTime, 0);
                sprite.Fade(t, 1);
                sprite.MoveX(0, t, t + 100, x + 90, x + 50);
                sprite.MoveX((OsbEasing)13, t + 100, t + 1200, x + 50, x);
                sprite.Scale(start, 0.45);
                sprite.Color(StartTime, 0.1, 0.1, 0.1);
                sprite.MoveY(0, StartTime, rt(103621), y, y - 750);
                // sprite.MoveY(0, StartTime, StartTime + 35745 - 33120, y, y - 150);
                // sprite.MoveY(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, y - 400, y - 550);
            }
        }

        private void Lyric2(StoryboardLayer layer)
        {
            var start = StartTime + (39870 - 33120);
            var end = StartTime + (40620 - 33120);
            // var postFix = "_st_2S";
            var postFix = "_2S";
            var sentence = "何処に堕ちるの";
            var height = 260;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var y = height * (i / (double)(sentence.Length - 1)) + 760 - height / 2d + 100;
                var x = 505;
                var t = start + i * (130 - i * 5);
                var sprite = layer.CreateSprite(pic);
                sprite.Fade(StartTime, 0);
                sprite.Fade(t, 1);
                sprite.MoveX(0, t, t + 100, x - 90, x - 50);
                sprite.MoveX((OsbEasing)13, t + 100, t + 1200, x - 50, x);
                sprite.Scale(start, 0.45);
                sprite.Color(StartTime, 0.1, 0.1, 0.1);
                sprite.MoveY(0, StartTime, rt(103621), y, y - 850);
                // sprite.MoveY(0, StartTime, StartTime + 36120 - 33120, y, y - 150);
                // sprite.MoveY(0, StartTime + 39120 - 33120, StartTime + 41745 - 33120, y - 400, y - 550);
                sprite.Fade(StartTime + 42120 - 33120, 1);
            }
        }

        private static string StringToUnicode(string srcText)
        {
            string dst = "";
            char[] src = srcText.ToCharArray();
            for (int i = 0; i < src.Length; i++)
            {
                byte[] bytes = Encoding.Unicode.GetBytes(src[i].ToString());
                string str = @"" + bytes[1].ToString("X2") + bytes[0].ToString("X2");
                dst += str;
            }
            return dst;
        }

        private static string ConvertToFileName(string name, string postFix)
        {
            var fileName = @"SB\output\" + StringToUnicode(name) + postFix + ".png";
            return fileName;
        }
    }
}
