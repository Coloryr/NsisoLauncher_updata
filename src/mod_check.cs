﻿using ICSharpCode.SharpZipLib.Zip;
using Newtonsoft.Json.Linq;
using NsisoLauncherCore.Util.Checker;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace NsisoLauncher_updata
{
    class mod_check
    {
        class ModListItem
        {
            /// <summary>
            /// MOD id
            /// </summary>
            public string modid { get; set; }
            /// <summary>
            /// 名字
            /// </summary>
            public string name { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public string description { get; set; }
            /// <summary>
            /// 版本
            /// </summary>
            public string version { get; set; }
            /// <summary>
            /// MC版本
            /// </summary>
            public string mcversion { get; set; }
            /// <summary>
            /// 网址
            /// </summary>
            public string url { get; set; }
            /// <summary>
            /// 更新网站
            /// </summary>
            public string updateUrl { get; set; }
            /// <summary>
            /// 作者列表
            /// </summary>
            public List<string> authorList { get; set; }
            /// <summary>
            /// 
            /// </summary>
            public string credits { get; set; }
            /// <summary>
            /// 日志文件
            /// </summary>
            public string logoFile { get; set; }
            /// <summary>
            /// 截图
            /// </summary>
            public List<string> screenshots { get; set; }
            /// <summary>
            /// 描述
            /// </summary>
            public List<string> dependencies { get; set; }
        }
        class mod_obj_2
        {
            public class Root
            {
                /// <summary>
                /// 
                /// </summary>
                public int modListVersion { get; set; }
                /// <summary>
                /// 
                /// </summary>
                public List<ModListItem> modList { get; set; }
            }
        }
        public List<updata_mod> ReadModInfo(string path)
        {
            if (!Directory.Exists(path))
            {
                MessageBox.Show("请选择mods文件夹");
                return new List<updata_mod>();
            }
            string[] files = Directory.GetFiles(path, "*.jar");
            List<updata_mod> list = new List<updata_mod>();
            foreach (string file in files)
            {
                updata_mod save = GetModsInfo(path, file);
                    if (list.Contains(save) == false)
                    list.Add(save);
            }
            return list;
        }
        public updata_mod GetModsInfo(string path, string fileName)
        {
            try
            {
                JToken modinfo = null;
                updata_mod mod = new updata_mod();
                try
                {
                    ZipFile zip = new ZipFile(fileName);
                    ZipEntry zp = zip.GetEntry("mcmod.info");
                    if (zp == null)
                    {
                        zip.Close();
                        goto a;
                    }
                    Stream stream = zip.GetInputStream(zp);
                    TextReader reader = new StreamReader(stream);
                    string b = reader.ReadToEnd();
                    try
                    {
                        modinfo = JArray.Parse(b)[0];
                    }
                    catch
                    {
                        try
                        {
                            var a = JObject.Parse(b).ToObject<mod_obj_2.Root>().modList[0];
                            modinfo = JObject.FromObject(a);
                        }
                        catch
                        {
                            zip.Close();
                            stream.Close();
                            modinfo = null;
                        }
                    }
                    zip.Close();
                    stream.Close();
                }
                catch
                {

                }
                if (modinfo != null)
                {
                    var b = modinfo.ToObject<ModListItem>();
                    if (b.modid != null)
                    {
                        mod.name = b.name;
                        mod.vision = b.version;
                    }
                }
            a:
                if (string.IsNullOrWhiteSpace(mod.name))
                {
                    mod.name = fileName.Replace(path + "\\", "");
                }
                IChecker checker = new MD5Checker();
                checker.FilePath = fileName;
                mod.check = checker.GetFileChecksum();
                mod.local = fileName;
                mod.url = server_info.server_local + fileName.Replace(path + "\\", "");
                return mod;
            }
            catch
            {
                return new updata_mod { name = fileName.Replace(path + "\\", "") };
            }
        }
    }
}
