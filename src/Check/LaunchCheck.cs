﻿using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;

namespace NsisoLauncher_updata.Check
{
    class LaunchCheck
    {
        public List<UpdataItem> ReadLaunchrInfo(string path)
        {
            List<UpdataItem> list = new List<UpdataItem>();
            path += @"\Config\";
            if (!Directory.Exists(path))
            {
                return null;
            }
            string[] files = Directory.GetFiles(path);
            IChecker checker = new MD5Checker();
            foreach (string a in files)
            {
                checker.FilePath = a;
                UpdataItem mod = new UpdataItem();
                mod.type = "启动器配置";
                mod.function = "add";
                mod.name = mod.filename = a.Replace(path, "");
                mod.url = ServerInfo.ServerLocal + @"/Config/" + mod.filename;
                mod.check = checker.GetFileChecksum();
                if (list.Contains(mod) == false)
                    list.Add(mod);
            }
            return list;
        }
    }
}
