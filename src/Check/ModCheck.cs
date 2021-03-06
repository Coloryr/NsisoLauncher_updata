﻿using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;
using NsisoLauncherCore.Util.Checker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NsisoLauncher_updata.Check

{
    class ModCheck
    {
        public Dictionary<string, UpdataItem> ReadModInfo(string path)
        {
            path += @"\.minecraft\mods\";
            Dictionary<string, UpdataItem> list = new Dictionary<string, UpdataItem>();
            try
            {
                if (!Directory.Exists(path))
                {
                    return new Dictionary<string, UpdataItem>();
                }
                string[] files = Directory.GetFiles(path, "*.jar");
                foreach (string file in files)
                {
                    UpdataItem save = GetModsInfo(path, file);
                    while (list.ContainsKey(save.name))
                        save.name += "1";
                    if (list.ContainsValue(save) == false)
                        list.Add(save.name, save);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return list;
        }
        public UpdataItem GetModsInfo(string path, string fileName)
        {
            try
            {
                JToken modinfo = null;
                UpdataItem mod = new UpdataItem();
                mod.filename = fileName.Replace(path, "");
                using (ZipFile zip = new ZipFile(fileName))
                {
                    ZipEntry zp = zip.GetEntry("mcmod.info");
                    if (zp == null)
                    {
                        foreach (string name in TranList)
                        {
                            if (mod.filename.Contains(name))
                                mod.name = name;
                        }
                    }
                    else
                    {
                        using (Stream stream = zip.GetInputStream(zp))
                        {
                            TextReader reader = new StreamReader(stream);
                            string jsonString = reader.ReadToEnd();
                            try
                            {
                                if (jsonString.StartsWith("{"))
                                    modinfo = JArray.Parse(jsonString)[0];
                                else if (jsonString.StartsWith("["))
                                {
                                    var a = JObject.Parse(jsonString).ToObject<ModObjList.Root>().modList[0];
                                    modinfo = JObject.FromObject(a);
                                }
                            }
                            catch
                            {
                                modinfo = null;
                            }
                            if (modinfo != null)
                            {
                                var c = modinfo.ToObject<ModObj>();
                                if (c.name != null)
                                {
                                    mod.name = c.name;
                                }
                            }
                        }
                    }
                }
                if (string.IsNullOrWhiteSpace(mod.name))
                {
                    mod.name = fileName.Replace(path, "");
                }
                IChecker checker = new MD5Checker
                {
                    FilePath = fileName
                };
                mod.type = "模组";
                mod.function = "add";
                mod.check = checker.GetFileChecksum();
                mod.url = ServerInfo.ServerLocal + @"/.minecraft/mods/" + mod.filename;
                return mod;
            }
            catch
            {
                return null;
            }
        }
        private static List<string> TranList = new List<string>()
        {
            "AppleCore", "BetterFps", "jehc", "MakeZoomZoom", "MCMultiPart",
            "Rally+Health", "SelfControl", "BNBGamingCore", "rftoolspower"
        };
    }
}
