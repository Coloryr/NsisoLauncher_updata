using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata
{
    class scripts_check
    {
        private List<string> getFileName(string path)
        {
            List<string> files = new List<string>();
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (FileInfo f in root.GetFiles())
            {
                files.Add(f.FullName);
            }
            return files;
        }
        private List<string> getDirectory(string path)
        {
            List<string> files = new List<string>();
            files.AddRange(getFileName(path));
            DirectoryInfo root = new DirectoryInfo(path);
            foreach (DirectoryInfo d in root.GetDirectories())
            {
                files.AddRange(getDirectory(d.FullName));
            }
            return files;
        }

        public List<updata_item> ReadscriptsInfo(string path)
        {
            path += @"\scripts\";
            if (!Directory.Exists(path))
            {
                return new List<updata_item>();
            }
            List<updata_item> list = new List<updata_item>();
            List<string> a = getDirectory(path);
            IChecker checker = new MD5Checker();
            foreach (string file in a)
            {
                checker.FilePath = file;
                updata_item mod = new updata_item();
                mod.type = "魔改";
                mod.function = "add";
                mod.name = mod.filename = file.Replace(path, "");
                mod.url = server_info.server_local + @"/scripts/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
