using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata.Check
{
    class ResourcepacksCheck
    {
        public List<UpdataItem> ReadresourcepacksInfo(string path)
        {
            path += @"\resourcepacks\";
            if (!Directory.Exists(path))
            {
                return new List<UpdataItem>();
            }
            List<UpdataItem> list = new List<UpdataItem>();
            string[] files = Directory.GetFiles(path, "*.zip");
            IChecker checker = new MD5Checker();
            foreach (string a in files)
            {
                checker.FilePath = a;
                UpdataItem mod = new UpdataItem();
                mod.type = "材质";
                mod.function = "add";
                mod.name = mod.filename = a.Replace(path, "");
                mod.url = ServerInfo.ServerLocal + @"/resourcepacks/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
