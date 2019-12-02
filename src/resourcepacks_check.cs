using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata
{
    class resourcepacks_check
    {
        public List<updata_item> ReadresourcepacksInfo(string path)
        {
            path += @"\resourcepacks\";
            if (!Directory.Exists(path))
            {
                return new List<updata_item>();
            }
            List<updata_item> list = new List<updata_item>();
            string[] files = Directory.GetFiles(path, "*.zip");
            IChecker checker = new MD5Checker();
            foreach (string a in files)
            {
                checker.FilePath = a;
                updata_item mod = new updata_item();
                mod.type = "材质";
                mod.function = "add";
                mod.name = mod.filename = a.Replace(path, "");
                mod.url = server_info.server_local + @"/resourcepacks/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
