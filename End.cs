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
    public class End : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("waifu");
            var bg = layer.CreateSprite(@"SB\components\bg_solo.jpg");
            bg.Fade(0, 198121, 216121, 1, 1);
            bg.Color(198121, 1, 1, 1);
            bg.Color(201121, 1, 0.4, 0.3);
            bg.Color(204121, 1, 1, 1);
            bg.Color(207121, 1, 0.4, 0.3);
            bg.Color(210121, 1, 1, 1);
            bg.Scale(198121, 0.4447916666666667);
            bg.Scale((OsbEasing)0, 210121, 216121, 0.4447916666666667, 0.4447916666666667 * 1.03);
            Preshow(layer);

            var title = layer.CreateSprite(@"SB\cg\top_mainvisual_logo.png", OsbOrigin.Centre);
            title.Move(0, 210121, 216121, 320, 240, 320, 240);
            title.Color(210121, 0.9, 1, 0.9);
            title.Scale((OsbEasing)0, 210121, 216121, 0.8, 0.9);
        }

        private static void Preshow(StoryboardLayer layer)
        {
            TextEnter(layer, 198121, 200371, "狂え染まれ目醒めよ", 420, "_2S");
            TextEnter(layer, 204121, 206371, "救え死者の痛みを", 390, "_2S");
            // TextEnter(layer, 150121, 152746, "楽園は", 130, "_2S");
            // TextEnter(layer, 153121, 155746, "地獄への", 180, "_2S");
            // TextEnter(layer, 156121, 158746, "道標", 60, "_2S");
        }

        private static void TextEnter(StoryboardLayer layer, double start, double end, string sentence, double width,
         string postFix)
        {
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 240;
                const int interval = 88;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)0, start, end, y, y);
                sprite.Scale(start + i * interval, start + i * interval + 200, 0, 0.4);
                sprite.Scale((OsbEasing)13, start + i * interval + 200, start + i * interval + 1820, 0.4, 0.65);
                sprite.Rotate(start + i * interval, start + i * interval + 200, 0.65 * 1.3, 0.4 * 1.3);
                sprite.Rotate((OsbEasing)13, start + i * interval + 200, start + i * interval + 1820, 0.4 * 1.3, 0);

                sprite.Scale((OsbEasing)12, start + i * interval + 1820, start + i * interval / 3d + 2740, 0.65, 0.4);
                sprite.Scale(start + i * interval / 3d + 2740, start + i * interval / 3d + 2900, 0.4, 0);
                sprite.Rotate((OsbEasing)12, start + i * interval + 1820, start + i * interval / 3d + 2740, 0, -0.4);
                sprite.Rotate(start + i * interval / 3d + 2740, start + i * interval / 3d + 2900, -0.4, -0.65);
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
