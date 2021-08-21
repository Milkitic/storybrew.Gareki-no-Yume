using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Coosu.Beatmap;
using Coosu.Storyboard;
using Coosu.Storyboard.Management;

namespace RemoveUselessFiles
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var folder = @"E:\Games\osu!\Songs\1037741 Denkishiki Karen Ongaku Shuudan - Gareki no Yume";
            var sbUnused = @"E:\Games\osu!\Songs\1037741 Denkishiki Karen Ongaku Shuudan - Gareki no Yume\sb_unused";
            if (!Directory.Exists(sbUnused)) Directory.CreateDirectory(sbUnused);
            var osus = Directory.EnumerateFiles(folder, "*.osu");
            var notExist = new HashSet<string>();
            var hashset = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);
            foreach (var osu in osus)
            {
                var o = await OsuFile.ReadFromFileAsync(osu);
                if (!o.ReadSuccess) throw o.ReadException;

                Enumrate(o.Events.ElementGroup.ElementList);
            }

            var osbs = Directory.EnumerateFiles(folder, "*.osb");
            foreach (var osb in osbs)
            {
                var eg = await ElementGroup.ParseFromFileAsync(osb);
                var egElementList = eg.ElementList;
                Enumrate(egElementList);
            }

            void Enumrate(List<EventContainer> egElementList)
            {
                foreach (var eventContainer in egElementList)
                {
                    if (eventContainer is AnimatedElement ae)
                    {
                        var f = Path.GetDirectoryName(ae.ImagePath);
                        var n = Path.GetFileNameWithoutExtension(ae.ImagePath);
                        var ext = Path.GetExtension(ae.ImagePath);
                        var frames = ae.FrameCount;
                        for (int i = 0; i < frames; i++)
                        {
                            var fi = new FileInfo(Path.Combine(folder, f, n + i + ext));
                            if (fi.Exists)
                                hashset.Add(fi.FullName);
                            else
                                notExist.Add(fi.FullName);
                        }

                    }
                    else if (eventContainer is Element ele)
                    {
                        var fi = new FileInfo(Path.Combine(folder, ele.ImagePath));
                        if (fi.Exists)
                            hashset.Add(fi.FullName);
                        else
                            notExist.Add(fi.FullName);
                    }
                }
            }


            var allPics = Directory.EnumerateFiles(Path.Combine(folder, "SB"), "*",
                new EnumerationOptions()
                {
                    RecurseSubdirectories = true
                })
               .Select(k => new FileInfo(k).FullName)
                .ToHashSet();
            var unused = allPics.Where(k => !hashset.Contains(k)).ToList();

            foreach (var u in unused)
            {
                File.Move(u, Path.Combine(sbUnused, Path.GetFileName(u)));
            }
        }
    }
}
