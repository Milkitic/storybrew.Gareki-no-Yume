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
using System.IO;
using System.Linq;
using System.Text;

namespace StorybrewScripts
{
    public class KiaiFake : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            var layer = GetLayer("waifu");

            var bg = layer.CreateSprite(@"SB\cg\0800_n_1180.jpg");
            bg.Color(174121, 1, 0.3, 0);
            bg.Fade(174121, 0.9);
            bg.Scale(174121, 179933, 1.5, 1.3);
            bg.Move(174121, 179933, 380, 540, 360, 440);
            bg.Scale(179933, 1.7);
            bg.Move(179933, 184621, 260, 590, 180, 590);
            var particleCount = 20;
            var lyric = @"
            傷ついた目で
何を探すの

衝突破滅憐れなる
彷徨う視線風に舞う

撃ち抜いた身体の奥底
駆け抜ける悲しみ
悪霊に魅入られた真実
空っぽの感情の奥底
吹き荒れる魂
迷子の欠片
飢えた恐怖を捧げようか

嘆く心で
何処に堕ちるの 

幻想絆愚かなる
打ち砕かれし夢が舞う 

眼差しに呼応する歪
崩れゆく境界
瓦礫に積もる置き去りの愚者
蠢いたざわめきの先で
降リ積もる後悔
あの日の記憶
秘めた約束叶えようか 

迷い込んだ楽園は
地獄への道標

撃ち抜いた身体の奥底
駆け抜ける悲しみ
悪霊に魅入られた真実
空っぽの感情の奥底
吹き荒れる魂
迷子の欠片
飢えた恐怖を捧げようか

狂え染まれ目醒めよ 

救え死者の痛みを";
            var files = lyric.Select(k => ConvertToFileName(k.ToString(), "_2S")).ToArray();

            var spriteList = new List<OsbSprite>();
            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }

            var inkWtfg = layer.CreateSprite(@"SB\components\ink\inkwtf.png");
            inkWtfg.FlipH(174121);
            inkWtfg.Fade(174121, 1);
            inkWtfg.Scale(174121, 179933, 1.5, 1);
            inkWtfg.Move(174121, 179933, 280, 540 - 500, 240, 380 - 370);
            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }
            var inkWtfgg = layer.CreateSprite(@"SB\components\ink\inkwtf.png");
            inkWtfgg.FlipV(174121);
            inkWtfgg.Fade(174121, 1);
            inkWtfgg.Scale(174121, 179933, 1.5, 1);
            inkWtfgg.Move(174121, 179933, 280, 540 - 200, 480, 480 - 70);

            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }

            var waifu = layer.CreateSprite(@"SB\cg\waifu2.png");
            waifu.Scale(174121, 179933, 1.5, 1);
            waifu.Color(174121, 0.8, 0.7, 0.7);
            waifu.Move(174121, 179933, 380, 540, 360, 380);
            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }
            var waifu2 = layer.CreateSprite(@"SB\cg\waifu.png");
            waifu2.Color(179933, 0.8, 0.7, 0.7);
            waifu2.Scale(179933, 1.7);
            waifu2.Move(179933, 184621, 260, 590, 110, 590);

            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }
            var inkWtf = layer.CreateSprite(@"SB\components\ink\inkwtf.png");
            inkWtf.Fade(174121, 1);
            inkWtf.Scale(174121, 179933, 1.5 / 1.5, 1 / 1.1);
            inkWtf.Move(174121, 179933, 380, 540 - 500, 400, 380 - 370);
            inkWtf.Scale(179933, 1.7);
            inkWtf.Move(179933, 184621, 260 + 200, 590 - 300, 110, 590 - 300);
            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }
            var inkWtf2 = layer.CreateSprite(@"SB\components\ink\inkwtf.png");
            inkWtf2.Rotate(174121, Math.PI);
            inkWtf2.Fade(174121, 1);
            inkWtf2.Scale(174121, 179933, 1.5 / 1.5, 1 / 1.1);
            inkWtf2.Move(174121, 179933, 280, 340, 230, 380);
            inkWtf2.Scale(179933, 1.7);
            inkWtf2.Move(179933, 184621, 260 + 200, 590 - 300, 110, 590 - 300);
            for (int i = 0; i < particleCount; i++)
            {
                spriteList.Add(layer.CreateSprite(files[Random(files.Length)]));
            }
            RenderText(layer);
            RenderParticle(layer, spriteList);
        }

        private void RenderParticle(StoryboardLayer layer, List<OsbSprite> spriteList)
        {
            var startTime = 173371;
            while (spriteList.Count > 0)
            {
                var item = spriteList[Random(spriteList.Count)];
                spriteList.Remove(item);
                var x = Random(-107, 747);
                if (startTime >= 184621)
                {
                    item.Fade(184621, 0);
                }
                else
                {
                    var end = startTime + Random(1000, 6000);

                    if (startTime < 174121)
                    {
                        item.Fade(startTime, 0);
                        item.Fade(174121, 0.7);
                    }

                    item.Move(startTime, end, x, 0 - 20, x + Random(-340, 340), 480 + 20);
                    item.Rotate(startTime, end, Random(-0.2, 0.2), Random(-0.2, 0.2));
                    var ratio = 0.6;
                    var s = Random(0.3, 0.65);
                    item.ScaleVec(startTime, s * ratio, s);
                    item.Fade(startTime, 0.7);
                    if (end >= 184621)
                    {
                        item.Fade(184621, 0);
                    }
                }

                startTime += 200;
            }
        }

        private void RenderText(StoryboardLayer layer)
        {
            var start = 174121;
            var end = 176746;
            var postFix = "_2S";
            var sentence = "撃ち抜いた身体の奥底";
            var width = 380;
            var width2 = 480;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                start += 100;
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var x2 = width2 * (i / (double)(sentence.Length - 1)) + 320 - width2 / 2d;
                var y = 350;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end - 300, x, x);
                sprite.MoveX((OsbEasing)7, end - 300, end + 200, x, x2);
                sprite.MoveY((OsbEasing)5, start, start + 1300, y - 150, y);
                sprite.Rotate((OsbEasing)5, start, start + 1300, Random(-Math.PI, Math.PI), 0);
                sprite.Fade(end, end + 200, 1, 0);
                sprite.Scale(start, 0.5);
                sprite.Color(start, 1.0, 0.9, 0.9);
            }

            start = 177121;
            end = 179558;
            postFix = "_2S";
            sentence = "駆け抜ける悲しみ";
            width = 310;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 350;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)5, start, end, y, y);
                sprite.Fade(end, end + 200, 1, 0);
                sprite.Scale(start, 0.5);
                sprite.Color(start, 1.0, 0.9, 0.9);
            }

            start = 179933;
            end = 184246;
            postFix = "_2S";
            sentence = "悪霊に魅入られた真実";
            width = 380;
            for (var i = 0; i < sentence.Length; i++)
            {
                var c = sentence[i];
                start += 200;
                var pic = ConvertToFileName(c.ToString(), postFix);
                var x = width * (i / (double)(sentence.Length - 1)) + 320 - width / 2d;
                var y = 350;
                var sprite = layer.CreateSprite(pic);
                sprite.MoveX((OsbEasing)0, start, end, x, x);
                sprite.MoveY((OsbEasing)5, start, start + 2300, y - 150, y);
                sprite.Rotate((OsbEasing)5, start, start + 2300, Random(-Math.PI, Math.PI), 0);
                sprite.Fade(end, end + 200, 1, 0);
                sprite.Scale(start, 0.5);
                sprite.Color(start, 1.0, 0.9, 0.9);
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
