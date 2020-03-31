using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata.Check
{
    class ScriptsCheck
    {
        private List<string> GetFileName(string path)
        {
            List<string> files = new List<string>();
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                files.Add(f.FullName);
            }
            return files;
        }
        private List<string> GetDirectory(string path)
        {
            List<string> files = new List<string>();
            files.AddRange(GetFileName(path));
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                files.AddRange(GetDirectory(d.FullName));
            }
            return files;
        }

        public List<UpdataItem> ReadscriptsInfo(string path)
        {
            path += @"\.minecraft\scripts\";
            if (!Directory.Exists(path))
            {
                return new List<UpdataItem>();
            }
            List<UpdataItem> list = new List<UpdataItem>();
            List<string> a = GetDirectory(path);
            IChecker checker = new MD5Checker();
            foreach (string file in a)
            {
                checker.FilePath = file;
                UpdataItem mod = new UpdataItem
                {
                    type = "魔改",
                    function = "add"
                };
                mod.name = mod.filename = file.Replace(path, "");
                mod.url = ServerInfo.ServerLocal + @"/.minecraft/scripts/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
