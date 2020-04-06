using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata.Check
{
    class LaunchSelfCheck
    {
        public List<UpdataItem> ReadLaunchrSelfInfo(string path)
        {
            path += @"\";
            if (!Directory.Exists(path))
            {
                return null;
            }
            List<UpdataItem> list = new List<UpdataItem>();
            string[] files = Directory.GetFiles(path);
            IChecker checker = new MD5Checker();
            foreach (string a in files)
            {
                checker.FilePath = a;
                UpdataItem mod = new UpdataItem();
                mod.type = "启动器";
                mod.function = "add";
                mod.name = mod.filename = a.Replace(path, "");
                mod.url = ServerInfo.ServerLocal + @"/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
