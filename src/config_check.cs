using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata
{
    class config_check
    {
        public List<updata_item> ReadconfigInfo(string path)
        {
            path += @"\";
            if (!Directory.Exists(path))
            {
                return null;
            }
            List<updata_item> list = new List<updata_item>();
            string[] files = Directory.GetFiles(path, "*.zip");
            IChecker checker = new MD5Checker();
            foreach (string a in files)
            {
                checker.FilePath = a;
                updata_item mod = new updata_item();
                mod.type = "配置";
                mod.name = mod.filename = a.Replace(path, "");
                mod.url = server_info.server_local + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
